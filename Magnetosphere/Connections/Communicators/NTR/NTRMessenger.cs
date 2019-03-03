using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Magnetosphere
{
    /// <summary>
    /// Communicates from the remote process to the NTR Console.
    /// </summary>
    public sealed class NTRMessenger : DeviceMessenger, IDisposable
    {
        private uint PacketCounter;

        public NTRMessenger(DeviceConnection connection) : base(connection)
        {
            if (!(connection is TcpConnection))
                throw new ArgumentException("Unsupported communication reader", nameof(connection));
            Heart.Elapsed += (s, e) => HeartBeatLog();
        }

        private void HeartBeatLog()
        {
            var response = SendHeartbeat();
            if (response.Data.Length == 0)
                return;

            var str = Encoding.UTF8.GetString(response.Data);
            var msgs = str.Split('\0');
            foreach (var msg in msgs)
                Logger.Info(msg);
        }

        public override Protocol Protocol => Protocol.NTR;
        public System.Timers.Timer Heart = new System.Timers.Timer(1000);

        // Overview
        public override bool Connect()
        {
            if (!Connection.Connect())
                return false;

            Heart.Enabled = true;
            return true;
        }

        public override bool Disconnect(bool joinThread = true)
        {
            Heart.Enabled = false;
            return Connection.Disconnect();
        }

        public override bool SendData(byte[] data) => Connection.SendPacket(data);
        public override bool ReceiveData(out byte[] data) => Connection.ReceivePacket(out data);

        private readonly object transmission = new object();

        // Workings

        public override bool SendPacket(IPacket packet)
        {
            lock (transmission)
                return SendPacketInternal(packet);
        }

        public override IPacket ReceivePacket(TimeSpan timeout = default(TimeSpan))
        {
            lock (transmission)
                return ReadPacketInternal(timeout);
        }

        public override IPacket SendReceivePacket(IPacket packet, TimeSpan timeout = default(TimeSpan))
        {
            lock (transmission)
            {
                SendPacketInternal(packet);
                return ReadPacketInternal(timeout);
            }
        }

        // Transmissions
        public override IPacket SendHeartbeat() => SendReceivePacket(GetNew(NTRCommand.Heartbeat));
        public override void SendHello() => SendPacket(GetNew(NTRCommand.Hello));

        private IPacket ReadPacketInternal(TimeSpan timeout)
        {
            var sw = Stopwatch.StartNew();
            byte[] d;
            while (!ReceiveData(out d))
            {
                if (sw.Elapsed < timeout)
                    throw new TimeoutException();
                Thread.Sleep(10);
            }

            return UngroupPacket(d);
        }

        private bool SendPacketInternal(IPacket packet)
        {
            var hdr = packet.Header.ToBytesClass();
            var result = SendData(hdr);
            if (result && packet.Data.Length != 0)
                result = SendData(packet.Data);
            return result;
        }

        public NTRPacket GetNew(NTRCommand cmd)
        {
            var header = GetEmptyPacket(cmd);
            return new NTRPacket(header);
        }

        private NTRPacketHeader GetEmptyPacket(NTRCommand cmd)
        {
            return new NTRPacketHeader
            {
                PacketID = PacketCounter++,
                Command = cmd,
            };
        }

        public NTRPacket GetNew(NTRCommand cmd, params uint[] args)
        {
            var header = GetEmptyPacket(cmd);
            args.CopyTo(header.Arguments, 0);
            return new NTRPacket(header);
        }

        private static NTRPacket UngroupPacket(byte[] data)
        {
            const int size = NTRPacketHeader.SIZE;
            Trace.Assert(data.Length >= size);
            var hdat = new byte[size];
            Array.Copy(data, 0, hdat, 0, size);
            var header = hdat.ToClass<NTRPacketHeader>();

            Trace.Assert(data.Length - size == header.Length);
            var packet = new NTRPacket(header);
            if (header.Length > 0)
            {
                var payload = new byte[header.Length];
                Array.Copy(data, size, payload, 0, header.Length);
                packet.Data = payload;
            }

            return packet;
        }

        public void Dispose()
        {
            Heart?.Dispose();
        }
    }
}
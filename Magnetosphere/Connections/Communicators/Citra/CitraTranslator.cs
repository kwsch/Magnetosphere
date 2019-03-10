using System;
using System.Diagnostics;
using System.Threading;

namespace Magnetosphere
{
    public sealed class CitraTranslator : IDeviceRW
    {
        private readonly DeviceMessenger Messenger;

        public CitraTranslator(DeviceMessenger m) => Messenger = m;

        public byte[] Read(ulong offset, ulong length, long pid) => ReadMemory((uint)offset, (uint)length);
        public void Write(byte[] data, ulong offset, long pid) => WriteMemory(data, (uint)offset);

        private const uint CURRENT_REQUEST_VERSION = 1;
        private const uint MAX_REQUEST_DATA_SIZE = 32;
        private const uint MAX_PACKET_SIZE = 48;

        private static readonly Random rand = new Random();
        private static uint Rand32() => (uint)rand.Next(1 << 30) << 2 | (uint)rand.Next(1 << 2);

        public static CitraPacketHeader GenerateHeader(CitraCommand type, uint dataSize = 0)
        {
            return new CitraPacketHeader
            {
                Version = CURRENT_REQUEST_VERSION,
                PacketID = Rand32(),
                Length = (int)dataSize,
                Type = type,
            };
        }

        public void Reboot()
        {
        }

        public static byte[] ReadAndValidateHeader(byte[] rawReply, uint expectedID, CitraCommand expectedType)
        {
            var hdr = rawReply.ToClass<CitraPacketHeader>();

            if (CURRENT_REQUEST_VERSION != hdr.Version)
                throw new ArgumentException(nameof(CitraPacketHeader.Version));
            if (expectedID != hdr.PacketID)
                throw new ArgumentException(nameof(CitraPacketHeader.PacketID));
            if (expectedType != hdr.Type)
                throw new ArgumentException(nameof(CitraPacketHeader.Type));
            if (rawReply.Length - CitraPacketHeader.SIZE != hdr.Length)
                throw new ArgumentException(nameof(CitraPacketHeader.Length));

            if (hdr.Length == 0)
                return Array.Empty<byte>();
            var data = new byte[hdr.Length];
            Array.Copy(rawReply, CitraPacketHeader.SIZE, data, 0, data.Length);
            return data;
        }

        public byte[] ReadMemory(uint address, uint size)
        {
            var result = new byte[size];

            // request, read, repeat
            var ctr = size;
            var readRPak = new byte[CitraPacketHeader.SIZE + 8];
            while (ctr > 0)
            {
                var readSize = Math.Min(ctr, MAX_REQUEST_DATA_SIZE);
                var readHdr = GenerateHeader(CitraCommand.ReadMemory, 8);
                readHdr.ToBytesClass().CopyTo(readRPak, 0);
                BitConverter.GetBytes(address).CopyTo(readRPak, CitraPacketHeader.SIZE + 0);
                BitConverter.GetBytes(readSize).CopyTo(readRPak, CitraPacketHeader.SIZE + 4);

                var response = SendReceive(readRPak);
                var data = ReadAndValidateHeader(response, readHdr.PacketID, readHdr.Type);
                if (data.Length == 0)
                    continue;
                data.CopyTo(result, size - ctr);

                var read = (uint)data.Length;
                ctr -= read;
                address += read;
            }

            return result;
        }

        public void WriteMemory(byte[] data, uint address)
        {
            var ctr = (uint)data.Length;
            while (ctr > 0)
            {
                var writesize = Math.Min(ctr, MAX_PACKET_SIZE - 8);

                var hdr = GenerateHeader(CitraCommand.WriteMemory, writesize + 8);
                var wData = new byte[CitraPacketHeader.SIZE + writesize + 8];
                hdr.ToBytesClass().CopyTo(wData, 0);
                BitConverter.GetBytes(address).CopyTo(wData, CitraPacketHeader.SIZE + 0);
                BitConverter.GetBytes(writesize).CopyTo(wData, CitraPacketHeader.SIZE + 4);
                Array.Copy(data, ctr - writesize, wData, CitraPacketHeader.SIZE + 8, writesize);

                var response = SendReceive(wData);
                var rdata = ReadAndValidateHeader(response, hdr.PacketID, hdr.Type);
                if (rdata.Length != 0)
                    continue;
                ctr -= writesize;
                address += writesize;
            }
        }

        private readonly object transmission = new object();
        private readonly Stopwatch TimeoutCheck = new Stopwatch();

        private byte[] SendReceive(byte[] data)
        {
            lock (transmission)
            {
                Messenger.SendData(data);
                TimeoutCheck.Restart();
                while (!Messenger.Connection.HasPacketReady)
                {
                    if (TimeoutCheck.Elapsed >= TimeSpan.FromSeconds(2))
                        throw new TimeoutException("Failed to receive a response from Citra.");
                    Thread.Sleep(Messenger.Connection.ReadLoopInterval);
                }

                TimeoutCheck.Stop();
                Messenger.ReceiveData(out var response);
                return response;
            }
        }
    }
}
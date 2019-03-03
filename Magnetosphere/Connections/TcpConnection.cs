using System;
using System.Diagnostics;
using System.Net.Sockets;

namespace Magnetosphere
{
    public class TcpConnection : DeviceConnection
    {
        public override string Summary => $"{Host}-{Port}";

        public readonly string Host;
        public readonly int Port;
        public readonly TcpClient Client = new TcpClient();
        public NetworkStream NetStream;

        public TcpConnection(string host, string port)
        {
            Port = int.Parse(port);
            Host = host;
        }

        public override bool Connect() => CreateRun();
        public override bool Disconnect() => CloseConnection();
        public override bool HasPacketReady => Client.Connected && Client.Available > 0;

        private bool CloseConnection()
        {
            Client.Close();
            return true;
        }

        private bool CreateRun()
        {
            Client.Connect(Host, Port);
            NetStream = Client.GetStream();
            return true;
        }

        public override bool SendPacket(byte[] data)
        {
            try
            {
                NetStream.Write(data, 0, data.Length);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public override bool ReceivePacket(out byte[] data)
        {
            if (!HasPacketReady)
            {
                data = Array.Empty<byte>();
                return false;
            }

            data = new byte[Client.Available];
            var len = NetStream.Read(data, 0, data.Length);
            return len == data.Length;
        }

        public override void Dispose()
        {
            base.Dispose();
            if (Client.Connected)
                Client.Close();
            Client?.Dispose();
            NetStream?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
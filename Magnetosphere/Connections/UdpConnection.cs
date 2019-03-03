using System;
using System.Diagnostics;
using System.Net.Sockets;

namespace Magnetosphere
{
    public class UdpConnection : DeviceConnection
    {
        public readonly string Host;
        public readonly int Port;

        public Socket Client;

        public override string Summary => $"{Host}-{Port}";

        public UdpConnection(string host, string port)
        {
            Port = int.Parse(port);
            Host = host;
        }

        public override bool Connect()
        {
            Client = new Socket(SocketType.Dgram, ProtocolType.Udp);
            Client.Connect(Host, Port);

            Console.WriteLine($"Socket connected to {Client.RemoteEndPoint}");
            return true;
        }

        public override bool Disconnect()
        {
            Client.Shutdown(SocketShutdown.Both);
            Client.Close();
            return true;
        }

        public override bool SendPacket(byte[] data)
        {
            var count = Client.Send(data);
            Debug.WriteLine($"Wrote {count} bytes to {Summary}.");
            return true;
        }

        public override bool ReceivePacket(out byte[] data)
        {
            var count = Client.Available;
            data = new byte[count];
            if (count == 0)
                throw new Exception("Server has not yet responded!");
            var recv = Client.Receive(data);
            Debug.WriteLine($"Received {recv} bytes to {Summary}.");
            return true;
        }

        public override bool HasPacketReady => Client.Available > 0;

        public const int SIO_UDP_CONNRESET = -1744830452;

        public void DisableICMP()
        {
            Client.IOControl((IOControlCode)SIO_UDP_CONNRESET, new byte[] { 0, 0, 0, 0 }, null);
        }
    }
}
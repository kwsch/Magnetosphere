using NetMQ;
using NetMQ.Sockets;

namespace Magnetosphere
{
    //[System.Obsolete("Citra no longer uses tcp-based Zmq as the protocol, instead uses UDP.")]
    public sealed class ZmqConnection : DeviceConnection
    {
        public readonly string Host;
        public readonly int Port;

        //private ResponseSocket Server;
        public RequestSocket Client;

        public override string Summary => Connection;

        private string Connection => $"tcp://{Host}:{Port}";
        private string ConnectionC => $">{Connection}";
        //private string ConnectionS => $">{Connection}";

        public ZmqConnection(string host, string port)
        {
            Port = int.Parse(port);
            Host = host;
        }

        public override bool Connect()
        {
            //Server = new ResponseSocket(ConnectionS);
            Client = new RequestSocket(ConnectionC);
            return true;
        }

        public override bool Disconnect()
        {
            Client.Disconnect(ConnectionC);
            //Server.Disconnect(ConnectionS);
            return true;
        }

        public override bool SendPacket(byte[] data)
        {
            Client.SendFrame(data);
            return true;
        }

        public override bool ReceivePacket(out byte[] data)
        {
            data = Client.ReceiveFrameBytes();
            return true;
        }

        public override bool HasPacketReady => Client.HasOut;
    }
}

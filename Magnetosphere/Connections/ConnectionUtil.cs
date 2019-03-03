namespace Magnetosphere
{
    public static class ConnectionUtil
    {
        public static DeviceConnection GetConnection(ConnectionType type, params string[] args)
        {
            switch (type)
            {
                case ConnectionType.Tcp:
                    return new TcpConnection(args[0], args[1]);
                case ConnectionType.Zmq:
                    return new ZmqConnection(args[0], args[1]);
                case ConnectionType.Udp:
                    return new UdpConnection(args[0], args[1]);
                default:
                    return null;
            }
        }
    }

    public enum ConnectionType
    {
        Tcp, // tcpclient
        Zmq, // netmq/zeromq
        Udp
    }
}

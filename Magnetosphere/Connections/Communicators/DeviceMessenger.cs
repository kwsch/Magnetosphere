using System;
using NLog;

namespace Magnetosphere
{
    public abstract class DeviceMessenger
    {
        public readonly DeviceConnection Connection;
        public readonly Logger Logger;

        public string Summary => $"{GetType().Name.Replace("Messenger", string.Empty)}-{Connection.Summary}";
        public abstract Protocol Protocol { get; }

        public abstract bool Connect();
        public abstract bool Disconnect(bool joinThread = true);

        public abstract bool SendData(byte[] data);
        public abstract bool ReceiveData(out byte[] data);

        public abstract bool SendPacket(IPacket packet);
        public abstract IPacket ReceivePacket(TimeSpan timeout = default(TimeSpan));
        public abstract IPacket SendReceivePacket(IPacket packet, TimeSpan timeout = default(TimeSpan));

        public abstract IPacket SendHeartbeat();
        public abstract void SendHello();

        protected DeviceMessenger(DeviceConnection connection)
        {
            Connection = connection;
            Logger = LogManager.GetLogger(Summary);
        }
    }
}

using System;

namespace Magnetosphere
{
    public sealed class CitraMessenger : DeviceMessenger
    {
        public CitraMessenger(DeviceConnection connection) : base(connection)
        {
        }

        public override Protocol Protocol => Protocol.Citra;
        public override bool Connect()
        {
            var result =  Connection.Connect();
            if (!result)
                return false;

            if (Connection is UdpConnection u)
                u.DisableICMP();

            return true;
        }

        public override bool Disconnect(bool joinThread = true) => Connection.Disconnect();

        public override bool SendData(byte[] data) => Connection.SendPacket(data);
        public override bool ReceiveData(out byte[] data) => Connection.ReceivePacket(out data);

        public override bool SendPacket(IPacket packet) => throw new NotImplementedException();
        public override IPacket ReceivePacket(TimeSpan timeout = default(TimeSpan)) => throw new NotImplementedException();
        public override IPacket SendReceivePacket(IPacket packet, TimeSpan timeout = default(TimeSpan)) => throw new NotImplementedException();

        public override IPacket SendHeartbeat() => throw new NotImplementedException();
        public override void SendHello() => throw new NotImplementedException();
    }
}
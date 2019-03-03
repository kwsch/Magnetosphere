using System;

namespace Magnetosphere
{
    public sealed class AMSMessenger : DeviceMessenger
    {
        public AMSMessenger(DeviceConnection connection) : base(connection)
        {
        }

        public override Protocol Protocol => Protocol.Atmosphere;

        public override bool Connect() => throw new NotImplementedException();
        public override bool Disconnect(bool joinThread = true) => throw new NotImplementedException();
        public override bool SendData(byte[] data) => throw new NotImplementedException();
        public override bool ReceiveData(out byte[] data) => throw new NotImplementedException();

        public override bool SendPacket(IPacket packet) => throw new NotImplementedException();
        public override IPacket ReceivePacket(TimeSpan timeout = default(TimeSpan)) => throw new NotImplementedException();
        public override IPacket SendReceivePacket(IPacket packet, TimeSpan timeout = default(TimeSpan)) => throw new NotImplementedException();

        public override IPacket SendHeartbeat() => throw new NotImplementedException();
        public override void SendHello() => throw new NotImplementedException();

        public AMSPacket GetNew(AMSCommand amsCommand, uint[] args)
        {
            throw new NotImplementedException();
        }
    }
}
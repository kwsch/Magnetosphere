namespace Magnetosphere
{
    public class AMSPacket : IPacket
    {
        public IPacketHeader Header { get; set; }
        public byte[] Data { get; set; }
    }
}
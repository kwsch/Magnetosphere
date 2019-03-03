namespace Magnetosphere
{
    public interface IPacket
    {
        IPacketHeader Header { get; set; }
        byte[] Data { get; }
    }
}
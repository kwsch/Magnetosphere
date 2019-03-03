using System;

namespace Magnetosphere
{
    public sealed class NTRPacket : IPacket
    {
        public IPacketHeader Header { get; set; }
        public byte[] Data { get; set; } = Array.Empty<byte>();

        public NTRPacket(NTRPacketHeader header) => Header = header;
    }
}
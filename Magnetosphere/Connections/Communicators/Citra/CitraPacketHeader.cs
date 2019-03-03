using System.Runtime.InteropServices;

namespace Magnetosphere
{
    [StructLayout(LayoutKind.Sequential, Size = SIZE)]
    public sealed class CitraPacketHeader
    {
        internal const int SIZE = 0x10;

        public uint Version { get; set; }
        public uint PacketID { get; set; }
        public CitraCommand Type { get; set; }
        public int Length { get; set; }

        public void SetData(byte[] data) => Length = data.Length;
    }
}
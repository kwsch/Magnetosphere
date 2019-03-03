using System.Runtime.InteropServices;

namespace Magnetosphere
{
    /// <summary>
    /// TODO -- THIS IS A COPY FROM NTR WITH MINOR REPLACEMENTS
    /// THIS IS PLACEHOLDER
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = SIZE)]
    public sealed class AMSPacketHeader : IPacketHeader
    {
        public const int SIZE = 54;

        //// 0x10 bytes intro
        //public uint Magic { get; set; } = 0x12345678;
        //public uint PacketID { get; set; }
        //public uint Type { get; set; }
        //public NTRCommand Command { get; set; }

        //// 0x40 bytes arguments
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
        //public uint[] args;

        //public uint[] Arguments
        //{
        //    get => args;
        //    set => args = value;
        //}

        //// 4 bytes Payload Length
        //public int Length;
        public void SetData(byte[] data)
        {
            throw new System.NotImplementedException();
        }
    }
}
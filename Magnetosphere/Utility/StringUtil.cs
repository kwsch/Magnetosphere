using System.Linq;

namespace Magnetosphere
{
    public static class StringUtil
    {
        public static string ToHexString(byte[] data) => string.Join(" ", data.Select(b => $"{b:X2}"));
        public static string ToHexStringC(byte[] data) => string.Join(", ", data.Select(b => $"{b:X2}"));
        public static string ToHexString0x(byte[] data) => string.Join(" ", data.Select(b => $"0x{b:X2}"));
        public static string ToHexString0xC(byte[] data) => string.Join(", ", data.Select(b => $"0x{b:X2}"));
    }
}
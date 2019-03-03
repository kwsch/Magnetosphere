using System.Runtime.InteropServices;

namespace Magnetosphere
{
    public static class StructUtil
    {
        public static T ToClass<T>(this byte[] bytes) where T : class
        {
            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try { return (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T)); }
            finally { handle.Free(); }
        }

        public static byte[] ToBytesClass<T>(this T obj) where T : class
        {
            var size = Marshal.SizeOf(obj);
            var arr = new byte[size];
            var ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }
    }
}

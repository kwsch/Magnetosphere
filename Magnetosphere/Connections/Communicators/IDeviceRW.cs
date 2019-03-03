using System;

namespace Magnetosphere
{
    public interface IDeviceRW
    {
        byte[] Read(ulong offset, ulong length, long pid = -1);
        void Write(byte[] data, ulong offset, long pid = -1);

        void Reboot();
    }

    public static class DeviceRWExtensions
    {
        // Read
        public static ulong ReadUInt64(this IDeviceRW device, ulong offset)
        {
            var data = device.Read(offset, 8);
            return BitConverter.ToUInt64(data, 0);
        }

        public static long ReadInt64(this IDeviceRW device, ulong offset)
        {
            var data = device.Read(offset, 8);
            return BitConverter.ToInt64(data, 0);
        }

        public static uint ReadUInt32(this IDeviceRW device, ulong offset)
        {
            var data = device.Read(offset, 4);
            return BitConverter.ToUInt32(data, 0);
        }

        public static int ReadInt32(this IDeviceRW device, ulong offset)
        {
            var data = device.Read(offset, 4);
            return BitConverter.ToInt32(data, 0);
        }

        public static ushort ReadUInt16(this IDeviceRW device, ulong offset)
        {
            var data = device.Read(offset, 2);
            return BitConverter.ToUInt16(data, 0);
        }

        public static short ReadInt16(this IDeviceRW device, ulong offset)
        {
            var data = device.Read(offset, 2);
            return BitConverter.ToInt16(data, 0);
        }

        public static byte ReadByte(this IDeviceRW device, ulong offset) => device.Read(offset, 1)[0];

        // Write
        public static void WriteUInt64(this IDeviceRW device, ulong value, ulong offset)
        {
            var data = BitConverter.GetBytes(value);
            device.Write(data, offset);
        }

        public static void WriteInt64(this IDeviceRW device, long value, ulong offset)
        {
            var data = BitConverter.GetBytes(value);
            device.Write(data, offset);
        }

        public static void WriteUInt32(this IDeviceRW device, uint value, ulong offset)
        {
            var data = BitConverter.GetBytes(value);
            device.Write(data, offset);
        }

        public static void WriteInt32(this IDeviceRW device, int value, ulong offset)
        {
            var data = BitConverter.GetBytes(value);
            device.Write(data, offset);
        }

        public static void WriteUInt16(this IDeviceRW device, ushort value, ulong offset)
        {
            var data = BitConverter.GetBytes(value);
            device.Write(data, offset);
        }

        public static void WriteInt16(this IDeviceRW device, short value, ulong offset)
        {
            var data = BitConverter.GetBytes(value);
            device.Write(data, offset);
        }

        public static void WriteByte(this IDeviceRW device, byte value, ulong offset) => device.Write(new []{value}, offset);
    }
}
using System;
using System.Linq;
using System.Text;
using NLog;
using static Magnetosphere.NTRCommand;

namespace Magnetosphere
{
    /// <summary>
    /// Translates API requests and sends to the device for a NTR device.
    /// </summary>
    public sealed class NTRTranslator : IDeviceRW, IDeviceInfoFetch, IDebuggable, IDeviceStream
    {
        private readonly NTRMessenger Messenger;
        public readonly Logger Log;

        public NTRTranslator(DeviceMessenger m)
        {
            Messenger = (NTRMessenger) m;
            Log = Messenger.Logger;
        }

        public void Send(NTRCommand c) => Messenger.SendPacket(GetPacket(c));
        public void Send(NTRCommand c, params uint[] args) => Messenger.SendPacket(Messenger.GetNew(c, args));

        public byte[] SendReceive(NTRCommand c, params uint[] args)
        {
            var pak = GetPacket(c, args);
            var send = Messenger.SendReceivePacket(pak, TimeSpan.FromSeconds(5));
            return send.Data;
        }

        private IPacket GetPacket(NTRCommand c, params uint[] args) => Messenger.GetNew(c, args);

        private IPacket GetPacket(NTRCommand c, byte[] data, params uint[] args)
        {
            var pak = Messenger.GetNew(c, args);
            var h = ((NTRPacketHeader)pak.Header);
            h.SetData(data);
            pak.Data = data;
            return pak;
        }

        public byte[] Read(ulong offset, ulong length, long pid = -1)
            => SendReceive(NTRCommand.Read, (uint)pid, (uint)offset, (uint)length);

        public void Write(byte[] data, ulong offset, long pid = -1)
        {
            var pak = GetPacket(NTRCommand.Write, data, (uint)pid, (uint)offset, (uint)data.Length);
            Messenger.SendPacket(pak);
        }

        public void WriteFile(byte[] data, string fileName)
        {
            var name = Encoding.UTF8.GetBytes(fileName);
            var payload = name.Concat(data).ToArray();
            var pak = GetPacket(NTRCommand.WriteFile, payload);
            Messenger.SendPacket(pak);
        }

        public byte[] ReadFile(string fileName)
        {
            var name = Encoding.UTF8.GetBytes(fileName);
            var pak = GetPacket(NTRCommand.ReadFile, name);
            return Messenger.SendReceivePacket(pak, TimeSpan.FromSeconds(10)).Data;
        }

        public void Reboot() => Send(Reload);
        public void ListProcess() => Send(NTRCommand.ListProcess);
        public void ListThread() => Send(NTRCommand.ListThread);
        public void AttachProcess(long pid, ulong offset) => Send(NTRCommand.AttachProcess, (uint)pid, (uint)offset);
        public void MemLayout() => Send(NTRCommand.MemLayout);

        public void BreakpointAdd(uint type, ulong addr) => SendBreakpointMsg(NTRBreakpointArg.Add, type, (uint)addr);
        public void BreakpointDel(uint index) => SendBreakpointMsg(NTRBreakpointArg.Delete, index);
        public void BreakpointResume() => SendBreakpointMsg(NTRBreakpointArg.Resume);
        public void BreakpointEnable(uint index) => SendBreakpointMsg(NTRBreakpointArg.Enable, index);
        public void BreakpointDisable(uint index) => SendBreakpointMsg(NTRBreakpointArg.Disable, index);

        private void SendBreakpointMsg(NTRBreakpointArg arg, uint type = 0, uint offset = 0) =>
            Send(Breakpoint, type, offset, (uint) arg);

        public void RemotePlayEnable() => Send(RemotePlayer);
        public void RemotePlayDisable() => Reboot();
    }
}
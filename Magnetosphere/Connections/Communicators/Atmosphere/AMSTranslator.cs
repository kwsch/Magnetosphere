using System;
using System.Linq;
using System.Text;

namespace Magnetosphere
{
    /// <summary>
    /// Translates API requests and sends to the device for a AMS device.
    /// </summary>
    /// <summary>
    /// TODO -- THIS IS A COPY FROM NTR WITH MINOR REPLACEMENTS
    /// THIS IS PLACEHOLDER
    /// </summary>
    public sealed class AMSTranslator : IDeviceRW, IDeviceFileRW, IDeviceInfoFetch
    {
        private readonly AMSMessenger Messenger;
        public AMSTranslator(DeviceMessenger m) => Messenger = (AMSMessenger)m;

        public void Send(AMSCommand c) => Messenger.SendPacket(GetPacket(c));
        public void Send(AMSCommand c, params uint[] args) => Messenger.SendPacket(Messenger.GetNew(c, args));

        public byte[] SendReceive(AMSCommand c, params uint[] args)
        {
            var pak = GetPacket(c, args);
            var send = Messenger.SendReceivePacket(pak, TimeSpan.FromSeconds(5));
            return send.Data;
        }

        private IPacket GetPacket(AMSCommand c, params uint[] args) => Messenger.GetNew(c, args);

        private IPacket GetPacket(AMSCommand c, byte[] data, params uint[] args)
        {
            var pak = Messenger.GetNew(c, args);
            var h = ((AMSPacketHeader)pak.Header);
            h.SetData(data);
            pak.Data = data;
            return pak;
        }

        public byte[] Read(ulong offset, ulong length, long pid)
            => SendReceive(AMSCommand.Read, (uint)pid, (uint)offset, (uint)length);

        public void Write(byte[] data, ulong offset, long pid)
        {
            var pak = GetPacket(AMSCommand.Write, data, (uint)pid, (uint)offset, (uint)data.Length);
            Messenger.SendPacket(pak);
        }

        public void WriteFile(byte[] data, string fileName)
        {
            var name = Encoding.UTF8.GetBytes(fileName);
            var payload = name.Concat(data).ToArray();
            var pak = GetPacket(AMSCommand.WriteFile, payload);
            Messenger.SendPacket(pak);
        }

        public byte[] ReadFile(string fileName)
        {
            var name = Encoding.UTF8.GetBytes(fileName);
            var pak = GetPacket(AMSCommand.ReadFile, name);
            return Messenger.SendReceivePacket(pak, TimeSpan.FromSeconds(10)).Data;
        }

        public void Reboot() => Send(AMSCommand.Reload);
        public void ListProcess() => Send(AMSCommand.ListProcess);
        public void ListThread() => Send(AMSCommand.ListThread);
        public void AttachProcess(long pid, ulong offset) => Send(AMSCommand.AttachProcess, (uint)pid, (uint)offset);
        public void MemLayout() => Send(AMSCommand.MemLayout);
    }
}
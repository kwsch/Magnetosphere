using System;
using System.Linq;
using System.Windows.Forms;
using Magnetosphere;

namespace Geotail
{
    public partial class RemoteControl : Form
    {
        private readonly Bot Bot;

        public RemoteControl(Bot b)
        {
            InitializeComponent();
            Bot = b;
        }

        private void B_RWTest_Click(object sender, EventArgs e)
        {
            const uint ofs = 0x330D67D0;
            var match = ReadWriteJunk(ofs);
            WinFormsUtil.Alert("RW Test: " + match);
        }

        private bool ReadWriteJunk(uint ofs)
        {
            var xl = (IDeviceRW)Bot.Translator;
            var payload = new byte[] {0xFA, 0xFE, 0xF7, 0xF2};
            var current = xl.Read(ofs, (uint) payload.Length);

            xl.Write(payload, ofs);
            var update = xl.Read(ofs, (uint) payload.Length);

            var match = update.SequenceEqual(payload);

            // restore
            xl.Write(current, ofs);
            return match;
        }

        private uint ReadTID(int offset)
        {
            var xl = (IDeviceRW)Bot.Translator;
            var tid = xl.ReadUInt32((uint)offset);
            return tid % 1_000_000;
        }

        private void B_SM_TID_Click(object sender, EventArgs e)
        {
            var tid = ReadTID(0x330D67D0);
            WinFormsUtil.Alert(tid.ToString());
        }

        private void B_UU_TID_Click(object sender, EventArgs e)
        {
            var tid = ReadTID(0x33012818);
            WinFormsUtil.Alert(tid.ToString());
        }

        private void MemDump(int offset, int length)
        {
            var xl = (IDeviceRW)Bot.Translator;
            var data = xl.Read((uint)offset, (uint)length, 0);

            var str = StringUtil.ToHexString(data);
            Clipboard.SetText(str);
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_SM_TIDBlock_Click(object sender, EventArgs e)
        {
            MemDump(0x330D67D0, 0x200);
        }

        private void B_UU_TIDBlock_Click(object sender, EventArgs e)
        {
            MemDump(0x33012818, 0x200);
        }
    }
}

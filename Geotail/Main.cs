using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

using Magnetosphere;
using Newtonsoft.Json;

namespace Geotail
{
    public partial class Main : Form, IBotObserver
    {
        private readonly BotConfig[] Defaults = BotConfig.GetFunctionalDefaultBots();
        private readonly BotManager Manager = new BotManager();

        public Main()
        {
            InitializeComponent();
            Manager.Parent = this;

            DetectSavedConfig();
            InitializeDefaultView();
        }

        public static readonly string WorkingDirectory = Application.StartupPath;
        public static readonly string ConfigPath = Path.Combine(WorkingDirectory, "bots.xml");

        private void DetectSavedConfig()
        {
            if (!File.Exists(ConfigPath))
                return;

            try
            {
                var lines = File.ReadAllText(ConfigPath);
                var bots = JsonConvert.DeserializeObject<BotConfig[]>(lines);
                LoadConfig(bots);
            }
            catch (Exception e)
            {
                WinFormsUtil.Error(e.Message);
            }
        }

        private void LoadConfig(IEnumerable<BotConfig> bots)
        {
            foreach (var cfg in bots)
                AddBot(cfg);
        }

        private void InitializeDefaultView()
        {
            foreach (var c in Defaults)
                CB_Default.Items.Add(c.Protocol.ToString());

            CB_Default.SelectedIndexChanged += (s, e) => ResetPropertyGrid(CB_Default.SelectedIndex);
            CB_Default.SelectedIndex = 0;
            PG_Default.BrowsableAttributes = new AttributeCollection(new CategoryAttribute(BotConfig.Inputs));
        }

        private void ResetPropertyGrid(int index) => PG_Default.SelectedObject = Defaults[index].Clone();

        private void B_Add_Click(object sender, EventArgs e)
        {
            var config = (BotConfig) PG_Default.SelectedObject;

#if !DEBUG
            try { AddBot(config.Clone()); }
            catch (Exception ex) { WinFormsUtil.Error("Unable to add Bot:", ex.Message); }
#else
            AddBot(config.Clone());
#endif
        }

        public Bot AddBot(BotConfig config)
        {
            var index = Manager.BotConfigs.FindIndex(z => z.Name == config.Name || z.Arguments == config.Arguments);
            if (index >= 0)
            {
                const string line1 = "Device with similar details has already been added.";
                const string line2 = "Please double check the entered configuration.";
                WinFormsUtil.Alert(line1, line2);
                return Manager[index];
            }
            var bot = Manager.AddBot(config);
            LB_Bots.Items.Add(new ListBoxExItem(bot, LB_Bots.Items.Count));
            return bot;
        }

        public void RemoveBot(int index)
        {
            Manager.RemoveBot(index);
            LB_Bots.Items.RemoveAt(index);
        }

        public void UpdateBotState() => Invoke((MethodInvoker)(() => LB_Bots.Invalidate()));

        private void Menu_HideConfig_Click(object sender, EventArgs e) => splitContainer1.Panel1Collapsed = hideNewToolStripMenuItem.Checked;

        private void Menu_About_Click(object sender, EventArgs e)
        {
            WinFormsUtil.Alert($"{nameof(Geotail)} / {nameof(Magnetosphere)} -- WIP.");
        }

        private void LB_Bots_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender != LB_Bots)
                return;
            LB_Bots.SelectedIndex = LB_Bots.IndexFromPoint(e.Location);
        }

        private void BotMenuOpening(object sender, CancelEventArgs e)
        {
            var index = LB_Bots.SelectedIndex;
            if (index < 0)
            {
                e.Cancel = true;
                return;
            }

            var bot = Manager[index];
            var disconnected = bot.State == DeviceState.Disconnected;
            TI_Connect.Visible = TI_Remove.Visible = disconnected;
            TI_Disconnect.Visible = TI_Test.Visible = !disconnected;
        }

        private void TI_Connect_Click(object sender, EventArgs e)
        {
            var index = LB_Bots.SelectedIndex;
            var bot = Manager[index];

#if DEBUG
            bot.Connect();
#else

            try
            {
                bot.Connect();
            }
            catch (Exception exception)
            {
                bot.LogError(exception.Message);
                WinFormsUtil.Error(exception.Message);
            }
#endif
        }

        private void TI_Disconnect_Click(object sender, EventArgs e)
        {
            var index = LB_Bots.SelectedIndex;
            Manager[index].Disconnect();
        }

        private void TI_Remove_Click(object sender, EventArgs e)
        {
            var index = LB_Bots.SelectedIndex;
            Manager.RemoveBot(index);
            LB_Bots.Items.RemoveAt(index);
        }

        private void TI_Test_Click(object sender, EventArgs e)
        {
            var index = LB_Bots.SelectedIndex;
            var bot = Manager[index];
            using (var remoteControl = new RemoteControl(bot))
                remoteControl.ShowDialog();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            var bots = Manager.BotConfigs.ToArray();
            var str = JsonConvert.SerializeObject(bots);
            File.WriteAllText(ConfigPath, str);
        }
    }
}

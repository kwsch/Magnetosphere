namespace Geotail
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.B_Add = new System.Windows.Forms.Button();
            this.CB_Default = new System.Windows.Forms.ComboBox();
            this.L_Template = new System.Windows.Forms.Label();
            this.PG_Default = new System.Windows.Forms.PropertyGrid();
            this.CS_BotMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TI_Connect = new System.Windows.Forms.ToolStripMenuItem();
            this.TI_Disconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.TI_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.TI_Test = new System.Windows.Forms.ToolStripMenuItem();
            this.LB_Bots = new Geotail.ListBoxEx();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.CS_BotMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.OptionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(644, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openConfigToolStripMenuItem,
            this.saveConfigToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openConfigToolStripMenuItem
            // 
            this.openConfigToolStripMenuItem.Name = "openConfigToolStripMenuItem";
            this.openConfigToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openConfigToolStripMenuItem.Text = "Open Config";
            this.openConfigToolStripMenuItem.Click += new System.EventHandler(this.Menu_Open_Click);
            // 
            // saveConfigToolStripMenuItem
            // 
            this.saveConfigToolStripMenuItem.Name = "saveConfigToolStripMenuItem";
            this.saveConfigToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveConfigToolStripMenuItem.Text = "Save Config";
            this.saveConfigToolStripMenuItem.Click += new System.EventHandler(this.Menu_Save_Click);
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideNewToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.OptionsToolStripMenuItem.Text = "Options";
            // 
            // hideNewToolStripMenuItem
            // 
            this.hideNewToolStripMenuItem.CheckOnClick = true;
            this.hideNewToolStripMenuItem.Name = "hideNewToolStripMenuItem";
            this.hideNewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.hideNewToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.hideNewToolStripMenuItem.Text = "Hide New";
            this.hideNewToolStripMenuItem.Click += new System.EventHandler(this.Menu_HideConfig_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.Menu_About_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1MinSize = 278;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Panel2.Controls.Add(this.LB_Bots);
            this.splitContainer1.Size = new System.Drawing.Size(644, 237);
            this.splitContainer1.SplitterDistance = 278;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.PG_Default);
            this.splitContainer2.Size = new System.Drawing.Size(278, 237);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.B_Add);
            this.flowLayoutPanel1.Controls.Add(this.CB_Default);
            this.flowLayoutPanel1.Controls.Add(this.L_Template);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(278, 25);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // B_Add
            // 
            this.B_Add.Location = new System.Drawing.Point(200, 1);
            this.B_Add.Margin = new System.Windows.Forms.Padding(1);
            this.B_Add.Name = "B_Add";
            this.B_Add.Size = new System.Drawing.Size(77, 23);
            this.B_Add.TabIndex = 0;
            this.B_Add.Text = "Add New >";
            this.B_Add.UseVisualStyleBackColor = true;
            this.B_Add.Click += new System.EventHandler(this.B_Add_Click);
            // 
            // CB_Default
            // 
            this.CB_Default.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Default.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Default.FormattingEnabled = true;
            this.CB_Default.Location = new System.Drawing.Point(98, 2);
            this.CB_Default.Margin = new System.Windows.Forms.Padding(1, 2, 1, 1);
            this.CB_Default.Name = "CB_Default";
            this.CB_Default.Size = new System.Drawing.Size(100, 21);
            this.CB_Default.TabIndex = 1;
            // 
            // L_Template
            // 
            this.L_Template.Location = new System.Drawing.Point(4, 0);
            this.L_Template.Name = "L_Template";
            this.L_Template.Padding = new System.Windows.Forms.Padding(2);
            this.L_Template.Size = new System.Drawing.Size(90, 22);
            this.L_Template.TabIndex = 2;
            this.L_Template.Text = "Load Template:";
            this.L_Template.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PG_Default
            // 
            this.PG_Default.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PG_Default.Location = new System.Drawing.Point(0, 0);
            this.PG_Default.Name = "PG_Default";
            this.PG_Default.Size = new System.Drawing.Size(278, 208);
            this.PG_Default.TabIndex = 1;
            this.PG_Default.ToolbarVisible = false;
            // 
            // CS_BotMenu
            // 
            this.CS_BotMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TI_Connect,
            this.TI_Disconnect,
            this.TI_Remove,
            this.TI_Test});
            this.CS_BotMenu.Name = "contextMenuStrip1";
            this.CS_BotMenu.Size = new System.Drawing.Size(134, 92);
            this.CS_BotMenu.Opening += new System.ComponentModel.CancelEventHandler(this.BotMenuOpening);
            // 
            // TI_Connect
            // 
            this.TI_Connect.Name = "TI_Connect";
            this.TI_Connect.Size = new System.Drawing.Size(133, 22);
            this.TI_Connect.Text = "Connect";
            this.TI_Connect.Click += new System.EventHandler(this.TI_Connect_Click);
            // 
            // TI_Disconnect
            // 
            this.TI_Disconnect.Name = "TI_Disconnect";
            this.TI_Disconnect.Size = new System.Drawing.Size(133, 22);
            this.TI_Disconnect.Text = "Disconnect";
            this.TI_Disconnect.Click += new System.EventHandler(this.TI_Disconnect_Click);
            // 
            // TI_Remove
            // 
            this.TI_Remove.Name = "TI_Remove";
            this.TI_Remove.Size = new System.Drawing.Size(133, 22);
            this.TI_Remove.Text = "Remove";
            this.TI_Remove.Click += new System.EventHandler(this.TI_Remove_Click);
            // 
            // TI_Test
            // 
            this.TI_Test.Name = "TI_Test";
            this.TI_Test.Size = new System.Drawing.Size(133, 22);
            this.TI_Test.Text = "Test";
            this.TI_Test.Click += new System.EventHandler(this.TI_Test_Click);
            // 
            // LB_Bots
            // 
            this.LB_Bots.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LB_Bots.ContextMenuStrip = this.CS_BotMenu;
            this.LB_Bots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LB_Bots.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LB_Bots.FormattingEnabled = true;
            this.LB_Bots.ItemHeight = 70;
            this.LB_Bots.Location = new System.Drawing.Point(0, 0);
            this.LB_Bots.Name = "LB_Bots";
            this.LB_Bots.Size = new System.Drawing.Size(362, 237);
            this.LB_Bots.TabIndex = 0;
            this.LB_Bots.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LB_Bots_MouseDown);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 261);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Geotail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.CS_BotMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PropertyGrid PG_Default;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button B_Add;
        private System.Windows.Forms.ComboBox CB_Default;
        private System.Windows.Forms.Label L_Template;
        private Geotail.ListBoxEx LB_Bots;
        private System.Windows.Forms.ToolStripMenuItem hideNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip CS_BotMenu;
        private System.Windows.Forms.ToolStripMenuItem TI_Connect;
        private System.Windows.Forms.ToolStripMenuItem TI_Disconnect;
        private System.Windows.Forms.ToolStripMenuItem TI_Remove;
        private System.Windows.Forms.ToolStripMenuItem TI_Test;
    }
}


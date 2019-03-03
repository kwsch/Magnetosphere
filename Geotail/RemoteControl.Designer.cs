namespace Geotail
{
    partial class RemoteControl
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
            this.B_RWTest = new System.Windows.Forms.Button();
            this.B_SM_TID = new System.Windows.Forms.Button();
            this.B_UU_TID = new System.Windows.Forms.Button();
            this.B_SM_TIDBlock = new System.Windows.Forms.Button();
            this.B_UU_TIDBlock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // B_RWTest
            // 
            this.B_RWTest.Location = new System.Drawing.Point(12, 12);
            this.B_RWTest.Name = "B_RWTest";
            this.B_RWTest.Size = new System.Drawing.Size(75, 23);
            this.B_RWTest.TabIndex = 0;
            this.B_RWTest.Text = "RW Test";
            this.B_RWTest.UseVisualStyleBackColor = true;
            this.B_RWTest.Click += new System.EventHandler(this.B_RWTest_Click);
            // 
            // B_SM_TID
            // 
            this.B_SM_TID.Location = new System.Drawing.Point(93, 12);
            this.B_SM_TID.Name = "B_SM_TID";
            this.B_SM_TID.Size = new System.Drawing.Size(102, 37);
            this.B_SM_TID.TabIndex = 1;
            this.B_SM_TID.Text = "Read SM TrainerID";
            this.B_SM_TID.UseVisualStyleBackColor = true;
            this.B_SM_TID.Click += new System.EventHandler(this.B_SM_TID_Click);
            // 
            // B_UU_TID
            // 
            this.B_UU_TID.Location = new System.Drawing.Point(93, 55);
            this.B_UU_TID.Name = "B_UU_TID";
            this.B_UU_TID.Size = new System.Drawing.Size(102, 37);
            this.B_UU_TID.TabIndex = 2;
            this.B_UU_TID.Text = "Read USUM TrainerID";
            this.B_UU_TID.UseVisualStyleBackColor = true;
            this.B_UU_TID.Click += new System.EventHandler(this.B_UU_TID_Click);
            // 
            // B_SM_TIDBlock
            // 
            this.B_SM_TIDBlock.Location = new System.Drawing.Point(201, 12);
            this.B_SM_TIDBlock.Name = "B_SM_TIDBlock";
            this.B_SM_TIDBlock.Size = new System.Drawing.Size(102, 37);
            this.B_SM_TIDBlock.TabIndex = 3;
            this.B_SM_TIDBlock.Text = "Read SM TrainerID Block";
            this.B_SM_TIDBlock.UseVisualStyleBackColor = true;
            this.B_SM_TIDBlock.Click += new System.EventHandler(this.B_SM_TIDBlock_Click);
            // 
            // B_UU_TIDBlock
            // 
            this.B_UU_TIDBlock.Location = new System.Drawing.Point(201, 55);
            this.B_UU_TIDBlock.Name = "B_UU_TIDBlock";
            this.B_UU_TIDBlock.Size = new System.Drawing.Size(102, 37);
            this.B_UU_TIDBlock.TabIndex = 4;
            this.B_UU_TIDBlock.Text = "Read USUM TrainerID Block";
            this.B_UU_TIDBlock.UseVisualStyleBackColor = true;
            this.B_UU_TIDBlock.Click += new System.EventHandler(this.B_UU_TIDBlock_Click);
            // 
            // RemoteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 98);
            this.Controls.Add(this.B_UU_TIDBlock);
            this.Controls.Add(this.B_SM_TIDBlock);
            this.Controls.Add(this.B_UU_TID);
            this.Controls.Add(this.B_SM_TID);
            this.Controls.Add(this.B_RWTest);
            this.Name = "RemoteControl";
            this.Text = "RemoteControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_RWTest;
        private System.Windows.Forms.Button B_SM_TID;
        private System.Windows.Forms.Button B_UU_TID;
        private System.Windows.Forms.Button B_SM_TIDBlock;
        private System.Windows.Forms.Button B_UU_TIDBlock;
    }
}
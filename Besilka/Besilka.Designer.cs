namespace Besilka
{
    partial class Besilka
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Besilka));
            this.hangerPanel = new System.Windows.Forms.Panel();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.tbHelpLeft = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.tbRemainingChoices = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUsedLetters = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbLetters = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.бесилкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lettersPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hangerPanel
            // 
            this.hangerPanel.Location = new System.Drawing.Point(236, 42);
            this.hangerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.hangerPanel.Name = "hangerPanel";
            this.hangerPanel.Padding = new System.Windows.Forms.Padding(2);
            this.hangerPanel.Size = new System.Drawing.Size(244, 269);
            this.hangerPanel.TabIndex = 0;
            this.hangerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.hangerPanel_Paint);
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.btnHelp);
            this.infoPanel.Controls.Add(this.tbHelpLeft);
            this.infoPanel.Controls.Add(this.label3);
            this.infoPanel.Controls.Add(this.btnStartStop);
            this.infoPanel.Controls.Add(this.tbRemainingChoices);
            this.infoPanel.Controls.Add(this.label2);
            this.infoPanel.Controls.Add(this.tbUsedLetters);
            this.infoPanel.Controls.Add(this.label1);
            this.infoPanel.Location = new System.Drawing.Point(372, 453);
            this.infoPanel.Margin = new System.Windows.Forms.Padding(2);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(318, 175);
            this.infoPanel.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(138, 150);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(91, 23);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "Помош избор";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Visible = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // tbHelpLeft
            // 
            this.tbHelpLeft.Enabled = false;
            this.tbHelpLeft.Location = new System.Drawing.Point(13, 120);
            this.tbHelpLeft.Name = "tbHelpLeft";
            this.tbHelpLeft.ReadOnly = true;
            this.tbHelpLeft.Size = new System.Drawing.Size(297, 20);
            this.tbHelpLeft.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Број на помошен избор";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(235, 150);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 4;
            this.btnStartStop.Text = "Започни";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // tbRemainingChoices
            // 
            this.tbRemainingChoices.CausesValidation = false;
            this.tbRemainingChoices.Enabled = false;
            this.tbRemainingChoices.Location = new System.Drawing.Point(10, 76);
            this.tbRemainingChoices.Margin = new System.Windows.Forms.Padding(2);
            this.tbRemainingChoices.Name = "tbRemainingChoices";
            this.tbRemainingChoices.ReadOnly = true;
            this.tbRemainingChoices.Size = new System.Drawing.Size(300, 20);
            this.tbRemainingChoices.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Број на преостанати грешни избори";
            // 
            // tbUsedLetters
            // 
            this.tbUsedLetters.CausesValidation = false;
            this.tbUsedLetters.Enabled = false;
            this.tbUsedLetters.Location = new System.Drawing.Point(10, 31);
            this.tbUsedLetters.Margin = new System.Windows.Forms.Padding(2);
            this.tbUsedLetters.Name = "tbUsedLetters";
            this.tbUsedLetters.ReadOnly = true;
            this.tbUsedLetters.Size = new System.Drawing.Size(300, 20);
            this.tbUsedLetters.TabIndex = 1;
            this.tbUsedLetters.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Искористени букви";
            // 
            // gbLetters
            // 
            this.gbLetters.Location = new System.Drawing.Point(24, 353);
            this.gbLetters.Name = "gbLetters";
            this.gbLetters.Size = new System.Drawing.Size(665, 84);
            this.gbLetters.TabIndex = 4;
            this.gbLetters.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.бесилкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(714, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // бесилкаToolStripMenuItem
            // 
            this.бесилкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.бесилкаToolStripMenuItem.Name = "бесилкаToolStripMenuItem";
            this.бесилкаToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.бесилкаToolStripMenuItem.Text = "Игра";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startToolStripMenuItem.Text = "Започни";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetToolStripMenuItem.Text = "Ресетирај";
            this.resetToolStripMenuItem.Visible = false;
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // lettersPanel
            // 
            this.lettersPanel.AutoScroll = true;
            this.lettersPanel.AutoScrollMinSize = new System.Drawing.Size(0, 105);
            this.lettersPanel.Location = new System.Drawing.Point(24, 453);
            this.lettersPanel.Name = "lettersPanel";
            this.lettersPanel.Size = new System.Drawing.Size(343, 175);
            this.lettersPanel.TabIndex = 6;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.helpToolStripMenuItem.Text = "Помош избор";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            this.helpToolStripMenuItem.Visible = false;
            // 
            // Besilka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 640);
            this.Controls.Add(this.lettersPanel);
            this.Controls.Add(this.gbLetters);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.hangerPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(730, 539);
            this.Name = "Besilka";
            this.Text = "Бесилка";
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel hangerPanel;
        public System.Windows.Forms.Panel infoPanel;
        public System.Windows.Forms.TextBox tbRemainingChoices;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbUsedLetters;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.GroupBox gbLetters;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem бесилкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        public System.Windows.Forms.FlowLayoutPanel lettersPanel;
        public System.Windows.Forms.Button btnStartStop;
        public System.Windows.Forms.Button btnHelp;
        public System.Windows.Forms.TextBox tbHelpLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}


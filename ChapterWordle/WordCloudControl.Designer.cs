namespace ChapterWordCloudPlugin
{
    partial class WordCloudControl
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
			this.cloudControl = new Gma.CodeCloud.Controls.CloudControl();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.currentChapterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectedTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cloudControl.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cloudControl
			// 
			this.cloudControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cloudControl.Controls.Add(this.progressBar1);
			this.cloudControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cloudControl.LayoutType = Gma.CodeCloud.Controls.LayoutType.Spiral;
			this.cloudControl.Location = new System.Drawing.Point(0, 24);
			this.cloudControl.MaxFontSize = 68;
			this.cloudControl.MinFontSize = 6;
			this.cloudControl.Name = "cloudControl";
			this.cloudControl.Palette = new System.Drawing.Color[] {
        System.Drawing.Color.DarkRed,
        System.Drawing.Color.DarkBlue,
        System.Drawing.Color.DarkGreen,
        System.Drawing.Color.Navy,
        System.Drawing.Color.DarkCyan,
        System.Drawing.Color.DarkOrange,
        System.Drawing.Color.DarkGoldenrod,
        System.Drawing.Color.DarkKhaki,
        System.Drawing.Color.Blue,
        System.Drawing.Color.Red,
        System.Drawing.Color.Green};
			this.cloudControl.Size = new System.Drawing.Size(715, 437);
			this.cloudControl.TabIndex = 0;
			this.cloudControl.WeightedWords = null;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(224, 157);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(100, 23);
			this.progressBar1.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(715, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentChapterToolStripMenuItem,
            this.selectedTextToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// currentChapterToolStripMenuItem
			// 
			this.currentChapterToolStripMenuItem.Checked = true;
			this.currentChapterToolStripMenuItem.CheckOnClick = true;
			this.currentChapterToolStripMenuItem.Name = "currentChapterToolStripMenuItem";
			this.currentChapterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.currentChapterToolStripMenuItem.Text = "Current Chapter";
			this.currentChapterToolStripMenuItem.CheckedChanged += new System.EventHandler(this.currentChapterToolStripMenuItem_CheckedChanged);
			// 
			// selectedTextToolStripMenuItem
			// 
			this.selectedTextToolStripMenuItem.CheckOnClick = true;
			this.selectedTextToolStripMenuItem.Name = "selectedTextToolStripMenuItem";
			this.selectedTextToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.selectedTextToolStripMenuItem.Text = "Selected Text";
			this.selectedTextToolStripMenuItem.CheckedChanged += new System.EventHandler(this.selectedTextToolStripMenuItem_CheckedChanged);
			// 
			// WordCloudControl
			// 
			this.Controls.Add(this.cloudControl);
			this.Controls.Add(this.menuStrip1);
			this.Name = "WordCloudControl";
			this.Size = new System.Drawing.Size(715, 461);
			this.cloudControl.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Gma.CodeCloud.Controls.CloudControl cloudControl;
        private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem currentChapterToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectedTextToolStripMenuItem;
	}
}
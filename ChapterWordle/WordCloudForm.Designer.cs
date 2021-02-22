namespace ChapterWordCloudPlugin
{
    partial class WordCloudForm
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
			this.cloudControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// cloudControl
			// 
			this.cloudControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cloudControl.Controls.Add(this.progressBar1);
			this.cloudControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cloudControl.LayoutType = Gma.CodeCloud.Controls.LayoutType.Spiral;
			this.cloudControl.Location = new System.Drawing.Point(0, 0);
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
			this.cloudControl.Size = new System.Drawing.Size(715, 461);
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
			// WordCloudForm
			// 
			this.ClientSize = new System.Drawing.Size(715, 461);
			this.Controls.Add(this.cloudControl);
			this.Name = "WordCloudForm";
			this.Text = "Chapter Word Cloud";
			this.cloudControl.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private Gma.CodeCloud.Controls.CloudControl cloudControl;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
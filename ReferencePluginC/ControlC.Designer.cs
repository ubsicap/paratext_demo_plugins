
namespace ReferencePluginC
{
	partial class ControlC
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.previousVerseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nextVerseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textBox = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.moveToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(610, 30);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// moveToolStripMenuItem
			// 
			this.moveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.previousVerseToolStripMenuItem,
			this.nextVerseToolStripMenuItem});
			this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
			this.moveToolStripMenuItem.Size = new System.Drawing.Size(60, 26);
			this.moveToolStripMenuItem.Text = "&Move";
			// 
			// previousVerseToolStripMenuItem
			// 
			this.previousVerseToolStripMenuItem.Name = "previousVerseToolStripMenuItem";
			this.previousVerseToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
			this.previousVerseToolStripMenuItem.Text = "&Previous Verse";
			this.previousVerseToolStripMenuItem.Click += new System.EventHandler(this.PreviousVerse);
			// 
			// nextVerseToolStripMenuItem
			// 
			this.nextVerseToolStripMenuItem.Name = "nextVerseToolStripMenuItem";
			this.nextVerseToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
			this.nextVerseToolStripMenuItem.Text = "&Next Verse";
			this.nextVerseToolStripMenuItem.Click += new System.EventHandler(this.NextVerse);
			// 
			// textBox
			// 
			this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox.Location = new System.Drawing.Point(5, 34);
			this.textBox.Multiline = true;
			this.textBox.Name = "textBox";
			this.textBox.ReadOnly = true;
			this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox.Size = new System.Drawing.Size(609, 416);
			this.textBox.TabIndex = 1;
			// 
			// ControlC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.textBox);
			this.Controls.Add(this.menuStrip1);
			this.Name = "ControlC";
			this.Size = new System.Drawing.Size(610, 450);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem previousVerseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nextVerseToolStripMenuItem;
		private System.Windows.Forms.TextBox textBox;
	}
}

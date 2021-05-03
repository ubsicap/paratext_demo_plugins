
namespace ReferencePluginG
{
	partial class ControlG
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
			this.timeTextBox = new System.Windows.Forms.TextBox();
			this.projectTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// timeTextBox
			// 
			this.timeTextBox.Location = new System.Drawing.Point(1, 4);
			this.timeTextBox.Name = "timeTextBox";
			this.timeTextBox.ReadOnly = true;
			this.timeTextBox.Size = new System.Drawing.Size(355, 22);
			this.timeTextBox.TabIndex = 0;
			// 
			// projectTextBox
			// 
			this.projectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.projectTextBox.Location = new System.Drawing.Point(5, 43);
			this.projectTextBox.Multiline = true;
			this.projectTextBox.Name = "projectTextBox";
			this.projectTextBox.ReadOnly = true;
			this.projectTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.projectTextBox.Size = new System.Drawing.Size(503, 191);
			this.projectTextBox.TabIndex = 1;
			// 
			// ControlG
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.projectTextBox);
			this.Controls.Add(this.timeTextBox);
			this.Name = "ControlG";
			this.Size = new System.Drawing.Size(506, 235);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox timeTextBox;
		private System.Windows.Forms.TextBox projectTextBox;
	}
}

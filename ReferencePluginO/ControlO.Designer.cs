
namespace ReferencePluginO
{
	partial class ControlO
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
            this.m_ProjectsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // m_ProjectsListBox
            // 
            this.m_ProjectsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ProjectsListBox.FormattingEnabled = true;
            this.m_ProjectsListBox.ItemHeight = 16;
            this.m_ProjectsListBox.Location = new System.Drawing.Point(4, 5);
            this.m_ProjectsListBox.Name = "m_ProjectsListBox";
            this.m_ProjectsListBox.Size = new System.Drawing.Size(806, 484);
            this.m_ProjectsListBox.TabIndex = 0;
            // 
            // ControlO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_ProjectsListBox);
            this.Name = "ControlO";
            this.Size = new System.Drawing.Size(813, 494);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox m_ProjectsListBox;
	}
}

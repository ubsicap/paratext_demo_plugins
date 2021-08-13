
namespace ReferencePluginF
{
	partial class ControlF
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
            this.m_DataTextBox = new System.Windows.Forms.TextBox();
            this.m_ReloadButton = new System.Windows.Forms.Button();
            this.m_ModTimeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.m_DataTextBox.Location = new System.Drawing.Point(3, 37);
            this.m_DataTextBox.Multiline = true;
            this.m_DataTextBox.Name = "textBox";
            this.m_DataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.m_DataTextBox.Size = new System.Drawing.Size(669, 437);
            this.m_DataTextBox.TabIndex = 0;
            // 
            // reloadButton
            // 
            this.m_ReloadButton.Location = new System.Drawing.Point(4, 8);
            this.m_ReloadButton.Name = "reloadButton";
            this.m_ReloadButton.Size = new System.Drawing.Size(130, 23);
            this.m_ReloadButton.TabIndex = 1;
            this.m_ReloadButton.Text = "Reload";
            this.m_ReloadButton.UseVisualStyleBackColor = true;
            this.m_ReloadButton.Click += new System.EventHandler(this.Reload);
            // 
            // m_modTimeTextBox
            // 
            this.m_ModTimeTextBox.Location = new System.Drawing.Point(154, 8);
            this.m_ModTimeTextBox.Name = "m_modTimeTextBox";
            this.m_ModTimeTextBox.ReadOnly = true;
            this.m_ModTimeTextBox.Size = new System.Drawing.Size(329, 22);
            this.m_ModTimeTextBox.TabIndex = 2;
            // 
            // ControlF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_ModTimeTextBox);
            this.Controls.Add(this.m_ReloadButton);
            this.Controls.Add(this.m_DataTextBox);
            this.Name = "ControlF";
            this.Size = new System.Drawing.Size(672, 474);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox m_DataTextBox;
		private System.Windows.Forms.Button m_ReloadButton;
        private System.Windows.Forms.TextBox m_ModTimeTextBox;
    }
}

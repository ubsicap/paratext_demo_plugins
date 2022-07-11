
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
			this.label1 = new System.Windows.Forms.Label();
			this.m_FileNameTextBox = new System.Windows.Forms.TextBox();
			this.m_ContentsTextBox = new System.Windows.Forms.TextBox();
			this.m_LoadButton = new System.Windows.Forms.Button();
			this.m_SaveButton = new System.Windows.Forms.Button();
			this.m_DeleteButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_ProjectsListBox
			// 
			this.m_ProjectsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_ProjectsListBox.FormattingEnabled = true;
			this.m_ProjectsListBox.ItemHeight = 16;
			this.m_ProjectsListBox.Location = new System.Drawing.Point(4, 69);
			this.m_ProjectsListBox.Name = "m_ProjectsListBox";
			this.m_ProjectsListBox.Size = new System.Drawing.Size(398, 420);
			this.m_ProjectsListBox.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Enter file name:";
			// 
			// m_FileNameTextBox
			// 
			this.m_FileNameTextBox.Location = new System.Drawing.Point(116, 0);
			this.m_FileNameTextBox.Name = "m_FileNameTextBox";
			this.m_FileNameTextBox.Size = new System.Drawing.Size(250, 22);
			this.m_FileNameTextBox.TabIndex = 2;
			// 
			// m_ContentsTextBox
			// 
			this.m_ContentsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_ContentsTextBox.Location = new System.Drawing.Point(408, 69);
			this.m_ContentsTextBox.Multiline = true;
			this.m_ContentsTextBox.Name = "m_ContentsTextBox";
			this.m_ContentsTextBox.Size = new System.Drawing.Size(404, 424);
			this.m_ContentsTextBox.TabIndex = 3;
			// 
			// m_LoadButton
			// 
			this.m_LoadButton.Location = new System.Drawing.Point(19, 28);
			this.m_LoadButton.Name = "m_LoadButton";
			this.m_LoadButton.Size = new System.Drawing.Size(187, 25);
			this.m_LoadButton.TabIndex = 4;
			this.m_LoadButton.Text = "Load Project File";
			this.m_LoadButton.UseVisualStyleBackColor = true;
			this.m_LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
			// 
			// m_SaveButton
			// 
			this.m_SaveButton.Location = new System.Drawing.Point(318, 28);
			this.m_SaveButton.Name = "m_SaveButton";
			this.m_SaveButton.Size = new System.Drawing.Size(187, 25);
			this.m_SaveButton.TabIndex = 5;
			this.m_SaveButton.Text = "Save Project File";
			this.m_SaveButton.UseVisualStyleBackColor = true;
			this.m_SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// m_DeleteButton
			// 
			this.m_DeleteButton.Location = new System.Drawing.Point(623, 28);
			this.m_DeleteButton.Name = "m_DeleteButton";
			this.m_DeleteButton.Size = new System.Drawing.Size(187, 25);
			this.m_DeleteButton.TabIndex = 6;
			this.m_DeleteButton.Text = "Delete Project File";
			this.m_DeleteButton.UseVisualStyleBackColor = true;
			this.m_DeleteButton.Click += new System.EventHandler(this.m_DeleteButton_Click);
			// 
			// ControlO
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_DeleteButton);
			this.Controls.Add(this.m_SaveButton);
			this.Controls.Add(this.m_LoadButton);
			this.Controls.Add(this.m_ContentsTextBox);
			this.Controls.Add(this.m_FileNameTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_ProjectsListBox);
			this.Name = "ControlO";
			this.Size = new System.Drawing.Size(813, 494);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox m_ProjectsListBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox m_FileNameTextBox;
		private System.Windows.Forms.TextBox m_ContentsTextBox;
		private System.Windows.Forms.Button m_LoadButton;
		private System.Windows.Forms.Button m_SaveButton;
		private System.Windows.Forms.Button m_DeleteButton;
	}
}

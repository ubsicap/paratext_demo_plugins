
namespace ReferencePluginL
{
	partial class AddNoteDialog
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
			this.m_comment = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.m_startTextBox = new System.Windows.Forms.TextBox();
			this.m_endTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_DecrVerseButton = new System.Windows.Forms.Button();
			this.m_IncrVerseButton = new System.Windows.Forms.Button();
			this.m_assigneeListBox = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_comment
			// 
			this.m_comment.AcceptsReturn = true;
			this.m_comment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_comment.Location = new System.Drawing.Point(4, 73);
			this.m_comment.Multiline = true;
			this.m_comment.Name = "m_comment";
			this.m_comment.Size = new System.Drawing.Size(793, 342);
			this.m_comment.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(9, 421);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(160, 26);
			this.button1.TabIndex = 1;
			this.button1.Text = "Add Note";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(187, 421);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(160, 26);
			this.button2.TabIndex = 2;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "Start Verse";
			// 
			// m_startTextBox
			// 
			this.m_startTextBox.Location = new System.Drawing.Point(102, 3);
			this.m_startTextBox.Name = "m_startTextBox";
			this.m_startTextBox.ReadOnly = true;
			this.m_startTextBox.Size = new System.Drawing.Size(244, 22);
			this.m_startTextBox.TabIndex = 4;
			// 
			// m_endTextBox
			// 
			this.m_endTextBox.Location = new System.Drawing.Point(163, 30);
			this.m_endTextBox.Name = "m_endTextBox";
			this.m_endTextBox.ReadOnly = true;
			this.m_endTextBox.Size = new System.Drawing.Size(244, 22);
			this.m_endTextBox.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 17);
			this.label2.TabIndex = 5;
			this.label2.Text = "End Verse";
			// 
			// m_DecrVerseButton
			// 
			this.m_DecrVerseButton.Location = new System.Drawing.Point(102, 29);
			this.m_DecrVerseButton.Name = "m_DecrVerseButton";
			this.m_DecrVerseButton.Size = new System.Drawing.Size(25, 23);
			this.m_DecrVerseButton.TabIndex = 7;
			this.m_DecrVerseButton.Text = "-";
			this.m_DecrVerseButton.UseVisualStyleBackColor = true;
			this.m_DecrVerseButton.Click += new System.EventHandler(this.OnDecrVerseClicked);
			// 
			// m_IncrVerseButton
			// 
			this.m_IncrVerseButton.Location = new System.Drawing.Point(132, 29);
			this.m_IncrVerseButton.Name = "m_IncrVerseButton";
			this.m_IncrVerseButton.Size = new System.Drawing.Size(25, 23);
			this.m_IncrVerseButton.TabIndex = 8;
			this.m_IncrVerseButton.Text = "+";
			this.m_IncrVerseButton.UseVisualStyleBackColor = true;
			this.m_IncrVerseButton.Click += new System.EventHandler(this.OnIncrVerseClicked);
			// 
			// m_assigneeListBox
			// 
			this.m_assigneeListBox.FormattingEnabled = true;
			this.m_assigneeListBox.ItemHeight = 16;
			this.m_assigneeListBox.Location = new System.Drawing.Point(544, 3);
			this.m_assigneeListBox.Name = "m_assigneeListBox";
			this.m_assigneeListBox.Size = new System.Drawing.Size(219, 52);
			this.m_assigneeListBox.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(472, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 17);
			this.label3.TabIndex = 10;
			this.label3.Text = "Assignee";
			// 
			// AddNoteDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_assigneeListBox);
			this.Controls.Add(this.m_IncrVerseButton);
			this.Controls.Add(this.m_DecrVerseButton);
			this.Controls.Add(this.m_endTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_startTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.m_comment);
			this.Name = "AddNoteDialog";
			this.Text = "Add Note";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.TextBox m_comment;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox m_startTextBox;
		private System.Windows.Forms.TextBox m_endTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button m_DecrVerseButton;
		private System.Windows.Forms.Button m_IncrVerseButton;
		private System.Windows.Forms.ListBox m_assigneeListBox;
		private System.Windows.Forms.Label label3;
	}
}

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
            this.m_assigneeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_VerseTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_selectTextTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_wholeWordCheckBox = new System.Windows.Forms.CheckBox();
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
            // m_assigneeComboBox
            // 
            this.m_assigneeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_assigneeComboBox.FormattingEnabled = true;
            this.m_assigneeComboBox.ItemHeight = 16;
            this.m_assigneeComboBox.Location = new System.Drawing.Point(544, 4);
            this.m_assigneeComboBox.Name = "m_assigneeComboBox";
            this.m_assigneeComboBox.Size = new System.Drawing.Size(219, 24);
            this.m_assigneeComboBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Assignee";
            // 
            // m_VerseTextBox
            // 
            this.m_VerseTextBox.Location = new System.Drawing.Point(67, 3);
            this.m_VerseTextBox.Name = "m_VerseTextBox";
            this.m_VerseTextBox.ReadOnly = true;
            this.m_VerseTextBox.Size = new System.Drawing.Size(137, 22);
            this.m_VerseTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Verse";
            // 
            // m_selectTextTextBox
            // 
            this.m_selectTextTextBox.Location = new System.Drawing.Point(110, 33);
            this.m_selectTextTextBox.Name = "m_selectTextTextBox";
            this.m_selectTextTextBox.Size = new System.Drawing.Size(296, 22);
            this.m_selectTextTextBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Text to select";
            // 
            // m_wholeWordCheckBox
            // 
            this.m_wholeWordCheckBox.AutoSize = true;
            this.m_wholeWordCheckBox.Location = new System.Drawing.Point(249, 3);
            this.m_wholeWordCheckBox.Name = "m_wholeWordCheckBox";
            this.m_wholeWordCheckBox.Size = new System.Drawing.Size(134, 21);
            this.m_wholeWordCheckBox.TabIndex = 13;
            this.m_wholeWordCheckBox.Text = "Whole word only";
            this.m_wholeWordCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddNoteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.m_wholeWordCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_selectTextTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_assigneeComboBox);
            this.Controls.Add(this.m_VerseTextBox);
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
		private System.Windows.Forms.ComboBox m_assigneeComboBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox m_VerseTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox m_selectTextTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox m_wholeWordCheckBox;
	}
}
﻿
namespace ReferencePluginL
{
	partial class ControlL
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
			this.label1 = new System.Windows.Forms.Label();
			this.m_BookComboBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_NotesListBox = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.m_commentsReadCheckBox = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.m_assignedToTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.m_replyToTextBox = new System.Windows.Forms.TextBox();
			this.m_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.m_AddCommentButton = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.m_resolvedButton = new System.Windows.Forms.Button();
			this.m_resolvedCheckBox = new System.Windows.Forms.CheckBox();
			this.m_includeResolvedCheckBox = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.m_ChapterComboBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 4);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(187, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select Book to get notes for:";
			// 
			// m_BookComboBox
			// 
			this.m_BookComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_BookComboBox.FormattingEnabled = true;
			this.m_BookComboBox.ItemHeight = 16;
			this.m_BookComboBox.Location = new System.Drawing.Point(209, 2);
			this.m_BookComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.m_BookComboBox.Name = "m_BookComboBox";
			this.m_BookComboBox.Size = new System.Drawing.Size(183, 24);
			this.m_BookComboBox.TabIndex = 1;
			this.m_BookComboBox.SelectedIndexChanged += new System.EventHandler(this.OnBookSelectionChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 92);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Verse for Note:";
			// 
			// m_NotesListBox
			// 
			this.m_NotesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_NotesListBox.FormattingEnabled = true;
			this.m_NotesListBox.ItemHeight = 16;
			this.m_NotesListBox.Location = new System.Drawing.Point(9, 113);
			this.m_NotesListBox.Margin = new System.Windows.Forms.Padding(4);
			this.m_NotesListBox.Name = "m_NotesListBox";
			this.m_NotesListBox.Size = new System.Drawing.Size(103, 340);
			this.m_NotesListBox.TabIndex = 3;
			this.m_NotesListBox.SelectedIndexChanged += new System.EventHandler(this.OnVerseSelectionChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(122, 92);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Note details:";
			// 
			// m_commentsReadCheckBox
			// 
			this.m_commentsReadCheckBox.AutoSize = true;
			this.m_commentsReadCheckBox.Enabled = false;
			this.m_commentsReadCheckBox.Location = new System.Drawing.Point(132, 114);
			this.m_commentsReadCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.m_commentsReadCheckBox.Name = "m_commentsReadCheckBox";
			this.m_commentsReadCheckBox.Size = new System.Drawing.Size(154, 21);
			this.m_commentsReadCheckBox.TabIndex = 5;
			this.m_commentsReadCheckBox.Text = "All comments read?";
			this.m_commentsReadCheckBox.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(128, 176);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(86, 17);
			this.label4.TabIndex = 6;
			this.label4.Text = "Assigned to:";
			// 
			// m_assignedToTextBox
			// 
			this.m_assignedToTextBox.Location = new System.Drawing.Point(229, 176);
			this.m_assignedToTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.m_assignedToTextBox.Name = "m_assignedToTextBox";
			this.m_assignedToTextBox.ReadOnly = true;
			this.m_assignedToTextBox.Size = new System.Drawing.Size(161, 22);
			this.m_assignedToTextBox.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(128, 209);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 17);
			this.label5.TabIndex = 8;
			this.label5.Text = "Reply to:";
			// 
			// m_replyToTextBox
			// 
			this.m_replyToTextBox.Location = new System.Drawing.Point(229, 200);
			this.m_replyToTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.m_replyToTextBox.Name = "m_replyToTextBox";
			this.m_replyToTextBox.ReadOnly = true;
			this.m_replyToTextBox.Size = new System.Drawing.Size(161, 22);
			this.m_replyToTextBox.TabIndex = 9;
			// 
			// m_tableLayoutPanel
			// 
			this.m_tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tableLayoutPanel.ColumnCount = 5;
			this.m_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.m_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.m_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.m_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.m_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.m_tableLayoutPanel.Location = new System.Drawing.Point(132, 269);
			this.m_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
			this.m_tableLayoutPanel.Name = "m_tableLayoutPanel";
			this.m_tableLayoutPanel.RowCount = 1;
			this.m_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tableLayoutPanel.Size = new System.Drawing.Size(291, 187);
			this.m_tableLayoutPanel.TabIndex = 10;
			// 
			// m_AddCommentButton
			// 
			this.m_AddCommentButton.Location = new System.Drawing.Point(132, 233);
			this.m_AddCommentButton.Margin = new System.Windows.Forms.Padding(4);
			this.m_AddCommentButton.Name = "m_AddCommentButton";
			this.m_AddCommentButton.Size = new System.Drawing.Size(120, 28);
			this.m_AddCommentButton.TabIndex = 12;
			this.m_AddCommentButton.Text = "Add Comment";
			this.m_AddCommentButton.UseVisualStyleBackColor = true;
			this.m_AddCommentButton.Click += new System.EventHandler(this.OnAddComment);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(271, 233);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 27);
			this.button1.TabIndex = 13;
			this.button1.Text = "Add Note";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.AddNewNote);
			// 
			// m_resolvedButton
			// 
			this.m_resolvedButton.Location = new System.Drawing.Point(289, 141);
			this.m_resolvedButton.Name = "m_resolvedButton";
			this.m_resolvedButton.Size = new System.Drawing.Size(75, 23);
			this.m_resolvedButton.TabIndex = 14;
			this.m_resolvedButton.Text = "Resolve";
			this.m_resolvedButton.UseVisualStyleBackColor = true;
			this.m_resolvedButton.Click += new System.EventHandler(this.ResolveClicked);
			// 
			// m_resolvedCheckBox
			// 
			this.m_resolvedCheckBox.AutoSize = true;
			this.m_resolvedCheckBox.Enabled = false;
			this.m_resolvedCheckBox.Location = new System.Drawing.Point(132, 143);
			this.m_resolvedCheckBox.Name = "m_resolvedCheckBox";
			this.m_resolvedCheckBox.Size = new System.Drawing.Size(89, 21);
			this.m_resolvedCheckBox.TabIndex = 15;
			this.m_resolvedCheckBox.Text = "Resolved";
			this.m_resolvedCheckBox.UseVisualStyleBackColor = true;
			// 
			// m_includeResolvedCheckBox
			// 
			this.m_includeResolvedCheckBox.AutoSize = true;
			this.m_includeResolvedCheckBox.Location = new System.Drawing.Point(8, 68);
			this.m_includeResolvedCheckBox.Name = "m_includeResolvedCheckBox";
			this.m_includeResolvedCheckBox.Size = new System.Drawing.Size(172, 21);
			this.m_includeResolvedCheckBox.TabIndex = 16;
			this.m_includeResolvedCheckBox.Text = "Include resolved notes";
			this.m_includeResolvedCheckBox.UseVisualStyleBackColor = true;
			this.m_includeResolvedCheckBox.CheckedChanged += new System.EventHandler(this.IncludeResolvedChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 34);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(101, 17);
			this.label6.TabIndex = 17;
			this.label6.Text = "Select Chapter";
			// 
			// m_ChapterComboBox
			// 
			this.m_ChapterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_ChapterComboBox.FormattingEnabled = true;
			this.m_ChapterComboBox.Location = new System.Drawing.Point(209, 34);
			this.m_ChapterComboBox.Name = "m_ChapterComboBox";
			this.m_ChapterComboBox.Size = new System.Drawing.Size(181, 24);
			this.m_ChapterComboBox.TabIndex = 18;
			this.m_ChapterComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedChapterChanged);
			// 
			// ControlL
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_ChapterComboBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.m_includeResolvedCheckBox);
			this.Controls.Add(this.m_resolvedCheckBox);
			this.Controls.Add(this.m_resolvedButton);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.m_AddCommentButton);
			this.Controls.Add(this.m_tableLayoutPanel);
			this.Controls.Add(this.m_replyToTextBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.m_assignedToTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.m_commentsReadCheckBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_NotesListBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_BookComboBox);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ControlL";
			this.Size = new System.Drawing.Size(427, 460);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox m_BookComboBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox m_NotesListBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox m_commentsReadCheckBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox m_assignedToTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox m_replyToTextBox;
		private System.Windows.Forms.TableLayoutPanel m_tableLayoutPanel;
		private System.Windows.Forms.Button m_AddCommentButton;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button m_resolvedButton;
		private System.Windows.Forms.CheckBox m_resolvedCheckBox;
		private System.Windows.Forms.CheckBox m_includeResolvedCheckBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox m_ChapterComboBox;
	}
}

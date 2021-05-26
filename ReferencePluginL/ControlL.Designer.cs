
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_assignedToTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_replyToTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_newCommentTextBox = new System.Windows.Forms.TextBox();
            this.m_AddCommentButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Book to get notes for:";
            // 
            // m_BookComboBox
            // 
            this.m_BookComboBox.FormattingEnabled = true;
            this.m_BookComboBox.Location = new System.Drawing.Point(157, 2);
            this.m_BookComboBox.Name = "m_BookComboBox";
            this.m_BookComboBox.Size = new System.Drawing.Size(138, 21);
            this.m_BookComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Verse for Note:";
            // 
            // m_NotesListBox
            // 
            this.m_NotesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.m_NotesListBox.FormattingEnabled = true;
            this.m_NotesListBox.Location = new System.Drawing.Point(7, 40);
            this.m_NotesListBox.Name = "m_NotesListBox";
            this.m_NotesListBox.Size = new System.Drawing.Size(78, 199);
            this.m_NotesListBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Note details:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(99, 43);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(118, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "All comments read?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Assigned to:";
            // 
            // m_assignedToTextBox
            // 
            this.m_assignedToTextBox.Location = new System.Drawing.Point(172, 63);
            this.m_assignedToTextBox.Name = "m_assignedToTextBox";
            this.m_assignedToTextBox.ReadOnly = true;
            this.m_assignedToTextBox.Size = new System.Drawing.Size(122, 20);
            this.m_assignedToTextBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Reply to:";
            // 
            // m_replyToTextBox
            // 
            this.m_replyToTextBox.Location = new System.Drawing.Point(172, 83);
            this.m_replyToTextBox.Name = "m_replyToTextBox";
            this.m_replyToTextBox.ReadOnly = true;
            this.m_replyToTextBox.Size = new System.Drawing.Size(122, 20);
            this.m_replyToTextBox.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(99, 168);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(218, 74);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // m_newCommentTextBox
            // 
            this.m_newCommentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_newCommentTextBox.Location = new System.Drawing.Point(99, 139);
            this.m_newCommentTextBox.Name = "m_newCommentTextBox";
            this.m_newCommentTextBox.Size = new System.Drawing.Size(221, 20);
            this.m_newCommentTextBox.TabIndex = 11;
            // 
            // m_AddCommentButton
            // 
            this.m_AddCommentButton.Location = new System.Drawing.Point(180, 109);
            this.m_AddCommentButton.Name = "m_AddCommentButton";
            this.m_AddCommentButton.Size = new System.Drawing.Size(58, 23);
            this.m_AddCommentButton.TabIndex = 12;
            this.m_AddCommentButton.Text = "Add";
            this.m_AddCommentButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(96, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "New comment:";
            // 
            // ControlL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_AddCommentButton);
            this.Controls.Add(this.m_newCommentTextBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.m_replyToTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_assignedToTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_NotesListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_BookComboBox);
            this.Controls.Add(this.label1);
            this.Name = "ControlL";
            this.Size = new System.Drawing.Size(320, 245);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_BookComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox m_NotesListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_assignedToTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_replyToTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox m_newCommentTextBox;
        private System.Windows.Forms.Button m_AddCommentButton;
        private System.Windows.Forms.Label label6;
    }
}

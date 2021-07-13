
namespace ReferencePluginL
{
	partial class AddCommentDialog
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
			this.m_addCommentButton = new System.Windows.Forms.Button();
			this.m_cancelButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.m_assigneeListBox = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// m_comment
			// 
			this.m_comment.AcceptsReturn = true;
			this.m_comment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_comment.Location = new System.Drawing.Point(5, 58);
			this.m_comment.Multiline = true;
			this.m_comment.Name = "m_comment";
			this.m_comment.Size = new System.Drawing.Size(797, 351);
			this.m_comment.TabIndex = 0;
			// 
			// m_addCommentButton
			// 
			this.m_addCommentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_addCommentButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_addCommentButton.Location = new System.Drawing.Point(5, 415);
			this.m_addCommentButton.Name = "m_addCommentButton";
			this.m_addCommentButton.Size = new System.Drawing.Size(148, 23);
			this.m_addCommentButton.TabIndex = 1;
			this.m_addCommentButton.Text = "Add Comment";
			this.m_addCommentButton.UseVisualStyleBackColor = true;
			// 
			// m_cancelButton
			// 
			this.m_cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_cancelButton.Location = new System.Drawing.Point(174, 415);
			this.m_cancelButton.Name = "m_cancelButton";
			this.m_cancelButton.Size = new System.Drawing.Size(98, 23);
			this.m_cancelButton.TabIndex = 2;
			this.m_cancelButton.Text = "Cancel";
			this.m_cancelButton.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 17);
			this.label3.TabIndex = 12;
			this.label3.Text = "Assignee";
			// 
			// m_assigneeListBox
			// 
			this.m_assigneeListBox.FormattingEnabled = true;
			this.m_assigneeListBox.ItemHeight = 16;
			this.m_assigneeListBox.Location = new System.Drawing.Point(74, 0);
			this.m_assigneeListBox.Name = "m_assigneeListBox";
			this.m_assigneeListBox.Size = new System.Drawing.Size(219, 52);
			this.m_assigneeListBox.TabIndex = 11;
			// 
			// AddCommentDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_assigneeListBox);
			this.Controls.Add(this.m_cancelButton);
			this.Controls.Add(this.m_addCommentButton);
			this.Controls.Add(this.m_comment);
			this.Name = "AddCommentDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Add Comment";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.TextBox m_comment;
		private System.Windows.Forms.Button m_addCommentButton;
		private System.Windows.Forms.Button m_cancelButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox m_assigneeListBox;
	}
}
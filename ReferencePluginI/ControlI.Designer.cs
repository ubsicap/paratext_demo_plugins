
namespace ReferencePluginI
{
	partial class ControlI
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
			this.getButton = new System.Windows.Forms.Button();
			this.putButton = new System.Windows.Forms.Button();
			this.chapterText = new System.Windows.Forms.TextBox();
			this.bookName = new System.Windows.Forms.TextBox();
			this.chapterNumber = new System.Windows.Forms.TextBox();
			this.UsfmRadioButton = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.UsfmTokensRadioButton = new System.Windows.Forms.RadioButton();
			this.UsxRadioButton = new System.Windows.Forms.RadioButton();
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.quitButton = new System.Windows.Forms.Button();
			this.lockedCheckBox = new System.Windows.Forms.CheckBox();
			this.changedCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// getButton
			// 
			this.getButton.Location = new System.Drawing.Point(0, 70);
			this.getButton.Name = "getButton";
			this.getButton.Size = new System.Drawing.Size(209, 36);
			this.getButton.TabIndex = 0;
			this.getButton.Text = "Get Chapter";
			this.getButton.UseVisualStyleBackColor = true;
			this.getButton.Click += new System.EventHandler(this.GetScripture);
			// 
			// putButton
			// 
			this.putButton.Location = new System.Drawing.Point(233, 70);
			this.putButton.Name = "putButton";
			this.putButton.Size = new System.Drawing.Size(204, 36);
			this.putButton.TabIndex = 1;
			this.putButton.Text = "Put Chapter";
			this.putButton.UseVisualStyleBackColor = true;
			this.putButton.Click += new System.EventHandler(this.PutScripture);
			// 
			// chapterText
			// 
			this.chapterText.AcceptsReturn = true;
			this.chapterText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chapterText.Location = new System.Drawing.Point(14, 150);
			this.chapterText.MaxLength = 0;
			this.chapterText.Multiline = true;
			this.chapterText.Name = "chapterText";
			this.chapterText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.chapterText.Size = new System.Drawing.Size(653, 129);
			this.chapterText.TabIndex = 2;
			this.chapterText.TextChanged += new System.EventHandler(this.ScriptureTextChanged);
			// 
			// bookName
			// 
			this.bookName.Location = new System.Drawing.Point(5, 8);
			this.bookName.Name = "bookName";
			this.bookName.ReadOnly = true;
			this.bookName.Size = new System.Drawing.Size(151, 22);
			this.bookName.TabIndex = 3;
			// 
			// chapterNumber
			// 
			this.chapterNumber.Location = new System.Drawing.Point(207, 8);
			this.chapterNumber.Name = "chapterNumber";
			this.chapterNumber.ReadOnly = true;
			this.chapterNumber.Size = new System.Drawing.Size(151, 22);
			this.chapterNumber.TabIndex = 3;
			// 
			// UsfmRadioButton
			// 
			this.UsfmRadioButton.AutoSize = true;
			this.UsfmRadioButton.Checked = true;
			this.UsfmRadioButton.Location = new System.Drawing.Point(99, 43);
			this.UsfmRadioButton.Name = "UsfmRadioButton";
			this.UsfmRadioButton.Size = new System.Drawing.Size(98, 21);
			this.UsfmRadioButton.TabIndex = 4;
			this.UsfmRadioButton.TabStop = true;
			this.UsfmRadioButton.Text = "USFM Text";
			this.UsfmRadioButton.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 17);
			this.label1.TabIndex = 5;
			this.label1.Text = "Format:";
			// 
			// UsfmTokensRadioButton
			// 
			this.UsfmTokensRadioButton.AutoSize = true;
			this.UsfmTokensRadioButton.Location = new System.Drawing.Point(202, 43);
			this.UsfmTokensRadioButton.Name = "UsfmTokensRadioButton";
			this.UsfmTokensRadioButton.Size = new System.Drawing.Size(118, 21);
			this.UsfmTokensRadioButton.TabIndex = 6;
			this.UsfmTokensRadioButton.Text = "USFM Tokens";
			this.UsfmTokensRadioButton.UseVisualStyleBackColor = true;
			// 
			// UsxRadioButton
			// 
			this.UsxRadioButton.AutoSize = true;
			this.UsxRadioButton.Location = new System.Drawing.Point(326, 43);
			this.UsxRadioButton.Name = "UsxRadioButton";
			this.UsxRadioButton.Size = new System.Drawing.Size(88, 21);
			this.UsxRadioButton.TabIndex = 7;
			this.UsxRadioButton.Text = "USX Text";
			this.UsxRadioButton.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel.AutoScroll = true;
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.21159F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.78841F));
			this.tableLayoutPanel.Location = new System.Drawing.Point(14, 150);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 1;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.Size = new System.Drawing.Size(656, 129);
			this.tableLayoutPanel.TabIndex = 8;
			// 
			// quitButton
			// 
			this.quitButton.Location = new System.Drawing.Point(463, 70);
			this.quitButton.Name = "quitButton";
			this.quitButton.Size = new System.Drawing.Size(204, 36);
			this.quitButton.TabIndex = 9;
			this.quitButton.Text = "Quit";
			this.quitButton.UseVisualStyleBackColor = true;
			this.quitButton.Click += new System.EventHandler(this.Quit);
			// 
			// lockedCheckBox
			// 
			this.lockedCheckBox.AutoCheck = false;
			this.lockedCheckBox.AutoSize = true;
			this.lockedCheckBox.Enabled = false;
			this.lockedCheckBox.Location = new System.Drawing.Point(14, 113);
			this.lockedCheckBox.Name = "lockedCheckBox";
			this.lockedCheckBox.Size = new System.Drawing.Size(76, 21);
			this.lockedCheckBox.TabIndex = 10;
			this.lockedCheckBox.TabStop = false;
			this.lockedCheckBox.Text = "Locked";
			this.lockedCheckBox.UseVisualStyleBackColor = true;
			// 
			// changedCheckBox
			// 
			this.changedCheckBox.AutoCheck = false;
			this.changedCheckBox.AutoSize = true;
			this.changedCheckBox.Enabled = false;
			this.changedCheckBox.Location = new System.Drawing.Point(98, 113);
			this.changedCheckBox.Name = "changedCheckBox";
			this.changedCheckBox.Size = new System.Drawing.Size(118, 21);
			this.changedCheckBox.TabIndex = 11;
			this.changedCheckBox.TabStop = false;
			this.changedCheckBox.Text = "Text Changed";
			this.changedCheckBox.UseVisualStyleBackColor = true;
			// 
			// ControlI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.changedCheckBox);
			this.Controls.Add(this.lockedCheckBox);
			this.Controls.Add(this.quitButton);
			this.Controls.Add(this.UsxRadioButton);
			this.Controls.Add(this.UsfmTokensRadioButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.UsfmRadioButton);
			this.Controls.Add(this.chapterNumber);
			this.Controls.Add(this.bookName);
			this.Controls.Add(this.putButton);
			this.Controls.Add(this.getButton);
			this.Controls.Add(this.chapterText);
			this.Controls.Add(this.tableLayoutPanel);
			this.Name = "ControlI";
			this.Size = new System.Drawing.Size(670, 279);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button getButton;
		private System.Windows.Forms.Button putButton;
		private System.Windows.Forms.TextBox chapterText;
		private System.Windows.Forms.TextBox bookName;
		private System.Windows.Forms.TextBox chapterNumber;
		private System.Windows.Forms.RadioButton UsfmRadioButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton UsfmTokensRadioButton;
		private System.Windows.Forms.RadioButton UsxRadioButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Button quitButton;
		private System.Windows.Forms.CheckBox lockedCheckBox;
		private System.Windows.Forms.CheckBox changedCheckBox;
	}
}

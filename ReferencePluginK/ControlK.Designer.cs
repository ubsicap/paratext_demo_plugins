
namespace ReferencePluginK
{
	partial class ControlK
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
			this.m_termsListBox = new System.Windows.Forms.ListBox();
			this.m_getTermsButton = new System.Windows.Forms.Button();
			this.m_whichListListBox = new System.Windows.Forms.ListBox();
			this.m_lemmaTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_glossTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.m_referencesListBox = new System.Windows.Forms.ListBox();
			this.m_highlightTermButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_termsListBox
			// 
			this.m_termsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.m_termsListBox.FormattingEnabled = true;
			this.m_termsListBox.ItemHeight = 16;
			this.m_termsListBox.Location = new System.Drawing.Point(0, 58);
			this.m_termsListBox.Name = "m_termsListBox";
			this.m_termsListBox.Size = new System.Drawing.Size(154, 276);
			this.m_termsListBox.TabIndex = 0;
			this.m_termsListBox.SelectedIndexChanged += new System.EventHandler(this.TermSelectionChanged);
			// 
			// m_getTermsButton
			// 
			this.m_getTermsButton.Location = new System.Drawing.Point(163, 3);
			this.m_getTermsButton.Name = "m_getTermsButton";
			this.m_getTermsButton.Size = new System.Drawing.Size(169, 35);
			this.m_getTermsButton.TabIndex = 1;
			this.m_getTermsButton.Text = "Get Biblical Terms";
			this.m_getTermsButton.UseVisualStyleBackColor = true;
			this.m_getTermsButton.Click += new System.EventHandler(this.GetBiblicalTerms);
			// 
			// m_whichListListBox
			// 
			this.m_whichListListBox.FormattingEnabled = true;
			this.m_whichListListBox.ItemHeight = 16;
			this.m_whichListListBox.Location = new System.Drawing.Point(0, 2);
			this.m_whichListListBox.Name = "m_whichListListBox";
			this.m_whichListListBox.Size = new System.Drawing.Size(154, 36);
			this.m_whichListListBox.TabIndex = 2;
			// 
			// m_lemmaTextBox
			// 
			this.m_lemmaTextBox.Location = new System.Drawing.Point(267, 117);
			this.m_lemmaTextBox.Name = "m_lemmaTextBox";
			this.m_lemmaTextBox.Size = new System.Drawing.Size(156, 22);
			this.m_lemmaTextBox.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(160, 117);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 17);
			this.label1.TabIndex = 4;
			this.label1.Text = "Lemma Form:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(160, 145);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 17);
			this.label2.TabIndex = 5;
			this.label2.Text = "Gloss:";
			// 
			// m_glossTextBox
			// 
			this.m_glossTextBox.Location = new System.Drawing.Point(214, 145);
			this.m_glossTextBox.Name = "m_glossTextBox";
			this.m_glossTextBox.Size = new System.Drawing.Size(208, 22);
			this.m_glossTextBox.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(160, 176);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 17);
			this.label3.TabIndex = 7;
			this.label3.Text = "References:";
			// 
			// m_referencesListBox
			// 
			this.m_referencesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_referencesListBox.FormattingEnabled = true;
			this.m_referencesListBox.ItemHeight = 16;
			this.m_referencesListBox.Location = new System.Drawing.Point(160, 202);
			this.m_referencesListBox.Name = "m_referencesListBox";
			this.m_referencesListBox.Size = new System.Drawing.Size(259, 132);
			this.m_referencesListBox.TabIndex = 8;
			// 
			// m_highlightTermButton
			// 
			this.m_highlightTermButton.Location = new System.Drawing.Point(160, 58);
			this.m_highlightTermButton.Name = "m_highlightTermButton";
			this.m_highlightTermButton.Size = new System.Drawing.Size(171, 38);
			this.m_highlightTermButton.TabIndex = 9;
			this.m_highlightTermButton.Text = "Highlight Term";
			this.m_highlightTermButton.UseVisualStyleBackColor = true;
			this.m_highlightTermButton.Click += new System.EventHandler(this.HighlightTerm);
			// 
			// ControlK
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_highlightTermButton);
			this.Controls.Add(this.m_referencesListBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_glossTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_lemmaTextBox);
			this.Controls.Add(this.m_whichListListBox);
			this.Controls.Add(this.m_getTermsButton);
			this.Controls.Add(this.m_termsListBox);
			this.Name = "ControlK";
			this.Size = new System.Drawing.Size(423, 337);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox m_termsListBox;
		private System.Windows.Forms.Button m_getTermsButton;
		private System.Windows.Forms.ListBox m_whichListListBox;
		private System.Windows.Forms.TextBox m_lemmaTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox m_glossTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox m_referencesListBox;
		private System.Windows.Forms.Button m_highlightTermButton;
	}
}

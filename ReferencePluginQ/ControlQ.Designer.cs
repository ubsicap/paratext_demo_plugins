
namespace ReferencePluginQ
{
	partial class ControlQ
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.ProjectsListBox = new System.Windows.Forms.ListBox();
            this.RefreshCollectionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(167, 4);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(788, 443);
            this.textBox.TabIndex = 0;
            // 
            // ProjectsListBox
            // 
            this.ProjectsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ProjectsListBox.FormattingEnabled = true;
            this.ProjectsListBox.ItemHeight = 16;
            this.ProjectsListBox.Location = new System.Drawing.Point(4, 36);
            this.ProjectsListBox.Name = "ProjectsListBox";
            this.ProjectsListBox.Size = new System.Drawing.Size(157, 404);
            this.ProjectsListBox.TabIndex = 1;
            this.ProjectsListBox.Click += new System.EventHandler(this.ProjectListBox_SelectedIndexChanged);
            this.ProjectsListBox.SelectedIndexChanged += new System.EventHandler(this.ProjectListBox_SelectedIndexChanged);
            // 
            // RefreshCollectionButton
            // 
            this.RefreshCollectionButton.Location = new System.Drawing.Point(2, 5);
            this.RefreshCollectionButton.Name = "RefreshCollectionButton";
            this.RefreshCollectionButton.Size = new System.Drawing.Size(158, 25);
            this.RefreshCollectionButton.TabIndex = 2;
            this.RefreshCollectionButton.Text = "Refresh Collection";
            this.RefreshCollectionButton.UseVisualStyleBackColor = true;
            this.RefreshCollectionButton.Click += new System.EventHandler(this.RefreshCollectionButton_Click);
            // 
            // ControlQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RefreshCollectionButton);
            this.Controls.Add(this.ProjectsListBox);
            this.Controls.Add(this.textBox);
            this.Name = "ControlQ";
            this.Size = new System.Drawing.Size(955, 447);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ListBox ProjectsListBox;
        private System.Windows.Forms.Button RefreshCollectionButton;
    }
}

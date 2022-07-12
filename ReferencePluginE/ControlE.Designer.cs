
namespace ReferencePluginE
{
	partial class ControlE
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
            this.ProjectListBox = new System.Windows.Forms.ListBox();
            this.IncResourcesCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(167, 0);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(788, 447);
            this.textBox.TabIndex = 0;
            // 
            // ProjectListBox
            // 
            this.ProjectListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ProjectListBox.FormattingEnabled = true;
            this.ProjectListBox.ItemHeight = 16;
            this.ProjectListBox.Location = new System.Drawing.Point(4, 36);
            this.ProjectListBox.Name = "ProjectListBox";
            this.ProjectListBox.Size = new System.Drawing.Size(157, 404);
            this.ProjectListBox.TabIndex = 1;
            this.ProjectListBox.SelectedIndexChanged += new System.EventHandler(this.ProjectListBox_SelectedIndexChanged);
            // 
            // IncResourcesCheckBox
            // 
            this.IncResourcesCheckBox.AutoSize = true;
            this.IncResourcesCheckBox.Location = new System.Drawing.Point(7, 2);
            this.IncResourcesCheckBox.Name = "IncResourcesCheckBox";
            this.IncResourcesCheckBox.Size = new System.Drawing.Size(147, 21);
            this.IncResourcesCheckBox.TabIndex = 2;
            this.IncResourcesCheckBox.Text = "Include Resources";
            this.IncResourcesCheckBox.UseVisualStyleBackColor = true;
            this.IncResourcesCheckBox.Click += new System.EventHandler(this.IncludeResourcesCheckBox_Click);
            // 
            // ControlE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.IncResourcesCheckBox);
            this.Controls.Add(this.ProjectListBox);
            this.Controls.Add(this.textBox);
            this.Name = "ControlE";
            this.Size = new System.Drawing.Size(955, 447);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ListBox ProjectListBox;
        private System.Windows.Forms.CheckBox IncResourcesCheckBox;
    }
}

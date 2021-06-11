
namespace ReferencePluginM
{
    partial class AddLogEntryDialog
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.m_param3TextBox = new System.Windows.Forms.TextBox();
            this.m_param2TextBox = new System.Windows.Forms.TextBox();
            this.m_param1TextBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.m_logStringTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.m_flushToDiskCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(175, 262);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 32);
            this.button2.TabIndex = 16;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(3, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 31);
            this.button1.TabIndex = 15;
            this.button1.Text = "Create Log Entry";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // m_param3TextBox
            // 
            this.m_param3TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_param3TextBox.Location = new System.Drawing.Point(3, 206);
            this.m_param3TextBox.Name = "m_param3TextBox";
            this.m_param3TextBox.Size = new System.Drawing.Size(448, 22);
            this.m_param3TextBox.TabIndex = 14;
            // 
            // m_param2TextBox
            // 
            this.m_param2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_param2TextBox.Location = new System.Drawing.Point(3, 178);
            this.m_param2TextBox.Name = "m_param2TextBox";
            this.m_param2TextBox.Size = new System.Drawing.Size(448, 22);
            this.m_param2TextBox.TabIndex = 13;
            // 
            // m_param1TextBox
            // 
            this.m_param1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_param1TextBox.Location = new System.Drawing.Point(3, 150);
            this.m_param1TextBox.Name = "m_param1TextBox";
            this.m_param1TextBox.Size = new System.Drawing.Size(448, 22);
            this.m_param1TextBox.TabIndex = 12;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(3, 118);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(448, 25);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "The values for parameters are specified in the following text boxes.";
            // 
            // m_logStringTextBox
            // 
            this.m_logStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_logStringTextBox.Location = new System.Drawing.Point(3, 90);
            this.m_logStringTextBox.Name = "m_logStringTextBox";
            this.m_logStringTextBox.Size = new System.Drawing.Size(448, 22);
            this.m_logStringTextBox.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(448, 81);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "Enter the text to be logged in the following text box.\r\nThe text may include .Net" +
    " formatting commands.\r\nUse { } for passing parameters to the string.";
            // 
            // m_flushToDiskCheckBox
            // 
            this.m_flushToDiskCheckBox.AutoSize = true;
            this.m_flushToDiskCheckBox.Location = new System.Drawing.Point(3, 235);
            this.m_flushToDiskCheckBox.Name = "m_flushToDiskCheckBox";
            this.m_flushToDiskCheckBox.Size = new System.Drawing.Size(142, 21);
            this.m_flushToDiskCheckBox.TabIndex = 17;
            this.m_flushToDiskCheckBox.Text = "Flush to Disk Now";
            this.m_flushToDiskCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddLogEntryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 299);
            this.Controls.Add(this.m_flushToDiskCheckBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_param3TextBox);
            this.Controls.Add(this.m_param2TextBox);
            this.Controls.Add(this.m_param1TextBox);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.m_logStringTextBox);
            this.Controls.Add(this.textBox1);
            this.Name = "AddLogEntryDialog";
            this.Text = "AddLogEntryDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox m_param3TextBox;
        private System.Windows.Forms.TextBox m_param2TextBox;
        private System.Windows.Forms.TextBox m_param1TextBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox m_logStringTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox m_flushToDiskCheckBox;
    }
}
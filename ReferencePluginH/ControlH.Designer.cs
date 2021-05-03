
namespace ReferencePluginH
{
	partial class ControlH
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
			this.itemsText = new System.Windows.Forms.TextBox();
			this.getSelectedItemsButton = new System.Windows.Forms.Button();
			this.getDisplayedItemsButton = new System.Windows.Forms.Button();
			this.getAllListItemsButton = new System.Windows.Forms.Button();
			this.generateListButton = new System.Windows.Forms.Button();
			this.titleText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.enableRerunCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// itemsText
			// 
			this.itemsText.Location = new System.Drawing.Point(6, 170);
			this.itemsText.Multiline = true;
			this.itemsText.Name = "itemsText";
			this.itemsText.ReadOnly = true;
			this.itemsText.Size = new System.Drawing.Size(509, 112);
			this.itemsText.TabIndex = 11;
			// 
			// getSelectedItemsButton
			// 
			this.getSelectedItemsButton.Location = new System.Drawing.Point(348, 118);
			this.getSelectedItemsButton.Name = "getSelectedItemsButton";
			this.getSelectedItemsButton.Size = new System.Drawing.Size(168, 30);
			this.getSelectedItemsButton.TabIndex = 8;
			this.getSelectedItemsButton.Text = "Get Selected List Items";
			this.getSelectedItemsButton.UseVisualStyleBackColor = true;
			this.getSelectedItemsButton.Click += new System.EventHandler(this.GetSelectedItems);
			// 
			// getDisplayedItemsButton
			// 
			this.getDisplayedItemsButton.Location = new System.Drawing.Point(174, 118);
			this.getDisplayedItemsButton.Name = "getDisplayedItemsButton";
			this.getDisplayedItemsButton.Size = new System.Drawing.Size(168, 30);
			this.getDisplayedItemsButton.TabIndex = 9;
			this.getDisplayedItemsButton.Text = "Get Displayed List Items";
			this.getDisplayedItemsButton.UseVisualStyleBackColor = true;
			this.getDisplayedItemsButton.Click += new System.EventHandler(this.GetDisplayedItems);
			// 
			// getAllListItemsButton
			// 
			this.getAllListItemsButton.Location = new System.Drawing.Point(0, 118);
			this.getAllListItemsButton.Name = "getAllListItemsButton";
			this.getAllListItemsButton.Size = new System.Drawing.Size(155, 30);
			this.getAllListItemsButton.TabIndex = 10;
			this.getAllListItemsButton.Text = "Get All List Items";
			this.getAllListItemsButton.UseVisualStyleBackColor = true;
			this.getAllListItemsButton.Click += new System.EventHandler(this.GetAllItems);
			// 
			// generateListButton
			// 
			this.generateListButton.Location = new System.Drawing.Point(0, 71);
			this.generateListButton.Name = "generateListButton";
			this.generateListButton.Size = new System.Drawing.Size(156, 31);
			this.generateListButton.TabIndex = 7;
			this.generateListButton.Text = "Generate List";
			this.generateListButton.UseVisualStyleBackColor = true;
			this.generateListButton.Click += new System.EventHandler(this.GenerateList);
			// 
			// titleText
			// 
			this.titleText.Location = new System.Drawing.Point(150, 3);
			this.titleText.Name = "titleText";
			this.titleText.Size = new System.Drawing.Size(366, 22);
			this.titleText.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(-3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(135, 17);
			this.label1.TabIndex = 5;
			this.label1.Text = "Title for List Window";
			// 
			// enableRerunCheckBox
			// 
			this.enableRerunCheckBox.AutoSize = true;
			this.enableRerunCheckBox.Location = new System.Drawing.Point(188, 77);
			this.enableRerunCheckBox.Name = "enableRerunCheckBox";
			this.enableRerunCheckBox.Size = new System.Drawing.Size(117, 21);
			this.enableRerunCheckBox.TabIndex = 12;
			this.enableRerunCheckBox.Text = "Enable Rerun";
			this.enableRerunCheckBox.UseVisualStyleBackColor = true;
			// 
			// ControlH
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.enableRerunCheckBox);
			this.Controls.Add(this.itemsText);
			this.Controls.Add(this.getSelectedItemsButton);
			this.Controls.Add(this.getDisplayedItemsButton);
			this.Controls.Add(this.getAllListItemsButton);
			this.Controls.Add(this.generateListButton);
			this.Controls.Add(this.titleText);
			this.Controls.Add(this.label1);
			this.Name = "ControlH";
			this.Size = new System.Drawing.Size(529, 319);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox itemsText;
		private System.Windows.Forms.Button getSelectedItemsButton;
		private System.Windows.Forms.Button getDisplayedItemsButton;
		private System.Windows.Forms.Button getAllListItemsButton;
		private System.Windows.Forms.Button generateListButton;
		private System.Windows.Forms.TextBox titleText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox enableRerunCheckBox;
	}
}

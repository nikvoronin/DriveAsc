namespace DriveASC.ui
{
	partial class SetBitValueForm
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
			this.cancelButton = new System.Windows.Forms.Button();
			this.setValueButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.valueTextBox = new System.Windows.Forms.TextBox();
			this.bitCheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(309, 238);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Отмена";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// setValueButton
			// 
			this.setValueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.setValueButton.Location = new System.Drawing.Point(228, 238);
			this.setValueButton.Name = "setValueButton";
			this.setValueButton.Size = new System.Drawing.Size(75, 23);
			this.setValueButton.TabIndex = 1;
			this.setValueButton.Text = "Задать";
			this.setValueButton.UseVisualStyleBackColor = true;
			this.setValueButton.Click += new System.EventHandler(this.setValueButton_Click);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Enabled = false;
			this.label2.Location = new System.Drawing.Point(225, 222);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Enter";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Enabled = false;
			this.label1.Location = new System.Drawing.Point(306, 222);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Escape";
			// 
			// valueTextBox
			// 
			this.valueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.valueTextBox.Location = new System.Drawing.Point(12, 12);
			this.valueTextBox.Name = "valueTextBox";
			this.valueTextBox.Size = new System.Drawing.Size(372, 20);
			this.valueTextBox.TabIndex = 0;
			this.valueTextBox.TextChanged += new System.EventHandler(this.valueTextBox_TextChanged);
			// 
			// bitCheckedListBox
			// 
			this.bitCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bitCheckedListBox.BackColor = System.Drawing.SystemColors.Window;
			this.bitCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.bitCheckedListBox.CheckOnClick = true;
			this.bitCheckedListBox.FormattingEnabled = true;
			this.bitCheckedListBox.Location = new System.Drawing.Point(12, 38);
			this.bitCheckedListBox.Name = "bitCheckedListBox";
			this.bitCheckedListBox.Size = new System.Drawing.Size(372, 165);
			this.bitCheckedListBox.TabIndex = 7;
			this.bitCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.bitCheckedListBox_SelectedIndexChanged);
			// 
			// SetBitValueForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(396, 273);
			this.Controls.Add(this.bitCheckedListBox);
			this.Controls.Add(this.valueTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.setValueButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(404, 300);
			this.Name = "SetBitValueForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "SetBitValueForm";
			this.Load += new System.EventHandler(this.SetBitValueForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button setValueButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox valueTextBox;
		private System.Windows.Forms.CheckedListBox bitCheckedListBox;
	}
}
namespace DriveASC
{
	partial class AboutForm
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
			this.appNameLabel = new System.Windows.Forms.Label();
			this.appVersionLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.closeButton = new System.Windows.Forms.Button();
			this.historyButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.userkeyTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// appNameLabel
			// 
			this.appNameLabel.AutoSize = true;
			this.appNameLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.appNameLabel.Location = new System.Drawing.Point(12, 9);
			this.appNameLabel.Name = "appNameLabel";
			this.appNameLabel.Size = new System.Drawing.Size(86, 23);
			this.appNameLabel.TabIndex = 0;
			this.appNameLabel.Text = "DriveASC";
			// 
			// appVersionLabel
			// 
			this.appVersionLabel.AutoSize = true;
			this.appVersionLabel.Location = new System.Drawing.Point(15, 54);
			this.appVersionLabel.Name = "appVersionLabel";
			this.appVersionLabel.Size = new System.Drawing.Size(35, 13);
			this.appVersionLabel.TabIndex = 1;
			this.appVersionLabel.Text = "label1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 76);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(248, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "© 2012-2013 Nikolai Voronin";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 92);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(154, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Tel: +7 (xxx) xxx-xx-xx";
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.Location = new System.Drawing.Point(274, 145);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 5;
			this.closeButton.Text = "Закрыть";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// historyButton
			// 
			this.historyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.historyButton.Location = new System.Drawing.Point(193, 145);
			this.historyButton.Name = "historyButton";
			this.historyButton.Size = new System.Drawing.Size(75, 23);
			this.historyButton.TabIndex = 6;
			this.historyButton.Text = "История";
			this.historyButton.UseVisualStyleBackColor = true;
			this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(152, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Drive Advanced Servo Control";
			// 
			// userkeyTextBox
			// 
			this.userkeyTextBox.BackColor = System.Drawing.SystemColors.Control;
			this.userkeyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.userkeyTextBox.Location = new System.Drawing.Point(126, 114);
			this.userkeyTextBox.Name = "userkeyTextBox";
			this.userkeyTextBox.ReadOnly = true;
			this.userkeyTextBox.Size = new System.Drawing.Size(142, 13);
			this.userkeyTextBox.TabIndex = 8;
			this.userkeyTextBox.TabStop = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 114);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(105, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Код пользователя:";
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(361, 180);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.userkeyTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.historyButton);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.appVersionLabel);
			this.Controls.Add(this.appNameLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "О программе DriveASC";
			this.Load += new System.EventHandler(this.AboutForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label appNameLabel;
		private System.Windows.Forms.Label appVersionLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Button historyButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox userkeyTextBox;
		private System.Windows.Forms.Label label4;
	}
}
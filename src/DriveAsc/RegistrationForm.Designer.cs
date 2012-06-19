namespace DriveASC
{
	partial class RegistrationForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.userkeyTextBox = new System.Windows.Forms.TextBox();
			this.copyButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.regkeyTextBox = new System.Windows.Forms.TextBox();
			this.registerButton = new System.Windows.Forms.Button();
			this.closeButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(147, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Нужно зарегистрироваться";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Код пользователя";
			// 
			// userkeyTextBox
			// 
			this.userkeyTextBox.Location = new System.Drawing.Point(137, 45);
			this.userkeyTextBox.Name = "userkeyTextBox";
			this.userkeyTextBox.ReadOnly = true;
			this.userkeyTextBox.Size = new System.Drawing.Size(175, 20);
			this.userkeyTextBox.TabIndex = 2;
			// 
			// copyButton
			// 
			this.copyButton.Location = new System.Drawing.Point(318, 43);
			this.copyButton.Name = "copyButton";
			this.copyButton.Size = new System.Drawing.Size(81, 23);
			this.copyButton.TabIndex = 3;
			this.copyButton.Text = "Копировать";
			this.copyButton.UseVisualStyleBackColor = true;
			this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(119, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Регистрационный код";
			// 
			// regkeyTextBox
			// 
			this.regkeyTextBox.Location = new System.Drawing.Point(137, 83);
			this.regkeyTextBox.Name = "regkeyTextBox";
			this.regkeyTextBox.Size = new System.Drawing.Size(175, 20);
			this.regkeyTextBox.TabIndex = 5;
			// 
			// registerButton
			// 
			this.registerButton.Location = new System.Drawing.Point(186, 129);
			this.registerButton.Name = "registerButton";
			this.registerButton.Size = new System.Drawing.Size(126, 23);
			this.registerButton.TabIndex = 6;
			this.registerButton.Text = "Зарегистрировать";
			this.registerButton.UseVisualStyleBackColor = true;
			this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(318, 129);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(81, 23);
			this.closeButton.TabIndex = 7;
			this.closeButton.Text = "Отмена";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// RegistrationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(411, 164);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.registerButton);
			this.Controls.Add(this.regkeyTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.copyButton);
			this.Controls.Add(this.userkeyTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RegistrationForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Регистрация";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox userkeyTextBox;
		private System.Windows.Forms.Button copyButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox regkeyTextBox;
		private System.Windows.Forms.Button registerButton;
		private System.Windows.Forms.Button closeButton;

	}
}
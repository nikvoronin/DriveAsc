namespace KeyASC
{
	partial class MainForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.userTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.regTextBox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.copyButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ключ пользователя";
			// 
			// userTextBox
			// 
			this.userTextBox.Location = new System.Drawing.Point(145, 12);
			this.userTextBox.Name = "userTextBox";
			this.userTextBox.Size = new System.Drawing.Size(157, 20);
			this.userTextBox.TabIndex = 1;
			this.userTextBox.TextChanged += new System.EventHandler(this.userTextBox_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(127, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Регистрационный ключ";
			// 
			// regTextBox
			// 
			this.regTextBox.Location = new System.Drawing.Point(145, 38);
			this.regTextBox.Name = "regTextBox";
			this.regTextBox.ReadOnly = true;
			this.regTextBox.Size = new System.Drawing.Size(157, 20);
			this.regTextBox.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(227, 74);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Закрыть";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// copyButton
			// 
			this.copyButton.Location = new System.Drawing.Point(145, 74);
			this.copyButton.Name = "copyButton";
			this.copyButton.Size = new System.Drawing.Size(76, 23);
			this.copyButton.TabIndex = 4;
			this.copyButton.Text = "Копировать";
			this.copyButton.UseVisualStyleBackColor = true;
			this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(314, 109);
			this.Controls.Add(this.copyButton);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.regTextBox);
			this.Controls.Add(this.userTextBox);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "KeyASC";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox userTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox regTextBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button copyButton;
	}
}


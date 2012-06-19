using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DriveASC.manage;

namespace KeyASC
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void userTextBox_TextChanged(object sender, EventArgs e)
		{
			string trimmedText = userTextBox.Text.Trim().ToUpper().Replace("-", "");
			if (string.IsNullOrWhiteSpace(trimmedText))
			{
				regTextBox.Text = "";
			}
			else
			{
				uint uiRegKey = Utils.GetCRC32(trimmedText);
				string strRegKey = trimmedText.Substring(0, 1) + uiRegKey;
				strRegKey = strRegKey.Insert(3, "-");
				strRegKey = strRegKey.Insert(8, "-");
				regTextBox.Text = strRegKey;
			}			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			userTextBox.Focus();
		}

		private void copyButton_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(regTextBox.Text, TextDataFormat.Text);
		}
	}
}

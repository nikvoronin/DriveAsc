using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DriveASC.manage;
using System.Diagnostics;
using System.IO;

namespace DriveASC
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
		}

		private void AboutForm_Load(object sender, EventArgs e)
		{
			if (!File.Exists("history.txt"))
			{
				historyButton.Enabled = false;
			}
			this.Text = string.Concat("О программе ", GSet.APP_NAME);
			appNameLabel.Text = GSet.APP_NAME;
			appVersionLabel.Text = string.Concat("Версия ", GSet.APP_FULLVERSION);

			if (!string.IsNullOrWhiteSpace(GSet.CMD_UserKey.Value))
			{
				userkeyTextBox.Text = Utils.InsertTires(GSet.CMD_UserKey.Value);
			}
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void historyButton_Click(object sender, EventArgs e)
		{
			Process proc = new Process();
			proc.StartInfo.UseShellExecute = true;
			proc.StartInfo.FileName = "history.txt";
			proc.Start();
		}
	}
}

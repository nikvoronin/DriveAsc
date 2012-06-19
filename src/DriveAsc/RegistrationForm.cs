using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
using System.Security.Cryptography;
using DriveASC.manage;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;

namespace DriveASC
{
	public partial class RegistrationForm : Form
	{
		public RegistrationForm()
		{
			InitializeComponent();

			userkeyTextBox.Text = Utils.InsertTires(GSet.CMD_UserKey.Value);
			this.Text += " " + GSet.APP_TITLE;
		}
		
		private void copyButton_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(userkeyTextBox.Text, TextDataFormat.Text);
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void registerButton_Click(object sender, EventArgs e)
		{
			File.WriteAllText(GSet.REG_FILENAME, regkeyTextBox.Text.Trim().ToUpper().Replace("-", ""));
			MessageBox.Show(
				"Спасибо! Перезапустите програму.\n\nЕсли не получится, выполните 'Помощь' -> 'Регистрация'.",
				"Регистрация завершена");
			this.Close();
			this.Dispose();
		}
	}
}

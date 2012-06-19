using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DriveASC.entity;
using DriveASC.manage;

namespace DriveASC.ui
{
	public partial class SetValueForm : Form
	{
		Command _command;

		public SetValueForm(Command command)
		{
			_command = command;
			InitializeComponent();
		}

		private void setValueButton_Click(object sender, EventArgs e)
		{
			
			this.Tag = valueTextBox.Text;
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void SetValueForm_Load(object sender, EventArgs e)
		{
			ValueParser.ParseResult result = ValueParser.ParseValue(_command);
			valueTextBox.Text = result.Result;
			this.Text = string.Concat(
				_command.ParentGroup.Id, ".", _command.Id.ToString("00"), " ",
				_command.Description);
		}

		private void valueTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				setValueButton_Click(sender, e);
			}
			else
			{
				if (e.KeyCode == Keys.Escape)
				{
					e.SuppressKeyPress = true;
					cancelButton_Click(sender, e);
				}
			}
		}
	}
}

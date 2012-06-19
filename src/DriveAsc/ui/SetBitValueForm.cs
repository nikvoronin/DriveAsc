using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DriveASC.manage;
using DriveASC.entity;

namespace DriveASC.ui
{
	public partial class SetBitValueForm : Form
	{
		Command _command;

		public SetBitValueForm(Command command)
		{			
			_command = command;
			InitializeComponent();
		}

		private void SetBitValueForm_Load(object sender, EventArgs e)
		{
			this.Text = string.Concat(
				_command.ParentGroup.Id, ".", _command.Id.ToString("00"), " ",
				_command.Description);

			int value = 0;
			int.TryParse(_command.Value, out value);

			int checksCnt = _command.ValueItems.Keys.Count;
			for (int i = 0; i < checksCnt; i++)
			{
				string name = "";
				uint val = (uint)(1 << _command.ValueItems[i].Index);
				if (string.IsNullOrWhiteSpace(_command.ValueItems[i].Description))
				{					
					name = string.Concat(val, ": Не доступно");
				}
				else
				{
					name = string.Concat(val, ": ", _command.ValueItems[i].Description);
				}
				bitCheckedListBox.Items.Add(name, (value & val) == val);
			}

			valueTextBox.Text = _command.Value;
			valueTextBox.KeyDown += new KeyEventHandler(form_KeyDown);
			valueTextBox.Focus();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void setValueButton_Click(object sender, EventArgs e)
		{
			this.Tag = valueTextBox.Text;
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void form_KeyDown(object sender, KeyEventArgs e)
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

		bool _isSupressEvents = false;
		private void valueTextBox_TextChanged(object sender, EventArgs e)
		{
			_isSupressEvents = true;
			int valTextBox = 0;
			if (int.TryParse(valueTextBox.Text, out valTextBox))
			{
				int checksCnt = bitCheckedListBox.Items.Count;
				for (int i = 0; i < checksCnt; i++)
				{
					int valCmd = 1 << _command.ValueItems[i].Index;
					bitCheckedListBox.SetItemChecked(i, (valTextBox & valCmd) == valCmd);
				}
			}
			_isSupressEvents = false;
		}

		private void bitCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_isSupressEvents)
			{
				return;
			}

			uint acc = 0;
			int checksCnt = bitCheckedListBox.Items.Count;
			for (int i = 0; i < checksCnt; i++)
			{
				uint v = (uint)(1 << _command.ValueItems[i].Index);
				if (bitCheckedListBox.GetItemChecked(i))
				{
					acc += (uint)(1 << i);
				}
			}

			valueTextBox.Text = acc.ToString();
		}
	}
}

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
	public partial class SetListValueForm : Form
	{
		Command _command;

		public SetListValueForm(Command command)
		{			
			_command = command;
			InitializeComponent();
		}

		private void SetListValueForm_Load(object sender, EventArgs e)
		{
			ValueParser.ParseResult result = ValueParser.ParseValue(_command);
			valueTextBox.Text = result.Result;
			this.Text = string.Concat(
				_command.ParentGroup.Id, ".", _command.Id.ToString("00"), " ",
				_command.Description);

			int iValue = 0;
			int.TryParse(_command.Value, out iValue);

			int selectedIndex = 0;

			if (_command.ResultType == Command.ResultTypes.List)
			{
				foreach (ValueItem item in _command.ValueItems.Values)
				{
					if (item.Index == iValue)
					{
						selectedIndex = valueComboBox.Items.Count;
					}
					valueComboBox.Items.Add(item);
				}
			}
			else
			{
				switch (_command.Name)
				{
					case "ACCUNIT":
						for (int i = 0; i < DimParser.ACCUNIT_CNT; i++)
						{
							string text = string.Concat(
								i,
								": ",
								DimParser.AccunitDimension(i));
							valueComboBox.Items.Add(text);
						}
						break;
					case "PUNIT":
						for (int i = 0; i < DimParser.PUNIT_CNT; i++)
						{
							string text = string.Concat(
								i,
								": ",
								DimParser.PunitDimension(i));
							valueComboBox.Items.Add(text);
						}
						break;
					case "VUNIT":
						for (int i = 0; i < DimParser.VUNIT_CNT; i++)
						{
							string text = string.Concat(
								i,
								": ",
								DimParser.VunitDimension(i));
							valueComboBox.Items.Add(text);
						}
						break;
				}
			}

			try
			{
				valueComboBox.SelectedIndex = selectedIndex;
			}
			catch { }
			valueTextBox.Focus();
		}

		private void valueComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (valueComboBox.SelectedItem != null)
			{
				if (valueComboBox.SelectedItem.GetType() == typeof(string))
				{
					valueTextBox.Text = (string)valueComboBox.SelectedItem;
				}
				else
				{
					valueTextBox.Text = ((ValueItem)valueComboBox.SelectedItem).ToString();
				}
				valueTextBox.Focus();
			}
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

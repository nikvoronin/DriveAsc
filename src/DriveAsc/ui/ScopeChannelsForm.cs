using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DriveASC.entity;
using DriveASC.manage;
using System.Globalization;

namespace DriveASC.ui
{
	public partial class ScopeChannelsForm : Form
	{
		int _channelIndex = 0;
		List<Command> _parameters = new List<Command>();
		
		public ScopeChannelsForm()
		{
			InitializeComponent();
		}

		public ScopeChannelsForm(int channelIndex)
		{
			_channelIndex = channelIndex;
			InitializeComponent();

			foreach (Group group in GSet.I.CurrentTemplate.Groups)
			{
				chGroupComboBox.Items.Add(group);
			}
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			FillMeasure();
			this.Close();
		}

		private void ScopeChannelsForm_Load(object sender, EventArgs e)
		{
			chColorComboBox.Initialize();
			OnChangeChannel();
			ReloadContent();
		}

		void ReloadContent()
		{
			ScopeChannel channel = Scope.I.Channels[_channelIndex];
			chActiveCheckBox.Checked = channel.IsActive;			
			chColorComboBox.SelectedIndex = channel.ColorIndex;
			chMeasureTextBox.Text = Utils.FloatToLongString(channel.MeasurePerMarkY);
			chShiftTextBox.Text = Utils.FloatToLongString(channel.ShiftY);
			if (channel.Parameter != null)
			{
				string dim = DimParser.ParseDim(channel.Parameter);
				chDimLabel.Text = string.Concat(
					dim,
					" / деление"
					);
				chDim2Label.Text = dim;
			}

			chNameLabel.Text = string.Concat("Канал ", ScopeChannel.Names[_channelIndex]);

			chGroupComboBox.Enabled = chActiveCheckBox.Checked;
			chParameterComboBox.Enabled = chActiveCheckBox.Checked;
			chColorComboBox.Enabled = chActiveCheckBox.Checked;
			chMeasureTextBox.Enabled = chActiveCheckBox.Checked;
			chShiftTextBox.Enabled = chActiveCheckBox.Checked;

			chAtoolStripButton.BackColor = Scope.I.Channels[0].IsActive ? Scope.I.Channels[0].ChannelColor : SystemColors.Control;
			chBtoolStripButton.BackColor = Scope.I.Channels[1].IsActive ? Scope.I.Channels[1].ChannelColor : SystemColors.Control;
			chCtoolStripButton.BackColor = Scope.I.Channels[2].IsActive ? Scope.I.Channels[2].ChannelColor : SystemColors.Control;
			chDtoolStripButton.BackColor = Scope.I.Channels[3].IsActive ? Scope.I.Channels[3].ChannelColor : SystemColors.Control;
			chEtoolStripButton.BackColor = Scope.I.Channels[4].IsActive ? Scope.I.Channels[4].ChannelColor : SystemColors.Control;
			chFtoolStripButton.BackColor = Scope.I.Channels[5].IsActive ? Scope.I.Channels[5].ChannelColor : SystemColors.Control;

			chAtoolStripButton.Checked = _channelIndex == 0;
			chBtoolStripButton.Checked = _channelIndex == 1;
			chCtoolStripButton.Checked = _channelIndex == 2;
			chDtoolStripButton.Checked = _channelIndex == 3;
			chEtoolStripButton.Checked = _channelIndex == 4;
			chFtoolStripButton.Checked = _channelIndex == 5;
		}

		private void chAtoolStripButton_Click(object sender, EventArgs e)
		{
			FillMeasure();

			_channelIndex = int.Parse((string)((ToolStripButton)sender).Tag);
			OnChangeChannel();
		}

		private void OnChangeChannel()
		{
			ScopeChannel channel = Scope.I.Channels[_channelIndex];

			if (channel.Parameter != null)
			{
				int chCount = chGroupComboBox.Items.Count;
				for (int i = 0; i < chCount; i++)
				{
					Group group = (Group)chGroupComboBox.Items[i];
					if (group.Id == channel.Parameter.ParentGroup.Id)
					{
						chGroupComboBox.SelectedIndex = i;
						break;
					}
				}
				
				for (int i = 0; i < _parameters.Count; i++)
				{
					Command cmd = _parameters[i];
					if (cmd == channel.Parameter)
					{
						chParameterComboBox.SelectedIndex = i;
						break;
					}
				}
			}
			else
			{
				if (chGroupComboBox.SelectedIndex > -1)
				{
					chParameterComboBox.SelectedIndex = 0;
				}
			}

			ReloadContent();
		}

		private void chColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Scope.I.Channels[_channelIndex].ColorIndex = chColorComboBox.SelectedIndex;
		}

		private void chParameterComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (chParameterComboBox.SelectedIndex > -1)
			{
				Scope.I.Channels[_channelIndex].Parameter = _parameters[chParameterComboBox.SelectedIndex];
				ReloadContent();
			}
		}

		private void chMeasureTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				FillMeasure();
			}
		}

		private void FillMeasure()
		{
			string str = chMeasureTextBox.Text;

			str = str.Replace(",", ".");
			float measure = 1.0f;
			if (float.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out measure))
			{
				Scope.I.Channels[_channelIndex].MeasurePerMarkY = measure;
			}

			str = chShiftTextBox.Text;

			str = str.Replace(",", ".");
			float shift = 1.0f;
			if (float.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out shift))
			{
				Scope.I.Channels[_channelIndex].ShiftY = shift;
			}
		}

		private void chActiveCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			Scope.I.Channels[_channelIndex].IsActive = chActiveCheckBox.Checked;
			if (chActiveCheckBox.Checked && chParameterComboBox.SelectedIndex > -1)
			{
				Scope.I.Channels[_channelIndex].Parameter = _parameters[chParameterComboBox.SelectedIndex];
			}

			ReloadContent();
		}

		private void chSwitchOffAllToolStripButton_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < Scope.CHANNELS_COUNT; i++)
			{
				Scope.I.Channels[i].IsActive = false;
			}

			ReloadContent();
		}

		private void chGroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (chGroupComboBox.SelectedIndex > -1)
			{
				_parameters.Clear();
				chParameterComboBox.Items.Clear();

				foreach (Command cmd in GSet.I.CurrentTemplate.Groups[chGroupComboBox.SelectedIndex].Commands)
				{
					if (cmd.CommandType == Command.CommandTypes.Parameter)
					{
						if (cmd.ResultType == Command.ResultTypes.Float ||
							cmd.ResultType == Command.ResultTypes.Integer ||
							cmd.ResultType == Command.ResultTypes.List)
						{
							string cmdName = "";
							switch (GSet.I.UiParamsDescription)
							{
								case 1:
									cmdName = cmd.Name;
									break;
								case 2:
									cmdName = string.Concat(cmd.Description, ", ", cmd.Name);
									break;
								default:
									cmdName = cmd.Description;
									break;
							}
							_parameters.Add(cmd);
							chParameterComboBox.Items.Add(string.Concat(cmd.Id.ToString("00"), ". ", cmdName));
						}
					}
				}
			}
		}
	}
}

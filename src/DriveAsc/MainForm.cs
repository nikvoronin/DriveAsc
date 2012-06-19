using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DriveASC.entity;
using DriveASC.Properties;
using System.Threading;
using System.IO;
using DriveASC.events;
using DriveASC.manage;
using System.Globalization;
using DriveASC.ui;
using System.Diagnostics;
using System.Reflection;

namespace DriveASC
{
	public partial class MainForm : Form
	{
		private Color COLOR_NORMAL = SystemColors.Window;
		private Color COLOR_READONLY = SystemColors.Info;
		private Color COLOR_NOTVALID = Color.FromArgb(255, 220, 186);
		private Color COLOR_COMMAND = Color.FromArgb(221, 238, 255);

		private const string CON_WAIT_FOR_CONNECTION = "ожидание соединения...";
		private const string CON_CONNECTED_L = "подключен";
		private const string CON_CONNECTED_H = "Подключен";
		private const string CON_DISCONNECTED_L = "отключен";
		private const string CON_DISCONNECTED_H = "Отключен";
		private const string CON_DEFAULT_NAME = "Привод";

		private bool _isLoadingStub = true;			// блокировка положения и размера окна на момент загрузки
		private bool _userDisconnected = false;
		private bool _isRebooting = false;
		private Stopwatch _scopeStopwatch = new Stopwatch();

		public enum SpecialStates
		{
			None,
			SetValue,
			DoCommand,
			AfterConnection,
			TerminalSend
		}

		SpecialStates _specialState = SpecialStates.None;
		Command _doCommand;
		string _doValue;

		public ToolStripButton ScopeCursorButton1
		{
			get
			{
				return scopeCursor1ToolStripButton;
			}
		}

		public MainForm()
		{
			InitializeComponent();
			scopeToolStrip.Visible = true; // дизайнер форм сбрасывает этот флаг, а мы вернем обратно
		}

		private string ComPortName
		{
			set
			{
				portNameStatusLabel.Text = string.Concat("@ ", GSet.I.PortName);
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			mainTabControl.MouseWheel += new MouseEventHandler(mainTabControl_MouseWheel);

			scopeCanvasUC.TheMainForm = this;
			scopeOpenFileDialog.DefaultExt = GSet.SCOPE_EXTENSION;
			scopeOpenFileDialog.Filter = GSet.SCOPE_OPENFILTER;
			scopeSaveAsFileDialog.DefaultExt = GSet.SCOPE_EXTENSION;
			scopeSaveAsFileDialog.Filter = GSet.SCOPE_SAVEFILTER;

			if (GSet.I.LoadConfig())
			{
				GSet.I.SaveConfig();

				if (GSet.I.LoadConfig())
				{
					MessageBox.Show(
						"Ошибка загрузки конфигурации программы.",
						GSet.APP_TITLE,
						MessageBoxButtons.OK,
						MessageBoxIcon.Error
						);
					this.Close();
					this.Dispose();
					return;
				}
			}

			string loadCommandsError = GSet.I.LoadCommands();
			if (loadCommandsError != null)
			{
				if (loadCommandsError != "")
				{
					MessageBox.Show(
						loadCommandsError,
						GSet.APP_TITLE,
						MessageBoxButtons.OK,
						MessageBoxIcon.Error
						);
				}
				this.Close();
				this.Dispose();
				return;
			}

			if (GSet.I.LoadValueItems())
			{
				MessageBox.Show(
					"Перезапустите программу и зарегистрируйте ее правильным ключом.",
					"Неудачная регистрация",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);

				this.Close();
				this.Dispose();
				return;
			}

			this.Text = GSet.APP_TITLE;
			label1.Text = "... Shift + Enter\r... Enter »";
			ComPortName = GSet.I.PortName;

			try
			{
				this.Location = GSet.I.UiAppWindowLoc;
				this.Size = GSet.I.UiAppWindowSize;
				paramsSplitContainer.SplitterDistance = GSet.I.UiParamsTabSplitterLeft;
			}
			catch { }
			
			// эта строка должна быть самой последней среди установок размеров и позиций
			this.WindowState = GSet.I.UiAppWindowState;

			_isLoadingStub = false;

			Km.I.OnConnected += I_OnConnected;
			Km.I.OnDisconnected += I_OnDisconnected;
			Km.I.OnPartDataReady += I_OnPartDataReady;
			Km.I.OnDataReady += I_OnDataReady;

			// если не знаем какой шаблон загружать, то не пытаемся подключиться, чтобы пользователь
			// мог выбрать шаблон
			Template template = GSet.I.LoadTemplate(GSet.I.LastTemplateFilename);
			if (template == null)
			{
				GSet.I.LastTemplateFilename = "";
				E_AppStartWithoutTemplate();
			}
			else
			{
				GSet.I.CurrentTemplate = template;
				UpdateUIwithNewTemplate();

				Km.I.Connect();
			}

			updateTimer.Enabled = true;
		}

		void mainTabControl_MouseWheel(object sender, MouseEventArgs e)
		{
			if (mainTabControl.SelectedIndex == 1)
			{
				scopeCanvasUC.canvasPanel_MouseWheel(sender, e);
			}
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////         ON CONNECTED
		void I_OnConnected(object sender, EventArgs e)
		{
			_specialState = SpecialStates.None;

			connectionStateStripLabel.ForeColor = Color.Black;
			connectionStateStripLabel.Text = CON_CONNECTED_H;
			connectionStateStripLabel.Image = Resources.connected_green_lamp;
			driveStateStatusLabel.Text = CON_CONNECTED_L;

			Km.I.RunTransmission();
			updateTimer.Enabled = true;
			_specialState = SpecialStates.AfterConnection;
			_isRebooting = false;

			E_ConnectionOn();
			
			// для первого раза нужно пнуть обработчик
			Km.I.Transmit(null, Km.TransmitOperations.ReadValue, false, GSet.DataReceivers.Idle);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////         ON DIS-CONNECTED
		void I_OnDisconnected(object sender, EventArgs e)
		{
			if (Scope.I.IsActive)
			{
				scopeCanvasUC.Stop();
				E_ScopeStop();
			}

			_specialState = SpecialStates.None;

			Km.I.EndTransmission();

			connectionStateStripLabel.ForeColor = Color.Black;
			connectionStateStripLabel.Text = CON_DISCONNECTED_H;
			connectionStateStripLabel.Image = Resources.disconnected_red_lamp;
			if (_isRebooting)
			{
				driveStateStatusLabel.Text = "перезагружается...";
			}
			else
			{
				if (_userDisconnected)
				{
					driveStateStatusLabel.Text = CON_DISCONNECTED_L;
				}
				else
				{
					driveStateStatusLabel.Text = CON_WAIT_FOR_CONNECTION;
				}
				driveNameStatusLabel.Text = CON_DEFAULT_NAME;
				_isRebooting = false;
			}

			softLockToolStripStatusLabel.BackColor = SystemColors.Control;
			appLockToolStripStatusLabel.BackColor = SystemColors.Control;
			errToolStripStatusLabel.BackColor = SystemColors.Control;
			stoLockToolStripStatusLabel.BackColor = SystemColors.Control;

			E_Disconnected();

			if (!_userDisconnected)
			{
				reconnectTimer.Enabled = true;
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			scopeCanvasUC.Stop();
			reconnectTimer.Enabled = false;

			Km.I.Disconnect();

			GSet.I.UiParamsTabSplitterLeft = paramsSplitContainer.SplitterDistance;
			GSet.I.UiAppWindowState = this.WindowState;
			GSet.I.SaveConfig();
		}

		private void MainForm_ResizeEnd(object sender, EventArgs e)
		{
			GSet.I.UiAppWindowSize = this.Size;
		}

		private void MainForm_Move(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Normal && !_isLoadingStub)
			{
				GSet.I.UiAppWindowLoc = this.Location;
			}
		}

		private void connectionToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			comPortToolStripMenuItem.DropDownItems.Clear();
			foreach(string name in Km.PortNames)
			{
				ToolStripMenuItem item = new ToolStripMenuItem(name);
				item.Checked = name == GSet.I.PortName;
				item.Click += new EventHandler(comPortItem_Click);
				comPortToolStripMenuItem.DropDownItems.Add(item);
			}

			if (comPortToolStripMenuItem.DropDownItems.Count == 0)
			{
				comPortToolStripMenuItem.Enabled = false;
			}
		}

		void comPortItem_Click(object sender, EventArgs e)
		{
			GSet.I.PortName = ((ToolStripMenuItem)sender).Text;
			ComPortName = GSet.I.PortName;
		}

		private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_userDisconnected = true;
			_isRebooting = false;
			reconnectTimer.Enabled = false;
	
			connectToolStripButton.Enabled = true;
			connectToolStripMenuItem.Enabled = true;

			if (GSet.I.Commands["ASC"].Value != string.Concat(
				GSet.CMD_UserKey.Value.Substring(0, 1),
				Utils.GetCRC32(GSet.CMD_UserKey.Value).ToString()))
			{
				File.Delete(GSet.REG_FILENAME);
			}

			disconnectToolStripButton.Enabled = false;
			disconnectToolStripMenuItem.Enabled = false;

			comPortToolStripMenuItem.Enabled = true;
			templateToolStripMenuItem.Enabled = true;

			Km.I.Disconnect();
			
			I_OnDisconnected(this, EventArgs.Empty);
		}

		private void connectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			driveStateStatusLabel.Text = CON_WAIT_FOR_CONNECTION;
			reconnectTimer.Enabled = false;
			_userDisconnected = false;

			if (GSet.I.Commands["ASC"].Value != string.Concat(
				GSet.CMD_UserKey.Value.Substring(0, 1),
				Utils.GetCRC32(GSet.CMD_UserKey.Value).ToString()))
			{
				File.Delete(GSet.REG_FILENAME);
			}

			connectToolStripButton.Enabled = false;
			connectToolStripMenuItem.Enabled = false;
			disconnectToolStripButton.Enabled = true;
			disconnectToolStripMenuItem.Enabled = true;
			comPortToolStripMenuItem.Enabled = false;
			templateToolStripMenuItem.Enabled = false;

			_isRebooting = false;

			Km.I.Connect();
		}

		private void reconnectTimer_Tick(object sender, EventArgs e)
		{
			reconnectTimer.Enabled = false;
			connectionStateStripLabel.ForeColor = Color.DarkRed;
			Km.I.Connect();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void viewToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			parametersToolStripMenuItem.Checked = mainTabControl.SelectedIndex == 0;
			scopeToolStripMenuItem.Checked = mainTabControl.SelectedIndex == 1;
			terminalToolStripMenuItem.Checked = mainTabControl.SelectedIndex == 2;
		}

		private void parametersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			mainTabControl.SelectedIndex = 0;
		}

		private void scopeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			mainTabControl.SelectedIndex = 1;
		}

		private void terminalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			mainTabControl.SelectedIndex = 2;
		}

		private void sw2ParametersToolStripButton_Click(object sender, EventArgs e)
		{
			mainTabControl.SelectedIndex = 0;
		}

		private void sw2ScopeToolStripButton_Click(object sender, EventArgs e)
		{
			mainTabControl.SelectedIndex = 1;
		}

		private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			sw2ParametersToolStripButton.Checked = mainTabControl.SelectedIndex == 0;
			sw2ScopeToolStripButton.Checked = mainTabControl.SelectedIndex == 1;

			switch (mainTabControl.SelectedIndex)
			{
				case 0: // Parameters
					if (Scope.I.IsActive)
					{
						scopeCanvasUC.Stop();
						E_ScopeStop();
					}
		
					updateTimer.Interval = 233;
					break;
				case 1: // Scope
					break;
				case 2: // Terminal
					if (Scope.I.IsActive)
					{
						scopeCanvasUC.Stop();
						E_ScopeStop();
					}

					updateTimer.Interval = 500;
					terminalTextBox.Focus();
					break;
			}
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////          DATA READY
		void I_OnDataReady(object sender, DataReadyEventArgs e)
		{
			// обрабатываем завершение операций обмена данными
			switch (e.Receiver)
			{
				case GSet.DataReceivers.Idle:		// никто ничего не просил, ПЧ пинается на предмет подключенности
					break;
				
				case GSet.DataReceivers.Parameters: // Parameters
					break;
				
				case GSet.DataReceivers.Scope:		// Scope
					ScopeTick newTick = new ScopeTick();
					newTick.Time = _scopeStopwatch.Elapsed.TotalMilliseconds;
					foreach (ScopeChannel channel in Scope.I.RecordedChannels)
					{
						float value = 0;
						float.TryParse(channel.Parameter.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
						newTick.Values.Add(value);
					}
					Scope.I.AddTick(newTick);
					break;

				case GSet.DataReceivers.Terminal:	// Terminal
					_specialState = SpecialStates.None;
					terminalSendButton.Enabled = true;
					terminalTextBox.Enabled = true;
					terminalTextBox.Clear();
					terminalTextBox.Focus();

					E_LongCommands(true);
					break;
	
				case GSet.DataReceivers.AfterConnection:
					try
					{
						driveNameStatusLabel.Text = string.Concat(
							ValueParser.DriveType,
							" (", GSet.CMD_Alias.Value, ")"
							);
					}
					catch { }

					// Парсим и сохраняем названия ошибок F01..F32
					string rawFltcnt = GSet.CMD_Fltcnt.Value;
					string[] lines = rawFltcnt.Split(new string[]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
					for(int i = 1; i < lines.Length; i++)
					{
						string faultName = lines[i];
						int spIndex = faultName.LastIndexOf(' ');
						if (spIndex > -1)
						{
							faultName = faultName.Substring(0, spIndex);
							GSet.I.FaultsName.Add(faultName);
						}
					}

					_specialState = SpecialStates.None;
					break;

				case GSet.DataReceivers.SetValue:
					E_LongCommands(true);

					_specialState = SpecialStates.None;
					if (_doValue != null)
					{
						MessageBox.Show(
							_doValue,
							string.Concat("Результат выполнения ", _doCommand.Name),
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning);
					}
					break;
				
				case GSet.DataReceivers.DoCommand:
					E_LongCommands(true);

					_specialState = SpecialStates.None;
					switch (_doCommand.Name)
					{
						case "COLDSTART":
							if (_doValue != null)
							{
								// не удалось перезагрузить привод
								coldstartToolStripButton.Enabled = true;
								coldstartToolStripMenuItem.Enabled = true;
								_isRebooting = false;
								MessageBox.Show(
									string.Concat("Не удалось перезагрузить привод.\nПроверьте отсутствие сигналов блокировки.\n\n", _doValue),
									"Ошибка перезагрузки привода",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
							}
							break;
						default:
							if (_doValue != null)
							{
								MessageBox.Show(
									_doValue,
									string.Concat("Результат выполнения ", _doCommand.Name),
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
							}
							break;
					}
					break;
			}

			// смотрим что делать дальше в соответствии с GUI
			List<Command> cmds = new List<Command>();
			Km.TransmitOperations operation = Km.TransmitOperations.ReadValue;
			bool isNeedProgress = false;
			GSet.DataReceivers receiver = GSet.DataReceivers.Idle;

			switch (_specialState)
			{
				case SpecialStates.None:
					switch (mainTabControl.SelectedIndex)
					{
						case 0: // Parameters
							if (paramsListView.Items.Count != 0)
							{
								foreach (ListViewItem item in paramsListView.Items)
								{
									Command cmd = (Command)item.Tag;
									if (cmd.CommandType == Command.CommandTypes.Parameter)
									{
										cmds.Add(cmd);
									}
								}
								operation = Km.TransmitOperations.ReadValue;
								isNeedProgress = true;
								receiver = GSet.DataReceivers.Parameters;
							}
							break;
						
						case 1: // Scope
							if (Scope.I.IsActive)
							{
								foreach (ScopeChannel channel in Scope.I.RecordedChannels)
								{
									cmds.Add(channel.Parameter);
								}
								operation = Km.TransmitOperations.ReadValue;
								isNeedProgress = false;
								receiver = GSet.DataReceivers.Scope;
							}
							break;
					}
					break;

				case SpecialStates.TerminalSend:
					string[] lines = terminalTextBox.Lines;
					foreach (string str in lines)
					{
						string text = str.Trim();
						int spPos = text.LastIndexOf(' ');
						if (spPos > -1 &&
							text.LastIndexOf('*') < 0)
						{
							text = text.Substring(0, spPos);
						}
						if (!string.IsNullOrEmpty(text))
						{
							Command cmd = new Command();
							if (GSet.I.Commands.ContainsKey(text))
							{
								Command presentCmd = GSet.I.Commands[text];
								cmd.IsLongTimeout = presentCmd.IsLongTimeout;
							}
							else
							{
								cmd.IsLongTimeout = true;
							}

							cmd.Name = str;
							cmd.CommandType = Command.CommandTypes.Dump;
							cmds.Add(cmd);
						}
					}

					if (cmds.Count > 0)
					{
						terminalSendButton.Enabled = false;
						terminalTextBox.Enabled = false;
						operation = Km.TransmitOperations.SetValue;
						isNeedProgress = true;
						receiver = GSet.DataReceivers.Terminal;

						E_LongCommands(false);
					}
					break;

				case SpecialStates.SetValue:
					// нельзя выставить значение раньше, т.к. может переписаться фоновым потоком
					_doCommand.Value = _doValue;
					cmds.Add(_doCommand);
					operation = Km.TransmitOperations.SetValue;
					isNeedProgress = true;
					receiver = GSet.DataReceivers.SetValue;

					if (_doCommand.IsLongTimeout)
					{
						E_LongCommands(false);
					}

					if (_doCommand.Name == "ALIAS")
					{
						driveNameStatusLabel.Text = string.Concat(
							ValueParser.DriveType,
							" (", _doValue.ToUpper(), ")"
							);
					}
					break;
				
				case SpecialStates.DoCommand:
					cmds.Add(_doCommand);
					operation = string.IsNullOrEmpty(_doValue) ? Km.TransmitOperations.ReadValue : Km.TransmitOperations.SetValue;
					isNeedProgress = true;
					receiver = GSet.DataReceivers.DoCommand;
					if (_doCommand.IsLongTimeout)
					{
						E_LongCommands(false);
					}
					break;
				
				case SpecialStates.AfterConnection:
					cmds.Add(GSet.CMD_Alias);
					cmds.Add(GSet.CMD_Drive);
					cmds.Add(GSet.CMD_Accunit);
					cmds.Add(GSet.CMD_Punit);
					cmds.Add(GSet.CMD_Vunit);
					cmds.Add(GSet.CMD_Fltcnt);
					operation = Km.TransmitOperations.ReadValue;
					isNeedProgress = false;
					receiver = GSet.DataReceivers.AfterConnection;
					break;
			}

			Km.I.Transmit(cmds, operation, isNeedProgress, receiver);
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////        PART DATA READY
		void I_OnPartDataReady(object sender, PartDataReadyEventArgs e)
		{
			string commandValue;
			switch (e.Receiver)
			{
				case GSet.DataReceivers.Parameters: // Parameters
					break;
			
				case GSet.DataReceivers.Scope: // Scope
					break;

				case GSet.DataReceivers.SetValue:
					commandValue = e.Parameter.Value;
					if (commandValue.Contains("\aERR"))
					{
						_doValue = commandValue.Replace("\a", "");
					}
					else
					{
						_doValue = null;
					}
					break;
				
				case GSet.DataReceivers.DoCommand:
					commandValue = e.Parameter.Value;
					if (commandValue.Contains("\aERR"))
					{
						_doValue = commandValue.Replace("\a", "");
					}
					else
					{
						_doValue = null;
					}
					break;
				
				case GSet.DataReceivers.Terminal: // Terminal
					terminalRichTextBox.AppendText(string.Concat("--> ", e.Parameter.Name, Environment.NewLine));
	
					commandValue = e.Parameter.Value;
					Color valueColor = Color.White;
					if (commandValue.Contains("\aERR"))
					{
						valueColor = Color.Red;
					}
					else
					{
						if (commandValue.Contains("\a"))
						{
							valueColor = Color.Yellow;
						}
					}

					terminalRichTextBox.SelectionColor = valueColor;
					commandValue = commandValue.Replace("\a", "");
					terminalRichTextBox.AppendText(commandValue);
					terminalRichTextBox.SelectionColor = Color.LightGray;
					terminalRichTextBox.ScrollToCaret();

					int c = terminalTextBox.Lines.Length;
					string[] newLines = new string[c - 1];
					for (int i = 1; i < c; i++)
					{
						newLines[i - 1] = terminalTextBox.Lines[i];
					}
					terminalTextBox.Lines = newLines;
					break;
			}
		}

		private void terminalSendButton_Click(object sender, EventArgs e)
		{
			_specialState = SpecialStates.TerminalSend;
		}

		private void terminalTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (e.Shift)
				{
					terminalRichTextBox.AppendText(Environment.NewLine);
				}
				else
				{
					terminalSendButton_Click(sender, e);
					e.SuppressKeyPress = true;
				}
			}
		}

		private void terminalTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
			}

			if (e.Control)
			{
				if (e.KeyCode == Keys.C)
				{
					terminalTextBox.Copy();
				}

				if (e.KeyCode == Keys.V)
				{
					terminalTextBox.Paste();
				}

				if (e.KeyCode == Keys.X)
				{
					terminalTextBox.Cut();
				}
			}
		}

		private void terminalCopyButton_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(
				terminalRichTextBox.Text,
				TextDataFormat.UnicodeText);
			terminalTextBox.Focus();
		}

		private void terminalClearButton_Click(object sender, EventArgs e)
		{
			terminalRichTextBox.Clear();
			terminalTextBox.Focus();
		}

		private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			try
			{
				templateToolStripMenuItem.DropDownItems.Clear();
				for(int i = 0; i < GSet.I.Templates.Length; i += 2)
				{
					ToolStripMenuItem item = new ToolStripMenuItem(GSet.I.Templates[i]);
					item.Tag = GSet.I.Templates[i + 1];
					item.Checked = GSet.I.Templates[i + 1] == GSet.I.LastTemplateFilename;
					item.Click += new EventHandler(templateItem_Click);
					templateToolStripMenuItem.DropDownItems.Add(item);
				}
			}
			catch{}
		}

		void UpdateUIwithNewTemplate()
		{
			this.Text = string.Concat(GSet.APP_TITLE, " - ", GSet.I.CurrentTemplate.Name);
			Template tpl = GSet.I.CurrentTemplate;
			groupsListView.Items.Clear();
			paramsListView.Items.Clear();
			foreach (Group group in tpl.Groups)
			{
				ListViewItem item = new ListViewItem(group.Id);
				item.SubItems.Add(group.Name);
				item.Tag = group;
				groupsListView.Items.Add(item);
			}

			if (tpl.Groups.Count > 0)
			{
				groupsListView.Items[0].Selected = true;
			}
		}

		void templateItem_Click(object sender, EventArgs e)
		{
			string filename = (string)((ToolStripMenuItem)sender).Tag;
			Template template = GSet.I.LoadTemplate(filename);
			if (template == null)
			{
				MessageBox.Show(
					"Ошибка загрузки шаблона!\n\nПрограмма продолжит работать с предыдущим загруженным шаблоном.",
					GSet.APP_TITLE,
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
			}
			else
			{
				GSet.I.LastTemplateFilename = filename;
				GSet.I.CurrentTemplate = null;
				GSet.I.CurrentTemplate = template;
				UpdateUIwithNewTemplate();
			}
		}

		private void groupsListView_Resize(object sender, EventArgs e)
		{
			groupsListView.Columns[1].Width = groupsListView.Width - groupsListView.Columns[0].Width;
		}

		private void groupsListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (groupsListView.SelectedItems.Count > 0)
			{
				Group group = (Group)groupsListView.SelectedItems[0].Tag;
				paramsListView.Items.Clear();
				foreach (Command cmd in group.Commands)
				{
					ListViewItem iitem = new ListViewItem(string.Concat(group.Id, ".", cmd.Id.ToString("00")));
					iitem.Tag = cmd;
					switch (GSet.I.UiParamsDescription)
					{
						case 1:
							iitem.SubItems.Add(cmd.Name);
							break;
						case 2:
							iitem.SubItems.Add(string.Concat(cmd.Description, ", ", cmd.Name));
							break;
						default:
							iitem.SubItems.Add(cmd.Description);
							break;
					}
					iitem.SubItems.Add("");
					paramsListView.Items.Add(iitem);
				}
				
				if (paramsListView.Columns.Count > 0)
				{
					int listW = paramsListView.Width;
					int cw0 = paramsListView.Columns[0].Width;
					int cw1 = paramsListView.Columns[1].Width;
					paramsListView.Columns[2].Width = listW - cw0 - cw1 - 32;
				}
			}
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////       UPDATE PARAMS LIST
		private void updateTimer_Tick(object sender, EventArgs e)
		{
			ValueParser.ParseResult result;
			if (Km.I.IsConnected && !Scope.I.IsActive)
			{
				int ready = -1;
				if (int.TryParse(GSet.CMD_Ready.Value, out ready))
				{
					softEnToolStripButton.Enabled = ready == 0;
					softEnToolStripMenuItem.Enabled = ready == 0;

					softDisToolStripButton.Enabled = ready == 1;
					softDisToolStripMenuItem.Enabled = ready == 1;

					softLockToolStripStatusLabel.BackColor = ready == 1 ? SystemColors.Control : Color.Red;
				}

				result = ValueParser.ParseValue(GSet.CMD_Errcode_, true);
				if (result.Result != null)
				{
					int errcode = -1;
					if (int.TryParse(
							result.Result.Substring(1),
							NumberStyles.HexNumber,
							CultureInfo.InvariantCulture,
							out errcode))
					{
						errToolStripStatusLabel.BackColor = errcode == 0 ? SystemColors.Control : Color.Red;
						clearFaultToolStripButton.Enabled = errcode != 0;
						clearFaultToolStripMenuItem.Enabled = errcode != 0;
					}
				}

				result = ValueParser.ParseValue(GSet.CMD_Stat, true);
				if (result.Result != null)
				{
					int stat = -1;
					if (int.TryParse(
							result.Result.Substring(1),
							NumberStyles.HexNumber,
							CultureInfo.InvariantCulture,
							out stat))
					{
						stoLockToolStripStatusLabel.BackColor = (stat & 0x80) == 0x80 ? Color.Red : SystemColors.Control;
					}
				}

				int remote = -1;
				if (int.TryParse(
						GSet.CMD_Remote.Value,
						out remote))
				{
					appLockToolStripStatusLabel.BackColor = remote == 1 ? SystemColors.Control : Color.Red;
				}
			}

			switch (mainTabControl.SelectedIndex)
			{
				case 0: // Parameters
					if (paramsListView.Items.Count > 0)
					{
						foreach (ListViewItem item in paramsListView.Items)
						{
							Command cmd = (Command)item.Tag;
							result = ValueParser.ParseValue(cmd);
							if (!Km.I.IsConnected)
							{
								item.BackColor = COLOR_NOTVALID;
								item.SubItems[2].Text = "Автономный режим";
							}
							else
							{
								if (cmd.CommandType == Command.CommandTypes.Command)
								{
									if (result.IsNotAvailable)
									{
										cmd.IsInvalid = true;
										item.BackColor = COLOR_NOTVALID;
									}
									else
									{
										item.BackColor = COLOR_COMMAND;
									}
								}
								else
								{
									if (result.IsError)
									{
										item.BackColor = COLOR_NOTVALID;
										cmd.IsInvalid = true;
									}
									else
									{
										cmd.IsInvalid = false;
										if (cmd.IsReadonly)
										{
											item.BackColor = COLOR_READONLY;
										}
										else
										{
											item.BackColor = COLOR_NORMAL;
										}
									}
								}

								item.SubItems[2].Text = result.Result;
							}
						}
					}
					break;
				case 1: // Scope
					if (Scope.I.IsActive)
					{
						scopeCanvasUC.UpdatePartScope();
					}
					break;
				case 2: // Terminal
					break;
			}
		}

		private void aboutDriveAscToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm aboutForm = new AboutForm();
			aboutForm.ShowDialog();
			aboutForm.Dispose();
			aboutForm = null;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////       SET VALUE
		private void paramsListView_DoubleClick(object sender, EventArgs e)
		{
			if (Km.I.IsConnected)
			{
				if (paramsListView.SelectedItems.Count > 0)
				{
					Command cmd = (Command)paramsListView.SelectedItems[0].Tag;
					if (cmd.IsReadonly || cmd.IsInvalid)
					{
						return;
					}

					if (cmd.CommandType == Command.CommandTypes.Command)
					{
						cmd.Value = null;	// стирает "ок"-результат предыдущего выполнения

						DialogResult res = MessageBox.Show(
							string.Concat(
								cmd.Description, ".",
								Environment.NewLine, Environment.NewLine,
								"Выполнить команду ", cmd.Name, " ?"),
							"Выполнить команду",
							MessageBoxButtons.YesNo,
							MessageBoxIcon.Question);
						if (res == System.Windows.Forms.DialogResult.Yes)
						{
							_doCommand = cmd;
							_doValue = null;
							_specialState = SpecialStates.DoCommand;
						}
						return;
					}

					Form theForm = null;
					if (cmd.ResultType == Command.ResultTypes.Xtro ||
						cmd.ResultType == Command.ResultTypes.List)
					{
						if (cmd.ValueItemsType == ValueItem.ValueItemType.BitMask)
						{
							theForm = new SetBitValueForm(cmd);
						}
						else
						{
							theForm = new SetListValueForm(cmd);
						}
					}
					else
					{
						theForm = new SetValueForm(cmd);
					}

					theForm.StartPosition = FormStartPosition.Manual;
					Point pt = paramsListView.PointToScreen(paramsListView.SelectedItems[0].Position);
					pt.Y -= 40;
					theForm.Location = pt;

					if (theForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						_doCommand = cmd;
						_doValue = (string)theForm.Tag;
						_specialState = SpecialStates.SetValue;
						theForm.Dispose();
						theForm = null;
					}
					else
					{
						_specialState = SpecialStates.None;
					}
				}
			}
		}

		private void paramsListView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				paramsListView_DoubleClick(sender, e);
			}
		}

		bool _cancelgrouplistColumnsEvents = false;
		private void groupsListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
		{
			if (_cancelgrouplistColumnsEvents)
			{
				return;
			}

			_cancelgrouplistColumnsEvents = true;
			groupsListView.Columns[1].Width = groupsListView.Width - groupsListView.Columns[0].Width;
			_cancelgrouplistColumnsEvents = false;
		}

		private void paramDescDescToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GSet.I.UiParamsDescription = int.Parse((string)((ToolStripMenuItem)sender).Tag);
			GSet.I.SaveConfig();
			groupsListView_SelectedIndexChanged(sender, e);

			scopeCanvasUC.UpdateScrollbar();
			scopeCanvasUC.RefreshScope();
		}

		private void paramDescriptionToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			paramDescDescToolStripMenuItem.Checked = GSet.I.UiParamsDescription == 0;
			paramDescAsciiToolStripMenuItem.Checked = GSet.I.UiParamsDescription == 1;
			paramDescFullToolStripMenuItem.Checked = GSet.I.UiParamsDescription == 2;
		}

		private void coldstartToolStripButton_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(
					"Убедитесь, что параметры были сохранены; иначе они будут потеряны!\n\nПроизвести перезагрузку частотного привода?",
					"Перезагрузка частотного привода",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				_doCommand = GSet.CMD_Coldstart;
				_doValue = null;
				_specialState = SpecialStates.DoCommand;
				coldstartToolStripButton.Enabled = false;
				coldstartToolStripMenuItem.Enabled = false;
				_isRebooting = true;
			}
		}

		private void softEnStripButton_Click(object sender, EventArgs e)
		{
			_doCommand = GSet.CMD_En;
			_doValue = null;
			_specialState = SpecialStates.DoCommand;
		}

		private void softDisToolStripButton_Click(object sender, EventArgs e)
		{
			_doCommand = GSet.CMD_Dis;
			_doValue = null;
			_specialState = SpecialStates.DoCommand;
		}

		private void saveEepromToolStripButton_Click(object sender, EventArgs e)
		{
			_doCommand = GSet.CMD_Save;
			_doValue = null;
			_specialState = SpecialStates.DoCommand;
		}

		private void rstvarToolStripButton_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(
					"Все внесенные изменения будут потеряны!\n\nПроизвести установку заводских данных?",
					"Установка заводских данных",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				_doCommand = GSet.CMD_Rstvar;
				_doValue = null;
				_specialState = SpecialStates.DoCommand;
			}
		}

		private void chAtoolStripButton_Click(object sender, EventArgs e)
		{
			chAtoolStripButton.BackColor = chBtoolStripButton.BackColor = chCtoolStripButton.BackColor = chDtoolStripButton.BackColor = chEtoolStripButton.BackColor = chFtoolStripButton.BackColor = SystemColors.Control;
			
			int chIndex = int.Parse((string)((ToolStripButton)sender).Tag);
			ScopeChannelsForm chForm = new ScopeChannelsForm(chIndex);

			chForm.ShowDialog();
			chForm.Dispose();
			chForm = null;

			HighlightActiveScopeChannels();
			scopeCanvasUC.RefreshScope();

			E_ScopeSaveRecStop();
		}

		private void HighlightActiveScopeChannels()
		{
			chAtoolStripButton.BackColor = Scope.I.Channels[0].IsActive ? Scope.I.Channels[0].ChannelColor : SystemColors.Control;
			chBtoolStripButton.BackColor = Scope.I.Channels[1].IsActive ? Scope.I.Channels[1].ChannelColor : SystemColors.Control;
			chCtoolStripButton.BackColor = Scope.I.Channels[2].IsActive ? Scope.I.Channels[2].ChannelColor : SystemColors.Control;
			chDtoolStripButton.BackColor = Scope.I.Channels[3].IsActive ? Scope.I.Channels[3].ChannelColor : SystemColors.Control;
			chEtoolStripButton.BackColor = Scope.I.Channels[4].IsActive ? Scope.I.Channels[4].ChannelColor : SystemColors.Control;
			chFtoolStripButton.BackColor = Scope.I.Channels[5].IsActive ? Scope.I.Channels[5].ChannelColor : SystemColors.Control;
			
		}

		// /////////////////////////////////////////////////////////////////////////////////////////////           SCOPE RECORD
		private void scopeRecordToolStripButton_Click(object sender, EventArgs e)
		{
			Scope.I.Ticks.Clear();
			Scope.I.RecordedChannels.Clear();

			foreach (ScopeChannel channel in Scope.I.Channels)
			{
				if (channel.IsActive)
				{
					Scope.I.RecordedChannels.Add(channel);
				}
			}

			string rawHM = scopeMeasureXtoolStripTextBox.Text;
			float hm = 1000f;
			if (float.TryParse(rawHM, out hm))
			{
				if (hm < 10f)
				{
					hm = 10f;
				}
				else
				{
					if (hm > 1000000)
					{
						hm = 1000000;
					}
				}
				scopeCanvasUC.MarkMeasureX = hm;
			}

			E_RecordScope();

			scopeCursor1ToolStripButton.Checked = false;
			scopeCanvasUC.Start();
			_scopeStopwatch.Restart();
			updateTimer.Interval = 100;
		}

		private void scopeStopToolStripButton_Click(object sender, EventArgs e)
		{
			updateTimer.Interval = 300;
	
			E_ScopeStop();
			
			_scopeStopwatch.Stop();
			scopeCanvasUC.Stop();
		}

		private void scopeMeasureInToolStripButton_Click(object sender, EventArgs e)
		{
			string rawHM = scopeMeasureXtoolStripTextBox.Text;
			float hm = 1000f;
			if (float.TryParse(rawHM, out hm))
			{
				hm /= 2f;
			}

			if (hm < 10f)
			{
				hm = 10f;
			}

			scopeMeasureXtoolStripTextBox.BackColor = SystemColors.Window;
			scopeMeasureXtoolStripTextBox.Text = ((int)hm).ToString();
			scopeCanvasUC.MarkMeasureX = hm;

			scopeCanvasUC.UpdateScrollbar();
			scopeCanvasUC.RefreshScope();
		}

		private void scopeMeasureOutToolStripButton_Click(object sender, EventArgs e)
		{
			string rawHM = scopeMeasureXtoolStripTextBox.Text;
			float hm = 1000f;
			if (float.TryParse(rawHM, out hm))
			{
				hm *= 2f;
			}

			if (hm < 10f)
			{
				hm = 10f;
			}

			if (hm > 1000000)
			{
				hm = 1000000;
			}

			scopeMeasureXtoolStripTextBox.BackColor = SystemColors.Window;
			scopeMeasureXtoolStripTextBox.Text = ((int)hm).ToString();
			scopeCanvasUC.MarkMeasureX = hm;

			scopeCanvasUC.UpdateScrollbar();
			scopeCanvasUC.RefreshScope();
		}

		private void scopeSaveImageToolStripButton_Click(object sender, EventArgs e)
		{
			if (scopeSaveImageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				if (!scopeCanvasUC.SaveImage(scopeSaveImageFileDialog.FileName))
				{
					MessageBox.Show(
						"Не удалось сохранить текущее изображение графика осциллографа",
						"Сохранение изображения графика",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
				}
			}
		}

		private void scopeHMeasureToolStripTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				string rawHM = scopeMeasureXtoolStripTextBox.Text;
				float hm = 1000f;
				if (float.TryParse(rawHM, out hm))
				{
					if (hm < 10f)
					{
						hm = 10f;
					}
					else
					{
						if (hm > 1000000)
						{
							hm = 1000000;
						}
					}
					scopeCanvasUC.MarkMeasureX = hm;
				}
				else
				{
					scopeMeasureXtoolStripTextBox.BackColor = COLOR_NOTVALID;
				}
			}
			else
			{
				scopeMeasureXtoolStripTextBox.BackColor = SystemColors.Window;
			}

			scopeCanvasUC.UpdateScrollbar();
			scopeCanvasUC.RefreshScope();
		}

		private void clearFaultToolStripButton_Click(object sender, EventArgs e)
		{
			_doCommand = GSet.CMD_Clrfault;
			_doValue = null;
			_specialState = SpecialStates.DoCommand;
		}

		// /////////////////////////////////////////////////////////////////////////////////////////////            SCOPE OPEN
		private void scopeOpenToolStripButton_Click(object sender, EventArgs e)
		{
			if(scopeOpenFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
			{
				return;
			}

			string filename = scopeOpenFileDialog.FileName;
			FileInfo info = new FileInfo(filename);

			bool isError = false;
			switch(info.Extension)
			{
				case ".csv":
					isError = Scope.I.LoadAsCsv(filename);
					break;
				case GSet.SCOPE_EXTENSION:
					isError = Scope.I.LoadAsAsc(filename);
					break;
			}


			if (isError)
			{
				MessageBox.Show(
					"Не удалось загрузить файл осциллографа.",
					"Ошибка загрузки файла осциллографа",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			E_ScopeSaveRecStop();

			scopeCursor1ToolStripButton.Checked = false;
			scopeCanvasUC.Cursor1 = null;
			HighlightActiveScopeChannels();
			scopeCanvasUC.UpdateScrollbar();
			scopeCanvasUC.RefreshScope();

			mainTabControl.SelectedIndex = 1;
		}

		private void scopeCursor1ToolStripButton_Click(object sender, EventArgs e)
		{
			if (scopeCanvasUC.Cursor1 != null)
			{
				scopeCanvasUC.Cursor1.Enable = scopeCursor1ToolStripButton.Checked;
				scopeCanvasUC.RefreshScope();
			}
			else
			{
				scopeCursor1ToolStripButton.Checked = false;
			}
		}

		private void scopeSaveAsToolStripButton_Click(object sender, EventArgs e)
		{
			if (scopeSaveAsFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Scope.I.SaveAsAsc(scopeSaveAsFileDialog.FileName);
			}
		}

		private void mainTabControl_KeyDown(object sender, KeyEventArgs e)
		{
			if (mainTabControl.SelectedIndex == 1 &&
				(e.KeyCode == Keys.Left || e.KeyCode == Keys.Right))
			{
				scopeCanvasUC.OnScopeCanvasUC_KeyDown(sender, e);
			}
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////////        NEW SCOPE
		private void scopeNewToolStripButton_Click(object sender, EventArgs e)
		{
			mainTabControl.SelectedIndex = 1;

			if (Scope.I.Ticks.Count > 0)
			{
				DialogResult result = MessageBox.Show(
						"Данные текущей осциллограммы будут потеряны.\n\nСохранить текущую осциллограмму?\n\nДа - сохранить и создать новую.\nНет - не сохранять, но создать новую.\nОтмена - ничего не трогать, оставить все как есть.",
						"Сохранение осциллограммы",
						MessageBoxButtons.YesNoCancel,
						MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					scopeSaveAsToolStripButton_Click(sender, e);
				}
				else
				{
					if (result == DialogResult.Cancel)
					{
						return;
					}
				}
			}

			Scope.I.NewScope();

			HighlightActiveScopeChannels();
			scopeCanvasUC.Cursor1 = null;
			scopeCursor1ToolStripButton.Checked = false;
			scopeCanvasUC.UpdateScrollbar();
			scopeCanvasUC.RefreshScope();

			E_ScopeSaveRecStop();
		}

		/// <summary>
		/// При запуске приложения без шаблона
		/// </summary>
		public void E_AppStartWithoutTemplate()
		{
			templateToolStripMenuItem.Enabled = true;
			comPortToolStripMenuItem.Enabled = true;
			connectToolStripButton.Enabled = true;
			connectToolStripMenuItem.Enabled = true;
			disconnectToolStripButton.Enabled = false;
			disconnectToolStripMenuItem.Enabled = false;
		}

		/// <summary>
		/// После установления связи с приводом
		/// </summary>
		public void E_ConnectionOn()
		{
			E_LongCommands(true);

			driveToolStripMenuItem.Enabled = true;
			coldstartToolStripButton.Enabled = true;
			coldstartToolStripMenuItem.Enabled = true;
			rstvarToolStripButton.Enabled = true;
			saveEepromToolStripButton.Enabled = true;
			errorsToolStripButton.Enabled = true;

			terminalSendButton.Enabled = true;
			terminalTextBox.Enabled = true;

			E_ScopeSaveRecStop();
		}

		/// <summary>
		/// Кнопки каналов осциллографа
		/// </summary>
		/// <param name="isEnable"></param>
		public void E_ScopeChannels(bool isEnable)
		{
			chAtoolStripButton.Enabled = isEnable;
			chBtoolStripButton.Enabled = isEnable;
			chCtoolStripButton.Enabled = isEnable;
			chDtoolStripButton.Enabled = isEnable;
			chEtoolStripButton.Enabled = isEnable;
			chFtoolStripButton.Enabled = isEnable;
		}
		
		/// <summary>
		/// Перед стартом записи осциллограммы
		/// </summary>
		public void E_RecordScope()
		{
			scopeRecordToolStripButton.Enabled = false;
			scopeStopToolStripButton.Enabled = true;

			if (GSet.I.Commands["ASC"].Value != string.Concat(
				GSet.CMD_UserKey.Value.Substring(0, 1),
				Utils.GetCRC32(GSet.CMD_UserKey.Value).ToString()))
			{
				File.Delete(GSet.REG_FILENAME);
			}

			coldstartToolStripButton.Enabled = false;
			softEnToolStripButton.Enabled = false;
			softDisToolStripButton.Enabled = false;
			rstvarToolStripButton.Enabled = false;
			saveEepromToolStripButton.Enabled = false;
			clearFaultToolStripButton.Enabled = false;
			errorsToolStripButton.Enabled = false;

			scopeSaveAsToolStripButton.Enabled = false;
			scopeNewToolStripButton.Enabled = false;
			scopeSaveImageToolStripButton.Enabled = false;
			scopeOpenToolStripButton.Enabled = false;

			paramSmoothToolStripMenuItem.Enabled = false;

			driveToolStripMenuItem.Enabled = false;

			openScopeToolStripMenuItem.Enabled = false;
			saveAsScopeToolStripMenuItem.Enabled = false;

			scopeCursor1ToolStripButton.Enabled = false;

			E_ScopeChannels(false);
		}

		/// <summary>
		/// После остановки записи осциллограммы
		/// </summary>
		public void E_ScopeStop()
		{
			scopeRecordToolStripButton.Enabled = true;
			scopeStopToolStripButton.Enabled = false;

			coldstartToolStripButton.Enabled = true;
			rstvarToolStripButton.Enabled = true;
			saveEepromToolStripButton.Enabled = true;
			errorsToolStripButton.Enabled = true;

			scopeNewToolStripButton.Enabled = true;
			scopeSaveImageToolStripButton.Enabled = true;
			scopeOpenToolStripButton.Enabled = true;

			paramSmoothToolStripMenuItem.Enabled = true;

			driveToolStripMenuItem.Enabled = true;

			openScopeToolStripMenuItem.Enabled = true;

			scopeCursor1ToolStripButton.Enabled = true;

			E_ScopeSaveRecStop();
			E_ScopeChannels(true);
		}

		/// <summary>
		/// Разрешние контролов осциллографа в зависимости от условий
		/// </summary>
		public void E_ScopeSaveRecStop()
		{
			scopeSaveImageToolStripButton.Enabled = Scope.I.Ticks.Count > 0;
			scopeSaveAsToolStripButton.Enabled = Scope.I.Ticks.Count > 0;
			saveAsScopeToolStripMenuItem.Enabled = Scope.I.Ticks.Count > 0;
			scopeCursor1ToolStripButton.Enabled = Scope.I.Ticks.Count > 0;

			bool oneChActive = false;
			foreach (ScopeChannel channel in Scope.I.Channels)
			{
				if (channel.IsActive)
				{
					oneChActive = true;
					break;
				}
			}
			scopeRecordToolStripButton.Enabled = Km.I.IsConnected && oneChActive;
			scopeStopToolStripButton.Enabled = false;
		}

		public void E_LongCommands(bool isEnabled)
		{
			scopeToolStrip.Enabled = isEnabled;

			newScopeToolStripMenuItem.Enabled = isEnabled;
			openScopeToolStripMenuItem.Enabled = isEnabled;
			saveAsScopeToolStripMenuItem.Enabled = isEnabled;

			coldstartToolStripButton.Enabled = isEnabled;
			softEnToolStripButton.Enabled = isEnabled;
			softDisToolStripButton.Enabled = isEnabled;
			rstvarToolStripButton.Enabled = isEnabled;
			saveEepromToolStripButton.Enabled = isEnabled;
			clearFaultToolStripButton.Enabled = isEnabled;
			errorsToolStripButton.Enabled = isEnabled;

			driveToolStripMenuItem.Enabled = isEnabled;
			
			terminalTextBox.Enabled = isEnabled;
			terminalSendButton.Enabled = isEnabled;
		}

		/// <summary>
		/// При отсоединении связи
		/// </summary>
		public void E_Disconnected()
		{
			E_LongCommands(true);

			coldstartToolStripButton.Enabled = false;
			softEnToolStripButton.Enabled = false;
			softDisToolStripButton.Enabled = false;
			rstvarToolStripButton.Enabled = false;
			saveEepromToolStripButton.Enabled = false;
			clearFaultToolStripButton.Enabled = false;
			errorsToolStripButton.Enabled = false;

			driveToolStripMenuItem.Enabled = false;

			terminalSendButton.Enabled = false;
			terminalTextBox.Enabled = false;

			E_ScopeSaveRecStop();
		}

		private void errorsToolStripButton_Click(object sender, EventArgs e)
		{
			ErrorsForm errorsForm = new ErrorsForm();
			errorsForm.ShowDialog();
			errorsForm.Dispose();
			errorsForm = null;
		}

		private void registerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(
				"Ахтунг! Нужно будет перезапустить программу.\n\nПеререгистрация, да?",
				"Регистрация",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				File.Delete(GSet.REG_FILENAME);
				this.Close();
				this.Dispose();
			}
		}

		private void paramSmoothFastToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GSet.I.UiScopeSmooth = int.Parse((string)((ToolStripMenuItem)sender).Tag);
			scopeCanvasUC.canvasPanel_SizeChanged(sender, e);
		}

		private void paramSmoothToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			int cnt = paramSmoothToolStripMenuItem.DropDownItems.Count;
			for (int i = 0; i < cnt; i++)
			{
				((ToolStripMenuItem)paramSmoothToolStripMenuItem.DropDownItems[i]).Checked = GSet.I.UiScopeSmooth == i;
			}
		}

		private void paramsListView_MouseEnter(object sender, EventArgs e)
		{
			paramsListView.Focus();
		}

		private void groupsListView_MouseEnter(object sender, EventArgs e)
		{
			groupsListView.Focus();
		}
	}
}

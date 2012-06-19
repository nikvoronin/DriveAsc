using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.ComponentModel;
using DriveASC.entity;
using DriveASC.events;
using System.Diagnostics;
using System.Windows.Forms;

namespace DriveASC.manage
{
	public class Km
	{
		private const int TIMEOUT_SHORT = 100;
		private const int TIMEOUT_LONG = 2000;

		private static Km _instance = new Km();
		public static Km I { get { return _instance; } }
		private SerialPort _port;

		public event EventHandler<EventArgs> OnConnected;
		public event EventHandler<EventArgs> OnDisconnected;

		public event EventHandler<DataReadyEventArgs> OnDataReady;
		public event EventHandler<PartDataReadyEventArgs> OnPartDataReady;

		private BackgroundWorker _connectionWorker;
		private BackgroundWorker _transmitWorker;
		private TransmitOperations _operation;

		public enum TransmitOperations
		{
			ReadValue,
			SetValue
		}

		private bool _isConnected = false;
		public bool IsConnected
		{
			get
			{
				return _isConnected;
			}
		}

		private List<Command> _commandsToSend = new List<Command>();
		private bool _isNeedToSend = false;
		private bool _isNeedProgress = false;
		private GSet.DataReceivers _receiver;

		private Km()
		{
			_connectionWorker = new BackgroundWorker();
			_connectionWorker.WorkerSupportsCancellation = true;
			_connectionWorker.DoWork += ConnectionWorker_DoWork;
			_connectionWorker.RunWorkerCompleted += ConnectionWorker_RunWorkerCompleted;

			_transmitWorker = new BackgroundWorker();
			_transmitWorker.WorkerSupportsCancellation = true;
			_transmitWorker.WorkerReportsProgress = true;
			_transmitWorker.DoWork += TransmitWorker_DoWork;
			_transmitWorker.ProgressChanged += TransmitWorker_ProgressChanges;
			_transmitWorker.RunWorkerCompleted += TransmitWorker_RunWorkerCompleted;
		}

		public static string[] PortNames
		{
			get
			{
				return SerialPort.GetPortNames();
			}
		}

		#region Communication methods			///////////////////////////////////////////////////////////////////////////////

		public bool IsShortTimeout
		{
			set
			{
				try
				{
					_port.WriteTimeout = value ? TIMEOUT_SHORT : TIMEOUT_LONG;
					_port.ReadTimeout = value ? TIMEOUT_SHORT : TIMEOUT_LONG;
				}
				catch { }
			}
		}
		
		/// <summary>
		/// By default 38400, no parity, 8 bits, 1 stop bit, 300 ms timeout, 80 bytes buffer
		/// </summary>
		/// <param name="portName"COM-port name></param>
		/// <returns>true - if port opened successfully, false - otherwise</returns>
		private bool OpenPort(string portName)
		{
			try
			{
				ClosePort();

				_port = new SerialPort(portName, 38400, Parity.None, 8, StopBits.One);
				_port.WriteTimeout = TIMEOUT_SHORT;
				_port.ReadTimeout = TIMEOUT_SHORT;
				_port.ReadBufferSize = 80;
				_port.WriteBufferSize = 80;
				_port.Open();
				_port.DiscardOutBuffer();
				_port.DiscardInBuffer();
				_port.DtrEnable = true;

				return _port.IsOpen;
			}
			catch
			{
				ClosePort();
				return false;
			}
		}

		private void ClosePort()
		{
			if (_port != null)
			{
				try
				{
					_port.Close();
					_port.Dispose();
				}
				catch { }
				finally
				{
					_port = null;
				}
			}
		}

		/// <summary>
		/// Тупо вычитать входной буфер порта
		/// </summary>
		private void ReadFlush()
		{
			while (true)
			{
				try
				{
					_port.ReadByte();
				}
				catch
				{
					break;
				}
			}
		}
		
		/// <summary>
		/// Read wholl text until timeout
		/// </summary>
		/// <returns>Readed bytes or null if error</returns>
		private byte[] ReadUntilTimeout()
		{
			int i = 0;
			int len = 16384;
			byte[] rbuffer = new byte[len];

			while (i < len)
			{
				try
				{
					rbuffer[i] = (byte)_port.ReadByte();
					i++;
				}
				catch
				{
					if (i == 0)
					{
						return null;
					}
					break;
				}
			}

			return rbuffer;
		}

		/// <summary>
		/// Read one text line until LF (=0x0A)
		/// </summary>
		/// <returns>ASCII encoded sting that readed from port or null if error</returns>
		private string ReadString()
		{
			int i = 0;
			int len = 16384;
			byte[] rbuffer = new byte[len];

			bool isError = false;
			while (i < len)
			{
				try
				{
					rbuffer[i] = (byte)_port.ReadByte();
					if (rbuffer[i] == 0x0A)
					{
						break;
					}
					i++;
				}
				catch
				{
					isError = true;
					break;
				}
			}

			string result = isError ? null : Buffer2String(rbuffer);

			return result;
		}

		/// <summary>
		/// Just send a text
		/// </summary>
		/// <param name="text">String to send</param>
		/// <returns>true - if successfully sended, false - otherwise</returns>
		private bool SendString(string text)
		{
			int cmdLength = text.Length;
			byte[] wbuffer = new byte[cmdLength + 1];
			byte[] cmdBuffer = Encoding.ASCII.GetBytes(text);

			for (int j = 0; j < cmdLength; j++)
			{
				wbuffer[j] = cmdBuffer[j];
			}
			wbuffer[cmdLength + 0] = 0x0D;

			try
			{
				_port.RtsEnable = true;
				_port.Write(wbuffer, 0, wbuffer.Length);
			}
			catch
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Send a checksummed text
		/// </summary>
		/// <param name="text">String to send</param>
		/// <returns>true - if successfully sended, false - otherwise</returns>
		private bool SendString3(string text)
		{
			int cmdLength = text.Length;
			byte[] cmdBuffer = Encoding.ASCII.GetBytes(text);
			byte[] wbuffer = new byte[cmdLength + 3];
			byte[] checksum = Checksum(text);

			for (int j = 0; j < cmdLength; j++)
			{
				wbuffer[j] = cmdBuffer[j];
			}
			wbuffer[cmdLength + 0] = checksum[0];
			wbuffer[cmdLength + 1] = checksum[1];
			wbuffer[cmdLength + 2] = 0x0D;

			try
			{
				_port.RtsEnable = true;
				_port.Write(wbuffer, 0, wbuffer.Length);
			}
			catch
			{
				return false;
			}

			return true;
		}
		#endregion

		#region Connection methods			///////////////////////////////////////////////////////////////////////////////
		public void Connect()
		{
			_transmitWorker.CancelAsync();
			_connectionWorker.CancelAsync();

			_connectionWorker.RunWorkerAsync();
		}

		public void Disconnect()
		{
			_connectionWorker.CancelAsync();
			_transmitWorker.CancelAsync();

			Thread.Sleep(100);

			ReadUntilTimeout();
			SendString("PROMPT 3");
			ReadUntilTimeout();
			SendString3("PROMPT 3");
			ReadUntilTimeout();
			SendString3("PROMPT 3");
			ReadUntilTimeout();

			ClosePort();
			_isConnected = false;
		}

		public byte[] Checksum(string command)
		{
			byte[] cmdBytes = Encoding.ASCII.GetBytes(command);
			int summ = 0;
			int len = cmdBytes.Length;
			for (int i = 0; i < len; i++)
			{
				summ += cmdBytes[i];
			}
			summ &= 0xFF;

			byte[] result = new byte[2];
			result[0] = (byte)(summ / 16 + 0x30);
			result[1] = (byte)(summ % 16 + 0x30);

			return result;
		}

		private string Buffer2String(byte[] buffer)
		{
			if (buffer == null || buffer.Length == 0)
			{
				return "";
			}

			string result = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
			int idx = result.IndexOf((char)0x00);
			if (idx > -1)
			{
				result = result.Substring(0, idx);
			}

			return result;
		}

		private bool InitializeConnection()
		{
			// Дочитываем все, что было в буфере порта. Возможно там ничего нет. В любом случае, оно нам не интересно.
			ReadFlush();

			if (!SendString("PROMPT 3"))
			{
				return false;
			}

			Thread.Sleep(100);

			byte[] rbuffer = ReadUntilTimeout();
			if (rbuffer == null)
			{
				return false;
			}
			else
			{
				string result = Buffer2String(rbuffer);
				if (!result.Contains("PROMPT 3"))
				{
					return false;
				}
			}

			if (!SendString3("PROMPT 0"))
			{
				return false;
			}

			Thread.Sleep(100);

			// Дочитываем все, что есть в буфере порта. Возможно там ничего нет. В любом случае, оно нам не интересно.
			ReadFlush();

			return true;
		}
		#endregion

		#region Connecion workers			///////////////////////////////////////////////////////////////////////////////
		private void ConnectionWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			bool isOpenned = OpenPort(GSet.I.PortName);
			bool isConnected = isOpenned;
			if (isOpenned)
			{
				if (_connectionWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}
				else
				{
					isConnected = InitializeConnection();
					if (isConnected)
					{
						// задержка между командами не нужна (максимальная = 160 мсек)
						isConnected = SendString("CMDDLY 0");
					}
					else
					{
						ClosePort();
					}
				}
			}

			e.Result = isConnected;
		}

		private void ConnectionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (!e.Cancelled)
			{
				if ((bool)e.Result)
				{
					_isConnected = true;
					RaiseOnConnected(EventArgs.Empty);
				}
				else
				{
					_isConnected = false;
					RaiseOnDisconnected(EventArgs.Empty);
				}
			}
		}
		#endregion		

		#region Transmision methods			///////////////////////////////////////////////////////////////////////////////
		public void RunTransmission()
		{
			_transmitWorker.CancelAsync();
			_connectionWorker.CancelAsync();

			//Thread.Sleep(100);

			_transmitWorker.RunWorkerAsync();
		}

		public void EndTransmission()
		{
				_connectionWorker.CancelAsync();
				_transmitWorker.CancelAsync();
		}

		public void Transmit(List<Command> commands, TransmitOperations operation, bool isNeedProgress, GSet.DataReceivers receiver)
		{
			_commandsToSend = commands;
			_receiver = receiver;
			_operation = operation;
			_isNeedProgress = isNeedProgress;
			_isNeedToSend = true;
		}

		#endregion

		#region Transmission workers			///////////////////////////////////////////////////////////////////////////////
		private void TransmitWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			e.Result = false;
			bool isError = false;
			ProgressChangedUserState userState = null;

			int pingCmdIndex = 0;
			List<Command> _pingCommands = new List<Command>
			{
				GSet.CMD_Accunit,
				GSet.CMD_Punit,
				GSet.CMD_Vunit,
				GSet.CMD_Stat,
				GSet.CMD_Ready,
				GSet.CMD_Remote,
				GSet.CMD_Errcode_,
				GSet.CMD_PGearI,
				GSet.CMD_PGearO,
				GSet.CMD_PrBase,
				GSet.CMD_VBusBal,
				GSet.CMD_Fltcnt_,
				GSet.CMD_Flthist_
			};

			while (!isError)
			{
				int progress = 0;
				userState = null;

				if (_transmitWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}

				if (!_isNeedToSend)
				{
					Thread.Sleep(1);
				}
				else
				{
					if (_commandsToSend != null &&
						_receiver != GSet.DataReceivers.Idle)
					{
						// есть список команд на отправку
						foreach(Command cmd in _commandsToSend)
						{
							if (_transmitWorker.CancellationPending)
							{
								e.Cancel = true;
								return;
							}

							isError = !SendString(
								_operation == TransmitOperations.SetValue ?
									string.Concat(cmd.Name, " ", cmd.Value) :
									cmd.Name
								);

							if (isError)
							{
								break;	// foreach(Command cmd in _commandsToSend)
							}

							string stringResult = "";
							if (cmd.CommandType == Command.CommandTypes.Parameter &&
								_operation == TransmitOperations.ReadValue)
							{
								stringResult = ReadString();
								if (stringResult == null)
								{
									isError = true;
									break; // foreach commands
								}
								else
								{
									if (stringResult.Length > 1)
									{
										stringResult = stringResult.Substring(0, stringResult.Length - 2);
									}
								}
							}
							else
							{
								if (cmd.IsLongTimeout)
								{
									// такое странное условие нужно чтобы дергать таймоуты
									// только при установки длинной задержки
									Km.I.IsShortTimeout = false;
								}

								byte[] byteResult = ReadUntilTimeout();
								
								if (cmd.IsLongTimeout)
								{
									Km.I.IsShortTimeout = true;
								}
								stringResult = Buffer2String(byteResult);
							}

							cmd.Value = stringResult;
							if (_isNeedProgress)
							{
								userState = new ProgressChangedUserState(cmd, _receiver);
								_transmitWorker.ReportProgress(0, userState);
							}
						} // foreach commands

						if (!isError)
						{
							userState = new ProgressChangedUserState(null, _receiver);
							progress = 100;
						}
					} // commandtosend.count > 0

					if (!isError)
					{
						if (_receiver != GSet.DataReceivers.Scope)
						{
							Command pingCommand = _pingCommands[pingCmdIndex];
							pingCmdIndex++;
							if (pingCmdIndex > _pingCommands.Count - 1)
							{
								pingCmdIndex = 0;
							}

							if (SendString(pingCommand.Name))
							{
								string res = ReadString();
								if (res == null)
								{
									isError = true;
								}
								else
								{
									if (res.Length > 1)
									{
										pingCommand.Value = res.Substring(0, res.Length - 2);
									}
								}
							}
							else
							{
								isError = true;
							}
						}

						if (!isError)
						{
							if (_commandsToSend == null ||
								_receiver == GSet.DataReceivers.Idle)
							{
								// OnIdle							
								userState = new ProgressChangedUserState(null, _receiver);
								progress = 100;
							}
						}
					}	// !isError
					
					_isNeedToSend = false;
					
					if (userState != null && !isError)
					{
						_transmitWorker.ReportProgress(progress, userState);
					}
				}	// need to send
			} // while
			
			ClosePort();
			e.Result = isError;
		}

		private void TransmitWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (!e.Cancelled)
			{
				if ((bool)e.Result)
				{
					// error occured
					_isConnected = false;
					RaiseOnDisconnected(EventArgs.Empty);
				}
			}
		}

		private void TransmitWorker_ProgressChanges(object sender, ProgressChangedEventArgs e)
		{
			if (e.ProgressPercentage == 100)
			{
				DataReadyEventArgs eventArgs = new DataReadyEventArgs();
				ProgressChangedUserState ustate = ((ProgressChangedUserState)e.UserState);
				eventArgs.Receiver = ustate.Receiver;

				RaiseOnDataReady(eventArgs);
			}
			else
			{
				PartDataReadyEventArgs eventArgs = new PartDataReadyEventArgs();
				ProgressChangedUserState ustate = ((ProgressChangedUserState)e.UserState);
				eventArgs.Receiver = ustate.Receiver;
				eventArgs.Parameter = ustate.Parameter;

				RaiseOnPartDataReady(eventArgs);
			}
		}
		#endregion

		#region Raise Events				///////////////////////////////////////////////////////////////////////////////
		protected virtual void RaiseOnConnected(EventArgs e)
		{
			EventHandler<EventArgs> temp = OnConnected;
			if (temp != null)
			{
				temp(this, e);
			}
		}

		protected virtual void RaiseOnDisconnected(EventArgs e)
		{
			EventHandler<EventArgs> temp = OnDisconnected;
			if (temp != null)
			{
				temp(this, e);
			}
		}

		protected virtual void RaiseOnPartDataReady(PartDataReadyEventArgs e)
		{
			EventHandler<PartDataReadyEventArgs> temp = OnPartDataReady;
			if (temp != null)
			{
				temp(this, e);
			}
		}

		protected virtual void RaiseOnDataReady(DataReadyEventArgs e)
		{
			EventHandler<DataReadyEventArgs> temp = OnDataReady;
			if (temp != null)
			{
				temp(this, e);
			}
		}
		#endregion
	}
}

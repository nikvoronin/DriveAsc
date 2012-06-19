using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using DriveASC.entity;
using System.Reflection;

namespace DriveASC.manage
{
	public class GSet
	{
		public const string APP_NAME = "DriveASC";
		public const string APP_VERSION = "1.3.0";
		public const string APP_FULLVERSION = APP_VERSION + " (май 2013)";
		public const string APP_TITLE = APP_NAME + " " + APP_VERSION;
		public const string REG_FILENAME = APP_NAME + ".lic";

		public string[] Templates =
		{
			"Универсальный список параметров", "multipurpose.groups",
			"ЧПУ с аналоговым управлением скоростью сигналом ±10В", "cnc-servo-analog.groups"
		};

		public const string SCOPE_EXTENSION = ".dasc";
		public const string SCOPE_SAVEFILTER =
			"Файлы осциллографа DriveASC (*" +
			SCOPE_EXTENSION +
			")|*" +
			SCOPE_EXTENSION;
		public const string SCOPE_OPENFILTER =
			"Файлы осциллографа DriveASC (*" +
			SCOPE_EXTENSION +
			")|*" +
			SCOPE_EXTENSION +
			"|Файлы осциллографа DriveGUI (*.csv)|*.csv";

		private const string APP_CONFIG_FILENAME = "DriveASC.config";
		private const string CMD_LIST_EMBED_RESOURCE = "DriveASC.data.commands.list";
		private const string VAL_LIST_EMBED_RESOURCE = "DriveASC.data.values.list";

		public static Command CMD_Alias;
		public static Command CMD_Drive;
		public static Command CMD_Accunit;
		public static Command CMD_Punit;
		public static Command CMD_Vunit;
		public static Command CMD_Stat;
		public static Command CMD_Errcode_;
		public static Command CMD_Ready;
		public static Command CMD_Remote;
		public static Command CMD_En;
		public static Command CMD_Dis;
		public static Command CMD_Save;
		public static Command CMD_Coldstart;
		public static Command CMD_Rstvar;
		public static Command CMD_Clrfault;
		public static Command CMD_Fltcnt;
		public static Command CMD_Fltcnt_;
		public static Command CMD_Flthist_;

		public static Command CMD_PGearI;
		public static Command CMD_PGearO;
		public static Command CMD_PrBase;

		public static Command CMD_VBusBal;
		public static Command CMD_UserKey;

		public enum DataReceivers
		{
			Idle,
			Parameters,
			Scope,
			Terminal,
			SetValue,
			AfterConnection,
			DoCommand
		}

		public Template CurrentTemplate = new Template();
		public Dictionary<string, Command> Commands = new Dictionary<string, Command>();	// <name of the command, the command>
		public List<string> FaultsName = new List<string>();

		private static GSet _instance = new GSet();
		private GSet()
		{
			CMD_UserKey = new Command();
			string typeA = Utils.R_ProcessorID;
			if (string.IsNullOrWhiteSpace(typeA))
			{
				string typeM = Utils.R_DiskDriveID;
				if (string.IsNullOrWhiteSpace(typeM))
				{
					string typeZ = Utils.R_MachineGUID;
					if (string.IsNullOrWhiteSpace(typeZ))
					{
						CMD_UserKey.Value = "";
					}
					else
					{
						CMD_UserKey.Value = string.Concat("Z", Utils.GetCRC32(typeZ));
					}
				}
				else
				{
					CMD_UserKey.Value = string.Concat("M", Utils.GetCRC32(typeM));
				}
			}
			else
			{
				CMD_UserKey.Value = string.Concat("A", Utils.GetCRC32(typeA));
			}
		}
		public static GSet I { get { return _instance; } }

		// сохраняемые/загружаемые параметры
		public string PortName = "";
		public string LastTemplateFilename = null;
		public bool IsStandalone = false;

		// сохраняемые/загружаемые рабочей среды
		public Size UiAppWindowSize = new Size(700, 500);
		public Point UiAppWindowLoc = new Point(50, 50);
		public FormWindowState UiAppWindowState = FormWindowState.Normal;
		public int UiParamsTabSplitterLeft = 200;
		public int UiParamsDescription = 0;
		public int UiScopeSmooth = 0;

		#region Template and Commands loading
		/// <summary>
		/// Load a template with given filename
		/// </summary>
		/// <param name="filename">Filename of a template</param>
		/// <returns>Template - successfully loaded, null - error, template didn't load</returns>
		public Template LoadTemplate(string filename)
		{
			bool isError = false;
			Template newTemplate = new Template();

			TextReader reader = null;
			try
			{
				Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DriveASC.data." + filename);
				if (stream == null)
				{
					return null;
				}
				reader = new StreamReader(stream);
				newTemplate.Filename = filename;

				string line = null;
				int state = 0;
				while ((line = reader.ReadLine()) != null)
				{
					if (string.IsNullOrWhiteSpace(line))
					{
						continue;
					}

					if (line.StartsWith("//"))
					{
						continue;
					}

					switch (state)
					{
						case 0:	// template name
							newTemplate.Name = line.Trim();
							state = 10;
							break;
						case 10: // group
							string[] indexParts = line.Split('.');
							if (indexParts.Length != 2)
							{
								isError = true;
								break;
							}
							else
							{
								string[] groupParts = indexParts[1].Trim().Split(':');
								if (groupParts.Length != 2)
								{
									isError = true;
									break;
								}
								else
								{
									Group newGroup = new Group();
									newGroup.Name = groupParts[0].Trim();
									newGroup.Id = indexParts[0].Trim();

									string[] cmdParts = groupParts[1].Trim().Split(';');
									if (cmdParts.Length > 0)
									{
										foreach (string rawCmd in cmdParts)
										{
											bool isReadonly = false;
											string name = "";

											string cmdItem = rawCmd.Trim();
											if (cmdItem[0] == '#')
											{
												isReadonly = true;
												name = cmdItem.Substring(1).Trim();
											}
											else
											{
												name = cmdItem.Trim();
											}

											if (Commands.ContainsKey(name))
											{
												Command cmd = Commands[name];
												if (isReadonly)
												{
													cmd.IsReadonly = true;
												}
												cmd.Id = newGroup.Commands.Count + 1;
												cmd.ParentGroup = newGroup;
												newGroup.Commands.Add(cmd);
											}
										}
									}

									if (newGroup.Commands.Count > 0)
									{
										newTemplate.Groups.Add(newGroup);
									}
								}
							}
							break;
					}
				}
			}
			catch
			{
				isError = true;
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
					reader.Dispose();
					reader = null;
				}
			}

			return isError ? null : newTemplate;
		}

		public bool LoadValueItems()
		{
			TextReader reader = null;
			bool isError = false;
			try
			{
				Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(VAL_LIST_EMBED_RESOURCE);
				if (stream == null)
				{
					return false;
				}
				reader = new StreamReader(stream);

				if(string.IsNullOrWhiteSpace(CMD_UserKey.Value))
				{
					File.Delete(GSet.REG_FILENAME);
					isError = true;
					throw new Exception();
				}

				if (Commands["ASC"].Value != string.Concat(
					CMD_UserKey.Value.Substring(0, 1),
					Utils.GetCRC32(CMD_UserKey.Value).ToString()))
				{
					File.Delete(GSet.REG_FILENAME);
					isError = true;
					throw new Exception();
				}

				string line = null;
				int state = 0;
				Command cmd = null;
				while ((line = reader.ReadLine()) != null)
				{
					if (string.IsNullOrWhiteSpace(line))
					{
						continue;
					}

					if (line.StartsWith("//"))
					{
						continue;
					}

					switch (state)
					{
						case 0: // имя команды
							string cmdName = line.Trim().ToUpper();
							if (GSet.I.Commands.ContainsKey(cmdName))
							{
								cmd = GSet.I.Commands[cmdName];
								state = 10;
							}
							break;
						case 10: // значения параметра
							string rawLine = line.Trim();
							if (rawLine.StartsWith(";"))
							{
								cmd = null;
								state = 0;
							}

							string[] lineParts = rawLine.Split(':');
							if (lineParts.Length == 2)
							{
								string rawIndex = lineParts[0].Trim();
								string description = lineParts[1].Trim();

								int startIndex = 0;
								int endIndex = 0;
								if (rawIndex.Contains("-"))
								{
									string[] indexParts = rawIndex.Split('-');
									if (indexParts.Length == 2)
									{
										cmd.ValueItemsType = ValueItem.ValueItemType.Integer;
										if (int.TryParse(indexParts[0], out startIndex))
										{
											if (!int.TryParse(indexParts[1], out endIndex))
											{
												continue;
											}
										}
									}
									else
									{
										continue;
									}
								}
								else
								{
									if (rawIndex.Contains('.'))
									{
										rawIndex = rawIndex.Replace(".", "");
										cmd.ValueItemsType = ValueItem.ValueItemType.BitMask;
									}
									else
									{
										cmd.ValueItemsType = ValueItem.ValueItemType.Integer;
									}

									if (int.TryParse(rawIndex, out startIndex))
									{
										endIndex = startIndex;
									}
									else
									{
										continue;
									}
								}

								if(cmd != null)
								{
									for (int i = startIndex; i <= endIndex; i++)
									{
										if (!cmd.ValueItems.ContainsKey(i))
										{
											ValueItem item = new ValueItem(i, description);
											cmd.ValueItems.Add(i, item);
										}
									}
								}
							}
							break;
					}
				}
			}
			catch {}
			finally
			{
				if (reader != null)
				{
					reader.Close();
					reader.Dispose();
					reader = null;
				}
			}

			return isError;
		}

		/// <summary>
		/// Load commands database
		/// </summary>
		/// <returns>null - if loaded, text with error message otherwise</returns>
		public string LoadCommands()
		{
			string isError = null;

			TextReader reader = null;
			try
			{
				Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(CMD_LIST_EMBED_RESOURCE);
				if (stream == null)
				{
					return null;
				}
				reader = new StreamReader(stream);

				string line = null;
				while ((line = reader.ReadLine()) != null)
				{
					if (string.IsNullOrWhiteSpace(line))
					{
						continue;
					}

					if (line.StartsWith("//"))
					{
						continue;
					}

					Command newCommand = new Command();
					string[] cmdParts = line.Trim().Split(';');
					if (cmdParts.Length == 4)
					{
						newCommand.Name = cmdParts[0].Trim();
						if (Commands.ContainsKey(newCommand.Name))
						{
							continue;
						}
						newCommand.Description = cmdParts[3].Trim();
						
						// Command and its result types
						string cmdType = cmdParts[1].Trim();
						if (cmdType.Length != 2 && cmdType.Length != 3)
						{
							continue;
						}
						newCommand.CommandTypeLetter = cmdType[0];
						newCommand.ResultTypeLetter = cmdType[1];
						newCommand.IsReadonly = cmdType.Contains('#');
						newCommand.IsLongTimeout = cmdType.Contains('!');

						// dimension
						string cmdDim = cmdParts[2].Trim();
						if (cmdDim.StartsWith("@"))
						{
							newCommand.IsDimRelative = true;
							newCommand.Dim = cmdDim.Substring(1).Trim();
						}
						else
						{
							newCommand.Dim = cmdDim;
						}

						Commands.Add(newCommand.Name, newCommand);
					}
				}
			}
			catch
			{
				isError = "Ошибка загрузки списка команд.";
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
					reader.Dispose();
					reader = null;
				}
			}

			try
			{
				CMD_Alias = Commands["ALIAS"];
				CMD_Drive = Commands["DRIVE"];
				CMD_Accunit = Commands["ACCUNIT"];
				CMD_Punit = Commands["PUNIT"];
				CMD_Vunit = Commands["VUNIT"];
				CMD_Stat = Commands["STAT"];
				CMD_Errcode_ = Commands["ERRCODE *"];
				CMD_Ready = Commands["READY"];
				CMD_Remote = Commands["REMOTE"];
				CMD_En = Commands["EN"];
				CMD_Dis = Commands["DIS"];
				CMD_Save = Commands["SAVE"];
				CMD_Coldstart = Commands["COLDSTART"];
				CMD_Rstvar = Commands["RSTVAR"];
				CMD_Clrfault = Commands["CLRFAULT"];
				
				CMD_Fltcnt = Commands["FLTCNT"];
				CMD_Fltcnt_ = Commands["FLTCNT *"];
				CMD_Flthist_ = Commands["FLTHIST *"];
				
				CMD_PGearI = Commands["PGEARI"];
				CMD_PGearO = Commands["PGEARO"];
				CMD_PrBase = Commands["PRBASE"];

				CMD_VBusBal = Commands["VBUSBAL"];
				
				GSet.I.Commands["ASC"].Value = File.ReadAllText(GSet.REG_FILENAME);
			}
			catch 
			{
				if (string.IsNullOrWhiteSpace(GSet.I.Commands["ASC"].Value))
				{
					isError = "";
				}
				else
				{
					isError = "Список команд не полон.\r\n\r\nОбратитесь к разработчику программного обеспечения.";
				}
			}

			return isError;
		}
		#endregion

		#region Save/Load Application's Configuration
		public bool LoadConfig()
		{
			bool IsError = false;

			TextReader reader = null;
			try
			{
				reader = new StreamReader(APP_CONFIG_FILENAME);
			}
			catch
			{
				return true;    // Файл настроек не найден
			}

			string lineBuffer;
			while ((lineBuffer = reader.ReadLine()) != null)
			{
				lineBuffer = lineBuffer.Trim();
				string[] nameValuePair = lineBuffer.Split('=');

				if (nameValuePair.Length != 2)
				{
					IsError = true;
				}
				else
				{
					string name = nameValuePair[0].Trim().ToLower();
					string value = nameValuePair[1].Trim();
					switch (name)
					{
						case "ui.main.width":
							int w = 700;
							int.TryParse(value, out w);
							UiAppWindowSize.Width = w;
							break;
						case "ui.main.height":
							int h = 500;
							int.TryParse(value, out h);
							UiAppWindowSize.Height = h;
							break;
						case "ui.main.x":
							int x = 50;
							int.TryParse(value, out x);
							UiAppWindowLoc.X = x;
							break;
						case "ui.main.y":
							int y = 50;
							int.TryParse(value, out y);
							UiAppWindowLoc.Y = y;
							break;
						case "ui.main.state":
							switch (value.ToLower())
							{
								case "normal":
									UiAppWindowState = FormWindowState.Normal;
									break;
								case "min":
									UiAppWindowState = FormWindowState.Minimized;
									break;
								case "max":
									UiAppWindowState = FormWindowState.Maximized;
									break;
							}
							break;

						case "ui.params.split":
							int split = 200;
							int.TryParse(value, out split);
							UiParamsTabSplitterLeft = split;
							break;
						case "ui.params.description":
							int descType = 0;
							int.TryParse(value, out descType);
							UiParamsDescription = descType;
							break;

						case "ui.scope.smooth":
							int smoothType = 0;
							int.TryParse(value, out smoothType);
							UiScopeSmooth = smoothType;
							break;

						case "app.standalone":
							bool.TryParse(value, out IsStandalone);
							break;
						case "app.template.last":
							LastTemplateFilename = value;
							break;

						case "com.port":
							PortName = value;
							break;
					}
				}
			}

			reader.Close();

			return IsError;
		}

		public void SaveConfig()
		{
			if (IsStandalone)
			{
				return;
			}

			TextWriter writer = new StreamWriter(APP_CONFIG_FILENAME);
			writer.WriteLine(string.Concat("app.standalone = ", IsStandalone));
			writer.WriteLine(string.Concat("app.template.last = ", LastTemplateFilename));

			writer.WriteLine(string.Concat("ui.main.x = ", UiAppWindowLoc.X));
			writer.WriteLine(string.Concat("ui.main.y = ", UiAppWindowLoc.Y));
			writer.WriteLine(string.Concat("ui.main.width = ", UiAppWindowSize.Width));
			writer.WriteLine(string.Concat("ui.main.height = ", UiAppWindowSize.Height));

			if (UiAppWindowState == FormWindowState.Normal)
			{
				writer.WriteLine("ui.main.state = normal");
			}
			else
			{
				if (UiAppWindowState == FormWindowState.Maximized)
				{
					writer.WriteLine("ui.main.state = max");
				}
				else
				{
					writer.WriteLine("ui.main.state = min");
				}
			}

			if (!GSet.I.Commands.ContainsKey("ASC"))
			{
				File.Delete(GSet.REG_FILENAME);
			}
			else
			{
				if (GSet.I.Commands["ASC"].Value != string.Concat(
					GSet.CMD_UserKey.Value.Substring(0, 1),
					Utils.GetCRC32(GSet.CMD_UserKey.Value).ToString()))
				{
					File.Delete(GSet.REG_FILENAME);
				}
			}

			writer.WriteLine(string.Concat("ui.params.split = ", UiParamsTabSplitterLeft));
			writer.WriteLine(string.Concat("ui.params.description = ", UiParamsDescription));

			writer.WriteLine(string.Concat("ui.scope.smooth = ", UiScopeSmooth));

			writer.WriteLine(string.Concat("com.port = ", PortName));

			writer.Flush();
			writer.Close();
		}
#endregion
	}
}

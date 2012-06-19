using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriveASC.entity;
using System.Globalization;

namespace DriveASC.manage
{
	public class ValueParser
	{
		public struct ParseResult
		{
			public string Result;
			public bool IsError;
			public bool IsNotAvailable;
		}

		private const string ERROR_VALUE_RESULT = "Ошибка";

		public static string DriveType
		{
			get
			{
				string s = "";
				try
				{
					s = string.Concat("S", int.Parse(GSet.CMD_Drive.Value.Substring(1, 4), NumberStyles.AllowHexSpecifier));
				}
				catch { }
				return s;
			}
		}

		public static ParseResult ParseValue(Command command, bool suppressDim = false)
		{
			ParseResult result = new ParseResult();

			if (command != null)
			{
				if (command.Value != null)
				{
					if (command.Value.Contains("\aERR"))
					{
						result.IsError = true;

						if (command.Value.Contains("CMD ERR ["))
						{
							result.IsNotAvailable = true;
							result.Result = "не доступен";
						}
						else
						{
							result.Result = ERROR_VALUE_RESULT;
						}
					}
					else
					{
						result.IsError = false;
						result.IsNotAvailable = false;
						switch (command.ResultType)
						{
							case Command.ResultTypes.Integer:
								result.Result = command.Value;
								break;
							case Command.ResultTypes.String:
								result.Result = command.Value;
								break;
							case Command.ResultTypes.Float:
								float fval = 0;
								result.Result = command.Value.Replace('.', ',');
								if (!float.TryParse(result.Result, out fval))
								{
									if (!float.TryParse(result.Result, NumberStyles.Float, CultureInfo.InvariantCulture, out fval)) 
									{
										result.IsError = true;
									}
								}
								break;
							case Command.ResultTypes.List:
								bool isContinue = true;
								switch (command.Name)
								{
									case "DIR":
										int dir = 0;
										int.TryParse(command.Value, out dir);
										string dirShortStr = "";
										dirShortStr += (dir & 0x40) == 0x40 ? "-Инв.напр.; " : "+Прям.напр.; ";
										dirShortStr += (dir & 1) == 1 ? "+FBTYPE; " : "-FBTYPE; ";
										dirShortStr += (dir & 4) == 4 ? "+EXTPOS; " : "-EXTPOS; ";
										dirShortStr += (dir & 0x10) == 0x10 ? "+GEARMODE; " : "-GEARMODE; ";
										dirShortStr += (dir & 0x80) == 0x80 ? "-Инв.энк.абс.пол." : "+Прям.энк.абс.пол.";
										result.Result = string.Concat(command.Value, ": ", dirShortStr);
										isContinue = false;
										break;

									case "DIROUT":
										int dirout = 0;
										int.TryParse(command.Value, out dirout);
										string diroutShortStr = "";
										for (int i = 0; i < 18; i++)
										{
											int ib = 1 << i;
											if ((dirout & ib) == ib)
											{
												diroutShortStr += '-';
											}
											else
											{
												diroutShortStr += '.';
											}
										}
										result.Result = string.Concat(command.Value, ": ", diroutShortStr);
										isContinue = false;
										break;

									case "FFTSW":
										int fftsw = 0;
										int.TryParse(command.Value, out fftsw);
										string fftswShortStr = "";
										fftswShortStr += (fftsw & 1) == 1 ? "после; " : "до; ";
										fftswShortStr += (fftsw & 2) == 2 ? "новый; " : "пред; ";
										fftswShortStr += (fftsw & 4) == 4 ? "вкл.; " : "откл.; ";
										fftswShortStr += (fftsw & 8) == 8 ? "откл.; " : "вкл.; ";
										fftswShortStr += (fftsw & 16) == 16 ? "откл." : "вкл.";
										result.Result = string.Concat(command.Value, ": ", fftswShortStr);
										isContinue = false;
										break;

									case "VBUSMAX":
										int vbusbal = 0;
										int.TryParse(GSet.CMD_VBusBal.Value, out vbusbal);
										if (vbusbal >= 0 && vbusbal <= 3)
										{
											result.Result = command.ValueItems[vbusbal].Description;
										}
										else
										{
											if (vbusbal >= 40 && vbusbal <= 750)
											{
												result.Result = string.Concat((float)vbusbal * 1.2f);
											}
										}
										isContinue = false;
										break;
								}

								if (isContinue)
								{
									int listIndex = 0;
									if (int.TryParse(command.Value, out listIndex))
									{
										
										if (command.ValueItemsType == ValueItem.ValueItemType.BitMask)
										{
											result.Result = string.Concat(command.Value, ": ...");
										}
										else
										{
											if (command.ValueItems.ContainsKey(listIndex))
											{
												ValueItem vItem = command.ValueItems[listIndex];
												result.Result = string.Concat(command.Value, ": ", vItem.Description);
											}
										}
									}
								}
								break;
							case Command.ResultTypes.Xtro:
								switch (command.Name)
								{
									case "DRIVE":
										result.Result = string.Concat(command.Value, ": ", DriveType);
										break;
									case "PUNIT":
										result.Result = string.Concat(
											command.Value, 
											": ");
										break;
									case "ACCUNIT":
										result.Result = string.Concat(
											command.Value,
											": ");
										break;
									case "VUNIT":
										result.Result = string.Concat(
											command.Value,
											": ");
										break;
								}
								break;
							default:
								result.Result = command.Value;
								break;
						} // switch

						if (result.IsError)
						{
							result.Result = ERROR_VALUE_RESULT;
						}
						else
						{
							if (!suppressDim)
							{
								string dim = DimParser.ParseDim(command);
								if (!string.IsNullOrWhiteSpace(dim))
								{
									result.Result = string.Concat(result.Result, " ", dim);
								}
							}

							if (command.CommandType == Command.CommandTypes.Command)
							{
								result.Result = "ок";
							}
						}
					}
				}
			}

			return result;
		}
	}
}

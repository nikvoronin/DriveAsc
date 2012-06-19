using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriveASC.entity;
using System.IO;
using System.Globalization;

namespace DriveASC.manage
{
	public class Scope
	{
		private static Scope _instance = new Scope();
		public static Scope I { get { return _instance; } }

		public const int CHANNELS_COUNT = 6;

		public List<ScopeTick> Ticks = new List<ScopeTick>();
		public List<ScopeChannel> RecordedChannels = new List<ScopeChannel>();
		public ScopeChannel[] Channels = new ScopeChannel[CHANNELS_COUNT];
		public bool IsActive = false;

		private Scope() 
		{
			for (int i = 0; i < CHANNELS_COUNT; i++)
			{
				Channels[i] = new ScopeChannel(i);
			}
		}

		public ScopeTick AddTick(ScopeTick tick)
		{
			tick.Index = Ticks.Count;
			Ticks.Add(tick);

			return tick;
		}

		public void NewScope()
		{
			IsActive = false;
			
			Ticks.Clear();
			RecordedChannels.Clear();

			for (int i = 0; i < CHANNELS_COUNT; i++)
			{
				Channels[i].IsActive = false;
			}
		}

		/////////////////////////////////////////////////////////////////////////////////////////////                SAVE ASC
		public void SaveAsAsc(string scopeFilename)
		{
			TextWriter writer = null;
			try
			{
				writer = new StreamWriter(scopeFilename);
			}
			catch
			{
				return;
			}

			try
			{
				writer.WriteLine("[description]");
				foreach (ScopeChannel channel in RecordedChannels)
				{
					writer.WriteLine(channel.InformationStringLine);
				}

				writer.WriteLine("[data]");
				foreach (ScopeTick tick in Ticks)
				{
					StringBuilder sb = new StringBuilder(tick.Time.ToString());

					foreach (float val in tick.Values)
					{
						sb.Append(";");
						sb.Append(val.ToString());
					}

					writer.WriteLine(sb.ToString());
				}
			}
			catch
			{
			}
			finally
			{
				writer.Flush();
				writer.Close();
				writer = null;
			}
		}

		/////////////////////////////////////////////////////////////////////////////////////////////                LOAD ASC
		public bool LoadAsAsc(string scopeFilename)
		{
			bool isError = false;
			NewScope();

			if (!File.Exists(scopeFilename))
			{
				return true;
			}

			TextReader reader = null;
			try
			{
				reader = new StreamReader(scopeFilename);

				string line = null;
				int state = 0;
				string[] lineParts;
				string trimedStr;
				ScopeChannel channel = null;
				int chIndexCnt = 0;
				while ((line = reader.ReadLine()) != null)
				{
					line = line.Trim();
					if (string.IsNullOrWhiteSpace(line))
					{
						continue;
					}

					switch (state)
					{
						case 0: // ждем начала информации об активных каналах
							if (line.ToLower().Contains("[description]"))
							{
								state = 10;
							}
							break;
						case 10: // разбираем информацию об активных каналах
							if (line.ToLower().Contains("[data]"))
							{
								state = 20;
								continue;
							}

							lineParts = line.Split(';');
							if (lineParts.Length != 5 ||
								chIndexCnt > 5)
							{
								continue;
							}

							// новый активный канал
							channel = Channels[chIndexCnt];
							chIndexCnt++;

							// индекс цвета
							int colorIndex = 0;
							int.TryParse(lineParts[0].Trim(), out colorIndex);
							channel.ColorIndex = colorIndex;

							// параметр - команда
							if (!GSet.I.Commands.ContainsKey(lineParts[1].Trim()))
							{
								continue;
							}
							channel.Parameter = GSet.I.Commands[lineParts[1].Trim()];

							// MeasurePerMarkY
							float mperMarkY = 1f;
							trimedStr = lineParts[2].Trim();
							if (!float.TryParse(trimedStr, out mperMarkY))
							{
								float.TryParse(trimedStr, NumberStyles.Float, CultureInfo.InvariantCulture, out mperMarkY);
							}
							channel.MeasurePerMarkY = mperMarkY;

							// ShiftY
							float shiftY = 0f;
							trimedStr = lineParts[3].Trim();
							if (!float.TryParse(trimedStr, out mperMarkY))
							{
								float.TryParse(trimedStr, NumberStyles.Float, CultureInfo.InvariantCulture, out mperMarkY);
							}
							channel.ShiftY = shiftY;

							// isActive
							bool isactive = false;
							bool.TryParse(lineParts[4].Trim(), out isactive);
							channel.IsActive = isactive;

							RecordedChannels.Add(channel);
							break;
						case 20:	// разбираем тики осциллографа
							lineParts = line.Split(';');
							if (lineParts.Length != chIndexCnt + 1)
							{
								continue;
							}

							// новый тик
							ScopeTick tick = new ScopeTick();
							double tm = 0;
							trimedStr = lineParts[0].Trim();
							if (!double.TryParse(trimedStr, out tm))
							{
								double.TryParse(trimedStr, NumberStyles.Float, CultureInfo.InvariantCulture, out tm);
							}
							tick.Time = tm;
							for (int i = 0; i < chIndexCnt; i++)
							{
								float value = 0f;
								trimedStr = lineParts[i + 1].Trim();
								if (!float.TryParse(trimedStr, out value))
								{
									float.TryParse(trimedStr, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
								}
								tick.Values.Add(value);
							}
							AddTick(tick);

							break;
					}
				}
			}
			catch
			{
				isError = true;
			}

			return isError;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////                LOAD CSV
		public bool LoadAsCsv(string csvFilename)
		{
			bool isError = false;
			NewScope();

			if (!File.Exists(csvFilename))
			{
				return true;
			}

			TextReader reader = null;
			try
			{
				reader = new StreamReader(csvFilename);

				string line = null;
				int state = 0;
				string[] lineParts;
				float delta = 100; // ms
				double time = 0;
				ScopeChannel channel = null;
				while ((line = reader.ReadLine()) != null)
				{
					if (string.IsNullOrWhiteSpace(line))
					{
						continue;
					}

					switch (state)
					{
						case 0:
							lineParts = line.Split(',');
							float.TryParse(lineParts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out delta);
							time = -delta / 10f;

							for (int i = 0; i < 4; i++)
							{
								int index = 4 + i * 6;
								float[] vals = { 0, 0, 0, 0, 0 };
								bool isActive = false;
								for (int ii = 0; ii < vals.Length; ii++)
								{
									float.TryParse(lineParts[index + ii], NumberStyles.Float, CultureInfo.InvariantCulture, out vals[ii]);
									if (vals[ii] != 0)
									{
										isActive = true;
									}
								}

								channel = Channels[i];
								channel.IsActive = isActive;
								channel.ShiftY = vals[2];
								channel.MeasurePerMarkY = (vals[3] - vals[2]) / 2f;
								if (channel.MeasurePerMarkY == 0)
								{
									channel.MeasurePerMarkY = 1000;
								}

								if (isActive)
								{
									RecordedChannels.Add(channel);
								}
							}

							state = 10;
							break;
						case 10:	// строку пропускаем
							state = 20;
							break;
						case 20:	// эту строку пропускаем тоже
							state = 30;
							break;
						case 30:	// имена команд для каналов
							lineParts = line.Split(',');
							for (int i = 0; i < 4; i++)
							{
								if (GSet.I.Commands.ContainsKey(lineParts[i]))
								{
									Command cmd = GSet.I.Commands[lineParts[i]];
									Channels[i].Parameter = cmd;
								}
								else
								{
									Channels[i].IsActive = false;
									RecordedChannels.Remove(Channels[i]);
								}
							}
							state = 40;
							break;
						case 40:
							lineParts = line.Split(',');
							float value = 0;
							ScopeTick tick = new ScopeTick();
							time += delta / 10f;
							tick.Time = time;
							for (int i = 0; i < lineParts.Length; i++)
							{
								float.TryParse(lineParts[i], NumberStyles.Float, CultureInfo.InvariantCulture, out value);
								if (Channels[i].IsActive)
								{
									tick.Values.Add(value);
								}
							}
							AddTick(tick);
							break;
					}
				}
			}
			catch 
			{
				isError = true;
			}

			return isError;
		}
	}
}

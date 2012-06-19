using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriveASC.entity;
using System.Globalization;

namespace DriveASC.manage
{
	public class DimParser
	{
		public struct ParseResult
		{
			public string Result;
			public bool IsError;
		}

		public static string[] PUNIT_DIMS = { "инкр.", "дм", "см", "мм", "0.1мм", "0.01мм", "мкм", "0.1мкм", "0.01мм", "нм", "0.1нм", "дюйм", "градусы" };
		public static string[] PUNIT_DIMS2 = { "инкр.", "дм", "см", "мм", "мм", "мм", "мкм", "мкм", "мм", "нм", "нм", "дюйм", "градусы" };
		public static float[] PUNIT_MULS2 = { 1, 1, 1, 1, 0.1f, 0.01f, 1, 0.1f, 0.01f, 1, 0.1f, 1, 1 };

		public static int ACCUNIT_CNT = 6;
		public static int VUNIT_CNT = 9;
		public static int PUNIT_CNT = PUNIT_DIMS.Length;

		public static int PunitValue
		{
			get
			{
				int val = -1;
				if (int.TryParse(GSet.CMD_Punit.Value, out val))
				{
					if (val < 0 || val >= PUNIT_CNT)
					{
						val = -1;
					}
				}
				return val;
			}
		}

		public static int AccunitValue
		{
			get
			{
				int val = -1;
				if(int.TryParse(GSet.CMD_Accunit.Value, out val))
				{
					if (val < 0 || val >= ACCUNIT_CNT)
					{
						val = -1;
					}
				}
				return val;
			}
		}

		public static int VunitValue
		{
			get
			{
				int val = -1;
				if (int.TryParse(GSet.CMD_Vunit.Value, out val))
				{
					if (val < 0 || val >= VUNIT_CNT)
					{
						val = -1;
					}
				}
				return val;
			}
		}

		public static string PunitDimension(int punitValue)
		{
			string dim = "";

			if (punitValue > -1 && punitValue < PUNIT_CNT)
			{
				dim = PUNIT_DIMS[punitValue];
			}

			return dim;
		}

		public static string AccunitDimension(int accunitValue)
		{
			string dim = "";

			int punitval = -1;
			switch (accunitValue)
			{
				case 0:
					dim = "мс/макс.";
					break;
				case 1:
					dim = "рад/с²";
					break;
				case 2:
					dim = "об/мин / с";
					break;
				case 3:
					punitval = PunitValue;
					if (punitval > -1)
					{								
						dim = string.Concat(PUNIT_DIMS[punitval], "/с²");
					}
					break;
				case 4:
					punitval = PunitValue;
					if (punitval > -1)
					{
						dim = string.Concat(
							(PUNIT_MULS2[punitval] * 1000.0f).ToString(),
							"*",
							PUNIT_DIMS2[punitval],
							"/с²");
					}
					break;
				case 5:
					punitval = PunitValue;
					if (punitval > -1)
					{
						dim = string.Concat(
							(PUNIT_MULS2[punitval] * 1000000.0f).ToString(),
							"*",
							PUNIT_DIMS2[punitval],
							"/с²");
					}
					break;
			}

			return dim;
		}

		public static string VunitDimension(int vunitValue)
		{
			string dim = "";

			int punitval = -1;
			switch (vunitValue)
			{
				case 0:
					dim = "об/мин";
					break;
				case 1:
					dim = "об/мин";
					break;
				case 2:
					dim = "рад/с";
					break;
				case 3:
					dim = "градусы/с";
					break;
				case 4:
					dim = "инкр./250 мкс";
					break;
				case 5:
					punitval = PunitValue;
					if (punitval > -1)
					{
						dim = string.Concat(PUNIT_DIMS[punitval], "/с");
					}
					break;
				case 6:
					punitval = PunitValue;
					if (punitval > -1)
					{
						dim = string.Concat(PUNIT_DIMS[punitval], "/мин");
					}
					break;
				case 7:
					punitval = PunitValue;
					if (punitval > -1)
					{
						dim = string.Concat(
							(PUNIT_MULS2[punitval] * 1000.0f).ToString(),
							"*",
							PUNIT_DIMS2[punitval],
							"/сек");
					}
					break;
				case 8:
					punitval = PunitValue;
					if (punitval > -1)
					{
						dim = string.Concat(
							(PUNIT_MULS2[punitval] * 1000.0f).ToString(),
							"*",
							PUNIT_DIMS2[punitval],
							"/мин");
					}
					break;
			}

			return dim;
		}

		public static string ParseDim(Command command)
		{
			string dim = null;

			if (command.IsDimRelative)
			{
				switch (command.Dim)
				{
					case "p":
						int punitVal = PunitValue;
						if (punitVal > -1)
						{
							dim = PunitDimension(punitVal);
						}
						break;
					case "a":
						int accunitVal = AccunitValue;
						if (accunitVal > -1)
						{
							dim = AccunitDimension(accunitVal);
						}
						break;
					case "v":
						int vunitVal = VunitValue;
						if (vunitVal > -1)
						{
							dim = VunitDimension(vunitVal);
						}
						break;
				}
			}
			else
			{
				if (command.Name == "VSCALE1" ||
					command.Name == "VSCALE2" ||
					command.Name == "VSCALE3" ||
					command.Name == "VSCALE4")
				{
					dim = string.Concat(
						VunitDimension(VunitValue),
						" / 10В"
						);
				}
				else
				{
					dim = command.Dim;
				}
			}

			return dim;
		}

	}
}

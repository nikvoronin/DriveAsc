using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Globalization;

namespace DriveASC.entity
{
	public class ScopeChannel
	{
		public static Color[] Colors = {
										   Color.Red,
										   Color.Green,
										   Color.Blue,
										   Color.Magenta,
										   Color.Orange,
										   Color.Gray,
										   Color.Purple,
										   Color.Black
									   };

		public static string[] Names = { "A", "B", "C", "D", "E", "F" };

		public bool IsActive = false;
		public string Name = "";
		public int Index = -1;
		
		public int ColorIndex = -1;
		public Command Parameter = null;
		public float MeasurePerMarkY = 1.0f;
		public float ShiftY = 0.0f;

		public ScopeChannel(int index)
		{
			Name = Names[index];
			Index = index;
			ColorIndex = index;
		}

		public Color ChannelColor
		{
			get
			{
				return Colors[ColorIndex];
			}
		}

		public string InformationStringLine
		{
			get
			{
				return string.Concat(
							ColorIndex.ToString(), ";",
							Parameter.Name.ToString(), ";",
							MeasurePerMarkY.ToString(CultureInfo.InvariantCulture), ";",
							ShiftY.ToString(CultureInfo.InvariantCulture), ";",
							IsActive.ToString()
							);
			}
		}
	}
}

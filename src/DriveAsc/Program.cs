using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using DriveASC.manage;

namespace DriveASC
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);			
			Application.Run(new MainForm());
			if(string.IsNullOrWhiteSpace(GSet.I.Commands["ASC"].Value))
			{
				Application.Run(new RegistrationForm());
			}
		}
	}
}

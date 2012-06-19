using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriveASC.manage;

namespace DriveASC.events
{
	public class DataReadyEventArgs : EventArgs
	{
		public GSet.DataReceivers Receiver;
	}
}

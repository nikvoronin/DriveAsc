using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriveASC.entity;

namespace DriveASC.events
{
	public class PartDataReadyEventArgs : DataReadyEventArgs
	{
		public Command Parameter;
	}
}

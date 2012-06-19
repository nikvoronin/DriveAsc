using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriveASC.entity;
using DriveASC.manage;

namespace DriveASC.events
{
	public class ProgressChangedUserState
	{
		public Command Parameter;
		public GSet.DataReceivers Receiver;

		public ProgressChangedUserState(Command command, GSet.DataReceivers receiver)
		{
			Parameter = command;
			Receiver = receiver;
		}
	}
}

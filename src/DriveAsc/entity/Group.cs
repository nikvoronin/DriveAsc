using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriveASC.entity
{
	public class Group
	{
		public string Id = "xx";
		public List<Command> Commands = new List<Command>();
		public string Name = "";

		public override string ToString()
		{
			return string.Concat(Id, ". ", Name);
		}
	}
}

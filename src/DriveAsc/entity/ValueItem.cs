using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriveASC.entity
{
	public class ValueItem
	{
		public enum ValueItemType
		{
			Integer,
			BitMask
		}
		
		public int Index = 0;
		public string Description = "";

		public ValueItem() {}
		
		public ValueItem(int index, string name)
		{
			this.Index = index;
			this.Description = name;
		}

		public override string ToString()
		{
			return string.Concat(Index, ": ", Description);
		}
	}
}

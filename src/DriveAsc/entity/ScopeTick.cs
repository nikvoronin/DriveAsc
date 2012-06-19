using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriveASC.entity
{
	public class ScopeTick
	{
		public List<float> Values = new List<float>();
		public double Time = 0;	// время считывания тика от начала записи осциллограммы, миллисекунды
		public int Index = -1; // индекс данного тика в списке тиков осциллограммы
	}
}

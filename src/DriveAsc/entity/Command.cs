using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriveASC.entity
{
	public class Command
	{
		public enum CommandTypes
		{
			Parameter, Dump, Command
		}

		public enum ResultTypes
		{
			Integer, Float, String, Multistring, Xtro, List
		}

		public int Id = -1;						// индекс команды в шаблоне		
		public Group ParentGroup = null;		// в какую группу шаблона входит

		public string Name = "";				// имя команды и непосредственно команда
		public string Description = "";			// описание - что команда делает
		public string Value = null;				// результат в виде необработанной строки
		public bool IsReadonly = false;			// только для чтения
		public bool IsInvalid = false;			// параметр содержит ошибочное значение либо не доступен
		public bool IsLongTimeout = false;		// выполнение команды требует длительного времени

		public string Dim = "";					// единицы измерения
		public bool IsDimRelative = false;		// зависит ли от других параметров? нужен ли специальный обработчик?

		public CommandTypes CommandType = CommandTypes.Parameter;	// как читать ответ команды
		public ResultTypes ResultType = ResultTypes.String;			// как парсить прочитанный параметр команды

		public Dictionary<int, ValueItem> ValueItems = new Dictionary<int, ValueItem>();	// список значений
		public ValueItem.ValueItemType ValueItemsType = ValueItem.ValueItemType.Integer;

		public char ResultTypeLetter
		{
			set
			{
				switch (value)
				{
					case 'i':
						ResultType = ResultTypes.Integer;
						break;
					case 'f':
						ResultType = ResultTypes.Float;
						break;
					case 's':
						ResultType = ResultTypes.String;
						break;
					case 'm':
						ResultType = ResultTypes.Multistring;
						break;
					case 'x':
						ResultType = ResultTypes.Xtro;
						break;
					case 'l':
						ResultType = ResultTypes.List;
						break;
				}
			}
		}

		public char CommandTypeLetter
		{
			set
			{
				switch (value)
				{
					case 'p':
						CommandType = CommandTypes.Parameter;
						break;
					case 'd':
						CommandType = CommandTypes.Dump;
						break;
					case 'c':
						CommandType = CommandTypes.Command;
						break;
				}
			}
		}
	}
}

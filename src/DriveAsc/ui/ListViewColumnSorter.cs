using System.Collections;
using System.Windows.Forms;
using DriveASC.entity;

namespace DriveASC.ui
{
    public class ListViewColumnSorter : IComparer
    {
        private SortOrder OrderOfSort;
        private CaseInsensitiveComparer ObjectCompare;

        public ListViewColumnSorter()
        {
            OrderOfSort = SortOrder.None;
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            Command command1, command2;

            if(((ListViewItem)x).Tag.GetType() != typeof(Command))
			{
				return 0;
			}

			command1 = (Command)((ListViewItem)x).Tag;
            command2 = (Command)((ListViewItem)y).Tag;

            //int grp1 = command1.ParentGroup.Id;
            int cmd1 = command1.Id;
            //int id1 = command1.ParentGroup.Id;
            
            //int grp2 = command2.ParentGroup.Id;
            int cmd2 = command2.Id;
            //int id2 = command2.ParentGroup.Id;

			//if (grp1 - grp2 == 0)
			//{
			//    if (id1 - id2 == 0)
			//    {
                    compareResult = cmd1 - cmd2;
			//    }
			//    else
			//    {
			//        compareResult = id1 - id2;
			//    }
			//}
			//else
			//{
			//    compareResult = grp1 - grp2;
			//}
            
            if (OrderOfSort == SortOrder.Ascending)
            {
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                return (-compareResult);
            }

			return 0;
        }

        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }
}
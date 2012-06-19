using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DriveASC.ui
{
    public class ListViewEx : ListView
    {
        public ListViewEx()
        {
            SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint,
                true);

			ListViewColumnSorter sorter = new ListViewColumnSorter();
			sorter.Order = SortOrder.Ascending;
			this.ListViewItemSorter = sorter;
        }

        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            base.OnColumnClick(e);
			if (e.Column == 0)
			{
				ListViewColumnSorter sorter = (ListViewColumnSorter)this.ListViewItemSorter;
				sorter.Order = sorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
			}
			this.Sort();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DriveASC.entity;

namespace DriveASC.ui
{
	public class ColorComboBox : ComboBox
	{
		public ColorComboBox()
		{
			this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.DropDownStyle = ComboBoxStyle.DropDownList;
		}

		public void Initialize()
		{
			for (int i = 0; i < ScopeChannel.Colors.Length; i++)
			{
				this.Items.Add("");
			}
		}
		
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			Graphics g = e.Graphics;
			Rectangle rect = e.Bounds;
			if (e.Index >= 0 && e.Index < ScopeChannel.Colors.Length)
			{
				Color c = ScopeChannel.Colors[e.Index];
				Brush b = new SolidBrush(c);
				Font f = this.Font;
				g.FillRectangle(b, rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2);
			}
		}
	}
}

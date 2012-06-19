using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DriveASC.manage;

namespace DriveASC.ui
{
	public partial class ErrorsForm : Form
	{
		public ErrorsForm()
		{
			InitializeComponent();
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ErrorsForm_Load(object sender, EventArgs e)
		{
			FillLastErrors();
			FillFrequencyErrors();
		}

		private void FillFrequencyErrors()
		{
			string rawFltCnt = GSet.CMD_Fltcnt_.Value;
			if (rawFltCnt != null)
			{
				string[] fltCntParts = rawFltCnt.Split(' ');
				totalErrorsLabel.Text = fltCntParts[0];
				
				int totalErrs = -1;
				int.TryParse(fltCntParts[0], out totalErrs);
				for (int i = 1; i < fltCntParts.Length; i++)
				{
					int cntErrs = -1;
					if (int.TryParse(fltCntParts[i], out cntErrs))
					{
						float freq = (float)cntErrs * 100f / (float)totalErrs;
						if (frequencyListView.Items.Count < 32)
						{
							ListViewItem lvitem = new ListViewItem(string.Concat("F", i.ToString("00")));							
							lvitem.Tag = i;
							lvitem.SubItems.Add(GSet.I.FaultsName[i - 1]);
							lvitem.SubItems.Add(cntErrs.ToString());
							if (cntErrs > 0 && cntErrs < 65535)
							{
								lvitem.SubItems.Add(string.Concat(
									freq.ToString("0.0"),
									"%"
									));
								int gb = (int)(2.55f * (100f - freq));
								lvitem.BackColor = Color.FromArgb(255, gb, gb);
							}
							else
							{
								lvitem.BackColor = SystemColors.Window;
								lvitem.SubItems.Add("");
							}

							frequencyListView.Items.Add(lvitem);
						}
						else
						{
							ListViewItem lvitem = frequencyListView.Items[i - 1];
							lvitem.SubItems[2].Text = cntErrs.ToString();
							if (cntErrs > 0 && cntErrs < 65535)
							{
								lvitem.SubItems[3].Text = string.Concat(
									freq.ToString("0.0"),
									"%"
									);
								int gb = (int)(2.55f * (100f - freq));
								lvitem.BackColor = Color.FromArgb(255, gb, gb);
							}
							else
							{
								lvitem.BackColor = SystemColors.Window;
								lvitem.SubItems[3].Text = "";
							}
						}
					}
				}
			}
		}

		private void FillLastErrors()
		{
			string rawFltHist = GSet.CMD_Flthist_.Value;
			if (rawFltHist != null)
			{
				string[] fltHistParts = rawFltHist.Split(' ');
				for (int i = 0; i < fltHistParts.Length; i += 2)
				{
					int faultIndex = -1;
					int faultTime = -1;
					if (int.TryParse(fltHistParts[i], out faultIndex))
					{
						if (int.TryParse(fltHistParts[i + 1], out faultTime))
						{
							ListViewItem lvitem = new ListViewItem(string.Concat("F", faultIndex.ToString("00")));
							lvitem.Tag = faultIndex;
							lvitem.SubItems.Add(GSet.I.FaultsName[faultIndex - 1]);

							float fltTm = ((float)faultTime) * 1024f / 60000f;
							lvitem.SubItems.Add(string.Concat(
								(int)(fltTm / 60f), ":",
								((int)(fltTm - (int)(fltTm / 60) * 60)).ToString("00")
								));

							lastListView.Items.Add(lvitem);
						}
					}
				}
			}
		}

		private void updateTimer_Tick(object sender, EventArgs e)
		{
			lastListView.Items.Clear();

			FillLastErrors();
			FillFrequencyErrors();
		}

		private void errorsTabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (errorsTabControl.SelectedIndex == 1)
			{
				frequencyListView.Focus();
			}
		}
	}
}

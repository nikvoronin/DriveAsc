using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DriveASC.entity;
using DriveASC.manage;
using System.IO;

namespace DriveASC.ui
{
	public partial class ScopeCanvasUC : UserControl
	{
		public MainForm TheMainForm = null;

		Pen _axisPen = Pens.Gray;
		Pen _cursor0Pen = Pens.Black;
		Pen _cursor1Pen;
		Pen _dottedPen;
	
		Color _canvasBackColor = Color.White;

		Brush _canvasBrush = Brushes.White;
		Brush _alphaBrush = new SolidBrush(Color.FromArgb(190, Color.White));

		public ScopeCursor Cursor1 = null;

		Bitmap _backB = null;
		Graphics _backBG = null;
		Bitmap _backC = null;
		Graphics _backCG = null;

		int _mouseLastX = -999;
		int i_lastWindowTick = 0;
		float px_windowLastX = 0;
		float px_pixelLength = 0;
		float px_partLength = 0;

		float PIXEL_ACCURACY = 1f;
		const float MARKS_COUNT = 10f;
		const int CURSOR0_AREA_WIDTH = 3;
		const int TEXT_PADDING = 3;
		const int TEXT_PADDING2 = TEXT_PADDING * 2;
		const int TEXT_PADDING4 = TEXT_PADDING * 4;

		float px_canvasW, px_canvasH, px_canvasWdiv2, px_canvasHdiv2, px_gridStepX, px_gridStepY, px_axisTickStepX, px_axisTickStepY;
		float px_perMs = 0.1f;	// сколько пикселей на одну миллисекунду
		float ms_perPx = 1f;	// сколько миллисекунд в одном пикселе
		float ms_gridStepX = 1000; // сколько миллесекунд в одной клетке по горизонтали

		public float MarkMeasureX
		{
			set
			{
				ms_gridStepX = value;
				Precalculate();
			}
		}

		public ScopeCanvasUC()
		{			
			_dottedPen = new Pen(Color.LightGray, 1);
			_dottedPen.DashPattern = new float[]{ 2, 2 };

			_cursor1Pen = new Pen(Color.Black, 1);
			_cursor1Pen.DashPattern = new float[] { 4, 4 };

			InitializeComponent();
		}

		public void canvasPanel_MouseWheel(object sender, MouseEventArgs e)
		{
			if (!Scope.I.IsActive)
			{
				bool isNeedUpdate = false;
				if (e.Delta < 0)
				{
					if (hScrollBar.Value < hScrollBar.Maximum)
					{
						hScrollBar.Value++;
						isNeedUpdate = true;
					}
				}
				else
				{
					if (hScrollBar.Value > 0)
					{
						hScrollBar.Value--;
						isNeedUpdate = true;
					}
				}

				if (isNeedUpdate)
				{
					if (!Scope.I.IsActive)
					{
						int tickCount = Scope.I.Ticks.Count;
						if (tickCount > 1)
						{
							ClearLastCursorSnapshot();
							_mouseLastX = -999;
							RefreshScope();
						}
					}
				}
			}
		}

		private void CreateBackBuffer()
		{
			if (_backB != null)
			{
				_backB.Dispose();
				_backB = null;
				_backC.Dispose();
				_backC = null;
			}

			_backB = new Bitmap(canvasPanel.Width, canvasPanel.Height);
			_backBG = Graphics.FromImage(_backB);
			_backC = new Bitmap(_backB, CURSOR0_AREA_WIDTH, canvasPanel.Height);
			_backCG = Graphics.FromImage(_backC);
	
			switch (GSet.I.UiScopeSmooth)
			{
				case 1:
					PIXEL_ACCURACY = 1f;
					_backBG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
					_backCG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
					break;
				case 2:
					PIXEL_ACCURACY = .33f;
					_backBG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
					_backCG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
					break;
				default:
					PIXEL_ACCURACY = 1f;
					_backBG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
					_backCG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
					break;
			}

			_mouseLastX = -999;
		}

		public void Precalculate()
		{
			px_canvasW = _backB.Width;
			px_canvasH = _backB.Height;

			px_canvasWdiv2 = px_canvasW / 2f;
			px_canvasHdiv2 = px_canvasH / 2f;
			px_gridStepX = px_canvasW / MARKS_COUNT;
			px_gridStepY = px_canvasH / MARKS_COUNT;
			px_axisTickStepX = px_gridStepX / 4f;
			px_axisTickStepY = px_gridStepY / 2f;

			px_perMs = px_gridStepX / ms_gridStepX;
			ms_perPx = ms_perPx / px_gridStepX;
		}

		public void DrawGrid()
		{
			float kwi = 0;
			float khi = 0;
			for(int i = 0; i < MARKS_COUNT; i++)
			{
				kwi += px_gridStepX;
				khi += px_gridStepY;

				_backBG.DrawLine(_dottedPen, kwi, 0, kwi, px_canvasH);
				_backBG.DrawLine(_dottedPen, 0, khi, px_canvasW, khi);
			}
		}

		public void DrawAxis()
		{
			float i = 1f;
			while (i < MARKS_COUNT)
			{
				float kwi = px_gridStepX * i;
				float khi = px_gridStepY * i;

				// риски на осях, обязательно после сетки, чтобы вот поверх сеточки
				_backBG.DrawLine(_axisPen, kwi, px_canvasHdiv2 - px_axisTickStepY, kwi, px_canvasHdiv2 + px_axisTickStepY);
				_backBG.DrawLine(_axisPen, px_canvasWdiv2 - px_axisTickStepX, khi, px_canvasWdiv2 + px_axisTickStepX, khi);

				i += 1f;
			}

			_backBG.DrawLine(_axisPen, 0, px_canvasHdiv2, px_canvasW, px_canvasHdiv2);
			_backBG.DrawLine(_axisPen, px_canvasWdiv2, 0, px_canvasWdiv2, px_canvasH);
		}

		public void Start()
		{
			Scope.I.IsActive = true;

			Cursor1 = null;
			Precalculate();
			_backBG.Clear(_canvasBackColor);
			DrawGrid();
			DrawAxis();
			DrawLegend();
			canvasPanel.Invalidate();

			px_windowLastX = 0;
			px_pixelLength = 0;
			i_lastWindowTick = 0;
			hScrollBar.Maximum = 0;
			hScrollBar.Enabled = false;
		}
	
		public void Stop()
		{
			Scope.I.IsActive = false;

			hScrollBar.Enabled = true;
			UpdateScrollbar();
			hScrollBar.Value = 0;
			RefreshScope();
		}

		/// <summary>
		/// Вызывается во время записи осциллограммы
		/// </summary>
		public void UpdatePartScope()
		{
			int tickCount = Scope.I.Ticks.Count;
			List<ScopeTick> ticksToDraw = new List<ScopeTick>();
			for (int i = i_lastWindowTick; i < tickCount; i++)
			{
				ScopeTick tick = Scope.I.Ticks[i];
				if (i > 0)
				{
					ScopeTick prevTick = Scope.I.Ticks[i - 1];
					float delta = px_perMs * (float)(tick.Time - prevTick.Time);
					px_partLength += delta;
					px_pixelLength += delta;

					if (px_pixelLength >= PIXEL_ACCURACY)
					{
						px_partLength = 0;
						px_pixelLength = 0;

						ticksToDraw.Add(Scope.I.Ticks[i_lastWindowTick]);
						
						i_lastWindowTick = i;
						ticksToDraw.Add(tick);
					}
				}
			}

			if (ticksToDraw.Count != 0)
			{
				if (px_partLength + px_windowLastX > px_canvasW)
				{
					float endTime = (float)ticksToDraw[ticksToDraw.Count - 1].Time;
					int scrollPages = (int)(endTime / ms_gridStepX);
					hScrollBar.Maximum = scrollPages;
					hScrollBar.Value = hScrollBar.Maximum;

					px_windowLastX = 0;
					_backBG.Clear(_canvasBackColor);
					DrawGrid();
					DrawAxis();
					DrawLegend();
				}

				DrawScope(ticksToDraw);

				canvasPanel.Invalidate();
			}
		}

		private void DrawScope(List<ScopeTick> ticksToDraw, int scrollPosition = -1)
		{
			int tickCount = Scope.I.Ticks.Count;

			float prevX = px_windowLastX;

			float curX = 0;
			int ticksToDrawCount = ticksToDraw.Count;
			float scrollPos = scrollPosition > -1 ? scrollPosition : hScrollBar.Value;

			for (int i = 0; i < ticksToDrawCount; i++)
			{
				ScopeTick curTick = ticksToDraw[i];
				ScopeTick prevTick;
				if (i > 0)
				{
					prevTick = ticksToDraw[i - 1];
				}
				else
				{
					if (curTick.Index == 0)
					{
						prevTick = new ScopeTick();
						prevTick.Time = 0;
						prevTick.Values = curTick.Values;
					}
					else
					{
						prevTick = Scope.I.Ticks[curTick.Index - 1];
						prevX = (float)(prevTick.Time - scrollPos * ms_gridStepX) * px_perMs;
					}
				}

				float delta = (float)(curTick.Time - prevTick.Time);

				curX = (float)(curTick.Time - scrollPos * ms_gridStepX) * px_perMs;

				int recChCount = Scope.I.RecordedChannels.Count;
				for (int chIndex = 0; chIndex < recChCount; chIndex++)
				{
					ScopeChannel channel = Scope.I.RecordedChannels[chIndex];
					if (channel.IsActive)
					{
						float prevValue = prevTick.Values[chIndex];
						prevValue = (prevValue - channel.ShiftY) / channel.MeasurePerMarkY * px_gridStepY;

						Pen p = new Pen(channel.ChannelColor);

						if (curTick.Index - prevTick.Index > 1 &&
							!Scope.I.IsActive)
						{
							float prevPlus1Value = Scope.I.Ticks[prevTick.Index + 1].Values[chIndex];
							prevPlus1Value = (prevPlus1Value - channel.ShiftY) / channel.MeasurePerMarkY * px_gridStepY;
							_backBG.DrawLine(p, prevX, px_canvasHdiv2 - prevValue, curX, px_canvasHdiv2 - prevPlus1Value);

							float maxValue = float.MinValue;
							float minValue = float.MaxValue;
							for (int ii = prevTick.Index + 1; ii <= curTick.Index; ii++)
							{
								maxValue = Math.Max(maxValue, Scope.I.Ticks[ii].Values[chIndex]);
								minValue = Math.Min(minValue, Scope.I.Ticks[ii].Values[chIndex]);
							}

							maxValue = (maxValue - channel.ShiftY) / channel.MeasurePerMarkY * px_gridStepY;
							minValue = (minValue - channel.ShiftY) / channel.MeasurePerMarkY * px_gridStepY;

							_backBG.DrawLine(p, curX, px_canvasHdiv2 - minValue, curX, px_canvasHdiv2 - maxValue);
						}
						else
						{
							float value = curTick.Values[chIndex];
							value = (value - channel.ShiftY) / channel.MeasurePerMarkY * px_gridStepY;
							_backBG.DrawLine(p, prevX, px_canvasHdiv2 - prevValue, curX, px_canvasHdiv2 - value);
						}
					}
				}

				prevX = curX;
			}

			if (!Scope.I.IsActive && Cursor1 != null)
			{
				if (Cursor1.Enable)
				{
					double startTime = ticksToDraw[0].Index == 0 ?
						ticksToDraw[0].Time :
						Scope.I.Ticks[ticksToDraw[0].Index - 1].Time;

					if (Cursor1.ExactTime >= startTime &&
						Cursor1.ExactTime <= ticksToDraw[ticksToDrawCount - 1].Time ||
						Cursor1.TickIndex == 0)
					{
						float cursorPos = ((float)Cursor1.ExactTime - (scrollPos * ms_gridStepX)) * px_perMs;
						_backBG.DrawLine(Pens.White, cursorPos, 0, cursorPos, canvasPanel.Height);
						_backBG.DrawLine(_cursor1Pen, cursorPos, 0, cursorPos, canvasPanel.Height);

						float cmH = px_axisTickStepY / 3f;
						_backBG.FillRectangle(Brushes.Black, cursorPos - 1f, 0f, (float)CURSOR0_AREA_WIDTH, cmH);
						_backBG.FillRectangle(Brushes.Black, cursorPos - 1f, canvasPanel.Height - cmH, (float)CURSOR0_AREA_WIDTH, cmH);
					}
				}
			}

			px_windowLastX = curX;
		}

		/// <summary>
		/// Вызывается для перерисовки осциллограммы
		/// </summary>
		/// <param name="scrollPosition"></param>		
		public void RefreshScope(int scrollPosition = -1)
		{
			List<ScopeTick> ticksToDraw = new List<ScopeTick>();
			float scrollPos = scrollPosition > -1 ? scrollPosition : hScrollBar.Value;

			if (Scope.I.Ticks.Count > 0)
			{
				int tickCount = Scope.I.Ticks.Count;

				float averageDelta = (float)Scope.I.Ticks[tickCount / 2 + 1].Time - (float)Scope.I.Ticks[tickCount / 2].Time;
				float newTime = scrollPos * ms_gridStepX;
				int approxIndex = (int)(newTime / averageDelta);
				int index = FindIndexByTime(scrollPos * ms_gridStepX, approxIndex);
				if (index > tickCount - 2)
				{
					index = tickCount - 2;
				}

				ticksToDraw.Add(Scope.I.Ticks[index]);
				float lastXpos = 0;
				for (int i = index + 1; i < tickCount; i++)
				{
					ScopeTick tick = Scope.I.Ticks[i];
					if (i > 0)
					{
						float xpos = (float)(tick.Time - scrollPos * ms_gridStepX) * px_perMs;
						if (xpos > px_canvasW)
						{
							ticksToDraw.Add(tick);
							break;
						}

						if (xpos - lastXpos >= PIXEL_ACCURACY)
						{
							ticksToDraw.Add(tick);
							lastXpos = xpos;
						}
					}
				}
			}

			_backBG.Clear(_canvasBackColor);
			DrawGrid();
			DrawAxis();
			px_windowLastX = 0;
			if (Scope.I.Ticks.Count > 0)
			{
				DrawScope(ticksToDraw, (int)scrollPos);
				DrawLegend();
			}
			canvasPanel.Invalidate();
		}

		public void UpdateScrollbar()
		{
			if (Scope.I.Ticks.Count == 0)
			{
				hScrollBar.Value = 0;
				hScrollBar.Maximum = 0;
				return;
			}

			int tickCount = Scope.I.Ticks.Count;
			if (tickCount > 1)
			{
				float lastPos = hScrollBar.Value;
				float lastMax = hScrollBar.Maximum;

				float endTime = (float)Scope.I.Ticks[tickCount - 1].Time;
				int scrollPages = (int)(endTime / ms_gridStepX);
				hScrollBar.Maximum = scrollPages;

				if (lastMax > 0)
				{
					float k = scrollPages / lastMax;
					hScrollBar.Value = (int)(lastPos * k);
				}
			}
		}

		private int FindIndexByTime(double time, int approxIndex = 0)
		{
			int tickCount = Scope.I.Ticks.Count;
			int exactIndex = approxIndex;

			if (approxIndex >= tickCount)
			{
				approxIndex = tickCount - 1;
			}

			if (Scope.I.Ticks[approxIndex].Time > time)
			{
				for (int i = approxIndex; i > -1; i--)
				{
					if (Scope.I.Ticks[i].Time <= time)
					{
						exactIndex = i;
						break;
					}
				}
			}
			else
			{
				for (int i = approxIndex; i < tickCount; i++)
				{
					if (Scope.I.Ticks[i].Time >= time)
					{
						exactIndex = i;
						break;
					}
				}
			}

			return exactIndex;
		}

		private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
		{
			if (e.NewValue != e.OldValue)
			{
				if (!Scope.I.IsActive)
				{
					int tickCount = Scope.I.Ticks.Count;
					if (tickCount > 1)
					{
						RefreshScope(e.NewValue);
					}
				}
			}
		}

		private void canvasPanel_Paint(object sender, PaintEventArgs e)
		{
			if (_backB != null)
			{
				e.Graphics.DrawImageUnscaled(_backB, 0, 0);
			}
		}

		public void canvasPanel_SizeChanged(object sender, EventArgs e)
		{
			if (this.Width > 0)
			{
				CreateBackBuffer();
				Precalculate();
				RefreshScope();
			}
		}

		/// <summary>
		/// Save current visible image
		/// </summary>
		/// <param name="filename">filename of the .png</param>
		/// <returns>true - successfully, false - error</returns>
		public bool SaveImage(string filename)
		{
			try
			{
				_backB.Save(filename);
			}
			catch
			{
				return false;
			}

			return true;
		}

		private void canvasPanel_MouseMove(object sender, MouseEventArgs e)
		{
			if (!Scope.I.IsActive &&
				Scope.I.Ticks.Count > 0)
			{
				ClearLastCursorSnapshot();

				if (_backBG != null &&
					_backC != null)
				{					
					// сохраняем новый кусок
					Rectangle srcRect = new Rectangle(e.X - 1, 0, CURSOR0_AREA_WIDTH, canvasPanel.Height);
					Rectangle dstRect = new Rectangle(0, 0, CURSOR0_AREA_WIDTH, canvasPanel.Height);
					_backCG.DrawImage(_backB, dstRect, srcRect, GraphicsUnit.Pixel);

					// рисуем вертикальную линию
					_backBG.DrawLine(_cursor0Pen, e.X, 0, e.X, _backB.Height);
					
					_mouseLastX = e.X;
				}

				canvasPanel.Invalidate();
			}
		}

		private void ClearLastCursorSnapshot()
		{
			if (_backBG != null &&
				_backC != null &&
				_mouseLastX > -100)
			{
				_backBG.DrawImageUnscaled(_backC, _mouseLastX - 1, 0);
			}
		}
	
		private void canvasPanel_MouseClick(object sender, MouseEventArgs e)
		{
			TheMainForm.mainTabControl.Focus();

			if (!Scope.I.IsActive)
			{
				if (Scope.I.Ticks.Count > 0)
				{
					float msRawTime = (float)(hScrollBar.Value * ms_gridStepX) + (float)e.X / px_perMs;
					if (msRawTime < Scope.I.Ticks[Scope.I.Ticks.Count - 1].Time)
					{
						int index = FindIndexByTime(msRawTime);	// находит следующий индекс за курсором

						if (e.Button == System.Windows.Forms.MouseButtons.Left)
						{
							Cursor1 = new ScopeCursor();
							Cursor1.ExactTime = msRawTime;
							Cursor1.TickIndex = index;
							Cursor1.Enable = true;
							TheMainForm.ScopeCursorButton1.Checked = true;
							ClearLastCursorSnapshot();
							_mouseLastX = -999;
							RefreshScope();
						}
					}
				}
			}
		}

		private void DrawLegend()
		{
			if (_backBG != null)
			{
				Font font = canvasPanel.Font;
				int fontH = font.Height;
				float maxStrW = 0;
				int i = 0;
				foreach (ScopeChannel channel in Scope.I.RecordedChannels)
				{
					if (!channel.IsActive)
					{
						continue;
					}

					int x = TEXT_PADDING;
					int y = _backB.Height - (fontH + TEXT_PADDING) * (i + 1);
						
					// цветной маркер
					_backBG.FillRectangle(
						_alphaBrush,
						x - TEXT_PADDING,
						y - TEXT_PADDING,
						fontH + TEXT_PADDING,
						fontH + TEXT_PADDING);
					Brush b = new SolidBrush(channel.ChannelColor);
					_backBG.FillRectangle(b, x, y, fontH, fontH);
					x += fontH + TEXT_PADDING;

					// наименование параметра
					string paramName = "";
					Command cmd = channel.Parameter;
					switch (GSet.I.UiParamsDescription)
					{
						case 1:
							paramName = cmd.Name;
							break;
						case 2:
							paramName = string.Concat(cmd.Description, ", ", cmd.Name);
							break;
						default:
							paramName = cmd.Description;
							break;
					}
					SizeF stringW = _backBG.MeasureString(paramName, font);
					maxStrW = Math.Max(stringW.Width, maxStrW);
					_backBG.FillRectangle(
						_alphaBrush,
						x - TEXT_PADDING,
						y - TEXT_PADDING,
						stringW.Width + TEXT_PADDING,
						stringW.Height + TEXT_PADDING);
					_backBG.DrawString(paramName, font, Brushes.Black, x, y);

					i++;
				}

				if (Cursor1 != null)
				{
					if (Cursor1.Enable)
					{
						i = 0;
						int j = 0;
						int x = TEXT_PADDING + fontH + TEXT_PADDING;
						foreach (ScopeChannel channel in Scope.I.RecordedChannels)
						{
							if (!channel.IsActive)
							{
								continue;
							}

							int y = _backB.Height - (fontH + TEXT_PADDING) * (i + 1);
							string dim = DimParser.ParseDim(channel.Parameter);

							float nextValue = Scope.I.Ticks[Cursor1.TickIndex].Values[j];
							float prevValue = Cursor1.TickIndex > 0 ?
								Scope.I.Ticks[Cursor1.TickIndex - 1].Values[j] :
								nextValue;

							ScopeTick nextTick = Scope.I.Ticks[Cursor1.TickIndex];
							ScopeTick prevTick;
							if (Cursor1.TickIndex > 0)
							{
								prevTick = Scope.I.Ticks[Cursor1.TickIndex - 1];
							}
							else
							{
								prevTick = new ScopeTick();
								prevTick.Time = 0;
								prevTick.Values = nextTick.Values;
							}

							double k = (Cursor1.ExactTime - prevTick.Time) / (nextTick.Time - prevTick.Time);
							if (double.IsNaN(k))
							{
								k = 0;
							}
							float value = (float)(prevValue + (nextValue - prevValue) * k);

							string s = value.ToString() + " " + dim;
							SizeF sWF = _backBG.MeasureString(s, font);

							_backBG.FillRectangle(
								_alphaBrush,
								x + maxStrW + TEXT_PADDING4 - TEXT_PADDING,
								y - TEXT_PADDING,
								sWF.Width + TEXT_PADDING2,
								sWF.Height + TEXT_PADDING2);

							_backBG.DrawString(
								s,
								font,
								Brushes.Black,
								x + maxStrW + TEXT_PADDING4, y);

							i++;
							j++;
						}
							
						//рисуем время тика курсора
						int yy = _backB.Height - (fontH + TEXT_PADDING) * (i + 1);
						TimeSpan sp = new TimeSpan((long)Cursor1.ExactTime * 10000);
						string ss = string.Concat(
							sp.Hours.ToString("00"), ":",
							sp.Minutes.ToString("00"), ":",
							sp.Seconds.ToString("00"), ".",
							sp.Milliseconds.ToString("000"),
							" (", sp.TotalMilliseconds, " мсек)"
							);
						SizeF sizef = _backBG.MeasureString(ss, font);
						_backBG.FillRectangle(
							_alphaBrush,
							x + maxStrW + TEXT_PADDING4 - TEXT_PADDING,
							yy - TEXT_PADDING,
							sizef.Width + TEXT_PADDING2,
							sizef.Height + TEXT_PADDING2);
						_backBG.DrawString(
							ss,
							font,
							Brushes.Black,
							x + maxStrW + TEXT_PADDING4, yy);
					}
				}
			}
		}

		private void canvasPanel_MouseLeave(object sender, EventArgs e)
		{
			ClearLastCursorSnapshot();
			_mouseLastX = -999;
			canvasPanel.Invalidate();
		}

		public void OnScopeCanvasUC_KeyDown(object sender, KeyEventArgs e)
		{
			if (!Scope.I.IsActive)
			{
				if (Cursor1 != null)
				{
					if (Cursor1.Enable)
					{
						if (e.KeyCode == Keys.Left)
						{
							Cursor1.TickIndex -= Cursor1.TickIndex > 0 ? 1 : 0;
							Cursor1.ExactTime = Scope.I.Ticks[Cursor1.TickIndex].Time;
							ClearLastCursorSnapshot();
							_mouseLastX = -999;
							RefreshScope();
						}
						else
						{
							if (e.KeyCode == Keys.Right)
							{
								Cursor1.TickIndex += Cursor1.TickIndex < Scope.I.Ticks.Count - 1 ? 1 : 0;
								Cursor1.ExactTime = Scope.I.Ticks[Cursor1.TickIndex].Time;
								ClearLastCursorSnapshot();
								_mouseLastX = -999;
								RefreshScope();
							}
						}
					}
				}
			}
		}
	}
}

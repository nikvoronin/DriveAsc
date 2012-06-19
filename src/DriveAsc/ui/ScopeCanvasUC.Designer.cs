namespace DriveASC.ui
{
	partial class ScopeCanvasUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.hScrollBar = new System.Windows.Forms.HScrollBar();
			this.canvasPanel = new DriveASC.ui.PanelEx();
			this.SuspendLayout();
			// 
			// hScrollBar
			// 
			this.hScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.hScrollBar.LargeChange = 1;
			this.hScrollBar.Location = new System.Drawing.Point(0, 282);
			this.hScrollBar.Maximum = 0;
			this.hScrollBar.Name = "hScrollBar";
			this.hScrollBar.Size = new System.Drawing.Size(439, 16);
			this.hScrollBar.TabIndex = 0;
			this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
			// 
			// canvasPanel
			// 
			this.canvasPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.canvasPanel.BackColor = System.Drawing.Color.White;
			this.canvasPanel.Location = new System.Drawing.Point(3, 3);
			this.canvasPanel.Name = "canvasPanel";
			this.canvasPanel.Size = new System.Drawing.Size(433, 276);
			this.canvasPanel.TabIndex = 1;
			this.canvasPanel.SizeChanged += new System.EventHandler(this.canvasPanel_SizeChanged);
			this.canvasPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.canvasPanel_Paint);
			this.canvasPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvasPanel_MouseClick);
			this.canvasPanel.MouseLeave += new System.EventHandler(this.canvasPanel_MouseLeave);
			this.canvasPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasPanel_MouseMove);
			// 
			// ScopeCanvasUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.canvasPanel);
			this.Controls.Add(this.hScrollBar);
			this.Name = "ScopeCanvasUC";
			this.Size = new System.Drawing.Size(439, 298);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.HScrollBar hScrollBar;
		private PanelEx canvasPanel;
	}
}

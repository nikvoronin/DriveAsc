namespace DriveASC.ui
{
	partial class ErrorsForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.lastListView = new DriveASC.ui.ListViewEx();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label1 = new System.Windows.Forms.Label();
			this.totalErrorsLabel = new System.Windows.Forms.Label();
			this.errorsTabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.frequencyListView = new DriveASC.ui.ListViewEx();
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.closeButton = new System.Windows.Forms.Button();
			this.updateTimer = new System.Windows.Forms.Timer(this.components);
			this.errorsTabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lastListView
			// 
			this.lastListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lastListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.lastListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lastListView.FullRowSelect = true;
			this.lastListView.Location = new System.Drawing.Point(3, 3);
			this.lastListView.Name = "lastListView";
			this.lastListView.Size = new System.Drawing.Size(453, 260);
			this.lastListView.TabIndex = 0;
			this.lastListView.UseCompatibleStateImageBehavior = false;
			this.lastListView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Код";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Название";
			this.columnHeader2.Width = 200;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Время (ч:мин)";
			this.columnHeader3.Width = 100;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 315);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Всего ошибок:";
			// 
			// totalErrorsLabel
			// 
			this.totalErrorsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.totalErrorsLabel.AutoSize = true;
			this.totalErrorsLabel.Location = new System.Drawing.Point(99, 315);
			this.totalErrorsLabel.Name = "totalErrorsLabel";
			this.totalErrorsLabel.Size = new System.Drawing.Size(13, 13);
			this.totalErrorsLabel.TabIndex = 2;
			this.totalErrorsLabel.Text = "0";
			// 
			// errorsTabControl
			// 
			this.errorsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.errorsTabControl.Controls.Add(this.tabPage1);
			this.errorsTabControl.Controls.Add(this.tabPage2);
			this.errorsTabControl.Location = new System.Drawing.Point(12, 12);
			this.errorsTabControl.Name = "errorsTabControl";
			this.errorsTabControl.SelectedIndex = 0;
			this.errorsTabControl.Size = new System.Drawing.Size(467, 292);
			this.errorsTabControl.TabIndex = 4;
			this.errorsTabControl.SelectedIndexChanged += new System.EventHandler(this.errorsTabControl_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.lastListView);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(459, 266);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Последние ошибки";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.frequencyListView);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(459, 266);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Частота";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// frequencyListView
			// 
			this.frequencyListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.frequencyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
			this.frequencyListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.frequencyListView.FullRowSelect = true;
			this.frequencyListView.Location = new System.Drawing.Point(3, 3);
			this.frequencyListView.Name = "frequencyListView";
			this.frequencyListView.Size = new System.Drawing.Size(453, 260);
			this.frequencyListView.TabIndex = 1;
			this.frequencyListView.UseCompatibleStateImageBehavior = false;
			this.frequencyListView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Код";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Название";
			this.columnHeader5.Width = 200;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Количество";
			this.columnHeader6.Width = 100;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Частота";
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.Location = new System.Drawing.Point(404, 310);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 5;
			this.closeButton.Text = "Закрыть";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// updateTimer
			// 
			this.updateTimer.Enabled = true;
			this.updateTimer.Interval = 1000;
			this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
			// 
			// ErrorsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(491, 345);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.errorsTabControl);
			this.Controls.Add(this.totalErrorsLabel);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(499, 372);
			this.Name = "ErrorsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Ошибки и предупреждения";
			this.Load += new System.EventHandler(this.ErrorsForm_Load);
			this.errorsTabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ListViewEx lastListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label totalErrorsLabel;
		private System.Windows.Forms.TabControl errorsTabControl;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private ListViewEx frequencyListView;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Timer updateTimer;
	}
}
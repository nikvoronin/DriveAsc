using DriveASC.ui;
namespace DriveASC
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.templateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.newScopeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openScopeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
			this.saveAsScopeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.parametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.scopeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.terminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.paramDescriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paramDescDescToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paramDescAsciiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paramDescFullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
			this.paramSmoothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paramSmoothFastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paramSmoothAAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paramSmoothPreciseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.transmitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.comPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.driveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveEepromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rstvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.softEnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.softDisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
			this.errorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearFaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.coldstartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contentsHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutDriveAscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainToolStrip = new System.Windows.Forms.ToolStrip();
			this.saveEepromToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.rstvarToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.softEnToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.softDisToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
			this.errorsToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.clearFaultToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.coldstartToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.connectionStateStripLabel = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.connectToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.disconnectToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.sw2ParametersToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.sw2ScopeToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
			this.driveNameStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.portNameStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.driveStateStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.softLockToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.appLockToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.stoLockToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.errToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.reconnectTimer = new System.Windows.Forms.Timer(this.components);
			this.updateTimer = new System.Windows.Forms.Timer(this.components);
			this.terminalTabPage = new System.Windows.Forms.TabPage();
			this.terminalSplitContainer = new System.Windows.Forms.SplitContainer();
			this.terminalClearButton = new System.Windows.Forms.Button();
			this.terminalCopyButton = new System.Windows.Forms.Button();
			this.terminalPanel = new System.Windows.Forms.Panel();
			this.terminalRichTextBox = new System.Windows.Forms.RichTextBox();
			this.terminalSendButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.terminalTextBox = new System.Windows.Forms.TextBox();
			this.paramsTabPage = new System.Windows.Forms.TabPage();
			this.paramsSplitContainer = new System.Windows.Forms.SplitContainer();
			this.groupsListView = new DriveASC.ui.ListViewEx();
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.paramsListView = new DriveASC.ui.ListViewEx();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.mainTabControl = new System.Windows.Forms.TabControl();
			this.scopeTabPage = new System.Windows.Forms.TabPage();
			this.scopeCanvasUC = new DriveASC.ui.ScopeCanvasUC();
			this.scopeToolStrip = new System.Windows.Forms.ToolStrip();
			this.scopeRecordToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.scopeStopToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.scopeNewToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.scopeOpenToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			this.scopeSaveAsToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.scopeSaveImageToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.scopeMeasureInToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.scopeMeasureXtoolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
			this.scopeMeasureOutToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
			this.chAtoolStripButton = new System.Windows.Forms.ToolStripButton();
			this.chBtoolStripButton = new System.Windows.Forms.ToolStripButton();
			this.chCtoolStripButton = new System.Windows.Forms.ToolStripButton();
			this.chDtoolStripButton = new System.Windows.Forms.ToolStripButton();
			this.chEtoolStripButton = new System.Windows.Forms.ToolStripButton();
			this.chFtoolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
			this.scopeCursor1ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.scopeSaveImageFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.scopeOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.scopeSaveAsFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			this.mainMenuStrip.SuspendLayout();
			this.mainToolStrip.SuspendLayout();
			this.mainStatusStrip.SuspendLayout();
			this.terminalTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.terminalSplitContainer)).BeginInit();
			this.terminalSplitContainer.Panel1.SuspendLayout();
			this.terminalSplitContainer.Panel2.SuspendLayout();
			this.terminalSplitContainer.SuspendLayout();
			this.terminalPanel.SuspendLayout();
			this.paramsTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.paramsSplitContainer)).BeginInit();
			this.paramsSplitContainer.Panel1.SuspendLayout();
			this.paramsSplitContainer.Panel2.SuspendLayout();
			this.paramsSplitContainer.SuspendLayout();
			this.mainTabControl.SuspendLayout();
			this.scopeTabPage.SuspendLayout();
			this.scopeToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenuStrip
			// 
			this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.transmitToolStripMenuItem,
            this.driveToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainMenuStrip.Name = "mainMenuStrip";
			this.mainMenuStrip.Size = new System.Drawing.Size(692, 24);
			this.mainMenuStrip.TabIndex = 0;
			this.mainMenuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.templateToolStripMenuItem,
            this.toolStripSeparator4,
            this.newScopeToolStripMenuItem,
            this.openScopeToolStripMenuItem,
            this.toolStripSeparator17,
            this.saveAsScopeToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
			this.fileToolStripMenuItem.Text = "&Файл";
			this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
			// 
			// templateToolStripMenuItem
			// 
			this.templateToolStripMenuItem.Enabled = false;
			this.templateToolStripMenuItem.Name = "templateToolStripMenuItem";
			this.templateToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
			this.templateToolStripMenuItem.Text = "&Шаблон";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(228, 6);
			// 
			// newScopeToolStripMenuItem
			// 
			this.newScopeToolStripMenuItem.Image = global::DriveASC.Properties.Resources.scope_new;
			this.newScopeToolStripMenuItem.Name = "newScopeToolStripMenuItem";
			this.newScopeToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
			this.newScopeToolStripMenuItem.Text = "&Новая осциллограмма";
			this.newScopeToolStripMenuItem.Click += new System.EventHandler(this.scopeNewToolStripButton_Click);
			// 
			// openScopeToolStripMenuItem
			// 
			this.openScopeToolStripMenuItem.Image = global::DriveASC.Properties.Resources.scopel_open;
			this.openScopeToolStripMenuItem.Name = "openScopeToolStripMenuItem";
			this.openScopeToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
			this.openScopeToolStripMenuItem.Text = "&Открыть осциллограмму...";
			this.openScopeToolStripMenuItem.Click += new System.EventHandler(this.scopeOpenToolStripButton_Click);
			// 
			// toolStripSeparator17
			// 
			this.toolStripSeparator17.Name = "toolStripSeparator17";
			this.toolStripSeparator17.Size = new System.Drawing.Size(228, 6);
			// 
			// saveAsScopeToolStripMenuItem
			// 
			this.saveAsScopeToolStripMenuItem.Enabled = false;
			this.saveAsScopeToolStripMenuItem.Image = global::DriveASC.Properties.Resources.scope_save;
			this.saveAsScopeToolStripMenuItem.Name = "saveAsScopeToolStripMenuItem";
			this.saveAsScopeToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
			this.saveAsScopeToolStripMenuItem.Text = "&Сохранить осциллограмму...";
			this.saveAsScopeToolStripMenuItem.Click += new System.EventHandler(this.scopeSaveAsToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(228, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
			this.exitToolStripMenuItem.Text = "&Выход";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parametersToolStripMenuItem,
            this.scopeToolStripMenuItem,
            this.terminalToolStripMenuItem,
            this.toolStripSeparator9,
            this.paramDescriptionToolStripMenuItem,
            this.toolStripSeparator21,
            this.paramSmoothToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
			this.viewToolStripMenuItem.Text = "&Вид";
			this.viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this.viewToolStripMenuItem_DropDownOpening);
			// 
			// parametersToolStripMenuItem
			// 
			this.parametersToolStripMenuItem.Name = "parametersToolStripMenuItem";
			this.parametersToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.parametersToolStripMenuItem.Text = "&Параметры";
			this.parametersToolStripMenuItem.Click += new System.EventHandler(this.parametersToolStripMenuItem_Click);
			// 
			// scopeToolStripMenuItem
			// 
			this.scopeToolStripMenuItem.Name = "scopeToolStripMenuItem";
			this.scopeToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.scopeToolStripMenuItem.Text = "&Осциллограф";
			this.scopeToolStripMenuItem.Click += new System.EventHandler(this.scopeToolStripMenuItem_Click);
			// 
			// terminalToolStripMenuItem
			// 
			this.terminalToolStripMenuItem.Name = "terminalToolStripMenuItem";
			this.terminalToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.terminalToolStripMenuItem.Text = "&Терминал";
			this.terminalToolStripMenuItem.Click += new System.EventHandler(this.terminalToolStripMenuItem_Click);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(201, 6);
			// 
			// paramDescriptionToolStripMenuItem
			// 
			this.paramDescriptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paramDescDescToolStripMenuItem,
            this.paramDescAsciiToolStripMenuItem,
            this.paramDescFullToolStripMenuItem});
			this.paramDescriptionToolStripMenuItem.Name = "paramDescriptionToolStripMenuItem";
			this.paramDescriptionToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.paramDescriptionToolStripMenuItem.Tag = "0";
			this.paramDescriptionToolStripMenuItem.Text = "&Описание параметров";
			this.paramDescriptionToolStripMenuItem.DropDownOpening += new System.EventHandler(this.paramDescriptionToolStripMenuItem_DropDownOpening);
			// 
			// paramDescDescToolStripMenuItem
			// 
			this.paramDescDescToolStripMenuItem.Name = "paramDescDescToolStripMenuItem";
			this.paramDescDescToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this.paramDescDescToolStripMenuItem.Tag = "0";
			this.paramDescDescToolStripMenuItem.Text = "&Описание";
			this.paramDescDescToolStripMenuItem.Click += new System.EventHandler(this.paramDescDescToolStripMenuItem_Click);
			// 
			// paramDescAsciiToolStripMenuItem
			// 
			this.paramDescAsciiToolStripMenuItem.Name = "paramDescAsciiToolStripMenuItem";
			this.paramDescAsciiToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this.paramDescAsciiToolStripMenuItem.Tag = "1";
			this.paramDescAsciiToolStripMenuItem.Text = "ASCII-&код";
			this.paramDescAsciiToolStripMenuItem.Click += new System.EventHandler(this.paramDescDescToolStripMenuItem_Click);
			// 
			// paramDescFullToolStripMenuItem
			// 
			this.paramDescFullToolStripMenuItem.Name = "paramDescFullToolStripMenuItem";
			this.paramDescFullToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this.paramDescFullToolStripMenuItem.Tag = "2";
			this.paramDescFullToolStripMenuItem.Text = "Описание &и ASCII-код";
			this.paramDescFullToolStripMenuItem.Click += new System.EventHandler(this.paramDescDescToolStripMenuItem_Click);
			// 
			// toolStripSeparator21
			// 
			this.toolStripSeparator21.Name = "toolStripSeparator21";
			this.toolStripSeparator21.Size = new System.Drawing.Size(201, 6);
			// 
			// paramSmoothToolStripMenuItem
			// 
			this.paramSmoothToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paramSmoothFastToolStripMenuItem,
            this.paramSmoothAAToolStripMenuItem,
            this.paramSmoothPreciseToolStripMenuItem});
			this.paramSmoothToolStripMenuItem.Name = "paramSmoothToolStripMenuItem";
			this.paramSmoothToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.paramSmoothToolStripMenuItem.Text = "&График осциллограммы";
			this.paramSmoothToolStripMenuItem.DropDownOpening += new System.EventHandler(this.paramSmoothToolStripMenuItem_DropDownOpening);
			// 
			// paramSmoothFastToolStripMenuItem
			// 
			this.paramSmoothFastToolStripMenuItem.Name = "paramSmoothFastToolStripMenuItem";
			this.paramSmoothFastToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.paramSmoothFastToolStripMenuItem.Tag = "0";
			this.paramSmoothFastToolStripMenuItem.Text = "&Быстрый";
			this.paramSmoothFastToolStripMenuItem.Click += new System.EventHandler(this.paramSmoothFastToolStripMenuItem_Click);
			// 
			// paramSmoothAAToolStripMenuItem
			// 
			this.paramSmoothAAToolStripMenuItem.Name = "paramSmoothAAToolStripMenuItem";
			this.paramSmoothAAToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.paramSmoothAAToolStripMenuItem.Tag = "1";
			this.paramSmoothAAToolStripMenuItem.Text = "&Гладкий";
			this.paramSmoothAAToolStripMenuItem.Click += new System.EventHandler(this.paramSmoothFastToolStripMenuItem_Click);
			// 
			// paramSmoothPreciseToolStripMenuItem
			// 
			this.paramSmoothPreciseToolStripMenuItem.Name = "paramSmoothPreciseToolStripMenuItem";
			this.paramSmoothPreciseToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.paramSmoothPreciseToolStripMenuItem.Tag = "2";
			this.paramSmoothPreciseToolStripMenuItem.Text = "&Аккуратный";
			this.paramSmoothPreciseToolStripMenuItem.Click += new System.EventHandler(this.paramSmoothFastToolStripMenuItem_Click);
			// 
			// transmitToolStripMenuItem
			// 
			this.transmitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.toolStripSeparator6,
            this.comPortToolStripMenuItem});
			this.transmitToolStripMenuItem.Name = "transmitToolStripMenuItem";
			this.transmitToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
			this.transmitToolStripMenuItem.Text = "&Связь";
			this.transmitToolStripMenuItem.DropDownOpening += new System.EventHandler(this.connectionToolStripMenuItem_DropDownOpening);
			// 
			// connectToolStripMenuItem
			// 
			this.connectToolStripMenuItem.Enabled = false;
			this.connectToolStripMenuItem.Image = global::DriveASC.Properties.Resources.plug_connect;
			this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
			this.connectToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.connectToolStripMenuItem.Text = "&Подключить";
			this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
			// 
			// disconnectToolStripMenuItem
			// 
			this.disconnectToolStripMenuItem.Image = global::DriveASC.Properties.Resources.plug_disconnect;
			this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
			this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.disconnectToolStripMenuItem.Text = "&Отключить";
			this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(147, 6);
			// 
			// comPortToolStripMenuItem
			// 
			this.comPortToolStripMenuItem.Enabled = false;
			this.comPortToolStripMenuItem.Name = "comPortToolStripMenuItem";
			this.comPortToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.comPortToolStripMenuItem.Text = "СОМ-по&рт";
			// 
			// driveToolStripMenuItem
			// 
			this.driveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveEepromToolStripMenuItem,
            this.rstvarToolStripMenuItem,
            this.toolStripSeparator10,
            this.softEnToolStripMenuItem,
            this.softDisToolStripMenuItem,
            this.toolStripSeparator18,
            this.errorsToolStripMenuItem,
            this.clearFaultToolStripMenuItem,
            this.toolStripSeparator11,
            this.coldstartToolStripMenuItem});
			this.driveToolStripMenuItem.Enabled = false;
			this.driveToolStripMenuItem.Name = "driveToolStripMenuItem";
			this.driveToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.driveToolStripMenuItem.Text = "П&ривод";
			// 
			// saveEepromToolStripMenuItem
			// 
			this.saveEepromToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveEepromToolStripMenuItem.Image")));
			this.saveEepromToolStripMenuItem.Name = "saveEepromToolStripMenuItem";
			this.saveEepromToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
			this.saveEepromToolStripMenuItem.Text = "&Сохранить в EEPROM";
			this.saveEepromToolStripMenuItem.Click += new System.EventHandler(this.saveEepromToolStripButton_Click);
			// 
			// rstvarToolStripMenuItem
			// 
			this.rstvarToolStripMenuItem.Image = global::DriveASC.Properties.Resources.default_params;
			this.rstvarToolStripMenuItem.Name = "rstvarToolStripMenuItem";
			this.rstvarToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
			this.rstvarToolStripMenuItem.Text = "&Установка заводских данных";
			this.rstvarToolStripMenuItem.Click += new System.EventHandler(this.rstvarToolStripButton_Click);
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(234, 6);
			// 
			// softEnToolStripMenuItem
			// 
			this.softEnToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("softEnToolStripMenuItem.Image")));
			this.softEnToolStripMenuItem.Name = "softEnToolStripMenuItem";
			this.softEnToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
			this.softEnToolStripMenuItem.Text = "&Деблокировка";
			this.softEnToolStripMenuItem.Click += new System.EventHandler(this.softEnStripButton_Click);
			// 
			// softDisToolStripMenuItem
			// 
			this.softDisToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("softDisToolStripMenuItem.Image")));
			this.softDisToolStripMenuItem.Name = "softDisToolStripMenuItem";
			this.softDisToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
			this.softDisToolStripMenuItem.Text = "&Блокировка";
			this.softDisToolStripMenuItem.Click += new System.EventHandler(this.softDisToolStripButton_Click);
			// 
			// toolStripSeparator18
			// 
			this.toolStripSeparator18.Name = "toolStripSeparator18";
			this.toolStripSeparator18.Size = new System.Drawing.Size(234, 6);
			// 
			// errorsToolStripMenuItem
			// 
			this.errorsToolStripMenuItem.Image = global::DriveASC.Properties.Resources.information_button;
			this.errorsToolStripMenuItem.Name = "errorsToolStripMenuItem";
			this.errorsToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
			this.errorsToolStripMenuItem.Text = "Ошибки и предупреждения";
			this.errorsToolStripMenuItem.Click += new System.EventHandler(this.errorsToolStripButton_Click);
			// 
			// clearFaultToolStripMenuItem
			// 
			this.clearFaultToolStripMenuItem.Image = global::DriveASC.Properties.Resources.rstvar;
			this.clearFaultToolStripMenuItem.Name = "clearFaultToolStripMenuItem";
			this.clearFaultToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
			this.clearFaultToolStripMenuItem.Text = "Сброс текущей &ошибки";
			this.clearFaultToolStripMenuItem.Click += new System.EventHandler(this.clearFaultToolStripButton_Click);
			// 
			// toolStripSeparator11
			// 
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(234, 6);
			// 
			// coldstartToolStripMenuItem
			// 
			this.coldstartToolStripMenuItem.Image = global::DriveASC.Properties.Resources.coldstart;
			this.coldstartToolStripMenuItem.Name = "coldstartToolStripMenuItem";
			this.coldstartToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
			this.coldstartToolStripMenuItem.Text = "Пе&резагрузить привод";
			this.coldstartToolStripMenuItem.Click += new System.EventHandler(this.coldstartToolStripButton_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsHelpToolStripMenuItem,
            this.toolStripSeparator5,
            this.registerToolStripMenuItem,
            this.toolStripSeparator20,
            this.aboutDriveAscToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.helpToolStripMenuItem.Text = "&Помощь";
			// 
			// contentsHelpToolStripMenuItem
			// 
			this.contentsHelpToolStripMenuItem.Enabled = false;
			this.contentsHelpToolStripMenuItem.Name = "contentsHelpToolStripMenuItem";
			this.contentsHelpToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.contentsHelpToolStripMenuItem.Text = "&Справка по программе";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(196, 6);
			// 
			// registerToolStripMenuItem
			// 
			this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
			this.registerToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.registerToolStripMenuItem.Text = "&Регистрация...";
			this.registerToolStripMenuItem.Click += new System.EventHandler(this.registerToolStripMenuItem_Click);
			// 
			// toolStripSeparator20
			// 
			this.toolStripSeparator20.Name = "toolStripSeparator20";
			this.toolStripSeparator20.Size = new System.Drawing.Size(196, 6);
			// 
			// aboutDriveAscToolStripMenuItem
			// 
			this.aboutDriveAscToolStripMenuItem.Name = "aboutDriveAscToolStripMenuItem";
			this.aboutDriveAscToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.aboutDriveAscToolStripMenuItem.Text = "&О программе DriveASC";
			this.aboutDriveAscToolStripMenuItem.Click += new System.EventHandler(this.aboutDriveAscToolStripMenuItem_Click);
			// 
			// mainToolStrip
			// 
			this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveEepromToolStripButton,
            this.rstvarToolStripButton,
            this.toolStripSeparator2,
            this.softEnToolStripButton,
            this.softDisToolStripButton,
            this.toolStripSeparator19,
            this.errorsToolStripButton,
            this.clearFaultToolStripButton,
            this.toolStripSeparator3,
            this.coldstartToolStripButton,
            this.connectionStateStripLabel,
            this.toolStripSeparator8,
            this.connectToolStripButton,
            this.disconnectToolStripButton,
            this.toolStripSeparator7,
            this.sw2ParametersToolStripButton,
            this.sw2ScopeToolStripButton});
			this.mainToolStrip.Location = new System.Drawing.Point(0, 24);
			this.mainToolStrip.Name = "mainToolStrip";
			this.mainToolStrip.Size = new System.Drawing.Size(692, 25);
			this.mainToolStrip.TabIndex = 1;
			this.mainToolStrip.Text = "toolStrip1";
			// 
			// saveEepromToolStripButton
			// 
			this.saveEepromToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveEepromToolStripButton.Enabled = false;
			this.saveEepromToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveEepromToolStripButton.Image")));
			this.saveEepromToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveEepromToolStripButton.Name = "saveEepromToolStripButton";
			this.saveEepromToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.saveEepromToolStripButton.Text = "Сохранить параметры привода в EEPROM";
			this.saveEepromToolStripButton.Click += new System.EventHandler(this.saveEepromToolStripButton_Click);
			// 
			// rstvarToolStripButton
			// 
			this.rstvarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.rstvarToolStripButton.Enabled = false;
			this.rstvarToolStripButton.Image = global::DriveASC.Properties.Resources.default_params;
			this.rstvarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.rstvarToolStripButton.Name = "rstvarToolStripButton";
			this.rstvarToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.rstvarToolStripButton.Text = "Установка заводских данных";
			this.rstvarToolStripButton.Click += new System.EventHandler(this.rstvarToolStripButton_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// softEnToolStripButton
			// 
			this.softEnToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.softEnToolStripButton.Enabled = false;
			this.softEnToolStripButton.ForeColor = System.Drawing.Color.Green;
			this.softEnToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("softEnToolStripButton.Image")));
			this.softEnToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.softEnToolStripButton.Name = "softEnToolStripButton";
			this.softEnToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.softEnToolStripButton.Text = "EN";
			this.softEnToolStripButton.ToolTipText = "Программная деблокировка";
			this.softEnToolStripButton.Click += new System.EventHandler(this.softEnStripButton_Click);
			// 
			// softDisToolStripButton
			// 
			this.softDisToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.softDisToolStripButton.Enabled = false;
			this.softDisToolStripButton.ForeColor = System.Drawing.Color.Maroon;
			this.softDisToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("softDisToolStripButton.Image")));
			this.softDisToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.softDisToolStripButton.Name = "softDisToolStripButton";
			this.softDisToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.softDisToolStripButton.Text = "DIS";
			this.softDisToolStripButton.ToolTipText = "Программная блокировка";
			this.softDisToolStripButton.Click += new System.EventHandler(this.softDisToolStripButton_Click);
			// 
			// toolStripSeparator19
			// 
			this.toolStripSeparator19.Name = "toolStripSeparator19";
			this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
			// 
			// errorsToolStripButton
			// 
			this.errorsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.errorsToolStripButton.Enabled = false;
			this.errorsToolStripButton.Image = global::DriveASC.Properties.Resources.information_button;
			this.errorsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.errorsToolStripButton.Name = "errorsToolStripButton";
			this.errorsToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.errorsToolStripButton.Text = "Ошибки и предупреждения";
			this.errorsToolStripButton.Click += new System.EventHandler(this.errorsToolStripButton_Click);
			// 
			// clearFaultToolStripButton
			// 
			this.clearFaultToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.clearFaultToolStripButton.Enabled = false;
			this.clearFaultToolStripButton.Image = global::DriveASC.Properties.Resources.rstvar;
			this.clearFaultToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.clearFaultToolStripButton.Name = "clearFaultToolStripButton";
			this.clearFaultToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.clearFaultToolStripButton.Text = "Сброс ошибки";
			this.clearFaultToolStripButton.Click += new System.EventHandler(this.clearFaultToolStripButton_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// coldstartToolStripButton
			// 
			this.coldstartToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.coldstartToolStripButton.Enabled = false;
			this.coldstartToolStripButton.Image = global::DriveASC.Properties.Resources.coldstart;
			this.coldstartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.coldstartToolStripButton.Name = "coldstartToolStripButton";
			this.coldstartToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.coldstartToolStripButton.Text = "Перезагрузить привод";
			this.coldstartToolStripButton.Click += new System.EventHandler(this.coldstartToolStripButton_Click);
			// 
			// connectionStateStripLabel
			// 
			this.connectionStateStripLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.connectionStateStripLabel.ForeColor = System.Drawing.Color.Black;
			this.connectionStateStripLabel.Image = global::DriveASC.Properties.Resources.disconnected_red_lamp;
			this.connectionStateStripLabel.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
			this.connectionStateStripLabel.Name = "connectionStateStripLabel";
			this.connectionStateStripLabel.Size = new System.Drawing.Size(76, 22);
			this.connectionStateStripLabel.Text = "Отключен";
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
			// 
			// connectToolStripButton
			// 
			this.connectToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.connectToolStripButton.Enabled = false;
			this.connectToolStripButton.Image = global::DriveASC.Properties.Resources.plug_connect;
			this.connectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.connectToolStripButton.Name = "connectToolStripButton";
			this.connectToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.connectToolStripButton.Text = "Подключить";
			this.connectToolStripButton.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
			// 
			// disconnectToolStripButton
			// 
			this.disconnectToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.disconnectToolStripButton.Image = global::DriveASC.Properties.Resources.plug_disconnect;
			this.disconnectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.disconnectToolStripButton.Name = "disconnectToolStripButton";
			this.disconnectToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.disconnectToolStripButton.Text = "Отключить";
			this.disconnectToolStripButton.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
			// 
			// sw2ParametersToolStripButton
			// 
			this.sw2ParametersToolStripButton.Checked = true;
			this.sw2ParametersToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.sw2ParametersToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.sw2ParametersToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("sw2ParametersToolStripButton.Image")));
			this.sw2ParametersToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.sw2ParametersToolStripButton.Margin = new System.Windows.Forms.Padding(2, 1, 0, 2);
			this.sw2ParametersToolStripButton.Name = "sw2ParametersToolStripButton";
			this.sw2ParametersToolStripButton.Size = new System.Drawing.Size(68, 22);
			this.sw2ParametersToolStripButton.Text = "Параметры";
			this.sw2ParametersToolStripButton.Click += new System.EventHandler(this.sw2ParametersToolStripButton_Click);
			// 
			// sw2ScopeToolStripButton
			// 
			this.sw2ScopeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.sw2ScopeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("sw2ScopeToolStripButton.Image")));
			this.sw2ScopeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.sw2ScopeToolStripButton.Name = "sw2ScopeToolStripButton";
			this.sw2ScopeToolStripButton.Size = new System.Drawing.Size(79, 22);
			this.sw2ScopeToolStripButton.Text = "Осциллограф";
			this.sw2ScopeToolStripButton.Click += new System.EventHandler(this.sw2ScopeToolStripButton_Click);
			// 
			// mainStatusStrip
			// 
			this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.driveNameStatusLabel,
            this.portNameStatusLabel,
            this.driveStateStatusLabel,
            this.softLockToolStripStatusLabel,
            this.appLockToolStripStatusLabel,
            this.stoLockToolStripStatusLabel,
            this.errToolStripStatusLabel});
			this.mainStatusStrip.Location = new System.Drawing.Point(0, 451);
			this.mainStatusStrip.Name = "mainStatusStrip";
			this.mainStatusStrip.Size = new System.Drawing.Size(692, 22);
			this.mainStatusStrip.TabIndex = 2;
			this.mainStatusStrip.Text = "statusStrip1";
			// 
			// driveNameStatusLabel
			// 
			this.driveNameStatusLabel.Name = "driveNameStatusLabel";
			this.driveNameStatusLabel.Size = new System.Drawing.Size(45, 17);
			this.driveNameStatusLabel.Text = "Привод";
			// 
			// portNameStatusLabel
			// 
			this.portNameStatusLabel.Name = "portNameStatusLabel";
			this.portNameStatusLabel.Size = new System.Drawing.Size(49, 17);
			this.portNameStatusLabel.Text = "@ COM1";
			// 
			// driveStateStatusLabel
			// 
			this.driveStateStatusLabel.Name = "driveStateStatusLabel";
			this.driveStateStatusLabel.Size = new System.Drawing.Size(347, 17);
			this.driveStateStatusLabel.Spring = true;
			this.driveStateStatusLabel.Text = "ожидание соединения...";
			this.driveStateStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// softLockToolStripStatusLabel
			// 
			this.softLockToolStripStatusLabel.BackColor = System.Drawing.SystemColors.Control;
			this.softLockToolStripStatusLabel.ForeColor = System.Drawing.Color.White;
			this.softLockToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 2, 2);
			this.softLockToolStripStatusLabel.Name = "softLockToolStripStatusLabel";
			this.softLockToolStripStatusLabel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.softLockToolStripStatusLabel.Size = new System.Drawing.Size(72, 17);
			this.softLockToolStripStatusLabel.Text = "Прог. блок.";
			// 
			// appLockToolStripStatusLabel
			// 
			this.appLockToolStripStatusLabel.BackColor = System.Drawing.SystemColors.Control;
			this.appLockToolStripStatusLabel.ForeColor = System.Drawing.Color.White;
			this.appLockToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 2, 2);
			this.appLockToolStripStatusLabel.Name = "appLockToolStripStatusLabel";
			this.appLockToolStripStatusLabel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.appLockToolStripStatusLabel.Size = new System.Drawing.Size(67, 17);
			this.appLockToolStripStatusLabel.Text = "Апп. блок.";
			// 
			// stoLockToolStripStatusLabel
			// 
			this.stoLockToolStripStatusLabel.ForeColor = System.Drawing.Color.White;
			this.stoLockToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 2, 2);
			this.stoLockToolStripStatusLabel.Name = "stoLockToolStripStatusLabel";
			this.stoLockToolStripStatusLabel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.stoLockToolStripStatusLabel.Size = new System.Drawing.Size(33, 17);
			this.stoLockToolStripStatusLabel.Text = "STO";
			// 
			// errToolStripStatusLabel
			// 
			this.errToolStripStatusLabel.BackColor = System.Drawing.SystemColors.Control;
			this.errToolStripStatusLabel.ForeColor = System.Drawing.Color.White;
			this.errToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
			this.errToolStripStatusLabel.Name = "errToolStripStatusLabel";
			this.errToolStripStatusLabel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.errToolStripStatusLabel.Size = new System.Drawing.Size(53, 17);
			this.errToolStripStatusLabel.Text = "Ошибка";
			// 
			// reconnectTimer
			// 
			this.reconnectTimer.Interval = 3000;
			this.reconnectTimer.Tick += new System.EventHandler(this.reconnectTimer_Tick);
			// 
			// updateTimer
			// 
			this.updateTimer.Interval = 233;
			this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
			// 
			// terminalTabPage
			// 
			this.terminalTabPage.Controls.Add(this.terminalSplitContainer);
			this.terminalTabPage.Location = new System.Drawing.Point(24, 4);
			this.terminalTabPage.Margin = new System.Windows.Forms.Padding(0);
			this.terminalTabPage.Name = "terminalTabPage";
			this.terminalTabPage.Size = new System.Drawing.Size(664, 394);
			this.terminalTabPage.TabIndex = 2;
			this.terminalTabPage.Text = "Терминал";
			this.terminalTabPage.UseVisualStyleBackColor = true;
			// 
			// terminalSplitContainer
			// 
			this.terminalSplitContainer.Cursor = System.Windows.Forms.Cursors.Default;
			this.terminalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.terminalSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.terminalSplitContainer.Name = "terminalSplitContainer";
			this.terminalSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// terminalSplitContainer.Panel1
			// 
			this.terminalSplitContainer.Panel1.Controls.Add(this.terminalClearButton);
			this.terminalSplitContainer.Panel1.Controls.Add(this.terminalCopyButton);
			this.terminalSplitContainer.Panel1.Controls.Add(this.terminalPanel);
			this.terminalSplitContainer.Panel1MinSize = 80;
			// 
			// terminalSplitContainer.Panel2
			// 
			this.terminalSplitContainer.Panel2.Controls.Add(this.terminalSendButton);
			this.terminalSplitContainer.Panel2.Controls.Add(this.label2);
			this.terminalSplitContainer.Panel2.Controls.Add(this.label1);
			this.terminalSplitContainer.Panel2.Controls.Add(this.terminalTextBox);
			this.terminalSplitContainer.Panel2MinSize = 80;
			this.terminalSplitContainer.Size = new System.Drawing.Size(664, 394);
			this.terminalSplitContainer.SplitterDistance = 283;
			this.terminalSplitContainer.TabIndex = 11;
			// 
			// terminalClearButton
			// 
			this.terminalClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.terminalClearButton.Location = new System.Drawing.Point(571, 41);
			this.terminalClearButton.Name = "terminalClearButton";
			this.terminalClearButton.Size = new System.Drawing.Size(85, 23);
			this.terminalClearButton.TabIndex = 11;
			this.terminalClearButton.Text = "Очистить";
			this.terminalClearButton.UseVisualStyleBackColor = true;
			this.terminalClearButton.Click += new System.EventHandler(this.terminalClearButton_Click);
			// 
			// terminalCopyButton
			// 
			this.terminalCopyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.terminalCopyButton.Location = new System.Drawing.Point(571, 3);
			this.terminalCopyButton.Name = "terminalCopyButton";
			this.terminalCopyButton.Size = new System.Drawing.Size(85, 23);
			this.terminalCopyButton.TabIndex = 10;
			this.terminalCopyButton.Text = "Копировать";
			this.terminalCopyButton.UseVisualStyleBackColor = true;
			this.terminalCopyButton.Click += new System.EventHandler(this.terminalCopyButton_Click);
			// 
			// terminalPanel
			// 
			this.terminalPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.terminalPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.terminalPanel.Controls.Add(this.terminalRichTextBox);
			this.terminalPanel.Location = new System.Drawing.Point(3, 3);
			this.terminalPanel.Margin = new System.Windows.Forms.Padding(0);
			this.terminalPanel.Name = "terminalPanel";
			this.terminalPanel.Padding = new System.Windows.Forms.Padding(8);
			this.terminalPanel.Size = new System.Drawing.Size(562, 280);
			this.terminalPanel.TabIndex = 9;
			// 
			// terminalRichTextBox
			// 
			this.terminalRichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.terminalRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.terminalRichTextBox.DetectUrls = false;
			this.terminalRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.terminalRichTextBox.Font = new System.Drawing.Font("Courier New", 10F);
			this.terminalRichTextBox.ForeColor = System.Drawing.Color.LightGray;
			this.terminalRichTextBox.Location = new System.Drawing.Point(8, 8);
			this.terminalRichTextBox.Name = "terminalRichTextBox";
			this.terminalRichTextBox.ReadOnly = true;
			this.terminalRichTextBox.ShortcutsEnabled = false;
			this.terminalRichTextBox.Size = new System.Drawing.Size(546, 264);
			this.terminalRichTextBox.TabIndex = 2;
			this.terminalRichTextBox.Text = "";
			this.terminalRichTextBox.WordWrap = false;
			// 
			// terminalSendButton
			// 
			this.terminalSendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.terminalSendButton.Enabled = false;
			this.terminalSendButton.Location = new System.Drawing.Point(571, 3);
			this.terminalSendButton.Name = "terminalSendButton";
			this.terminalSendButton.Size = new System.Drawing.Size(85, 23);
			this.terminalSendButton.TabIndex = 12;
			this.terminalSendButton.Text = "Отправить";
			this.terminalSendButton.UseVisualStyleBackColor = true;
			this.terminalSendButton.Click += new System.EventHandler(this.terminalSendButton_Click);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Enabled = false;
			this.label2.Location = new System.Drawing.Point(571, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "... Enter »";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Enabled = false;
			this.label1.Location = new System.Drawing.Point(571, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(142, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "... Shift + Enter\\r... Enter »";
			// 
			// terminalTextBox
			// 
			this.terminalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.terminalTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.terminalTextBox.Enabled = false;
			this.terminalTextBox.Location = new System.Drawing.Point(3, 3);
			this.terminalTextBox.Multiline = true;
			this.terminalTextBox.Name = "terminalTextBox";
			this.terminalTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.terminalTextBox.ShortcutsEnabled = false;
			this.terminalTextBox.Size = new System.Drawing.Size(562, 101);
			this.terminalTextBox.TabIndex = 11;
			this.terminalTextBox.WordWrap = false;
			this.terminalTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.terminalTextBox_KeyDown);
			this.terminalTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.terminalTextBox_KeyUp);
			// 
			// paramsTabPage
			// 
			this.paramsTabPage.Controls.Add(this.paramsSplitContainer);
			this.paramsTabPage.Location = new System.Drawing.Point(24, 4);
			this.paramsTabPage.Margin = new System.Windows.Forms.Padding(0);
			this.paramsTabPage.Name = "paramsTabPage";
			this.paramsTabPage.Size = new System.Drawing.Size(664, 394);
			this.paramsTabPage.TabIndex = 0;
			this.paramsTabPage.Text = "Параметры";
			this.paramsTabPage.UseVisualStyleBackColor = true;
			// 
			// paramsSplitContainer
			// 
			this.paramsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.paramsSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.paramsSplitContainer.Margin = new System.Windows.Forms.Padding(0);
			this.paramsSplitContainer.Name = "paramsSplitContainer";
			// 
			// paramsSplitContainer.Panel1
			// 
			this.paramsSplitContainer.Panel1.Controls.Add(this.groupsListView);
			// 
			// paramsSplitContainer.Panel2
			// 
			this.paramsSplitContainer.Panel2.Controls.Add(this.paramsListView);
			this.paramsSplitContainer.Size = new System.Drawing.Size(664, 394);
			this.paramsSplitContainer.SplitterDistance = 200;
			this.paramsSplitContainer.TabIndex = 0;
			// 
			// groupsListView
			// 
			this.groupsListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.groupsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader4});
			this.groupsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupsListView.FullRowSelect = true;
			this.groupsListView.HideSelection = false;
			this.groupsListView.Location = new System.Drawing.Point(0, 0);
			this.groupsListView.MultiSelect = false;
			this.groupsListView.Name = "groupsListView";
			this.groupsListView.ShowGroups = false;
			this.groupsListView.ShowItemToolTips = true;
			this.groupsListView.Size = new System.Drawing.Size(200, 394);
			this.groupsListView.TabIndex = 0;
			this.groupsListView.UseCompatibleStateImageBehavior = false;
			this.groupsListView.View = System.Windows.Forms.View.Details;
			this.groupsListView.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.groupsListView_ColumnWidthChanged);
			this.groupsListView.SelectedIndexChanged += new System.EventHandler(this.groupsListView_SelectedIndexChanged);
			this.groupsListView.MouseEnter += new System.EventHandler(this.groupsListView_MouseEnter);
			this.groupsListView.Resize += new System.EventHandler(this.groupsListView_Resize);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "";
			this.columnHeader5.Width = 32;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Группы";
			// 
			// paramsListView
			// 
			this.paramsListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.paramsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.paramsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.paramsListView.FullRowSelect = true;
			this.paramsListView.Location = new System.Drawing.Point(0, 0);
			this.paramsListView.Margin = new System.Windows.Forms.Padding(0);
			this.paramsListView.MultiSelect = false;
			this.paramsListView.Name = "paramsListView";
			this.paramsListView.ShowGroups = false;
			this.paramsListView.Size = new System.Drawing.Size(460, 394);
			this.paramsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.paramsListView.TabIndex = 0;
			this.paramsListView.UseCompatibleStateImageBehavior = false;
			this.paramsListView.View = System.Windows.Forms.View.Details;
			this.paramsListView.DoubleClick += new System.EventHandler(this.paramsListView_DoubleClick);
			this.paramsListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.paramsListView_KeyDown);
			this.paramsListView.MouseEnter += new System.EventHandler(this.paramsListView_MouseEnter);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Индекс";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Описание";
			this.columnHeader2.Width = 230;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Значение";
			this.columnHeader3.Width = 150;
			// 
			// mainTabControl
			// 
			this.mainTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
			this.mainTabControl.Controls.Add(this.paramsTabPage);
			this.mainTabControl.Controls.Add(this.scopeTabPage);
			this.mainTabControl.Controls.Add(this.terminalTabPage);
			this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTabControl.Location = new System.Drawing.Point(0, 49);
			this.mainTabControl.Multiline = true;
			this.mainTabControl.Name = "mainTabControl";
			this.mainTabControl.SelectedIndex = 0;
			this.mainTabControl.Size = new System.Drawing.Size(692, 402);
			this.mainTabControl.TabIndex = 3;
			this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
			this.mainTabControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainTabControl_KeyDown);
			// 
			// scopeTabPage
			// 
			this.scopeTabPage.Controls.Add(this.scopeCanvasUC);
			this.scopeTabPage.Controls.Add(this.scopeToolStrip);
			this.scopeTabPage.Location = new System.Drawing.Point(24, 4);
			this.scopeTabPage.Margin = new System.Windows.Forms.Padding(0);
			this.scopeTabPage.Name = "scopeTabPage";
			this.scopeTabPage.Size = new System.Drawing.Size(664, 394);
			this.scopeTabPage.TabIndex = 1;
			this.scopeTabPage.Text = "Осциллограф";
			this.scopeTabPage.UseVisualStyleBackColor = true;
			// 
			// scopeCanvasUC
			// 
			this.scopeCanvasUC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scopeCanvasUC.Location = new System.Drawing.Point(0, 25);
			this.scopeCanvasUC.Name = "scopeCanvasUC";
			this.scopeCanvasUC.Size = new System.Drawing.Size(664, 369);
			this.scopeCanvasUC.TabIndex = 2;
			// 
			// scopeToolStrip
			// 
			this.scopeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scopeRecordToolStripButton,
            this.scopeStopToolStripButton,
            this.toolStripSeparator13,
            this.scopeNewToolStripButton,
            this.scopeOpenToolStripButton,
            this.toolStripSeparator14,
            this.scopeSaveAsToolStripButton,
            this.scopeSaveImageToolStripButton,
            this.toolStripSeparator12,
            this.scopeMeasureInToolStripButton,
            this.scopeMeasureXtoolStripTextBox,
            this.scopeMeasureOutToolStripButton,
            this.toolStripSeparator15,
            this.chAtoolStripButton,
            this.chBtoolStripButton,
            this.chCtoolStripButton,
            this.chDtoolStripButton,
            this.chEtoolStripButton,
            this.chFtoolStripButton,
            this.toolStripSeparator16,
            this.scopeCursor1ToolStripButton});
			this.scopeToolStrip.Location = new System.Drawing.Point(0, 0);
			this.scopeToolStrip.Name = "scopeToolStrip";
			this.scopeToolStrip.Size = new System.Drawing.Size(664, 25);
			this.scopeToolStrip.TabIndex = 1;
			this.scopeToolStrip.Text = "scopeToolStrip";
			// 
			// scopeRecordToolStripButton
			// 
			this.scopeRecordToolStripButton.Enabled = false;
			this.scopeRecordToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("scopeRecordToolStripButton.Image")));
			this.scopeRecordToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.scopeRecordToolStripButton.Name = "scopeRecordToolStripButton";
			this.scopeRecordToolStripButton.Size = new System.Drawing.Size(58, 22);
			this.scopeRecordToolStripButton.Text = "Старт";
			this.scopeRecordToolStripButton.Click += new System.EventHandler(this.scopeRecordToolStripButton_Click);
			// 
			// scopeStopToolStripButton
			// 
			this.scopeStopToolStripButton.Enabled = false;
			this.scopeStopToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("scopeStopToolStripButton.Image")));
			this.scopeStopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.scopeStopToolStripButton.Name = "scopeStopToolStripButton";
			this.scopeStopToolStripButton.Size = new System.Drawing.Size(52, 22);
			this.scopeStopToolStripButton.Text = "Стоп";
			this.scopeStopToolStripButton.Click += new System.EventHandler(this.scopeStopToolStripButton_Click);
			// 
			// scopeNewToolStripButton
			// 
			this.scopeNewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.scopeNewToolStripButton.Image = global::DriveASC.Properties.Resources.scope_new;
			this.scopeNewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.scopeNewToolStripButton.Name = "scopeNewToolStripButton";
			this.scopeNewToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.scopeNewToolStripButton.Text = "Новая осциллограмма";
			this.scopeNewToolStripButton.Click += new System.EventHandler(this.scopeNewToolStripButton_Click);
			// 
			// scopeOpenToolStripButton
			// 
			this.scopeOpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.scopeOpenToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("scopeOpenToolStripButton.Image")));
			this.scopeOpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.scopeOpenToolStripButton.Name = "scopeOpenToolStripButton";
			this.scopeOpenToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.scopeOpenToolStripButton.Text = "Открыть осциллограмму...";
			this.scopeOpenToolStripButton.Click += new System.EventHandler(this.scopeOpenToolStripButton_Click);
			// 
			// toolStripSeparator14
			// 
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
			// 
			// scopeSaveAsToolStripButton
			// 
			this.scopeSaveAsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.scopeSaveAsToolStripButton.Enabled = false;
			this.scopeSaveAsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("scopeSaveAsToolStripButton.Image")));
			this.scopeSaveAsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.scopeSaveAsToolStripButton.Name = "scopeSaveAsToolStripButton";
			this.scopeSaveAsToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.scopeSaveAsToolStripButton.Text = "Сохранить осциллограмму...";
			this.scopeSaveAsToolStripButton.Click += new System.EventHandler(this.scopeSaveAsToolStripButton_Click);
			// 
			// scopeSaveImageToolStripButton
			// 
			this.scopeSaveImageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.scopeSaveImageToolStripButton.Enabled = false;
			this.scopeSaveImageToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("scopeSaveImageToolStripButton.Image")));
			this.scopeSaveImageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.scopeSaveImageToolStripButton.Name = "scopeSaveImageToolStripButton";
			this.scopeSaveImageToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.scopeSaveImageToolStripButton.Text = "Сохранить картинку...";
			this.scopeSaveImageToolStripButton.Click += new System.EventHandler(this.scopeSaveImageToolStripButton_Click);
			// 
			// toolStripSeparator12
			// 
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
			// 
			// scopeMeasureInToolStripButton
			// 
			this.scopeMeasureInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.scopeMeasureInToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("scopeMeasureInToolStripButton.Image")));
			this.scopeMeasureInToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.scopeMeasureInToolStripButton.Name = "scopeMeasureInToolStripButton";
			this.scopeMeasureInToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.scopeMeasureInToolStripButton.Text = "Уменьшить мс/деление";
			this.scopeMeasureInToolStripButton.Click += new System.EventHandler(this.scopeMeasureInToolStripButton_Click);
			// 
			// scopeMeasureXtoolStripTextBox
			// 
			this.scopeMeasureXtoolStripTextBox.Name = "scopeMeasureXtoolStripTextBox";
			this.scopeMeasureXtoolStripTextBox.Size = new System.Drawing.Size(50, 25);
			this.scopeMeasureXtoolStripTextBox.Text = "1000";
			this.scopeMeasureXtoolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.scopeMeasureXtoolStripTextBox.ToolTipText = "Масштаб по горизонтали, мс/деление";
			this.scopeMeasureXtoolStripTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.scopeHMeasureToolStripTextBox_KeyUp);
			// 
			// scopeMeasureOutToolStripButton
			// 
			this.scopeMeasureOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.scopeMeasureOutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("scopeMeasureOutToolStripButton.Image")));
			this.scopeMeasureOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.scopeMeasureOutToolStripButton.Name = "scopeMeasureOutToolStripButton";
			this.scopeMeasureOutToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.scopeMeasureOutToolStripButton.Text = "Увеличить мс/деление";
			this.scopeMeasureOutToolStripButton.Click += new System.EventHandler(this.scopeMeasureOutToolStripButton_Click);
			// 
			// toolStripSeparator15
			// 
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
			// 
			// chAtoolStripButton
			// 
			this.chAtoolStripButton.BackColor = System.Drawing.SystemColors.Control;
			this.chAtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.chAtoolStripButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chAtoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("chAtoolStripButton.Image")));
			this.chAtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.chAtoolStripButton.Name = "chAtoolStripButton";
			this.chAtoolStripButton.Size = new System.Drawing.Size(23, 22);
			this.chAtoolStripButton.Tag = "0";
			this.chAtoolStripButton.Text = "A";
			this.chAtoolStripButton.ToolTipText = "Канал A";
			this.chAtoolStripButton.Click += new System.EventHandler(this.chAtoolStripButton_Click);
			// 
			// chBtoolStripButton
			// 
			this.chBtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.chBtoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("chBtoolStripButton.Image")));
			this.chBtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.chBtoolStripButton.Name = "chBtoolStripButton";
			this.chBtoolStripButton.Size = new System.Drawing.Size(23, 22);
			this.chBtoolStripButton.Tag = "1";
			this.chBtoolStripButton.Text = "B";
			this.chBtoolStripButton.ToolTipText = "Канал B";
			this.chBtoolStripButton.Click += new System.EventHandler(this.chAtoolStripButton_Click);
			// 
			// chCtoolStripButton
			// 
			this.chCtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.chCtoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("chCtoolStripButton.Image")));
			this.chCtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.chCtoolStripButton.Name = "chCtoolStripButton";
			this.chCtoolStripButton.Size = new System.Drawing.Size(23, 22);
			this.chCtoolStripButton.Tag = "2";
			this.chCtoolStripButton.Text = "C";
			this.chCtoolStripButton.ToolTipText = "Канал C";
			this.chCtoolStripButton.Click += new System.EventHandler(this.chAtoolStripButton_Click);
			// 
			// chDtoolStripButton
			// 
			this.chDtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.chDtoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("chDtoolStripButton.Image")));
			this.chDtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.chDtoolStripButton.Name = "chDtoolStripButton";
			this.chDtoolStripButton.Size = new System.Drawing.Size(23, 22);
			this.chDtoolStripButton.Tag = "3";
			this.chDtoolStripButton.Text = "D";
			this.chDtoolStripButton.ToolTipText = "Канал D";
			this.chDtoolStripButton.Click += new System.EventHandler(this.chAtoolStripButton_Click);
			// 
			// chEtoolStripButton
			// 
			this.chEtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.chEtoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("chEtoolStripButton.Image")));
			this.chEtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.chEtoolStripButton.Name = "chEtoolStripButton";
			this.chEtoolStripButton.Size = new System.Drawing.Size(23, 22);
			this.chEtoolStripButton.Tag = "4";
			this.chEtoolStripButton.Text = "E";
			this.chEtoolStripButton.ToolTipText = "Канал E";
			this.chEtoolStripButton.Click += new System.EventHandler(this.chAtoolStripButton_Click);
			// 
			// chFtoolStripButton
			// 
			this.chFtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.chFtoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("chFtoolStripButton.Image")));
			this.chFtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.chFtoolStripButton.Name = "chFtoolStripButton";
			this.chFtoolStripButton.Size = new System.Drawing.Size(23, 22);
			this.chFtoolStripButton.Tag = "5";
			this.chFtoolStripButton.Text = "F";
			this.chFtoolStripButton.ToolTipText = "Канал F";
			this.chFtoolStripButton.Click += new System.EventHandler(this.chAtoolStripButton_Click);
			// 
			// toolStripSeparator16
			// 
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
			// 
			// scopeCursor1ToolStripButton
			// 
			this.scopeCursor1ToolStripButton.CheckOnClick = true;
			this.scopeCursor1ToolStripButton.Image = global::DriveASC.Properties.Resources.scope_cursor_1;
			this.scopeCursor1ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.scopeCursor1ToolStripButton.Name = "scopeCursor1ToolStripButton";
			this.scopeCursor1ToolStripButton.Size = new System.Drawing.Size(63, 22);
			this.scopeCursor1ToolStripButton.Text = "Курсор";
			this.scopeCursor1ToolStripButton.ToolTipText = "Скрыть или показать курсор";
			this.scopeCursor1ToolStripButton.Click += new System.EventHandler(this.scopeCursor1ToolStripButton_Click);
			// 
			// scopeSaveImageFileDialog
			// 
			this.scopeSaveImageFileDialog.DefaultExt = "png";
			this.scopeSaveImageFileDialog.Filter = "Картинка в формате PNG (*.png)|*.png";
			this.scopeSaveImageFileDialog.RestoreDirectory = true;
			this.scopeSaveImageFileDialog.SupportMultiDottedExtensions = true;
			// 
			// scopeOpenFileDialog
			// 
			this.scopeOpenFileDialog.DefaultExt = "scope";
			this.scopeOpenFileDialog.Filter = "Файлы осциллографа DriveASC (*.scope)|*.scope|Файлы осциллографа DriveGUI (*.csv)" +
    "|*.csv";
			this.scopeOpenFileDialog.RestoreDirectory = true;
			this.scopeOpenFileDialog.SupportMultiDottedExtensions = true;
			// 
			// scopeSaveAsFileDialog
			// 
			this.scopeSaveAsFileDialog.DefaultExt = "scope";
			this.scopeSaveAsFileDialog.Filter = "Файлы осциллографа DriveASC (*.scope)|*.scope";
			this.scopeSaveAsFileDialog.RestoreDirectory = true;
			this.scopeSaveAsFileDialog.SupportMultiDottedExtensions = true;
			// 
			// toolStripSeparator13
			// 
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(692, 473);
			this.Controls.Add(this.mainTabControl);
			this.Controls.Add(this.mainStatusStrip);
			this.Controls.Add(this.mainToolStrip);
			this.Controls.Add(this.mainMenuStrip);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mainMenuStrip;
			this.MinimumSize = new System.Drawing.Size(560, 320);
			this.Name = "MainForm";
			this.Text = "DriveASC";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
			this.Move += new System.EventHandler(this.MainForm_Move);
			this.mainMenuStrip.ResumeLayout(false);
			this.mainMenuStrip.PerformLayout();
			this.mainToolStrip.ResumeLayout(false);
			this.mainToolStrip.PerformLayout();
			this.mainStatusStrip.ResumeLayout(false);
			this.mainStatusStrip.PerformLayout();
			this.terminalTabPage.ResumeLayout(false);
			this.terminalSplitContainer.Panel1.ResumeLayout(false);
			this.terminalSplitContainer.Panel2.ResumeLayout(false);
			this.terminalSplitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.terminalSplitContainer)).EndInit();
			this.terminalSplitContainer.ResumeLayout(false);
			this.terminalPanel.ResumeLayout(false);
			this.paramsTabPage.ResumeLayout(false);
			this.paramsSplitContainer.Panel1.ResumeLayout(false);
			this.paramsSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.paramsSplitContainer)).EndInit();
			this.paramsSplitContainer.ResumeLayout(false);
			this.mainTabControl.ResumeLayout(false);
			this.scopeTabPage.ResumeLayout(false);
			this.scopeTabPage.PerformLayout();
			this.scopeToolStrip.ResumeLayout(false);
			this.scopeToolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mainMenuStrip;
		private System.Windows.Forms.ToolStrip mainToolStrip;
		private System.Windows.Forms.StatusStrip mainStatusStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem parametersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scopeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem terminalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem transmitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem comPortToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem driveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton saveEepromToolStripButton;
		private System.Windows.Forms.ToolStripButton rstvarToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton softEnToolStripButton;
		private System.Windows.Forms.ToolStripButton softDisToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripStatusLabel driveNameStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel portNameStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel driveStateStatusLabel;
		private System.Windows.Forms.ToolStripMenuItem contentsHelpToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem aboutDriveAscToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripButton coldstartToolStripButton;
		private System.Windows.Forms.ToolStripButton disconnectToolStripButton;
		private System.Windows.Forms.ToolStripButton connectToolStripButton;
		private System.Windows.Forms.ToolStripLabel connectionStateStripLabel;
		private System.Windows.Forms.Timer reconnectTimer;
		private System.Windows.Forms.ToolStripButton sw2ParametersToolStripButton;
		private System.Windows.Forms.ToolStripButton sw2ScopeToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem templateToolStripMenuItem;
		private System.Windows.Forms.Timer updateTimer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripMenuItem paramDescriptionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem paramDescDescToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem paramDescAsciiToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem paramDescFullToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem coldstartToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripMenuItem softEnToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem softDisToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveEepromToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rstvarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.TabPage terminalTabPage;
		private System.Windows.Forms.SplitContainer terminalSplitContainer;
		private System.Windows.Forms.Button terminalClearButton;
		private System.Windows.Forms.Button terminalCopyButton;
		private System.Windows.Forms.Panel terminalPanel;
		private System.Windows.Forms.RichTextBox terminalRichTextBox;
		private System.Windows.Forms.Button terminalSendButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox terminalTextBox;
		private System.Windows.Forms.TabPage paramsTabPage;
		private System.Windows.Forms.SplitContainer paramsSplitContainer;
		private ListViewEx groupsListView;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private ListViewEx paramsListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.TabPage scopeTabPage;
		private System.Windows.Forms.ToolStrip scopeToolStrip;
		private System.Windows.Forms.ToolStripButton scopeSaveAsToolStripButton;
		private System.Windows.Forms.ToolStripButton scopeSaveImageToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
		private System.Windows.Forms.ToolStripButton scopeOpenToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
		private System.Windows.Forms.ToolStripButton scopeMeasureInToolStripButton;
		private System.Windows.Forms.ToolStripTextBox scopeMeasureXtoolStripTextBox;
		private System.Windows.Forms.ToolStripButton scopeMeasureOutToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
		private System.Windows.Forms.ToolStripButton scopeRecordToolStripButton;
		private System.Windows.Forms.ToolStripButton scopeStopToolStripButton;
		private System.Windows.Forms.ToolStripButton chAtoolStripButton;
		private System.Windows.Forms.ToolStripButton chBtoolStripButton;
		private System.Windows.Forms.ToolStripButton chCtoolStripButton;
		private System.Windows.Forms.ToolStripButton chDtoolStripButton;
		private System.Windows.Forms.ToolStripButton chEtoolStripButton;
		private System.Windows.Forms.ToolStripButton chFtoolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
		private System.Windows.Forms.ToolStripButton scopeCursor1ToolStripButton;
		private ScopeCanvasUC scopeCanvasUC;
		private System.Windows.Forms.SaveFileDialog scopeSaveImageFileDialog;
		private System.Windows.Forms.ToolStripStatusLabel softLockToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel appLockToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel errToolStripStatusLabel;
		private System.Windows.Forms.ToolStripButton clearFaultToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem clearFaultToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog scopeOpenFileDialog;
		private System.Windows.Forms.SaveFileDialog scopeSaveAsFileDialog;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem openScopeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsScopeToolStripMenuItem;
		public System.Windows.Forms.TabControl mainTabControl;
		private System.Windows.Forms.ToolStripButton scopeNewToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem newScopeToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
		private System.Windows.Forms.ToolStripButton errorsToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
		private System.Windows.Forms.ToolStripMenuItem errorsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
		private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
		private System.Windows.Forms.ToolStripMenuItem paramSmoothToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem paramSmoothFastToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem paramSmoothAAToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem paramSmoothPreciseToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel stoLockToolStripStatusLabel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
	}
}


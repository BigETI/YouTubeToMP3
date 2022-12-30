namespace YouTubeToMP3.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.startDownloadingButton = new System.Windows.Forms.Button();
            this.browseAtYouTubeButton = new System.Windows.Forms.Button();
            this.urlsDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinationPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isEnabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.etaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.urlDataSet = new System.Data.DataSet();
            this.urlDataTable = new System.Data.DataTable();
            this.isEnabled = new System.Data.DataColumn();
            this.url = new System.Data.DataColumn();
            this.status = new System.Data.DataColumn();
            this.titleDataColumn = new System.Data.DataColumn();
            this.statusDataColumn = new System.Data.DataColumn();
            this.progressDataColumn = new System.Data.DataColumn();
            this.sizeDataColumn = new System.Data.DataColumn();
            this.speedDataColumn = new System.Data.DataColumn();
            this.etaDataColumn = new System.Data.DataColumn();
            this.timeDataColumn = new System.Data.DataColumn();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadURLsFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadURLsFromFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadURLsFromAnInternetResourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveURLsAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remainingEnabledEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlyHighlightedAndEnabledEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.everythingEnabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableEverythingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableEverythingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.pasteURLsFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeHighlightedEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.fetchInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseAtYouTubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automaticallyAddURLsFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automaticallyFetchVideoInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateAtKofiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.browseYouTubePictureBox = new System.Windows.Forms.PictureBox();
            this.loadURLsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.loadURLsFromFilePictureBox = new System.Windows.Forms.PictureBox();
            this.loadURLsFromAnInternetResourcePictureBox = new System.Windows.Forms.PictureBox();
            this.urlsOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.urlsSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.gitHubRepositoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mainPanel.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.buttonsFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.urlsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urlsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urlDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urlDataTable)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.startupTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browseYouTubePictureBox)).BeginInit();
            this.loadURLsTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadURLsFromFilePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadURLsFromAnInternetResourcePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.mainTableLayoutPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 426);
            this.mainPanel.TabIndex = 0;
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 1;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.buttonsFlowLayoutPanel, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.urlsDataGridView, 0, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(800, 426);
            this.mainTableLayoutPanel.TabIndex = 5;
            // 
            // buttonsFlowLayoutPanel
            // 
            this.buttonsFlowLayoutPanel.Controls.Add(this.startDownloadingButton);
            this.buttonsFlowLayoutPanel.Controls.Add(this.browseAtYouTubeButton);
            this.buttonsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonsFlowLayoutPanel.Location = new System.Drawing.Point(0, 397);
            this.buttonsFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonsFlowLayoutPanel.Name = "buttonsFlowLayoutPanel";
            this.buttonsFlowLayoutPanel.Size = new System.Drawing.Size(800, 29);
            this.buttonsFlowLayoutPanel.TabIndex = 3;
            // 
            // startDownloadingButton
            // 
            this.startDownloadingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startDownloadingButton.Enabled = false;
            this.startDownloadingButton.Location = new System.Drawing.Point(3, 3);
            this.startDownloadingButton.Name = "startDownloadingButton";
            this.startDownloadingButton.Size = new System.Drawing.Size(120, 23);
            this.startDownloadingButton.TabIndex = 1;
            this.startDownloadingButton.Text = "Start downloading";
            this.startDownloadingButton.UseVisualStyleBackColor = true;
            this.startDownloadingButton.Click += new System.EventHandler(this.StartDownloadingButtonClickEvent);
            // 
            // browseAtYouTubeButton
            // 
            this.browseAtYouTubeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.browseAtYouTubeButton.Location = new System.Drawing.Point(129, 3);
            this.browseAtYouTubeButton.Name = "browseAtYouTubeButton";
            this.browseAtYouTubeButton.Size = new System.Drawing.Size(120, 23);
            this.browseAtYouTubeButton.TabIndex = 3;
            this.browseAtYouTubeButton.Text = "Browse at YouTube";
            this.browseAtYouTubeButton.UseVisualStyleBackColor = true;
            this.browseAtYouTubeButton.Click += new System.EventHandler(this.BrowseAtYouTubeButtonClickEvent);
            // 
            // urlsDataGridView
            // 
            this.urlsDataGridView.AllowUserToAddRows = false;
            this.urlsDataGridView.AllowUserToDeleteRows = false;
            this.urlsDataGridView.AllowUserToResizeColumns = false;
            this.urlsDataGridView.AllowUserToResizeRows = false;
            this.urlsDataGridView.AutoGenerateColumns = false;
            this.urlsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.urlsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.urlsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.destinationPathDataGridViewTextBoxColumn,
            this.isEnabledDataGridViewCheckBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.progressDataGridViewTextBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.speedDataGridViewTextBoxColumn,
            this.etaDataGridViewTextBoxColumn,
            this.timeDataGridViewTextBoxColumn});
            this.urlsDataGridView.DataSource = this.urlsBindingSource;
            this.urlsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.urlsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.urlsDataGridView.Name = "urlsDataGridView";
            this.urlsDataGridView.ReadOnly = true;
            this.urlsDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.urlsDataGridView.RowHeadersVisible = false;
            this.urlsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.urlsDataGridView.Size = new System.Drawing.Size(794, 391);
            this.urlsDataGridView.TabIndex = 0;
            this.urlsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.URLsDataGridViewCellClickEvent);
            this.urlsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.URLsDataGridViewCellDoubleClickEvent);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // destinationPathDataGridViewTextBoxColumn
            // 
            this.destinationPathDataGridViewTextBoxColumn.DataPropertyName = "destinationPath";
            this.destinationPathDataGridViewTextBoxColumn.HeaderText = "destinationPath";
            this.destinationPathDataGridViewTextBoxColumn.Name = "destinationPathDataGridViewTextBoxColumn";
            this.destinationPathDataGridViewTextBoxColumn.ReadOnly = true;
            this.destinationPathDataGridViewTextBoxColumn.Visible = false;
            // 
            // isEnabledDataGridViewCheckBoxColumn
            // 
            this.isEnabledDataGridViewCheckBoxColumn.DataPropertyName = "isEnabled";
            this.isEnabledDataGridViewCheckBoxColumn.HeaderText = "";
            this.isEnabledDataGridViewCheckBoxColumn.Name = "isEnabledDataGridViewCheckBoxColumn";
            this.isEnabledDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isEnabledDataGridViewCheckBoxColumn.Width = 20;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.FillWeight = 40F;
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.FillWeight = 10F;
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // progressDataGridViewTextBoxColumn
            // 
            this.progressDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.progressDataGridViewTextBoxColumn.DataPropertyName = "progress";
            this.progressDataGridViewTextBoxColumn.FillWeight = 10F;
            this.progressDataGridViewTextBoxColumn.HeaderText = "Progress";
            this.progressDataGridViewTextBoxColumn.Name = "progressDataGridViewTextBoxColumn";
            this.progressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            this.sizeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sizeDataGridViewTextBoxColumn.DataPropertyName = "size";
            this.sizeDataGridViewTextBoxColumn.FillWeight = 10F;
            this.sizeDataGridViewTextBoxColumn.HeaderText = "Size";
            this.sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            this.sizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // speedDataGridViewTextBoxColumn
            // 
            this.speedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.speedDataGridViewTextBoxColumn.DataPropertyName = "speed";
            this.speedDataGridViewTextBoxColumn.FillWeight = 10F;
            this.speedDataGridViewTextBoxColumn.HeaderText = "Speed";
            this.speedDataGridViewTextBoxColumn.Name = "speedDataGridViewTextBoxColumn";
            this.speedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // etaDataGridViewTextBoxColumn
            // 
            this.etaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.etaDataGridViewTextBoxColumn.DataPropertyName = "eta";
            this.etaDataGridViewTextBoxColumn.FillWeight = 10F;
            this.etaDataGridViewTextBoxColumn.HeaderText = "ETA";
            this.etaDataGridViewTextBoxColumn.Name = "etaDataGridViewTextBoxColumn";
            this.etaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "time";
            this.timeDataGridViewTextBoxColumn.FillWeight = 10F;
            this.timeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            this.timeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // urlsBindingSource
            // 
            this.urlsBindingSource.DataMember = "URLs";
            this.urlsBindingSource.DataSource = this.urlDataSet;
            // 
            // urlDataSet
            // 
            this.urlDataSet.CaseSensitive = true;
            this.urlDataSet.DataSetName = "URLDataSet";
            this.urlDataSet.Locale = new System.Globalization.CultureInfo("en-US");
            this.urlDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.urlDataTable});
            // 
            // urlDataTable
            // 
            this.urlDataTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.isEnabled,
            this.url,
            this.status,
            this.titleDataColumn,
            this.statusDataColumn,
            this.progressDataColumn,
            this.sizeDataColumn,
            this.speedDataColumn,
            this.etaDataColumn,
            this.timeDataColumn});
            this.urlDataTable.TableName = "URLs";
            // 
            // isEnabled
            // 
            this.isEnabled.AllowDBNull = false;
            this.isEnabled.Caption = "";
            this.isEnabled.ColumnName = "id";
            this.isEnabled.DefaultValue = "";
            // 
            // url
            // 
            this.url.AllowDBNull = false;
            this.url.Caption = "";
            this.url.ColumnName = "destinationPath";
            this.url.DefaultValue = "";
            // 
            // status
            // 
            this.status.AllowDBNull = false;
            this.status.Caption = "";
            this.status.ColumnName = "isEnabled";
            this.status.DataType = typeof(bool);
            this.status.DefaultValue = true;
            // 
            // titleDataColumn
            // 
            this.titleDataColumn.AllowDBNull = false;
            this.titleDataColumn.Caption = "Title";
            this.titleDataColumn.ColumnName = "title";
            this.titleDataColumn.DefaultValue = "";
            // 
            // statusDataColumn
            // 
            this.statusDataColumn.AllowDBNull = false;
            this.statusDataColumn.Caption = "Status";
            this.statusDataColumn.ColumnName = "status";
            this.statusDataColumn.DefaultValue = "Added";
            // 
            // progressDataColumn
            // 
            this.progressDataColumn.AllowDBNull = false;
            this.progressDataColumn.Caption = "Progress";
            this.progressDataColumn.ColumnName = "progress";
            this.progressDataColumn.DefaultValue = "";
            // 
            // sizeDataColumn
            // 
            this.sizeDataColumn.AllowDBNull = false;
            this.sizeDataColumn.Caption = "Size";
            this.sizeDataColumn.ColumnName = "size";
            this.sizeDataColumn.DefaultValue = "";
            // 
            // speedDataColumn
            // 
            this.speedDataColumn.AllowDBNull = false;
            this.speedDataColumn.Caption = "Speed";
            this.speedDataColumn.ColumnName = "speed";
            this.speedDataColumn.DefaultValue = "";
            // 
            // etaDataColumn
            // 
            this.etaDataColumn.AllowDBNull = false;
            this.etaDataColumn.Caption = "ETA";
            this.etaDataColumn.ColumnName = "eta";
            this.etaDataColumn.DefaultValue = "";
            // 
            // timeDataColumn
            // 
            this.timeDataColumn.AllowDBNull = false;
            this.timeDataColumn.Caption = "Time";
            this.timeDataColumn.ColumnName = "time";
            this.timeDataColumn.DefaultValue = "";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.TimerTickEvent);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadURLsFromToolStripMenuItem,
            this.saveURLsAsToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadURLsFromToolStripMenuItem
            // 
            this.loadURLsFromToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadURLsFromFilesToolStripMenuItem,
            this.loadURLsFromAnInternetResourceToolStripMenuItem});
            this.loadURLsFromToolStripMenuItem.Name = "loadURLsFromToolStripMenuItem";
            this.loadURLsFromToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.loadURLsFromToolStripMenuItem.Text = "Load URLs from...";
            // 
            // loadURLsFromFilesToolStripMenuItem
            // 
            this.loadURLsFromFilesToolStripMenuItem.Name = "loadURLsFromFilesToolStripMenuItem";
            this.loadURLsFromFilesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadURLsFromFilesToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.loadURLsFromFilesToolStripMenuItem.Text = "Files";
            this.loadURLsFromFilesToolStripMenuItem.Click += new System.EventHandler(this.LoadURLsFromFilesToolStripMenuItemClickEvent);
            // 
            // loadURLsFromAnInternetResourceToolStripMenuItem
            // 
            this.loadURLsFromAnInternetResourceToolStripMenuItem.Name = "loadURLsFromAnInternetResourceToolStripMenuItem";
            this.loadURLsFromAnInternetResourceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.loadURLsFromAnInternetResourceToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.loadURLsFromAnInternetResourceToolStripMenuItem.Text = "Internet resource";
            this.loadURLsFromAnInternetResourceToolStripMenuItem.Click += new System.EventHandler(this.LoadURLsFromAnInternetResourceToolStripMenuItemClickEvent);
            // 
            // saveURLsAsToolStripMenuItem
            // 
            this.saveURLsAsToolStripMenuItem.Name = "saveURLsAsToolStripMenuItem";
            this.saveURLsAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveURLsAsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.saveURLsAsToolStripMenuItem.Text = "Save URLs as...";
            this.saveURLsAsToolStripMenuItem.Click += new System.EventHandler(this.SaveURLsAsToolStripMenuItemClickEvent);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remainingEnabledEntriesToolStripMenuItem,
            this.onlyHighlightedAndEnabledEntriesToolStripMenuItem,
            this.everythingEnabledToolStripMenuItem});
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.downloadToolStripMenuItem.Text = "Download...";
            // 
            // remainingEnabledEntriesToolStripMenuItem
            // 
            this.remainingEnabledEntriesToolStripMenuItem.Name = "remainingEnabledEntriesToolStripMenuItem";
            this.remainingEnabledEntriesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.remainingEnabledEntriesToolStripMenuItem.Size = new System.Drawing.Size(395, 22);
            this.remainingEnabledEntriesToolStripMenuItem.Text = "Remaining enabled entries";
            this.remainingEnabledEntriesToolStripMenuItem.Click += new System.EventHandler(this.DownloadRemainingSelectedEntriesToolStripMenuItemClickEvent);
            // 
            // onlyHighlightedAndEnabledEntriesToolStripMenuItem
            // 
            this.onlyHighlightedAndEnabledEntriesToolStripMenuItem.Name = "onlyHighlightedAndEnabledEntriesToolStripMenuItem";
            this.onlyHighlightedAndEnabledEntriesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.onlyHighlightedAndEnabledEntriesToolStripMenuItem.Size = new System.Drawing.Size(395, 22);
            this.onlyHighlightedAndEnabledEntriesToolStripMenuItem.Text = "Only highlighted and enabled entries";
            this.onlyHighlightedAndEnabledEntriesToolStripMenuItem.Click += new System.EventHandler(this.DownloadOnlyHighlightedAndEnabledEntriesToolStripMenuItemClickEvent);
            // 
            // everythingEnabledToolStripMenuItem
            // 
            this.everythingEnabledToolStripMenuItem.Name = "everythingEnabledToolStripMenuItem";
            this.everythingEnabledToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.R)));
            this.everythingEnabledToolStripMenuItem.Size = new System.Drawing.Size(395, 22);
            this.everythingEnabledToolStripMenuItem.Text = "Everything enabled";
            this.everythingEnabledToolStripMenuItem.Click += new System.EventHandler(this.DownloadEverythingEnabledToolStripMenuItemClickEvent);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClickEvent);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableEverythingToolStripMenuItem,
            this.disableEverythingToolStripMenuItem,
            this.toolStripSeparator3,
            this.pasteURLsFromClipboardToolStripMenuItem,
            this.removeHighlightedEntriesToolStripMenuItem,
            this.toolStripSeparator4,
            this.fetchInformationToolStripMenuItem,
            this.toolStripSeparator1,
            this.preferencesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // enableEverythingToolStripMenuItem
            // 
            this.enableEverythingToolStripMenuItem.Enabled = false;
            this.enableEverythingToolStripMenuItem.Name = "enableEverythingToolStripMenuItem";
            this.enableEverythingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.enableEverythingToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.enableEverythingToolStripMenuItem.Text = "Enable everything";
            this.enableEverythingToolStripMenuItem.Click += new System.EventHandler(this.EnableEverythingToolStripMenuItemClickEvent);
            // 
            // disableEverythingToolStripMenuItem
            // 
            this.disableEverythingToolStripMenuItem.Enabled = false;
            this.disableEverythingToolStripMenuItem.Name = "disableEverythingToolStripMenuItem";
            this.disableEverythingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.A)));
            this.disableEverythingToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.disableEverythingToolStripMenuItem.Text = "Disable everything";
            this.disableEverythingToolStripMenuItem.Click += new System.EventHandler(this.DisableEverythingToolStripMenuItemClickEvent);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(292, 6);
            // 
            // pasteURLsFromClipboardToolStripMenuItem
            // 
            this.pasteURLsFromClipboardToolStripMenuItem.Name = "pasteURLsFromClipboardToolStripMenuItem";
            this.pasteURLsFromClipboardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteURLsFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.pasteURLsFromClipboardToolStripMenuItem.Text = "Paste URLs from clipboard";
            this.pasteURLsFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.PasteURLsFromClipboardToolStripMenuItemClickEvent);
            // 
            // removeHighlightedEntriesToolStripMenuItem
            // 
            this.removeHighlightedEntriesToolStripMenuItem.Enabled = false;
            this.removeHighlightedEntriesToolStripMenuItem.Name = "removeHighlightedEntriesToolStripMenuItem";
            this.removeHighlightedEntriesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.removeHighlightedEntriesToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.removeHighlightedEntriesToolStripMenuItem.Text = "Remove highlighted entries";
            this.removeHighlightedEntriesToolStripMenuItem.Click += new System.EventHandler(this.RemoveHighlightedEntriesToolStripMenuItemClickEvent);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(292, 6);
            // 
            // fetchInformationToolStripMenuItem
            // 
            this.fetchInformationToolStripMenuItem.Name = "fetchInformationToolStripMenuItem";
            this.fetchInformationToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.fetchInformationToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.fetchInformationToolStripMenuItem.Text = "Fetch information";
            this.fetchInformationToolStripMenuItem.Click += new System.EventHandler(this.FetchInformationToolStripMenuItemClickEvent);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(292, 6);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.PreferencesToolStripMenuItemClickEvent);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInExplorerToolStripMenuItem,
            this.browseAtYouTubeToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showInExplorerToolStripMenuItem
            // 
            this.showInExplorerToolStripMenuItem.Name = "showInExplorerToolStripMenuItem";
            this.showInExplorerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.showInExplorerToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.showInExplorerToolStripMenuItem.Text = "Show in explorer";
            this.showInExplorerToolStripMenuItem.Click += new System.EventHandler(this.ShowInExplorerToolStripMenuItemClickEvent);
            // 
            // browseAtYouTubeToolStripMenuItem
            // 
            this.browseAtYouTubeToolStripMenuItem.Name = "browseAtYouTubeToolStripMenuItem";
            this.browseAtYouTubeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.browseAtYouTubeToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.browseAtYouTubeToolStripMenuItem.Text = "Browse at YouTube";
            this.browseAtYouTubeToolStripMenuItem.Click += new System.EventHandler(this.BrowseAtYouTubeToolStripMenuItemClickEvent);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.automaticallyAddURLsFromClipboardToolStripMenuItem,
            this.automaticallyFetchVideoInformationToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // automaticallyAddURLsFromClipboardToolStripMenuItem
            // 
            this.automaticallyAddURLsFromClipboardToolStripMenuItem.Checked = true;
            this.automaticallyAddURLsFromClipboardToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.automaticallyAddURLsFromClipboardToolStripMenuItem.Name = "automaticallyAddURLsFromClipboardToolStripMenuItem";
            this.automaticallyAddURLsFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.automaticallyAddURLsFromClipboardToolStripMenuItem.Text = "Automatically add URLs from clipboard";
            this.automaticallyAddURLsFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.AutomaticallyAddURLsFromClipboardToolStripMenuItemClickEvent);
            // 
            // automaticallyFetchVideoInformationToolStripMenuItem
            // 
            this.automaticallyFetchVideoInformationToolStripMenuItem.Checked = true;
            this.automaticallyFetchVideoInformationToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.automaticallyFetchVideoInformationToolStripMenuItem.Name = "automaticallyFetchVideoInformationToolStripMenuItem";
            this.automaticallyFetchVideoInformationToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.automaticallyFetchVideoInformationToolStripMenuItem.Text = "Automatically fetch video information";
            this.automaticallyFetchVideoInformationToolStripMenuItem.Click += new System.EventHandler(this.AutomaticallyFetchVideoInformationToolStripMenuItemClickEvent);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.toolStripSeparator5,
            this.donateAtKofiToolStripMenuItem,
            this.gitHubRepositoryToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClickEvent);
            // 
            // donateAtKofiToolStripMenuItem
            // 
            this.donateAtKofiToolStripMenuItem.Name = "donateAtKofiToolStripMenuItem";
            this.donateAtKofiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.donateAtKofiToolStripMenuItem.Text = "Donate at Ko-fi";
            this.donateAtKofiToolStripMenuItem.Click += new System.EventHandler(this.DonateAtKofiToolStripMenuItemClickEvent);
            // 
            // startupTableLayoutPanel
            // 
            this.startupTableLayoutPanel.ColumnCount = 2;
            this.startupTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startupTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startupTableLayoutPanel.Controls.Add(this.browseYouTubePictureBox, 0, 0);
            this.startupTableLayoutPanel.Controls.Add(this.loadURLsTableLayoutPanel, 1, 0);
            this.startupTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startupTableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.startupTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.startupTableLayoutPanel.Name = "startupTableLayoutPanel";
            this.startupTableLayoutPanel.RowCount = 1;
            this.startupTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startupTableLayoutPanel.Size = new System.Drawing.Size(800, 426);
            this.startupTableLayoutPanel.TabIndex = 5;
            // 
            // browseYouTubePictureBox
            // 
            this.browseYouTubePictureBox.BackColor = System.Drawing.Color.Red;
            this.browseYouTubePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browseYouTubePictureBox.Image = global::YouTubeToMP3.Properties.Resources.YouTubeIconSquare;
            this.browseYouTubePictureBox.Location = new System.Drawing.Point(0, 0);
            this.browseYouTubePictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.browseYouTubePictureBox.Name = "browseYouTubePictureBox";
            this.browseYouTubePictureBox.Size = new System.Drawing.Size(400, 426);
            this.browseYouTubePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.browseYouTubePictureBox.TabIndex = 0;
            this.browseYouTubePictureBox.TabStop = false;
            this.browseYouTubePictureBox.Click += new System.EventHandler(this.BrowseAtYouTubePictureBoxClickEvent);
            // 
            // loadURLsTableLayoutPanel
            // 
            this.loadURLsTableLayoutPanel.ColumnCount = 1;
            this.loadURLsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.loadURLsTableLayoutPanel.Controls.Add(this.loadURLsFromFilePictureBox, 0, 0);
            this.loadURLsTableLayoutPanel.Controls.Add(this.loadURLsFromAnInternetResourcePictureBox, 0, 1);
            this.loadURLsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadURLsTableLayoutPanel.Location = new System.Drawing.Point(400, 0);
            this.loadURLsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.loadURLsTableLayoutPanel.Name = "loadURLsTableLayoutPanel";
            this.loadURLsTableLayoutPanel.RowCount = 2;
            this.loadURLsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.loadURLsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.loadURLsTableLayoutPanel.Size = new System.Drawing.Size(400, 426);
            this.loadURLsTableLayoutPanel.TabIndex = 1;
            // 
            // loadURLsFromFilePictureBox
            // 
            this.loadURLsFromFilePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.loadURLsFromFilePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadURLsFromFilePictureBox.Image = global::YouTubeToMP3.Properties.Resources.OpenFile;
            this.loadURLsFromFilePictureBox.Location = new System.Drawing.Point(0, 0);
            this.loadURLsFromFilePictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.loadURLsFromFilePictureBox.Name = "loadURLsFromFilePictureBox";
            this.loadURLsFromFilePictureBox.Size = new System.Drawing.Size(400, 213);
            this.loadURLsFromFilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loadURLsFromFilePictureBox.TabIndex = 2;
            this.loadURLsFromFilePictureBox.TabStop = false;
            this.loadURLsFromFilePictureBox.Click += new System.EventHandler(this.LoadURLsFromFilePictureBoxClickEvent);
            // 
            // loadURLsFromAnInternetResourcePictureBox
            // 
            this.loadURLsFromAnInternetResourcePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(255)))));
            this.loadURLsFromAnInternetResourcePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadURLsFromAnInternetResourcePictureBox.Image = global::YouTubeToMP3.Properties.Resources.InternetResource;
            this.loadURLsFromAnInternetResourcePictureBox.Location = new System.Drawing.Point(0, 213);
            this.loadURLsFromAnInternetResourcePictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.loadURLsFromAnInternetResourcePictureBox.Name = "loadURLsFromAnInternetResourcePictureBox";
            this.loadURLsFromAnInternetResourcePictureBox.Size = new System.Drawing.Size(400, 213);
            this.loadURLsFromAnInternetResourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loadURLsFromAnInternetResourcePictureBox.TabIndex = 3;
            this.loadURLsFromAnInternetResourcePictureBox.TabStop = false;
            this.loadURLsFromAnInternetResourcePictureBox.Click += new System.EventHandler(this.LoadURLsFromAnInternetResourcePictureBoxClickEvent);
            // 
            // urlsOpenFileDialog
            // 
            this.urlsOpenFileDialog.AddExtension = false;
            this.urlsOpenFileDialog.DefaultExt = "txt";
            this.urlsOpenFileDialog.Filter = "Text file|*.txt|Log file|*.log|Any file|*";
            this.urlsOpenFileDialog.Multiselect = true;
            // 
            // urlsSaveFileDialog
            // 
            this.urlsSaveFileDialog.DefaultExt = "txt";
            this.urlsSaveFileDialog.Filter = "Text file|*.txt|Log file|*.log|Any file|*";
            // 
            // gitHubRepositoryToolStripMenuItem
            // 
            this.gitHubRepositoryToolStripMenuItem.Name = "gitHubRepositoryToolStripMenuItem";
            this.gitHubRepositoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gitHubRepositoryToolStripMenuItem.Text = "GitHub repository";
            this.gitHubRepositoryToolStripMenuItem.Click += new System.EventHandler(this.GitHubRepositoryToolStripMenuItemClickEvent);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startupTableLayoutPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "YouTube to MP3";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosedEvent);
            this.Shown += new System.EventHandler(this.MainFormShownEvent);
            this.mainPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.buttonsFlowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.urlsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urlsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urlDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urlDataTable)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.startupTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.browseYouTubePictureBox)).EndInit();
            this.loadURLsTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadURLsFromFilePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadURLsFromAnInternetResourcePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.FlowLayoutPanel buttonsFlowLayoutPanel;
        private System.Windows.Forms.Button startDownloadingButton;
        private System.Windows.Forms.Button browseAtYouTubeButton;
        private System.Windows.Forms.BindingSource urlsBindingSource;
        private System.Data.DataSet urlDataSet;
        private System.Data.DataTable urlDataTable;
        private System.Data.DataColumn isEnabled;
        private System.Data.DataColumn url;
        private System.Data.DataColumn status;
        private System.Windows.Forms.Timer timer;
        private System.Data.DataColumn titleDataColumn;
        private System.Data.DataColumn statusDataColumn;
        private System.Data.DataColumn progressDataColumn;
        private System.Data.DataColumn sizeDataColumn;
        private System.Data.DataColumn speedDataColumn;
        private System.Data.DataColumn etaDataColumn;
        private System.Data.DataColumn timeDataColumn;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeHighlightedEntriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteURLsFromClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadURLsFromToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remainingEnabledEntriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlyHighlightedAndEnabledEntriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem everythingEnabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseAtYouTubeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadURLsFromFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadURLsFromAnInternetResourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableEverythingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableEverythingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridView urlsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinationPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isEnabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn progressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn speedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn etaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel startupTableLayoutPanel;
        private System.Windows.Forms.PictureBox browseYouTubePictureBox;
        private System.Windows.Forms.TableLayoutPanel loadURLsTableLayoutPanel;
        private System.Windows.Forms.PictureBox loadURLsFromFilePictureBox;
        private System.Windows.Forms.PictureBox loadURLsFromAnInternetResourcePictureBox;
        private System.Windows.Forms.OpenFileDialog urlsOpenFileDialog;
        private System.Windows.Forms.ToolStripMenuItem saveURLsAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog urlsSaveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automaticallyAddURLsFromClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automaticallyFetchVideoInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem fetchInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateAtKofiToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem gitHubRepositoryToolStripMenuItem;
    }
}


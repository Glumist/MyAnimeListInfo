namespace MyAnimeListInfo
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.dgvAnimeList = new System.Windows.Forms.DataGridView();
            this.colListUserStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListUserScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListUserProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListUserStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListUserEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListPopularity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefreshInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefreshUserStats = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefreshFull = new System.Windows.Forms.ToolStripMenuItem();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpAll = new System.Windows.Forms.TabPage();
            this.tsList = new System.Windows.Forms.ToolStrip();
            this.tscbShowList = new System.Windows.Forms.ToolStripComboBox();
            this.tstbFilter = new System.Windows.Forms.ToolStripTextBox();
            this.tpSearch = new System.Windows.Forms.TabPage();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.colSearchUserStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRelatedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRelatedQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRelatedType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRelatedStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRelatedEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsSearch = new System.Windows.Forms.ToolStrip();
            this.tsbStartSearch = new System.Windows.Forms.ToolStripButton();
            this.tstbSearchText = new System.Windows.Forms.ToolStripTextBox();
            this.tpNews = new System.Windows.Forms.TabPage();
            this.dgvNews = new System.Windows.Forms.DataGridView();
            this.colNewsDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewsTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msNews = new System.Windows.Forms.MenuStrip();
            this.tsmiMarkRead = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.pAnimeInfo = new MyAnimeListInfo.UserControlAnimeInfo();
            this.pEmpty = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tspbLoading = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimeList)).BeginInit();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpAll.SuspendLayout();
            this.tsList.SuspendLayout();
            this.tpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.tsSearch.SuspendLayout();
            this.tpNews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNews)).BeginInit();
            this.msNews.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAnimeList
            // 
            this.dgvAnimeList.AllowUserToAddRows = false;
            this.dgvAnimeList.AllowUserToDeleteRows = false;
            this.dgvAnimeList.AllowUserToResizeRows = false;
            this.dgvAnimeList.BackgroundColor = System.Drawing.Color.White;
            this.dgvAnimeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnimeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colListUserStatus,
            this.colListName,
            this.colListUserScore,
            this.colListScore,
            this.colListType,
            this.colListUserProgress,
            this.colListUserStartDate,
            this.colListUserEndDate,
            this.colListDays,
            this.colListQuantity,
            this.colListStartDate,
            this.colListEndDate,
            this.colListRating,
            this.colListPopularity});
            this.dgvAnimeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnimeList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAnimeList.Location = new System.Drawing.Point(4, 38);
            this.dgvAnimeList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvAnimeList.MultiSelect = false;
            this.dgvAnimeList.Name = "dgvAnimeList";
            this.dgvAnimeList.ReadOnly = true;
            this.dgvAnimeList.RowHeadersVisible = false;
            this.dgvAnimeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnimeList.Size = new System.Drawing.Size(959, 1013);
            this.dgvAnimeList.TabIndex = 4;
            this.dgvAnimeList.SelectionChanged += new System.EventHandler(this.dgvList_SelectionChanged);
            // 
            // colListUserStatus
            // 
            this.colListUserStatus.DataPropertyName = "UserStatus";
            this.colListUserStatus.HeaderText = "Статус";
            this.colListUserStatus.Name = "colListUserStatus";
            this.colListUserStatus.ReadOnly = true;
            this.colListUserStatus.Width = 60;
            // 
            // colListName
            // 
            this.colListName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colListName.DataPropertyName = "Name";
            this.colListName.HeaderText = "Название";
            this.colListName.Name = "colListName";
            this.colListName.ReadOnly = true;
            // 
            // colListUserScore
            // 
            this.colListUserScore.DataPropertyName = "UserScore";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colListUserScore.DefaultCellStyle = dataGridViewCellStyle1;
            this.colListUserScore.HeaderText = "Оценка";
            this.colListUserScore.Name = "colListUserScore";
            this.colListUserScore.ReadOnly = true;
            this.colListUserScore.Width = 30;
            // 
            // colListScore
            // 
            this.colListScore.DataPropertyName = "Score";
            this.colListScore.HeaderText = "Оценка общества";
            this.colListScore.Name = "colListScore";
            this.colListScore.ReadOnly = true;
            this.colListScore.Width = 30;
            // 
            // colListType
            // 
            this.colListType.DataPropertyName = "Type";
            this.colListType.HeaderText = "Тип";
            this.colListType.Name = "colListType";
            this.colListType.ReadOnly = true;
            this.colListType.Width = 45;
            // 
            // colListUserProgress
            // 
            this.colListUserProgress.DataPropertyName = "Progress";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colListUserProgress.DefaultCellStyle = dataGridViewCellStyle2;
            this.colListUserProgress.HeaderText = "Прогресс";
            this.colListUserProgress.Name = "colListUserProgress";
            this.colListUserProgress.ReadOnly = true;
            this.colListUserProgress.Width = 55;
            // 
            // colListUserStartDate
            // 
            this.colListUserStartDate.DataPropertyName = "UserStartDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colListUserStartDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colListUserStartDate.HeaderText = "Дата начала";
            this.colListUserStartDate.Name = "colListUserStartDate";
            this.colListUserStartDate.ReadOnly = true;
            this.colListUserStartDate.Width = 65;
            // 
            // colListUserEndDate
            // 
            this.colListUserEndDate.DataPropertyName = "UserEndDate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colListUserEndDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.colListUserEndDate.HeaderText = "Дата окончания";
            this.colListUserEndDate.Name = "colListUserEndDate";
            this.colListUserEndDate.ReadOnly = true;
            this.colListUserEndDate.Width = 65;
            // 
            // colListDays
            // 
            this.colListDays.DataPropertyName = "Duration";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colListDays.DefaultCellStyle = dataGridViewCellStyle5;
            this.colListDays.HeaderText = "Продолжительность";
            this.colListDays.Name = "colListDays";
            this.colListDays.ReadOnly = true;
            this.colListDays.Width = 30;
            // 
            // colListQuantity
            // 
            this.colListQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colListQuantity.DefaultCellStyle = dataGridViewCellStyle6;
            this.colListQuantity.HeaderText = "Кол-во серий";
            this.colListQuantity.Name = "colListQuantity";
            this.colListQuantity.ReadOnly = true;
            this.colListQuantity.Width = 30;
            // 
            // colListStartDate
            // 
            this.colListStartDate.DataPropertyName = "StartDate";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colListStartDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.colListStartDate.HeaderText = "Дата начала";
            this.colListStartDate.Name = "colListStartDate";
            this.colListStartDate.ReadOnly = true;
            this.colListStartDate.Width = 65;
            // 
            // colListEndDate
            // 
            this.colListEndDate.DataPropertyName = "EndDate";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colListEndDate.DefaultCellStyle = dataGridViewCellStyle8;
            this.colListEndDate.HeaderText = "Дата окончания";
            this.colListEndDate.Name = "colListEndDate";
            this.colListEndDate.ReadOnly = true;
            this.colListEndDate.Width = 65;
            // 
            // colListRating
            // 
            this.colListRating.DataPropertyName = "Rank";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colListRating.DefaultCellStyle = dataGridViewCellStyle9;
            this.colListRating.HeaderText = "Рейтинг";
            this.colListRating.Name = "colListRating";
            this.colListRating.ReadOnly = true;
            this.colListRating.Width = 40;
            // 
            // colListPopularity
            // 
            this.colListPopularity.DataPropertyName = "Popularity";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colListPopularity.DefaultCellStyle = dataGridViewCellStyle10;
            this.colListPopularity.HeaderText = "Популярность";
            this.colListPopularity.Name = "colListPopularity";
            this.colListPopularity.ReadOnly = true;
            this.colListPopularity.Width = 50;
            // 
            // msMain
            // 
            this.msMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSettings,
            this.tsmiRefresh});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msMain.Size = new System.Drawing.Size(1664, 35);
            this.msMain.TabIndex = 5;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(112, 29);
            this.tsmiSettings.Text = "Настройки";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefreshInfo,
            this.tsmiRefreshUserStats,
            this.tsmiRefreshFull});
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.Size = new System.Drawing.Size(105, 29);
            this.tsmiRefresh.Text = "Обновить";
            // 
            // tsmiRefreshInfo
            // 
            this.tsmiRefreshInfo.Name = "tsmiRefreshInfo";
            this.tsmiRefreshInfo.Size = new System.Drawing.Size(211, 30);
            this.tsmiRefreshInfo.Text = "Информацию";
            this.tsmiRefreshInfo.Click += new System.EventHandler(this.tsmiRefreshInfo_Click);
            // 
            // tsmiRefreshUserStats
            // 
            this.tsmiRefreshUserStats.Name = "tsmiRefreshUserStats";
            this.tsmiRefreshUserStats.Size = new System.Drawing.Size(211, 30);
            this.tsmiRefreshUserStats.Text = "Статистику";
            this.tsmiRefreshUserStats.Click += new System.EventHandler(this.tsmiRefreshUserStats_Click);
            // 
            // tsmiRefreshFull
            // 
            this.tsmiRefreshFull.Name = "tsmiRefreshFull";
            this.tsmiRefreshFull.Size = new System.Drawing.Size(211, 30);
            this.tsmiRefreshFull.Text = "Полностью";
            this.tsmiRefreshFull.Click += new System.EventHandler(this.tsmiRefreshFull_Click);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 35);
            this.scMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.tcMain);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.pAnimeInfo);
            this.scMain.Panel2.Controls.Add(this.pEmpty);
            this.scMain.Size = new System.Drawing.Size(1664, 1089);
            this.scMain.SplitterDistance = 975;
            this.scMain.SplitterWidth = 9;
            this.scMain.TabIndex = 6;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpAll);
            this.tcMain.Controls.Add(this.tpSearch);
            this.tcMain.Controls.Add(this.tpNews);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(975, 1089);
            this.tcMain.TabIndex = 5;
            this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
            // 
            // tpAll
            // 
            this.tpAll.Controls.Add(this.dgvAnimeList);
            this.tpAll.Controls.Add(this.tsList);
            this.tpAll.Location = new System.Drawing.Point(4, 29);
            this.tpAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpAll.Name = "tpAll";
            this.tpAll.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpAll.Size = new System.Drawing.Size(967, 1056);
            this.tpAll.TabIndex = 0;
            this.tpAll.Text = "Все";
            this.tpAll.UseVisualStyleBackColor = true;
            // 
            // tsList
            // 
            this.tsList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsList.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbShowList,
            this.tstbFilter});
            this.tsList.Location = new System.Drawing.Point(4, 5);
            this.tsList.Name = "tsList";
            this.tsList.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsList.Size = new System.Drawing.Size(959, 33);
            this.tsList.TabIndex = 5;
            this.tsList.Text = "toolStrip1";
            // 
            // tscbShowList
            // 
            this.tscbShowList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbShowList.Name = "tscbShowList";
            this.tscbShowList.Size = new System.Drawing.Size(180, 33);
            this.tscbShowList.SelectedIndexChanged += new System.EventHandler(this.tscbShowList_SelectedIndexChanged);
            // 
            // tstbFilter
            // 
            this.tstbFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tstbFilter.Name = "tstbFilter";
            this.tstbFilter.Size = new System.Drawing.Size(148, 33);
            this.tstbFilter.TextChanged += new System.EventHandler(this.tstbFilter_TextChanged);
            // 
            // tpSearch
            // 
            this.tpSearch.Controls.Add(this.dgvSearch);
            this.tpSearch.Controls.Add(this.tsSearch);
            this.tpSearch.Location = new System.Drawing.Point(4, 29);
            this.tpSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpSearch.Name = "tpSearch";
            this.tpSearch.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpSearch.Size = new System.Drawing.Size(967, 1042);
            this.tpSearch.TabIndex = 7;
            this.tpSearch.Text = "Поиск";
            this.tpSearch.UseVisualStyleBackColor = true;
            // 
            // dgvSearch
            // 
            this.dgvSearch.AllowUserToAddRows = false;
            this.dgvSearch.AllowUserToDeleteRows = false;
            this.dgvSearch.AllowUserToResizeRows = false;
            this.dgvSearch.BackgroundColor = System.Drawing.Color.White;
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSearchUserStatus,
            this.colRelatedName,
            this.colRelatedQuantity,
            this.colRelatedType,
            this.colRelatedStart,
            this.colRelatedEnd});
            this.dgvSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSearch.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSearch.Location = new System.Drawing.Point(4, 36);
            this.dgvSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvSearch.MultiSelect = false;
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.ReadOnly = true;
            this.dgvSearch.RowHeadersVisible = false;
            this.dgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearch.Size = new System.Drawing.Size(959, 1001);
            this.dgvSearch.TabIndex = 7;
            this.dgvSearch.SelectionChanged += new System.EventHandler(this.dgvSearch_SelectionChanged);
            // 
            // colSearchUserStatus
            // 
            this.colSearchUserStatus.DataPropertyName = "UserStatus";
            this.colSearchUserStatus.HeaderText = "Статус";
            this.colSearchUserStatus.Name = "colSearchUserStatus";
            this.colSearchUserStatus.ReadOnly = true;
            this.colSearchUserStatus.Width = 60;
            // 
            // colRelatedName
            // 
            this.colRelatedName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRelatedName.DataPropertyName = "Name";
            this.colRelatedName.HeaderText = "Название";
            this.colRelatedName.Name = "colRelatedName";
            this.colRelatedName.ReadOnly = true;
            // 
            // colRelatedQuantity
            // 
            this.colRelatedQuantity.DataPropertyName = "Quantity";
            this.colRelatedQuantity.HeaderText = "Кол-во серий";
            this.colRelatedQuantity.Name = "colRelatedQuantity";
            this.colRelatedQuantity.ReadOnly = true;
            this.colRelatedQuantity.Width = 30;
            // 
            // colRelatedType
            // 
            this.colRelatedType.DataPropertyName = "Type";
            this.colRelatedType.HeaderText = "Тип";
            this.colRelatedType.Name = "colRelatedType";
            this.colRelatedType.ReadOnly = true;
            this.colRelatedType.Width = 45;
            // 
            // colRelatedStart
            // 
            this.colRelatedStart.DataPropertyName = "StartDate";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colRelatedStart.DefaultCellStyle = dataGridViewCellStyle11;
            this.colRelatedStart.HeaderText = "Дата начала";
            this.colRelatedStart.Name = "colRelatedStart";
            this.colRelatedStart.ReadOnly = true;
            this.colRelatedStart.Width = 65;
            // 
            // colRelatedEnd
            // 
            this.colRelatedEnd.DataPropertyName = "EndDate";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colRelatedEnd.DefaultCellStyle = dataGridViewCellStyle12;
            this.colRelatedEnd.HeaderText = "Дата окончания";
            this.colRelatedEnd.Name = "colRelatedEnd";
            this.colRelatedEnd.ReadOnly = true;
            this.colRelatedEnd.Width = 65;
            // 
            // tsSearch
            // 
            this.tsSearch.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSearch.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbStartSearch,
            this.tstbSearchText});
            this.tsSearch.Location = new System.Drawing.Point(4, 5);
            this.tsSearch.Name = "tsSearch";
            this.tsSearch.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsSearch.Size = new System.Drawing.Size(959, 31);
            this.tsSearch.TabIndex = 8;
            this.tsSearch.Text = "toolStrip1";
            this.tsSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tsSearch_KeyDown);
            // 
            // tsbStartSearch
            // 
            this.tsbStartSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbStartSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStartSearch.Image = global::MyAnimeListInfo.Properties.Resources.IconSearch;
            this.tsbStartSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStartSearch.Name = "tsbStartSearch";
            this.tsbStartSearch.Size = new System.Drawing.Size(28, 28);
            this.tsbStartSearch.Text = "Поиск";
            this.tsbStartSearch.Click += new System.EventHandler(this.tsbStartSearch_Click);
            // 
            // tstbSearchText
            // 
            this.tstbSearchText.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tstbSearchText.Name = "tstbSearchText";
            this.tstbSearchText.Size = new System.Drawing.Size(148, 31);
            // 
            // tpNews
            // 
            this.tpNews.Controls.Add(this.dgvNews);
            this.tpNews.Controls.Add(this.msNews);
            this.tpNews.Location = new System.Drawing.Point(4, 29);
            this.tpNews.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpNews.Name = "tpNews";
            this.tpNews.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpNews.Size = new System.Drawing.Size(967, 1042);
            this.tpNews.TabIndex = 6;
            this.tpNews.Text = "Новости";
            this.tpNews.UseVisualStyleBackColor = true;
            // 
            // dgvNews
            // 
            this.dgvNews.AllowUserToAddRows = false;
            this.dgvNews.AllowUserToDeleteRows = false;
            this.dgvNews.AllowUserToResizeRows = false;
            this.dgvNews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNews.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNewsDate,
            this.colNewsTitle,
            this.colField,
            this.colValue});
            this.dgvNews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNews.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvNews.Location = new System.Drawing.Point(4, 40);
            this.dgvNews.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvNews.MultiSelect = false;
            this.dgvNews.Name = "dgvNews";
            this.dgvNews.ReadOnly = true;
            this.dgvNews.RowHeadersVisible = false;
            this.dgvNews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNews.Size = new System.Drawing.Size(959, 997);
            this.dgvNews.TabIndex = 1;
            this.dgvNews.SelectionChanged += new System.EventHandler(this.dgvList_SelectionChanged);
            // 
            // colNewsDate
            // 
            this.colNewsDate.DataPropertyName = "Date";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNewsDate.DefaultCellStyle = dataGridViewCellStyle13;
            this.colNewsDate.HeaderText = "Дата";
            this.colNewsDate.Name = "colNewsDate";
            this.colNewsDate.ReadOnly = true;
            this.colNewsDate.Width = 95;
            // 
            // colNewsTitle
            // 
            this.colNewsTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNewsTitle.DataPropertyName = "AnimeRecord";
            this.colNewsTitle.HeaderText = "Аниме";
            this.colNewsTitle.Name = "colNewsTitle";
            this.colNewsTitle.ReadOnly = true;
            // 
            // colField
            // 
            this.colField.DataPropertyName = "Field";
            this.colField.HeaderText = "Обновленное поле";
            this.colField.Name = "colField";
            this.colField.ReadOnly = true;
            // 
            // colValue
            // 
            this.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colValue.DataPropertyName = "Text";
            this.colValue.HeaderText = "Значение";
            this.colValue.Name = "colValue";
            this.colValue.ReadOnly = true;
            this.colValue.Width = 119;
            // 
            // msNews
            // 
            this.msNews.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msNews.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMarkRead,
            this.tsmiRemoveAll});
            this.msNews.Location = new System.Drawing.Point(4, 5);
            this.msNews.Name = "msNews";
            this.msNews.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msNews.Size = new System.Drawing.Size(959, 35);
            this.msNews.TabIndex = 0;
            this.msNews.Text = "menuStrip1";
            // 
            // tsmiMarkRead
            // 
            this.tsmiMarkRead.Name = "tsmiMarkRead";
            this.tsmiMarkRead.Size = new System.Drawing.Size(229, 29);
            this.tsmiMarkRead.Text = "Отметить прочитанными";
            this.tsmiMarkRead.Click += new System.EventHandler(this.tsmiMarkRead_Click);
            // 
            // tsmiRemoveAll
            // 
            this.tsmiRemoveAll.Name = "tsmiRemoveAll";
            this.tsmiRemoveAll.Size = new System.Drawing.Size(99, 29);
            this.tsmiRemoveAll.Text = "Очистить";
            this.tsmiRemoveAll.Click += new System.EventHandler(this.tsmiRemoveAll_Click);
            // 
            // pAnimeInfo
            // 
            this.pAnimeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAnimeInfo.Location = new System.Drawing.Point(0, 0);
            this.pAnimeInfo.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.pAnimeInfo.Name = "pAnimeInfo";
            this.pAnimeInfo.Size = new System.Drawing.Size(680, 1089);
            this.pAnimeInfo.TabIndex = 0;
            // 
            // pEmpty
            // 
            this.pEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pEmpty.Location = new System.Drawing.Point(0, 0);
            this.pEmpty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pEmpty.Name = "pEmpty";
            this.pEmpty.Size = new System.Drawing.Size(680, 1089);
            this.pEmpty.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbLoading});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1124);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1664, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "ssMain";
            // 
            // tspbLoading
            // 
            this.tspbLoading.Name = "tspbLoading";
            this.tspbLoading.Size = new System.Drawing.Size(150, 25);
            this.tspbLoading.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 1146);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.msMain);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.Text = "MyAnimeList Info";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimeList)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tpAll.ResumeLayout(false);
            this.tpAll.PerformLayout();
            this.tsList.ResumeLayout(false);
            this.tsList.PerformLayout();
            this.tpSearch.ResumeLayout(false);
            this.tpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.tsSearch.ResumeLayout(false);
            this.tsSearch.PerformLayout();
            this.tpNews.ResumeLayout(false);
            this.tpNews.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNews)).EndInit();
            this.msNews.ResumeLayout(false);
            this.msNews.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvAnimeList;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpAll;
        private System.Windows.Forms.Panel pEmpty;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tspbLoading;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshUserStats;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshFull;
        private System.Windows.Forms.TabPage tpNews;
        private System.Windows.Forms.MenuStrip msNews;
        private System.Windows.Forms.ToolStripMenuItem tsmiMarkRead;
        private System.Windows.Forms.DataGridView dgvNews;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewsDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewsTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colField;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveAll;
        private System.Windows.Forms.TabPage tpSearch;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.ToolStrip tsList;
        private System.Windows.Forms.ToolStripComboBox tscbShowList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListUserStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListUserScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListUserProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListUserStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListUserEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListDays;
        private UserControlAnimeInfo pAnimeInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListPopularity;
        private System.Windows.Forms.ToolStripTextBox tstbFilter;
        private System.Windows.Forms.ToolStrip tsSearch;
        private System.Windows.Forms.ToolStripButton tsbStartSearch;
        private System.Windows.Forms.ToolStripTextBox tstbSearchText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSearchUserStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRelatedName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRelatedQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRelatedType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRelatedStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRelatedEnd;
    }
}


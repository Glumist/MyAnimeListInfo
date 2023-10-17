namespace MyAnimeListInfo
{
    partial class UserControlAnimeInfo
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbType = new System.Windows.Forms.TextBox();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEpisodeDuration = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbEndDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStartDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSynopsis = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpSynopsis = new System.Windows.Forms.TabPage();
            this.tpGenres = new System.Windows.Forms.TabPage();
            this.dgvGenres = new System.Windows.Forms.DataGridView();
            this.colGenreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpAltTitles = new System.Windows.Forms.TabPage();
            this.dgvAltTitles = new System.Windows.Forms.DataGridView();
            this.colLanguage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpRelatedAnime = new System.Windows.Forms.TabPage();
            this.dgvRelatedAnime = new System.Windows.Forms.DataGridView();
            this.tpRecommended = new System.Windows.Forms.TabPage();
            this.dgvRecommended = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbBrowse = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbAddWatched = new System.Windows.Forms.ToolStripButton();
            this.scPic = new System.Windows.Forms.SplitContainer();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.tbUserStatus = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.scTabs = new System.Windows.Forms.SplitContainer();
            this.colRelationsRelation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRelationsStatusIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.colRelationsTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecommendsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecommedsStatusIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.colRecommendsTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tpSynopsis.SuspendLayout();
            this.tpGenres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenres)).BeginInit();
            this.tpAltTitles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAltTitles)).BeginInit();
            this.tpRelatedAnime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedAnime)).BeginInit();
            this.tpRecommended.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecommended)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scPic)).BeginInit();
            this.scPic.Panel1.SuspendLayout();
            this.scPic.Panel2.SuspendLayout();
            this.scPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scTabs)).BeginInit();
            this.scTabs.Panel1.SuspendLayout();
            this.scTabs.Panel2.SuspendLayout();
            this.scTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbName.Location = new System.Drawing.Point(5, 58);
            this.tbName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(738, 34);
            this.tbName.TabIndex = 1;
            this.tbName.TabStop = false;
            this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Тип:";
            // 
            // tbType
            // 
            this.tbType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbType.Location = new System.Drawing.Point(203, 29);
            this.tbType.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbType.Name = "tbType";
            this.tbType.ReadOnly = true;
            this.tbType.Size = new System.Drawing.Size(227, 24);
            this.tbType.TabIndex = 3;
            this.tbType.TabStop = false;
            // 
            // tbQuantity
            // 
            this.tbQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbQuantity.Location = new System.Drawing.Point(203, 65);
            this.tbQuantity.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.ReadOnly = true;
            this.tbQuantity.Size = new System.Drawing.Size(227, 24);
            this.tbQuantity.TabIndex = 5;
            this.tbQuantity.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Серии:";
            // 
            // tbEpisodeDuration
            // 
            this.tbEpisodeDuration.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbEpisodeDuration.Location = new System.Drawing.Point(203, 102);
            this.tbEpisodeDuration.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbEpisodeDuration.Name = "tbEpisodeDuration";
            this.tbEpisodeDuration.ReadOnly = true;
            this.tbEpisodeDuration.Size = new System.Drawing.Size(227, 24);
            this.tbEpisodeDuration.TabIndex = 7;
            this.tbEpisodeDuration.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Продолжительность:";
            // 
            // tbEndDate
            // 
            this.tbEndDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbEndDate.Location = new System.Drawing.Point(203, 210);
            this.tbEndDate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbEndDate.Name = "tbEndDate";
            this.tbEndDate.ReadOnly = true;
            this.tbEndDate.Size = new System.Drawing.Size(227, 24);
            this.tbEndDate.TabIndex = 13;
            this.tbEndDate.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 208);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Дата окончания:";
            // 
            // tbStartDate
            // 
            this.tbStartDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbStartDate.Location = new System.Drawing.Point(203, 173);
            this.tbStartDate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbStartDate.Name = "tbStartDate";
            this.tbStartDate.ReadOnly = true;
            this.tbStartDate.Size = new System.Drawing.Size(227, 24);
            this.tbStartDate.TabIndex = 11;
            this.tbStartDate.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Дата начала:";
            // 
            // tbStatus
            // 
            this.tbStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbStatus.Location = new System.Drawing.Point(203, 137);
            this.tbStatus.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ReadOnly = true;
            this.tbStatus.Size = new System.Drawing.Size(227, 24);
            this.tbStatus.TabIndex = 9;
            this.tbStatus.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 135);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Статус:";
            // 
            // tbSynopsis
            // 
            this.tbSynopsis.BackColor = System.Drawing.SystemColors.Control;
            this.tbSynopsis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSynopsis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSynopsis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbSynopsis.Location = new System.Drawing.Point(5, 6);
            this.tbSynopsis.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbSynopsis.Multiline = true;
            this.tbSynopsis.Name = "tbSynopsis";
            this.tbSynopsis.ReadOnly = true;
            this.tbSynopsis.Size = new System.Drawing.Size(727, 632);
            this.tbSynopsis.TabIndex = 15;
            this.tbSynopsis.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpSynopsis);
            this.tabControl1.Controls.Add(this.tpGenres);
            this.tabControl1.Controls.Add(this.tpAltTitles);
            this.tabControl1.Controls.Add(this.tpRelatedAnime);
            this.tabControl1.Controls.Add(this.tpRecommended);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(745, 682);
            this.tabControl1.TabIndex = 17;
            // 
            // tpSynopsis
            // 
            this.tpSynopsis.Controls.Add(this.tbSynopsis);
            this.tpSynopsis.Location = new System.Drawing.Point(4, 34);
            this.tpSynopsis.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tpSynopsis.Name = "tpSynopsis";
            this.tpSynopsis.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tpSynopsis.Size = new System.Drawing.Size(737, 644);
            this.tpSynopsis.TabIndex = 0;
            this.tpSynopsis.Text = "Суть";
            this.tpSynopsis.UseVisualStyleBackColor = true;
            // 
            // tpGenres
            // 
            this.tpGenres.Controls.Add(this.dgvGenres);
            this.tpGenres.Location = new System.Drawing.Point(4, 34);
            this.tpGenres.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tpGenres.Name = "tpGenres";
            this.tpGenres.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tpGenres.Size = new System.Drawing.Size(737, 644);
            this.tpGenres.TabIndex = 3;
            this.tpGenres.Text = "Жанры";
            this.tpGenres.UseVisualStyleBackColor = true;
            // 
            // dgvGenres
            // 
            this.dgvGenres.AllowUserToAddRows = false;
            this.dgvGenres.AllowUserToDeleteRows = false;
            this.dgvGenres.AllowUserToResizeRows = false;
            this.dgvGenres.BackgroundColor = System.Drawing.Color.White;
            this.dgvGenres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGenres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGenreName});
            this.dgvGenres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGenres.Location = new System.Drawing.Point(5, 6);
            this.dgvGenres.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dgvGenres.Name = "dgvGenres";
            this.dgvGenres.RowHeadersVisible = false;
            this.dgvGenres.RowHeadersWidth = 62;
            this.dgvGenres.Size = new System.Drawing.Size(727, 632);
            this.dgvGenres.TabIndex = 0;
            // 
            // colGenreName
            // 
            this.colGenreName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGenreName.DataPropertyName = "GenreName";
            this.colGenreName.HeaderText = "Жанр";
            this.colGenreName.MinimumWidth = 8;
            this.colGenreName.Name = "colGenreName";
            // 
            // tpAltTitles
            // 
            this.tpAltTitles.Controls.Add(this.dgvAltTitles);
            this.tpAltTitles.Location = new System.Drawing.Point(4, 34);
            this.tpAltTitles.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tpAltTitles.Name = "tpAltTitles";
            this.tpAltTitles.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tpAltTitles.Size = new System.Drawing.Size(737, 644);
            this.tpAltTitles.TabIndex = 1;
            this.tpAltTitles.Text = "Альтернативные названия";
            this.tpAltTitles.UseVisualStyleBackColor = true;
            // 
            // dgvAltTitles
            // 
            this.dgvAltTitles.AllowUserToAddRows = false;
            this.dgvAltTitles.AllowUserToDeleteRows = false;
            this.dgvAltTitles.AllowUserToResizeRows = false;
            this.dgvAltTitles.BackgroundColor = System.Drawing.Color.White;
            this.dgvAltTitles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAltTitles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLanguage,
            this.colTitle});
            this.dgvAltTitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAltTitles.Location = new System.Drawing.Point(5, 6);
            this.dgvAltTitles.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dgvAltTitles.MultiSelect = false;
            this.dgvAltTitles.Name = "dgvAltTitles";
            this.dgvAltTitles.ReadOnly = true;
            this.dgvAltTitles.RowHeadersVisible = false;
            this.dgvAltTitles.RowHeadersWidth = 62;
            this.dgvAltTitles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAltTitles.Size = new System.Drawing.Size(727, 632);
            this.dgvAltTitles.TabIndex = 0;
            // 
            // colLanguage
            // 
            this.colLanguage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLanguage.DataPropertyName = "Language";
            this.colLanguage.HeaderText = "Язык";
            this.colLanguage.MinimumWidth = 8;
            this.colLanguage.Name = "colLanguage";
            this.colLanguage.ReadOnly = true;
            this.colLanguage.Width = 89;
            // 
            // colTitle
            // 
            this.colTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTitle.DataPropertyName = "Title";
            this.colTitle.HeaderText = "Название";
            this.colTitle.MinimumWidth = 8;
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            // 
            // tpRelatedAnime
            // 
            this.tpRelatedAnime.Controls.Add(this.dgvRelatedAnime);
            this.tpRelatedAnime.Location = new System.Drawing.Point(4, 34);
            this.tpRelatedAnime.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tpRelatedAnime.Name = "tpRelatedAnime";
            this.tpRelatedAnime.Size = new System.Drawing.Size(737, 644);
            this.tpRelatedAnime.TabIndex = 2;
            this.tpRelatedAnime.Text = "Связанные";
            this.tpRelatedAnime.UseVisualStyleBackColor = true;
            // 
            // dgvRelatedAnime
            // 
            this.dgvRelatedAnime.AllowUserToAddRows = false;
            this.dgvRelatedAnime.AllowUserToDeleteRows = false;
            this.dgvRelatedAnime.AllowUserToResizeRows = false;
            this.dgvRelatedAnime.BackgroundColor = System.Drawing.Color.White;
            this.dgvRelatedAnime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatedAnime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRelationsRelation,
            this.colRelationsStatusIcon,
            this.colRelationsTitle});
            this.dgvRelatedAnime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRelatedAnime.Location = new System.Drawing.Point(0, 0);
            this.dgvRelatedAnime.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dgvRelatedAnime.MultiSelect = false;
            this.dgvRelatedAnime.Name = "dgvRelatedAnime";
            this.dgvRelatedAnime.ReadOnly = true;
            this.dgvRelatedAnime.RowHeadersVisible = false;
            this.dgvRelatedAnime.RowHeadersWidth = 62;
            this.dgvRelatedAnime.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRelatedAnime.Size = new System.Drawing.Size(737, 644);
            this.dgvRelatedAnime.TabIndex = 0;
            this.dgvRelatedAnime.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRelatedAnime_CellMouseDoubleClick);
            // 
            // tpRecommended
            // 
            this.tpRecommended.Controls.Add(this.dgvRecommended);
            this.tpRecommended.Location = new System.Drawing.Point(4, 34);
            this.tpRecommended.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tpRecommended.Name = "tpRecommended";
            this.tpRecommended.Size = new System.Drawing.Size(737, 644);
            this.tpRecommended.TabIndex = 4;
            this.tpRecommended.Text = "Рекомендованные";
            this.tpRecommended.UseVisualStyleBackColor = true;
            // 
            // dgvRecommended
            // 
            this.dgvRecommended.AllowUserToAddRows = false;
            this.dgvRecommended.AllowUserToDeleteRows = false;
            this.dgvRecommended.AllowUserToResizeRows = false;
            this.dgvRecommended.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecommended.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecommended.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRecommendsCount,
            this.colRecommedsStatusIcon,
            this.colRecommendsTitle});
            this.dgvRecommended.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecommended.Location = new System.Drawing.Point(0, 0);
            this.dgvRecommended.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dgvRecommended.MultiSelect = false;
            this.dgvRecommended.Name = "dgvRecommended";
            this.dgvRecommended.ReadOnly = true;
            this.dgvRecommended.RowHeadersVisible = false;
            this.dgvRecommended.RowHeadersWidth = 62;
            this.dgvRecommended.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecommended.Size = new System.Drawing.Size(737, 644);
            this.dgvRecommended.TabIndex = 1;
            this.dgvRecommended.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecommended_CellContentDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBrowse,
            this.tsbRefresh,
            this.tsbAdd,
            this.tsbEdit,
            this.tsbDelete,
            this.tsbAddWatched});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(750, 33);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbBrowse
            // 
            this.tsbBrowse.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbBrowse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBrowse.Image = global::MyAnimeListInfo.Properties.Resources.IconInternet;
            this.tsbBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBrowse.Name = "tsbBrowse";
            this.tsbBrowse.Size = new System.Drawing.Size(34, 28);
            this.tsbBrowse.Text = "Открыть в браузере";
            this.tsbBrowse.Click += new System.EventHandler(this.tsbOpenInBrowser_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = global::MyAnimeListInfo.Properties.Resources.iconRecalc;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(34, 28);
            this.tsbRefresh.Text = "Обновить";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAdd.Image = global::MyAnimeListInfo.Properties.Resources.add_icon;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(34, 28);
            this.tsbAdd.Text = "Добавить";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEdit.Image = global::MyAnimeListInfo.Properties.Resources.IconEdit;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(34, 28);
            this.tsbEdit.Text = "Редактировать";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = global::MyAnimeListInfo.Properties.Resources.action_delete_sharp_thick;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(34, 28);
            this.tsbDelete.Text = "Удалить";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbAddWatched
            // 
            this.tsbAddWatched.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddWatched.Image = global::MyAnimeListInfo.Properties.Resources.IconPlus;
            this.tsbAddWatched.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddWatched.Name = "tsbAddWatched";
            this.tsbAddWatched.Size = new System.Drawing.Size(34, 28);
            this.tsbAddWatched.Click += new System.EventHandler(this.tsbAddWatched_Click);
            // 
            // scPic
            // 
            this.scPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scPic.Location = new System.Drawing.Point(0, 0);
            this.scPic.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.scPic.Name = "scPic";
            // 
            // scPic.Panel1
            // 
            this.scPic.Panel1.Controls.Add(this.pbImage);
            // 
            // scPic.Panel2
            // 
            this.scPic.Panel2.Controls.Add(this.tbUserStatus);
            this.scPic.Panel2.Controls.Add(this.label7);
            this.scPic.Panel2.Controls.Add(this.label1);
            this.scPic.Panel2.Controls.Add(this.tbType);
            this.scPic.Panel2.Controls.Add(this.label2);
            this.scPic.Panel2.Controls.Add(this.tbEndDate);
            this.scPic.Panel2.Controls.Add(this.tbQuantity);
            this.scPic.Panel2.Controls.Add(this.label4);
            this.scPic.Panel2.Controls.Add(this.label3);
            this.scPic.Panel2.Controls.Add(this.tbStartDate);
            this.scPic.Panel2.Controls.Add(this.tbEpisodeDuration);
            this.scPic.Panel2.Controls.Add(this.label5);
            this.scPic.Panel2.Controls.Add(this.label6);
            this.scPic.Panel2.Controls.Add(this.tbStatus);
            this.scPic.Size = new System.Drawing.Size(745, 689);
            this.scPic.SplitterDistance = 246;
            this.scPic.SplitterWidth = 10;
            this.scPic.TabIndex = 20;
            // 
            // pbImage
            // 
            this.pbImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage.Location = new System.Drawing.Point(0, 0);
            this.pbImage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(246, 689);
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // tbUserStatus
            // 
            this.tbUserStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUserStatus.Location = new System.Drawing.Point(203, 248);
            this.tbUserStatus.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbUserStatus.Name = "tbUserStatus";
            this.tbUserStatus.ReadOnly = true;
            this.tbUserStatus.Size = new System.Drawing.Size(227, 24);
            this.tbUserStatus.TabIndex = 15;
            this.tbUserStatus.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 244);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "Статус юзера:";
            // 
            // scTabs
            // 
            this.scTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scTabs.Location = new System.Drawing.Point(5, 127);
            this.scTabs.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.scTabs.Name = "scTabs";
            this.scTabs.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scTabs.Panel1
            // 
            this.scTabs.Panel1.Controls.Add(this.scPic);
            // 
            // scTabs.Panel2
            // 
            this.scTabs.Panel2.Controls.Add(this.tabControl1);
            this.scTabs.Size = new System.Drawing.Size(745, 1383);
            this.scTabs.SplitterDistance = 689;
            this.scTabs.SplitterWidth = 12;
            this.scTabs.TabIndex = 1;
            // 
            // colRelationsRelation
            // 
            this.colRelationsRelation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRelationsRelation.DataPropertyName = "Relation";
            this.colRelationsRelation.HeaderText = "Связь";
            this.colRelationsRelation.MinimumWidth = 8;
            this.colRelationsRelation.Name = "colRelationsRelation";
            this.colRelationsRelation.ReadOnly = true;
            this.colRelationsRelation.Width = 95;
            // 
            // colRelationsStatusIcon
            // 
            this.colRelationsStatusIcon.DataPropertyName = "UserStatusIcon";
            this.colRelationsStatusIcon.HeaderText = "Статус";
            this.colRelationsStatusIcon.MinimumWidth = 8;
            this.colRelationsStatusIcon.Name = "colRelationsStatusIcon";
            this.colRelationsStatusIcon.ReadOnly = true;
            this.colRelationsStatusIcon.Width = 50;
            // 
            // colRelationsTitle
            // 
            this.colRelationsTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRelationsTitle.DataPropertyName = "Name";
            this.colRelationsTitle.HeaderText = "Название";
            this.colRelationsTitle.MinimumWidth = 8;
            this.colRelationsTitle.Name = "colRelationsTitle";
            this.colRelationsTitle.ReadOnly = true;
            // 
            // colRecommendsCount
            // 
            this.colRecommendsCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRecommendsCount.DataPropertyName = "Count";
            this.colRecommendsCount.HeaderText = "Рекомендовало";
            this.colRecommendsCount.MinimumWidth = 8;
            this.colRecommendsCount.Name = "colRecommendsCount";
            this.colRecommendsCount.ReadOnly = true;
            this.colRecommendsCount.Width = 179;
            // 
            // colRecommedsStatusIcon
            // 
            this.colRecommedsStatusIcon.DataPropertyName = "UserStatusIcon";
            this.colRecommedsStatusIcon.HeaderText = "Статус";
            this.colRecommedsStatusIcon.MinimumWidth = 8;
            this.colRecommedsStatusIcon.Name = "colRecommedsStatusIcon";
            this.colRecommedsStatusIcon.ReadOnly = true;
            this.colRecommedsStatusIcon.Width = 50;
            // 
            // colRecommendsTitle
            // 
            this.colRecommendsTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRecommendsTitle.DataPropertyName = "Name";
            this.colRecommendsTitle.HeaderText = "Название";
            this.colRecommendsTitle.MinimumWidth = 8;
            this.colRecommendsTitle.Name = "colRecommendsTitle";
            this.colRecommendsTitle.ReadOnly = true;
            // 
            // UserControlAnimeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scTabs);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tbName);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "UserControlAnimeInfo";
            this.Size = new System.Drawing.Size(750, 1515);
            this.tabControl1.ResumeLayout(false);
            this.tpSynopsis.ResumeLayout(false);
            this.tpSynopsis.PerformLayout();
            this.tpGenres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenres)).EndInit();
            this.tpAltTitles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAltTitles)).EndInit();
            this.tpRelatedAnime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedAnime)).EndInit();
            this.tpRecommended.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecommended)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.scPic.Panel1.ResumeLayout(false);
            this.scPic.Panel2.ResumeLayout(false);
            this.scPic.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scPic)).EndInit();
            this.scPic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.scTabs.Panel1.ResumeLayout(false);
            this.scTabs.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTabs)).EndInit();
            this.scTabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbEpisodeDuration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSynopsis;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpSynopsis;
        private System.Windows.Forms.TabPage tpAltTitles;
        private System.Windows.Forms.DataGridView dgvAltTitles;
        private System.Windows.Forms.TabPage tpRelatedAnime;
        private System.Windows.Forms.DataGridView dgvRelatedAnime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLanguage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbBrowse;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.SplitContainer scPic;
        private System.Windows.Forms.SplitContainer scTabs;
        private System.Windows.Forms.TextBox tbUserStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tpGenres;
        private System.Windows.Forms.DataGridView dgvGenres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenreName;
        private System.Windows.Forms.TabPage tpRecommended;
        private System.Windows.Forms.DataGridView dgvRecommended;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbAddWatched;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRelationsRelation;
        private System.Windows.Forms.DataGridViewImageColumn colRelationsStatusIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRelationsTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecommendsCount;
        private System.Windows.Forms.DataGridViewImageColumn colRecommedsStatusIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecommendsTitle;
    }
}

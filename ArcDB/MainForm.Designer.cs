namespace ArcDB
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabctrMainform = new System.Windows.Forms.TabControl();
            this.tabPageCollect = new System.Windows.Forms.TabPage();
            this.btnDeleteCoconfig = new System.Windows.Forms.Button();
            this.btnCopyCoconfig = new System.Windows.Forms.Button();
            this.btnCoArticles = new System.Windows.Forms.Button();
            this.btnAddCoconfig = new System.Windows.Forms.Button();
            this.btnClearCoFilter = new System.Windows.Forms.Button();
            this.gboxCoFilter = new System.Windows.Forms.GroupBox();
            this.btnCoUnselectAll = new System.Windows.Forms.Button();
            this.btnCoSelectAll = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tboxCoFilterType_name = new System.Windows.Forms.TextBox();
            this.lblCoFilterType_name = new System.Windows.Forms.Label();
            this.cboxCoFilterType_name = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tboxCoFilterCo_nums = new System.Windows.Forms.TextBox();
            this.lblCoFilterCo_nums = new System.Windows.Forms.Label();
            this.cboxCoFilterCo_nums = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tboxCoFilterSource_site = new System.Windows.Forms.TextBox();
            this.lblCoFilterSource_site = new System.Windows.Forms.Label();
            this.cboxCoFilterSource_site = new System.Windows.Forms.ComboBox();
            this.panelFilterCo_name = new System.Windows.Forms.Panel();
            this.tboxCoFilterCo_name = new System.Windows.Forms.TextBox();
            this.lblCoFileterCo_name = new System.Windows.Forms.Label();
            this.cboxCoFilterCo_name = new System.Windows.Forms.ComboBox();
            this.btnModifyCoconfig = new System.Windows.Forms.Button();
            this.listViewCollect = new ArcDB.ListViewNF();
            this.cid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.co_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.source_lang = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.source_site = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.up_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.co_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.co_nums = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLoadCoconfig = new System.Windows.Forms.Button();
            this.tabPageDelWatermark = new System.Windows.Forms.TabPage();
            this.tabPageDistribute = new System.Windows.Forms.TabPage();
            this.btnDelPubConfig = new System.Windows.Forms.Button();
            this.btnCopyPubConfig = new System.Windows.Forms.Button();
            this.btnPubArticles = new System.Windows.Forms.Button();
            this.btnAddPubConfig = new System.Windows.Forms.Button();
            this.btnClearPubFilter = new System.Windows.Forms.Button();
            this.btnModifyPubConfig = new System.Windows.Forms.Button();
            this.btnLoadPubConfig = new System.Windows.Forms.Button();
            this.gboxPubFilter = new System.Windows.Forms.GroupBox();
            this.btnPubUnselectAll = new System.Windows.Forms.Button();
            this.btnPubSelectAll = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tboxPubFilterPub_typename = new System.Windows.Forms.TextBox();
            this.lblPubFilterPub_typename = new System.Windows.Forms.Label();
            this.cboxPubFilterPub_typename = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tboxPubFilterCo_typename = new System.Windows.Forms.TextBox();
            this.lblPubFilterCo_typename = new System.Windows.Forms.Label();
            this.cboxPubFilterCo_typename = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tboxPubFilterPub_name = new System.Windows.Forms.TextBox();
            this.lblPubFilterPub_name = new System.Windows.Forms.Label();
            this.cboxPubFilterPub_name = new System.Windows.Forms.ComboBox();
            this.listViewPublish = new ArcDB.ListViewNF();
            this.pub_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pub_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.co_typename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.unused_nums = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pub_typename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pub_nums = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.published_nums = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pub_add_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pub_export_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.gbxPubDatabaseSet = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tboxPubTablePrename = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tboxPubPort = new System.Windows.Forms.TextBox();
            this.tboxPubHostName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tboxPubDbName = new System.Windows.Forms.TextBox();
            this.tboxPubUserName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tboxPubPassword = new System.Windows.Forms.TextBox();
            this.cboxPubCharset = new System.Windows.Forms.ComboBox();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.gbxCoDatabaseSet = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxCoPort = new System.Windows.Forms.TextBox();
            this.tboxCoHostName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tboxCoDbName = new System.Windows.Forms.TextBox();
            this.tboxCoUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tboxCoPassword = new System.Windows.Forms.TextBox();
            this.cboxCoCharset = new System.Windows.Forms.ComboBox();
            this.tabctrMainform.SuspendLayout();
            this.tabPageCollect.SuspendLayout();
            this.gboxCoFilter.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelFilterCo_name.SuspendLayout();
            this.tabPageDistribute.SuspendLayout();
            this.gboxPubFilter.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabPageConfig.SuspendLayout();
            this.gbxPubDatabaseSet.SuspendLayout();
            this.gbxCoDatabaseSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabctrMainform
            // 
            this.tabctrMainform.Controls.Add(this.tabPageCollect);
            this.tabctrMainform.Controls.Add(this.tabPageDelWatermark);
            this.tabctrMainform.Controls.Add(this.tabPageDistribute);
            this.tabctrMainform.Controls.Add(this.tabPageConfig);
            this.tabctrMainform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabctrMainform.Location = new System.Drawing.Point(0, 0);
            this.tabctrMainform.Name = "tabctrMainform";
            this.tabctrMainform.SelectedIndex = 0;
            this.tabctrMainform.Size = new System.Drawing.Size(1015, 659);
            this.tabctrMainform.TabIndex = 1;
            // 
            // tabPageCollect
            // 
            this.tabPageCollect.Controls.Add(this.btnDeleteCoconfig);
            this.tabPageCollect.Controls.Add(this.btnCopyCoconfig);
            this.tabPageCollect.Controls.Add(this.btnCoArticles);
            this.tabPageCollect.Controls.Add(this.btnAddCoconfig);
            this.tabPageCollect.Controls.Add(this.btnClearCoFilter);
            this.tabPageCollect.Controls.Add(this.gboxCoFilter);
            this.tabPageCollect.Controls.Add(this.btnModifyCoconfig);
            this.tabPageCollect.Controls.Add(this.listViewCollect);
            this.tabPageCollect.Controls.Add(this.btnLoadCoconfig);
            this.tabPageCollect.Location = new System.Drawing.Point(4, 28);
            this.tabPageCollect.Name = "tabPageCollect";
            this.tabPageCollect.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCollect.Size = new System.Drawing.Size(1007, 627);
            this.tabPageCollect.TabIndex = 0;
            this.tabPageCollect.Text = "采集内容";
            this.tabPageCollect.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCoconfig
            // 
            this.btnDeleteCoconfig.Location = new System.Drawing.Point(559, 571);
            this.btnDeleteCoconfig.Name = "btnDeleteCoconfig";
            this.btnDeleteCoconfig.Size = new System.Drawing.Size(133, 37);
            this.btnDeleteCoconfig.TabIndex = 9;
            this.btnDeleteCoconfig.Text = "删除采集规则";
            this.btnDeleteCoconfig.UseVisualStyleBackColor = true;
            this.btnDeleteCoconfig.Click += new System.EventHandler(this.btnDeleteCoconfig_Click);
            // 
            // btnCopyCoconfig
            // 
            this.btnCopyCoconfig.Location = new System.Drawing.Point(420, 571);
            this.btnCopyCoconfig.Name = "btnCopyCoconfig";
            this.btnCopyCoconfig.Size = new System.Drawing.Size(133, 37);
            this.btnCopyCoconfig.TabIndex = 8;
            this.btnCopyCoconfig.Text = "复制采集规则";
            this.btnCopyCoconfig.UseVisualStyleBackColor = true;
            this.btnCopyCoconfig.Click += new System.EventHandler(this.btnCopyCoconfig_Click);
            // 
            // btnCoArticles
            // 
            this.btnCoArticles.Location = new System.Drawing.Point(869, 571);
            this.btnCoArticles.Name = "btnCoArticles";
            this.btnCoArticles.Size = new System.Drawing.Size(133, 37);
            this.btnCoArticles.TabIndex = 7;
            this.btnCoArticles.Text = "开始采集";
            this.btnCoArticles.UseVisualStyleBackColor = true;
            this.btnCoArticles.Click += new System.EventHandler(this.btnCoArticles_Click);
            // 
            // btnAddCoconfig
            // 
            this.btnAddCoconfig.Location = new System.Drawing.Point(281, 571);
            this.btnAddCoconfig.Name = "btnAddCoconfig";
            this.btnAddCoconfig.Size = new System.Drawing.Size(133, 37);
            this.btnAddCoconfig.TabIndex = 6;
            this.btnAddCoconfig.Text = "增加采集规则";
            this.btnAddCoconfig.UseVisualStyleBackColor = true;
            this.btnAddCoconfig.Click += new System.EventHandler(this.btnAddCoconfig_Click);
            // 
            // btnClearCoFilter
            // 
            this.btnClearCoFilter.Location = new System.Drawing.Point(701, 571);
            this.btnClearCoFilter.Name = "btnClearCoFilter";
            this.btnClearCoFilter.Size = new System.Drawing.Size(133, 37);
            this.btnClearCoFilter.TabIndex = 5;
            this.btnClearCoFilter.Text = "清空过滤器";
            this.btnClearCoFilter.UseVisualStyleBackColor = true;
            this.btnClearCoFilter.Click += new System.EventHandler(this.btnClearCoFilter_Click);
            // 
            // gboxCoFilter
            // 
            this.gboxCoFilter.Controls.Add(this.btnCoUnselectAll);
            this.gboxCoFilter.Controls.Add(this.btnCoSelectAll);
            this.gboxCoFilter.Controls.Add(this.panel3);
            this.gboxCoFilter.Controls.Add(this.panel2);
            this.gboxCoFilter.Controls.Add(this.panel1);
            this.gboxCoFilter.Controls.Add(this.panelFilterCo_name);
            this.gboxCoFilter.Location = new System.Drawing.Point(3, 7);
            this.gboxCoFilter.Name = "gboxCoFilter";
            this.gboxCoFilter.Size = new System.Drawing.Size(999, 149);
            this.gboxCoFilter.TabIndex = 4;
            this.gboxCoFilter.TabStop = false;
            this.gboxCoFilter.Text = "过滤器";
            // 
            // btnCoUnselectAll
            // 
            this.btnCoUnselectAll.Location = new System.Drawing.Point(476, 92);
            this.btnCoUnselectAll.Name = "btnCoUnselectAll";
            this.btnCoUnselectAll.Size = new System.Drawing.Size(133, 37);
            this.btnCoUnselectAll.TabIndex = 11;
            this.btnCoUnselectAll.Text = "取消全选";
            this.btnCoUnselectAll.UseVisualStyleBackColor = true;
            this.btnCoUnselectAll.Click += new System.EventHandler(this.btnCoUnselectAll_Click);
            // 
            // btnCoSelectAll
            // 
            this.btnCoSelectAll.Location = new System.Drawing.Point(337, 92);
            this.btnCoSelectAll.Name = "btnCoSelectAll";
            this.btnCoSelectAll.Size = new System.Drawing.Size(133, 37);
            this.btnCoSelectAll.TabIndex = 10;
            this.btnCoSelectAll.Text = "全选采集规则";
            this.btnCoSelectAll.UseVisualStyleBackColor = true;
            this.btnCoSelectAll.Click += new System.EventHandler(this.btnCoSelectAll_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tboxCoFilterType_name);
            this.panel3.Controls.Add(this.lblCoFilterType_name);
            this.panel3.Controls.Add(this.cboxCoFilterType_name);
            this.panel3.Location = new System.Drawing.Point(8, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(323, 48);
            this.panel3.TabIndex = 4;
            // 
            // tboxCoFilterType_name
            // 
            this.tboxCoFilterType_name.Location = new System.Drawing.Point(170, 11);
            this.tboxCoFilterType_name.Name = "tboxCoFilterType_name";
            this.tboxCoFilterType_name.Size = new System.Drawing.Size(145, 28);
            this.tboxCoFilterType_name.TabIndex = 3;
            // 
            // lblCoFilterType_name
            // 
            this.lblCoFilterType_name.AutoSize = true;
            this.lblCoFilterType_name.Location = new System.Drawing.Point(3, 14);
            this.lblCoFilterType_name.Name = "lblCoFilterType_name";
            this.lblCoFilterType_name.Size = new System.Drawing.Size(80, 18);
            this.lblCoFilterType_name.TabIndex = 1;
            this.lblCoFilterType_name.Text = "分类名称";
            // 
            // cboxCoFilterType_name
            // 
            this.cboxCoFilterType_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCoFilterType_name.FormattingEnabled = true;
            this.cboxCoFilterType_name.Items.AddRange(new object[] {
            "=",
            "like",
            "<>"});
            this.cboxCoFilterType_name.Location = new System.Drawing.Point(92, 11);
            this.cboxCoFilterType_name.Name = "cboxCoFilterType_name";
            this.cboxCoFilterType_name.Size = new System.Drawing.Size(72, 26);
            this.cboxCoFilterType_name.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tboxCoFilterCo_nums);
            this.panel2.Controls.Add(this.lblCoFilterCo_nums);
            this.panel2.Controls.Add(this.cboxCoFilterCo_nums);
            this.panel2.Location = new System.Drawing.Point(666, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(323, 48);
            this.panel2.TabIndex = 5;
            // 
            // tboxCoFilterCo_nums
            // 
            this.tboxCoFilterCo_nums.Location = new System.Drawing.Point(170, 11);
            this.tboxCoFilterCo_nums.Name = "tboxCoFilterCo_nums";
            this.tboxCoFilterCo_nums.Size = new System.Drawing.Size(145, 28);
            this.tboxCoFilterCo_nums.TabIndex = 3;
            // 
            // lblCoFilterCo_nums
            // 
            this.lblCoFilterCo_nums.AutoSize = true;
            this.lblCoFilterCo_nums.Location = new System.Drawing.Point(3, 14);
            this.lblCoFilterCo_nums.Name = "lblCoFilterCo_nums";
            this.lblCoFilterCo_nums.Size = new System.Drawing.Size(80, 18);
            this.lblCoFilterCo_nums.TabIndex = 1;
            this.lblCoFilterCo_nums.Text = "采集数量";
            // 
            // cboxCoFilterCo_nums
            // 
            this.cboxCoFilterCo_nums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCoFilterCo_nums.FormattingEnabled = true;
            this.cboxCoFilterCo_nums.Items.AddRange(new object[] {
            "=",
            "<>",
            ">",
            "<"});
            this.cboxCoFilterCo_nums.Location = new System.Drawing.Point(92, 11);
            this.cboxCoFilterCo_nums.Name = "cboxCoFilterCo_nums";
            this.cboxCoFilterCo_nums.Size = new System.Drawing.Size(72, 26);
            this.cboxCoFilterCo_nums.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tboxCoFilterSource_site);
            this.panel1.Controls.Add(this.lblCoFilterSource_site);
            this.panel1.Controls.Add(this.cboxCoFilterSource_site);
            this.panel1.Location = new System.Drawing.Point(337, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 48);
            this.panel1.TabIndex = 4;
            // 
            // tboxCoFilterSource_site
            // 
            this.tboxCoFilterSource_site.Location = new System.Drawing.Point(170, 11);
            this.tboxCoFilterSource_site.Name = "tboxCoFilterSource_site";
            this.tboxCoFilterSource_site.Size = new System.Drawing.Size(145, 28);
            this.tboxCoFilterSource_site.TabIndex = 3;
            // 
            // lblCoFilterSource_site
            // 
            this.lblCoFilterSource_site.AutoSize = true;
            this.lblCoFilterSource_site.Location = new System.Drawing.Point(3, 14);
            this.lblCoFilterSource_site.Name = "lblCoFilterSource_site";
            this.lblCoFilterSource_site.Size = new System.Drawing.Size(80, 18);
            this.lblCoFilterSource_site.TabIndex = 1;
            this.lblCoFilterSource_site.Text = "采集来源";
            // 
            // cboxCoFilterSource_site
            // 
            this.cboxCoFilterSource_site.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCoFilterSource_site.FormattingEnabled = true;
            this.cboxCoFilterSource_site.Items.AddRange(new object[] {
            "=",
            "like",
            "<>"});
            this.cboxCoFilterSource_site.Location = new System.Drawing.Point(92, 11);
            this.cboxCoFilterSource_site.Name = "cboxCoFilterSource_site";
            this.cboxCoFilterSource_site.Size = new System.Drawing.Size(72, 26);
            this.cboxCoFilterSource_site.TabIndex = 0;
            // 
            // panelFilterCo_name
            // 
            this.panelFilterCo_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilterCo_name.Controls.Add(this.tboxCoFilterCo_name);
            this.panelFilterCo_name.Controls.Add(this.lblCoFileterCo_name);
            this.panelFilterCo_name.Controls.Add(this.cboxCoFilterCo_name);
            this.panelFilterCo_name.Location = new System.Drawing.Point(8, 23);
            this.panelFilterCo_name.Name = "panelFilterCo_name";
            this.panelFilterCo_name.Size = new System.Drawing.Size(323, 48);
            this.panelFilterCo_name.TabIndex = 2;
            // 
            // tboxCoFilterCo_name
            // 
            this.tboxCoFilterCo_name.Location = new System.Drawing.Point(170, 11);
            this.tboxCoFilterCo_name.Name = "tboxCoFilterCo_name";
            this.tboxCoFilterCo_name.Size = new System.Drawing.Size(145, 28);
            this.tboxCoFilterCo_name.TabIndex = 3;
            // 
            // lblCoFileterCo_name
            // 
            this.lblCoFileterCo_name.AutoSize = true;
            this.lblCoFileterCo_name.Location = new System.Drawing.Point(3, 14);
            this.lblCoFileterCo_name.Name = "lblCoFileterCo_name";
            this.lblCoFileterCo_name.Size = new System.Drawing.Size(80, 18);
            this.lblCoFileterCo_name.TabIndex = 1;
            this.lblCoFileterCo_name.Text = "采集名称";
            // 
            // cboxCoFilterCo_name
            // 
            this.cboxCoFilterCo_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCoFilterCo_name.FormattingEnabled = true;
            this.cboxCoFilterCo_name.Items.AddRange(new object[] {
            "=",
            "like",
            "<>"});
            this.cboxCoFilterCo_name.Location = new System.Drawing.Point(92, 11);
            this.cboxCoFilterCo_name.Name = "cboxCoFilterCo_name";
            this.cboxCoFilterCo_name.Size = new System.Drawing.Size(72, 26);
            this.cboxCoFilterCo_name.TabIndex = 0;
            // 
            // btnModifyCoconfig
            // 
            this.btnModifyCoconfig.Location = new System.Drawing.Point(142, 571);
            this.btnModifyCoconfig.Name = "btnModifyCoconfig";
            this.btnModifyCoconfig.Size = new System.Drawing.Size(133, 37);
            this.btnModifyCoconfig.TabIndex = 3;
            this.btnModifyCoconfig.Text = "修改采集规则";
            this.btnModifyCoconfig.UseVisualStyleBackColor = true;
            this.btnModifyCoconfig.Click += new System.EventHandler(this.btnModifyCoconfig_Click);
            // 
            // listViewCollect
            // 
            this.listViewCollect.CheckBoxes = true;
            this.listViewCollect.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cid,
            this.co_name,
            this.type_name,
            this.source_lang,
            this.source_site,
            this.up_time,
            this.co_time,
            this.co_nums});
            this.listViewCollect.FullRowSelect = true;
            this.listViewCollect.GridLines = true;
            this.listViewCollect.Location = new System.Drawing.Point(3, 162);
            this.listViewCollect.MultiSelect = false;
            this.listViewCollect.Name = "listViewCollect";
            this.listViewCollect.Size = new System.Drawing.Size(999, 390);
            this.listViewCollect.TabIndex = 2;
            this.listViewCollect.UseCompatibleStateImageBehavior = false;
            this.listViewCollect.View = System.Windows.Forms.View.Details;
            // 
            // cid
            // 
            this.cid.Text = "ID";
            this.cid.Width = 50;
            // 
            // co_name
            // 
            this.co_name.Text = "采集名称";
            this.co_name.Width = 120;
            // 
            // type_name
            // 
            this.type_name.Text = "文章分类";
            this.type_name.Width = 120;
            // 
            // source_lang
            // 
            this.source_lang.Text = "编码";
            this.source_lang.Width = 70;
            // 
            // source_site
            // 
            this.source_site.Text = "采集来源";
            this.source_site.Width = 120;
            // 
            // up_time
            // 
            this.up_time.Text = "加入/修改日期";
            this.up_time.Width = 95;
            // 
            // co_time
            // 
            this.co_time.Text = "最后采集日期";
            this.co_time.Width = 95;
            // 
            // co_nums
            // 
            this.co_nums.Text = "采集数量";
            this.co_nums.Width = 90;
            // 
            // btnLoadCoconfig
            // 
            this.btnLoadCoconfig.Location = new System.Drawing.Point(3, 571);
            this.btnLoadCoconfig.Name = "btnLoadCoconfig";
            this.btnLoadCoconfig.Size = new System.Drawing.Size(133, 37);
            this.btnLoadCoconfig.TabIndex = 1;
            this.btnLoadCoconfig.Text = "加载采集规则";
            this.btnLoadCoconfig.UseVisualStyleBackColor = true;
            this.btnLoadCoconfig.Click += new System.EventHandler(this.btnLoadCoconfig_Click);
            // 
            // tabPageDelWatermark
            // 
            this.tabPageDelWatermark.Location = new System.Drawing.Point(4, 28);
            this.tabPageDelWatermark.Name = "tabPageDelWatermark";
            this.tabPageDelWatermark.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDelWatermark.Size = new System.Drawing.Size(1007, 627);
            this.tabPageDelWatermark.TabIndex = 1;
            this.tabPageDelWatermark.Text = "去水印";
            this.tabPageDelWatermark.UseVisualStyleBackColor = true;
            // 
            // tabPageDistribute
            // 
            this.tabPageDistribute.Controls.Add(this.btnDelPubConfig);
            this.tabPageDistribute.Controls.Add(this.btnCopyPubConfig);
            this.tabPageDistribute.Controls.Add(this.btnPubArticles);
            this.tabPageDistribute.Controls.Add(this.btnAddPubConfig);
            this.tabPageDistribute.Controls.Add(this.btnClearPubFilter);
            this.tabPageDistribute.Controls.Add(this.btnModifyPubConfig);
            this.tabPageDistribute.Controls.Add(this.btnLoadPubConfig);
            this.tabPageDistribute.Controls.Add(this.gboxPubFilter);
            this.tabPageDistribute.Controls.Add(this.listViewPublish);
            this.tabPageDistribute.Location = new System.Drawing.Point(4, 28);
            this.tabPageDistribute.Name = "tabPageDistribute";
            this.tabPageDistribute.Size = new System.Drawing.Size(1007, 627);
            this.tabPageDistribute.TabIndex = 2;
            this.tabPageDistribute.Text = "内容分发";
            this.tabPageDistribute.UseVisualStyleBackColor = true;
            // 
            // btnDelPubConfig
            // 
            this.btnDelPubConfig.Location = new System.Drawing.Point(559, 571);
            this.btnDelPubConfig.Name = "btnDelPubConfig";
            this.btnDelPubConfig.Size = new System.Drawing.Size(133, 37);
            this.btnDelPubConfig.TabIndex = 16;
            this.btnDelPubConfig.Text = "删除发布规则";
            this.btnDelPubConfig.UseVisualStyleBackColor = true;
            this.btnDelPubConfig.Click += new System.EventHandler(this.btnDelPubConfig_Click);
            // 
            // btnCopyPubConfig
            // 
            this.btnCopyPubConfig.Location = new System.Drawing.Point(420, 571);
            this.btnCopyPubConfig.Name = "btnCopyPubConfig";
            this.btnCopyPubConfig.Size = new System.Drawing.Size(133, 37);
            this.btnCopyPubConfig.TabIndex = 15;
            this.btnCopyPubConfig.Text = "复制发布规则";
            this.btnCopyPubConfig.UseVisualStyleBackColor = true;
            this.btnCopyPubConfig.Click += new System.EventHandler(this.btnCopyPubConfig_Click);
            // 
            // btnPubArticles
            // 
            this.btnPubArticles.Location = new System.Drawing.Point(869, 571);
            this.btnPubArticles.Name = "btnPubArticles";
            this.btnPubArticles.Size = new System.Drawing.Size(133, 37);
            this.btnPubArticles.TabIndex = 14;
            this.btnPubArticles.Text = "开始发布";
            this.btnPubArticles.UseVisualStyleBackColor = true;
            this.btnPubArticles.Click += new System.EventHandler(this.btnPubArticles_Click);
            // 
            // btnAddPubConfig
            // 
            this.btnAddPubConfig.Location = new System.Drawing.Point(281, 571);
            this.btnAddPubConfig.Name = "btnAddPubConfig";
            this.btnAddPubConfig.Size = new System.Drawing.Size(133, 37);
            this.btnAddPubConfig.TabIndex = 13;
            this.btnAddPubConfig.Text = "增加发布规则";
            this.btnAddPubConfig.UseVisualStyleBackColor = true;
            this.btnAddPubConfig.Click += new System.EventHandler(this.btnAddPubConfig_Click);
            // 
            // btnClearPubFilter
            // 
            this.btnClearPubFilter.Location = new System.Drawing.Point(701, 571);
            this.btnClearPubFilter.Name = "btnClearPubFilter";
            this.btnClearPubFilter.Size = new System.Drawing.Size(133, 37);
            this.btnClearPubFilter.TabIndex = 12;
            this.btnClearPubFilter.Text = "清空过滤器";
            this.btnClearPubFilter.UseVisualStyleBackColor = true;
            this.btnClearPubFilter.Click += new System.EventHandler(this.btnClearPubFilter_Click);
            // 
            // btnModifyPubConfig
            // 
            this.btnModifyPubConfig.Location = new System.Drawing.Point(142, 571);
            this.btnModifyPubConfig.Name = "btnModifyPubConfig";
            this.btnModifyPubConfig.Size = new System.Drawing.Size(133, 37);
            this.btnModifyPubConfig.TabIndex = 11;
            this.btnModifyPubConfig.Text = "修改发布规则";
            this.btnModifyPubConfig.UseVisualStyleBackColor = true;
            this.btnModifyPubConfig.Click += new System.EventHandler(this.btnModifyPubConfig_Click);
            // 
            // btnLoadPubConfig
            // 
            this.btnLoadPubConfig.Location = new System.Drawing.Point(3, 571);
            this.btnLoadPubConfig.Name = "btnLoadPubConfig";
            this.btnLoadPubConfig.Size = new System.Drawing.Size(133, 37);
            this.btnLoadPubConfig.TabIndex = 10;
            this.btnLoadPubConfig.Text = "加载发布规则";
            this.btnLoadPubConfig.UseVisualStyleBackColor = true;
            this.btnLoadPubConfig.Click += new System.EventHandler(this.btnLoadPubConfig_Click);
            // 
            // gboxPubFilter
            // 
            this.gboxPubFilter.Controls.Add(this.btnPubUnselectAll);
            this.gboxPubFilter.Controls.Add(this.btnPubSelectAll);
            this.gboxPubFilter.Controls.Add(this.panel5);
            this.gboxPubFilter.Controls.Add(this.panel6);
            this.gboxPubFilter.Controls.Add(this.panel7);
            this.gboxPubFilter.Location = new System.Drawing.Point(3, 7);
            this.gboxPubFilter.Name = "gboxPubFilter";
            this.gboxPubFilter.Size = new System.Drawing.Size(999, 149);
            this.gboxPubFilter.TabIndex = 5;
            this.gboxPubFilter.TabStop = false;
            this.gboxPubFilter.Text = "过滤器";
            // 
            // btnPubUnselectAll
            // 
            this.btnPubUnselectAll.Location = new System.Drawing.Point(147, 92);
            this.btnPubUnselectAll.Name = "btnPubUnselectAll";
            this.btnPubUnselectAll.Size = new System.Drawing.Size(133, 37);
            this.btnPubUnselectAll.TabIndex = 11;
            this.btnPubUnselectAll.Text = "取消全选";
            this.btnPubUnselectAll.UseVisualStyleBackColor = true;
            this.btnPubUnselectAll.Click += new System.EventHandler(this.btnPubUnselectAll_Click);
            // 
            // btnPubSelectAll
            // 
            this.btnPubSelectAll.Location = new System.Drawing.Point(8, 92);
            this.btnPubSelectAll.Name = "btnPubSelectAll";
            this.btnPubSelectAll.Size = new System.Drawing.Size(133, 37);
            this.btnPubSelectAll.TabIndex = 10;
            this.btnPubSelectAll.Text = "全选发布规则";
            this.btnPubSelectAll.UseVisualStyleBackColor = true;
            this.btnPubSelectAll.Click += new System.EventHandler(this.btnPubSelectAll_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.tboxPubFilterPub_typename);
            this.panel5.Controls.Add(this.lblPubFilterPub_typename);
            this.panel5.Controls.Add(this.cboxPubFilterPub_typename);
            this.panel5.Location = new System.Drawing.Point(666, 23);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(323, 48);
            this.panel5.TabIndex = 5;
            // 
            // tboxPubFilterPub_typename
            // 
            this.tboxPubFilterPub_typename.Location = new System.Drawing.Point(170, 11);
            this.tboxPubFilterPub_typename.Name = "tboxPubFilterPub_typename";
            this.tboxPubFilterPub_typename.Size = new System.Drawing.Size(145, 28);
            this.tboxPubFilterPub_typename.TabIndex = 3;
            // 
            // lblPubFilterPub_typename
            // 
            this.lblPubFilterPub_typename.AutoSize = true;
            this.lblPubFilterPub_typename.Location = new System.Drawing.Point(3, 14);
            this.lblPubFilterPub_typename.Name = "lblPubFilterPub_typename";
            this.lblPubFilterPub_typename.Size = new System.Drawing.Size(80, 18);
            this.lblPubFilterPub_typename.TabIndex = 1;
            this.lblPubFilterPub_typename.Text = "发布分类";
            // 
            // cboxPubFilterPub_typename
            // 
            this.cboxPubFilterPub_typename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPubFilterPub_typename.FormattingEnabled = true;
            this.cboxPubFilterPub_typename.Items.AddRange(new object[] {
            "=",
            "like",
            "<>"});
            this.cboxPubFilterPub_typename.Location = new System.Drawing.Point(92, 11);
            this.cboxPubFilterPub_typename.Name = "cboxPubFilterPub_typename";
            this.cboxPubFilterPub_typename.Size = new System.Drawing.Size(72, 26);
            this.cboxPubFilterPub_typename.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.tboxPubFilterCo_typename);
            this.panel6.Controls.Add(this.lblPubFilterCo_typename);
            this.panel6.Controls.Add(this.cboxPubFilterCo_typename);
            this.panel6.Location = new System.Drawing.Point(337, 23);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(323, 48);
            this.panel6.TabIndex = 4;
            // 
            // tboxPubFilterCo_typename
            // 
            this.tboxPubFilterCo_typename.Location = new System.Drawing.Point(170, 11);
            this.tboxPubFilterCo_typename.Name = "tboxPubFilterCo_typename";
            this.tboxPubFilterCo_typename.Size = new System.Drawing.Size(145, 28);
            this.tboxPubFilterCo_typename.TabIndex = 3;
            // 
            // lblPubFilterCo_typename
            // 
            this.lblPubFilterCo_typename.AutoSize = true;
            this.lblPubFilterCo_typename.Location = new System.Drawing.Point(3, 14);
            this.lblPubFilterCo_typename.Name = "lblPubFilterCo_typename";
            this.lblPubFilterCo_typename.Size = new System.Drawing.Size(80, 18);
            this.lblPubFilterCo_typename.TabIndex = 1;
            this.lblPubFilterCo_typename.Text = "采集分类";
            // 
            // cboxPubFilterCo_typename
            // 
            this.cboxPubFilterCo_typename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPubFilterCo_typename.FormattingEnabled = true;
            this.cboxPubFilterCo_typename.Items.AddRange(new object[] {
            "=",
            "like",
            "<>"});
            this.cboxPubFilterCo_typename.Location = new System.Drawing.Point(92, 11);
            this.cboxPubFilterCo_typename.Name = "cboxPubFilterCo_typename";
            this.cboxPubFilterCo_typename.Size = new System.Drawing.Size(72, 26);
            this.cboxPubFilterCo_typename.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.tboxPubFilterPub_name);
            this.panel7.Controls.Add(this.lblPubFilterPub_name);
            this.panel7.Controls.Add(this.cboxPubFilterPub_name);
            this.panel7.Location = new System.Drawing.Point(8, 23);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(323, 48);
            this.panel7.TabIndex = 2;
            // 
            // tboxPubFilterPub_name
            // 
            this.tboxPubFilterPub_name.Location = new System.Drawing.Point(170, 11);
            this.tboxPubFilterPub_name.Name = "tboxPubFilterPub_name";
            this.tboxPubFilterPub_name.Size = new System.Drawing.Size(145, 28);
            this.tboxPubFilterPub_name.TabIndex = 3;
            // 
            // lblPubFilterPub_name
            // 
            this.lblPubFilterPub_name.AutoSize = true;
            this.lblPubFilterPub_name.Location = new System.Drawing.Point(3, 14);
            this.lblPubFilterPub_name.Name = "lblPubFilterPub_name";
            this.lblPubFilterPub_name.Size = new System.Drawing.Size(80, 18);
            this.lblPubFilterPub_name.TabIndex = 1;
            this.lblPubFilterPub_name.Text = "发布名称";
            // 
            // cboxPubFilterPub_name
            // 
            this.cboxPubFilterPub_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPubFilterPub_name.FormattingEnabled = true;
            this.cboxPubFilterPub_name.Items.AddRange(new object[] {
            "=",
            "like",
            "<>"});
            this.cboxPubFilterPub_name.Location = new System.Drawing.Point(92, 11);
            this.cboxPubFilterPub_name.Name = "cboxPubFilterPub_name";
            this.cboxPubFilterPub_name.Size = new System.Drawing.Size(72, 26);
            this.cboxPubFilterPub_name.TabIndex = 0;
            // 
            // listViewPublish
            // 
            this.listViewPublish.CheckBoxes = true;
            this.listViewPublish.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pub_id,
            this.pub_name,
            this.co_typename,
            this.unused_nums,
            this.pub_typename,
            this.pub_nums,
            this.published_nums,
            this.pub_add_date,
            this.pub_export_date});
            this.listViewPublish.FullRowSelect = true;
            this.listViewPublish.GridLines = true;
            this.listViewPublish.Location = new System.Drawing.Point(3, 162);
            this.listViewPublish.MultiSelect = false;
            this.listViewPublish.Name = "listViewPublish";
            this.listViewPublish.Size = new System.Drawing.Size(999, 390);
            this.listViewPublish.TabIndex = 0;
            this.listViewPublish.UseCompatibleStateImageBehavior = false;
            this.listViewPublish.View = System.Windows.Forms.View.Details;
            // 
            // pub_id
            // 
            this.pub_id.Text = "ID";
            // 
            // pub_name
            // 
            this.pub_name.Text = "发布规则名称";
            this.pub_name.Width = 120;
            // 
            // co_typename
            // 
            this.co_typename.Text = "采集分类";
            this.co_typename.Width = 120;
            // 
            // unused_nums
            // 
            this.unused_nums.Text = "可用文章数";
            this.unused_nums.Width = 120;
            // 
            // pub_typename
            // 
            this.pub_typename.Text = "发布分类";
            this.pub_typename.Width = 120;
            // 
            // pub_nums
            // 
            this.pub_nums.Text = "单次发布数量";
            this.pub_nums.Width = 120;
            // 
            // published_nums
            // 
            this.published_nums.Text = "已发布数量";
            this.published_nums.Width = 120;
            // 
            // pub_add_date
            // 
            this.pub_add_date.Text = "添加日期";
            this.pub_add_date.Width = 120;
            // 
            // pub_export_date
            // 
            this.pub_export_date.Text = "发布日期";
            this.pub_export_date.Width = 120;
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.gbxPubDatabaseSet);
            this.tabPageConfig.Controls.Add(this.btnSaveConfig);
            this.tabPageConfig.Controls.Add(this.gbxCoDatabaseSet);
            this.tabPageConfig.Location = new System.Drawing.Point(4, 28);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfig.Size = new System.Drawing.Size(1007, 627);
            this.tabPageConfig.TabIndex = 3;
            this.tabPageConfig.Text = "系统设置";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // gbxPubDatabaseSet
            // 
            this.gbxPubDatabaseSet.Controls.Add(this.label13);
            this.gbxPubDatabaseSet.Controls.Add(this.tboxPubTablePrename);
            this.gbxPubDatabaseSet.Controls.Add(this.label5);
            this.gbxPubDatabaseSet.Controls.Add(this.tboxPubPort);
            this.gbxPubDatabaseSet.Controls.Add(this.tboxPubHostName);
            this.gbxPubDatabaseSet.Controls.Add(this.label7);
            this.gbxPubDatabaseSet.Controls.Add(this.label9);
            this.gbxPubDatabaseSet.Controls.Add(this.tboxPubDbName);
            this.gbxPubDatabaseSet.Controls.Add(this.tboxPubUserName);
            this.gbxPubDatabaseSet.Controls.Add(this.label10);
            this.gbxPubDatabaseSet.Controls.Add(this.label11);
            this.gbxPubDatabaseSet.Controls.Add(this.label12);
            this.gbxPubDatabaseSet.Controls.Add(this.tboxPubPassword);
            this.gbxPubDatabaseSet.Controls.Add(this.cboxPubCharset);
            this.gbxPubDatabaseSet.Location = new System.Drawing.Point(8, 204);
            this.gbxPubDatabaseSet.Name = "gbxPubDatabaseSet";
            this.gbxPubDatabaseSet.Size = new System.Drawing.Size(991, 162);
            this.gbxPubDatabaseSet.TabIndex = 37;
            this.gbxPubDatabaseSet.TabStop = false;
            this.gbxPubDatabaseSet.Text = "发布数据库设置(CMS数据库)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(657, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(134, 18);
            this.label13.TabIndex = 36;
            this.label13.Text = "CMS数据表前缀:";
            // 
            // tboxPubTablePrename
            // 
            this.tboxPubTablePrename.Location = new System.Drawing.Point(803, 32);
            this.tboxPubTablePrename.Name = "tboxPubTablePrename";
            this.tboxPubTablePrename.Size = new System.Drawing.Size(166, 28);
            this.tboxPubTablePrename.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 18);
            this.label5.TabIndex = 23;
            this.label5.Text = "Mysql HostName:";
            // 
            // tboxPubPort
            // 
            this.tboxPubPort.Location = new System.Drawing.Point(471, 107);
            this.tboxPubPort.Name = "tboxPubPort";
            this.tboxPubPort.Size = new System.Drawing.Size(166, 28);
            this.tboxPubPort.TabIndex = 35;
            this.tboxPubPort.Text = "3306";
            // 
            // tboxPubHostName
            // 
            this.tboxPubHostName.Location = new System.Drawing.Point(155, 34);
            this.tboxPubHostName.Name = "tboxPubHostName";
            this.tboxPubHostName.Size = new System.Drawing.Size(166, 28);
            this.tboxPubHostName.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(327, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 18);
            this.label7.TabIndex = 34;
            this.label7.Text = "Mysql Port:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 18);
            this.label9.TabIndex = 24;
            this.label9.Text = "Mysql UserName:";
            // 
            // tboxPubDbName
            // 
            this.tboxPubDbName.Location = new System.Drawing.Point(155, 107);
            this.tboxPubDbName.Name = "tboxPubDbName";
            this.tboxPubDbName.Size = new System.Drawing.Size(166, 28);
            this.tboxPubDbName.TabIndex = 31;
            // 
            // tboxPubUserName
            // 
            this.tboxPubUserName.Location = new System.Drawing.Point(155, 68);
            this.tboxPubUserName.Name = "tboxPubUserName";
            this.tboxPubUserName.Size = new System.Drawing.Size(166, 28);
            this.tboxPubUserName.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 18);
            this.label10.TabIndex = 30;
            this.label10.Text = "Mysql DbName:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(327, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 18);
            this.label11.TabIndex = 26;
            this.label11.Text = "Mysql Password:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(327, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 18);
            this.label12.TabIndex = 29;
            this.label12.Text = "Mysql Charset:";
            // 
            // tboxPubPassword
            // 
            this.tboxPubPassword.Location = new System.Drawing.Point(471, 68);
            this.tboxPubPassword.Name = "tboxPubPassword";
            this.tboxPubPassword.Size = new System.Drawing.Size(166, 28);
            this.tboxPubPassword.TabIndex = 27;
            // 
            // cboxPubCharset
            // 
            this.cboxPubCharset.FormattingEnabled = true;
            this.cboxPubCharset.Items.AddRange(new object[] {
            "utf8",
            "gb2312"});
            this.cboxPubCharset.Location = new System.Drawing.Point(471, 34);
            this.cboxPubCharset.Name = "cboxPubCharset";
            this.cboxPubCharset.Size = new System.Drawing.Size(166, 26);
            this.cboxPubCharset.TabIndex = 28;
            this.cboxPubCharset.Text = "utf8";
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(848, 419);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(129, 36);
            this.btnSaveConfig.TabIndex = 37;
            this.btnSaveConfig.Text = "保存配置";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // gbxCoDatabaseSet
            // 
            this.gbxCoDatabaseSet.Controls.Add(this.label1);
            this.gbxCoDatabaseSet.Controls.Add(this.tboxCoPort);
            this.gbxCoDatabaseSet.Controls.Add(this.tboxCoHostName);
            this.gbxCoDatabaseSet.Controls.Add(this.label8);
            this.gbxCoDatabaseSet.Controls.Add(this.label2);
            this.gbxCoDatabaseSet.Controls.Add(this.tboxCoDbName);
            this.gbxCoDatabaseSet.Controls.Add(this.tboxCoUserName);
            this.gbxCoDatabaseSet.Controls.Add(this.label6);
            this.gbxCoDatabaseSet.Controls.Add(this.label3);
            this.gbxCoDatabaseSet.Controls.Add(this.label4);
            this.gbxCoDatabaseSet.Controls.Add(this.tboxCoPassword);
            this.gbxCoDatabaseSet.Controls.Add(this.cboxCoCharset);
            this.gbxCoDatabaseSet.Location = new System.Drawing.Point(8, 17);
            this.gbxCoDatabaseSet.Name = "gbxCoDatabaseSet";
            this.gbxCoDatabaseSet.Size = new System.Drawing.Size(651, 162);
            this.gbxCoDatabaseSet.TabIndex = 36;
            this.gbxCoDatabaseSet.TabStop = false;
            this.gbxCoDatabaseSet.Text = "采集数据库设置";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "Mysql HostName:";
            // 
            // tboxCoPort
            // 
            this.tboxCoPort.Location = new System.Drawing.Point(471, 107);
            this.tboxCoPort.Name = "tboxCoPort";
            this.tboxCoPort.Size = new System.Drawing.Size(166, 28);
            this.tboxCoPort.TabIndex = 35;
            this.tboxCoPort.Text = "3306";
            // 
            // tboxCoHostName
            // 
            this.tboxCoHostName.Location = new System.Drawing.Point(155, 34);
            this.tboxCoHostName.Name = "tboxCoHostName";
            this.tboxCoHostName.Size = new System.Drawing.Size(166, 28);
            this.tboxCoHostName.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(327, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 18);
            this.label8.TabIndex = 34;
            this.label8.Text = "Mysql Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "Mysql UserName:";
            // 
            // tboxCoDbName
            // 
            this.tboxCoDbName.Location = new System.Drawing.Point(155, 107);
            this.tboxCoDbName.Name = "tboxCoDbName";
            this.tboxCoDbName.Size = new System.Drawing.Size(166, 28);
            this.tboxCoDbName.TabIndex = 31;
            // 
            // tboxCoUserName
            // 
            this.tboxCoUserName.Location = new System.Drawing.Point(155, 68);
            this.tboxCoUserName.Name = "tboxCoUserName";
            this.tboxCoUserName.Size = new System.Drawing.Size(166, 28);
            this.tboxCoUserName.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 18);
            this.label6.TabIndex = 30;
            this.label6.Text = "Mysql DbName:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "Mysql Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 18);
            this.label4.TabIndex = 29;
            this.label4.Text = "Mysql Charset:";
            // 
            // tboxCoPassword
            // 
            this.tboxCoPassword.Location = new System.Drawing.Point(471, 68);
            this.tboxCoPassword.Name = "tboxCoPassword";
            this.tboxCoPassword.Size = new System.Drawing.Size(166, 28);
            this.tboxCoPassword.TabIndex = 27;
            // 
            // cboxCoCharset
            // 
            this.cboxCoCharset.FormattingEnabled = true;
            this.cboxCoCharset.Items.AddRange(new object[] {
            "utf8",
            "gb2312"});
            this.cboxCoCharset.Location = new System.Drawing.Point(471, 34);
            this.cboxCoCharset.Name = "cboxCoCharset";
            this.cboxCoCharset.Size = new System.Drawing.Size(166, 26);
            this.cboxCoCharset.TabIndex = 28;
            this.cboxCoCharset.Text = "utf8";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 659);
            this.Controls.Add(this.tabctrMainform);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "内容源工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_Closed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabctrMainform.ResumeLayout(false);
            this.tabPageCollect.ResumeLayout(false);
            this.gboxCoFilter.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFilterCo_name.ResumeLayout(false);
            this.panelFilterCo_name.PerformLayout();
            this.tabPageDistribute.ResumeLayout(false);
            this.gboxPubFilter.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tabPageConfig.ResumeLayout(false);
            this.gbxPubDatabaseSet.ResumeLayout(false);
            this.gbxPubDatabaseSet.PerformLayout();
            this.gbxCoDatabaseSet.ResumeLayout(false);
            this.gbxCoDatabaseSet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabctrMainform;
        private System.Windows.Forms.TabPage tabPageCollect;
        private System.Windows.Forms.TabPage tabPageDelWatermark;
        private System.Windows.Forms.TabPage tabPageDistribute;
        private System.Windows.Forms.TabPage tabPageConfig;
        private System.Windows.Forms.GroupBox gbxCoDatabaseSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxCoPort;
        private System.Windows.Forms.TextBox tboxCoHostName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tboxCoDbName;
        private System.Windows.Forms.TextBox tboxCoUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tboxCoPassword;
        private System.Windows.Forms.ComboBox cboxCoCharset;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnLoadCoconfig;
        //private System.Windows.Forms.ListView listViewCollect;
        private ListViewNF listViewCollect;
        private System.Windows.Forms.ColumnHeader cid;
        private System.Windows.Forms.ColumnHeader co_name;
        private System.Windows.Forms.ColumnHeader source_lang;
        private System.Windows.Forms.ColumnHeader source_site;
        private System.Windows.Forms.ColumnHeader up_time;
        private System.Windows.Forms.ColumnHeader co_time;
        private System.Windows.Forms.ColumnHeader co_nums;
        private System.Windows.Forms.Button btnModifyCoconfig;
        private System.Windows.Forms.GroupBox gboxCoFilter;
        private System.Windows.Forms.ComboBox cboxCoFilterCo_name;
        private System.Windows.Forms.Panel panelFilterCo_name;
        private System.Windows.Forms.TextBox tboxCoFilterCo_name;
        private System.Windows.Forms.Label lblCoFileterCo_name;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tboxCoFilterCo_nums;
        private System.Windows.Forms.Label lblCoFilterCo_nums;
        private System.Windows.Forms.ComboBox cboxCoFilterCo_nums;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tboxCoFilterSource_site;
        private System.Windows.Forms.Label lblCoFilterSource_site;
        private System.Windows.Forms.ComboBox cboxCoFilterSource_site;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tboxCoFilterType_name;
        private System.Windows.Forms.Label lblCoFilterType_name;
        private System.Windows.Forms.ComboBox cboxCoFilterType_name;
        private System.Windows.Forms.Button btnClearCoFilter;
        private System.Windows.Forms.ColumnHeader type_name;
        private System.Windows.Forms.Button btnAddCoconfig;
        private System.Windows.Forms.Button btnCoArticles;
        private System.Windows.Forms.Button btnCopyCoconfig;
        private System.Windows.Forms.Button btnDeleteCoconfig;
        private System.Windows.Forms.Button btnCoUnselectAll;
        private System.Windows.Forms.Button btnCoSelectAll;
        private System.Windows.Forms.GroupBox gbxPubDatabaseSet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tboxPubPort;
        private System.Windows.Forms.TextBox tboxPubHostName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tboxPubDbName;
        private System.Windows.Forms.TextBox tboxPubUserName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tboxPubPassword;
        private System.Windows.Forms.ComboBox cboxPubCharset;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tboxPubTablePrename;
        private ListViewNF listViewPublish;
        private System.Windows.Forms.ColumnHeader pub_id;
        private System.Windows.Forms.ColumnHeader pub_name;
        private System.Windows.Forms.ColumnHeader co_typename;
        private System.Windows.Forms.ColumnHeader pub_typename;
        private System.Windows.Forms.ColumnHeader pub_add_date;
        private System.Windows.Forms.ColumnHeader pub_export_date;
        private System.Windows.Forms.ColumnHeader pub_nums;
        private System.Windows.Forms.GroupBox gboxPubFilter;
        private System.Windows.Forms.Button btnPubUnselectAll;
        private System.Windows.Forms.Button btnPubSelectAll;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tboxPubFilterPub_typename;
        private System.Windows.Forms.Label lblPubFilterPub_typename;
        private System.Windows.Forms.ComboBox cboxPubFilterPub_typename;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox tboxPubFilterCo_typename;
        private System.Windows.Forms.Label lblPubFilterCo_typename;
        private System.Windows.Forms.ComboBox cboxPubFilterCo_typename;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox tboxPubFilterPub_name;
        private System.Windows.Forms.Label lblPubFilterPub_name;
        private System.Windows.Forms.ComboBox cboxPubFilterPub_name;
        private System.Windows.Forms.Button btnLoadPubConfig;
        private System.Windows.Forms.Button btnModifyPubConfig;
        private System.Windows.Forms.Button btnClearPubFilter;
        private System.Windows.Forms.Button btnAddPubConfig;
        private System.Windows.Forms.Button btnPubArticles;
        private System.Windows.Forms.Button btnCopyPubConfig;
        private System.Windows.Forms.Button btnDelPubConfig;
        private System.Windows.Forms.ColumnHeader published_nums;
        private System.Windows.Forms.ColumnHeader unused_nums;
    }
}


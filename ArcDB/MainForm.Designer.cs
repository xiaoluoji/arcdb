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
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.gboxFilter = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tboxFilterType_name = new System.Windows.Forms.TextBox();
            this.lblFilterType_name = new System.Windows.Forms.Label();
            this.cboxFilterType_name = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tboxFilterCo_nums = new System.Windows.Forms.TextBox();
            this.lblFilterCo_nums = new System.Windows.Forms.Label();
            this.cboxFilterCo_nums = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tboxFilterSource_site = new System.Windows.Forms.TextBox();
            this.lblFilterSource_site = new System.Windows.Forms.Label();
            this.cboxFilterSource_site = new System.Windows.Forms.ComboBox();
            this.panelFilterCo_name = new System.Windows.Forms.Panel();
            this.tboxFilterCo_name = new System.Windows.Forms.TextBox();
            this.lblFileterCo_name = new System.Windows.Forms.Label();
            this.cboxFilterCo_name = new System.Windows.Forms.ComboBox();
            this.btnModifyCoconfig = new System.Windows.Forms.Button();
            this.listViewCollect = new System.Windows.Forms.ListView();
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
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.gbxDatabaseSet = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxPort = new System.Windows.Forms.TextBox();
            this.tboxHostName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tboxDbName = new System.Windows.Forms.TextBox();
            this.tboxUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tboxPassword = new System.Windows.Forms.TextBox();
            this.cboxCharset = new System.Windows.Forms.ComboBox();
            this.tabctrMainform.SuspendLayout();
            this.tabPageCollect.SuspendLayout();
            this.gboxFilter.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelFilterCo_name.SuspendLayout();
            this.tabPageConfig.SuspendLayout();
            this.gbxDatabaseSet.SuspendLayout();
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
            this.tabPageCollect.Controls.Add(this.btnClearFilter);
            this.tabPageCollect.Controls.Add(this.gboxFilter);
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
            // 
            // btnCopyCoconfig
            // 
            this.btnCopyCoconfig.Location = new System.Drawing.Point(420, 571);
            this.btnCopyCoconfig.Name = "btnCopyCoconfig";
            this.btnCopyCoconfig.Size = new System.Drawing.Size(133, 37);
            this.btnCopyCoconfig.TabIndex = 8;
            this.btnCopyCoconfig.Text = "复制采集规则";
            this.btnCopyCoconfig.UseVisualStyleBackColor = true;
            // 
            // btnCoArticles
            // 
            this.btnCoArticles.Location = new System.Drawing.Point(869, 571);
            this.btnCoArticles.Name = "btnCoArticles";
            this.btnCoArticles.Size = new System.Drawing.Size(133, 37);
            this.btnCoArticles.TabIndex = 7;
            this.btnCoArticles.Text = "采集";
            this.btnCoArticles.UseVisualStyleBackColor = true;
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
            // btnClearFilter
            // 
            this.btnClearFilter.Location = new System.Drawing.Point(701, 571);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(133, 37);
            this.btnClearFilter.TabIndex = 5;
            this.btnClearFilter.Text = "清空过滤器";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // gboxFilter
            // 
            this.gboxFilter.Controls.Add(this.panel3);
            this.gboxFilter.Controls.Add(this.panel2);
            this.gboxFilter.Controls.Add(this.panel1);
            this.gboxFilter.Controls.Add(this.panelFilterCo_name);
            this.gboxFilter.Location = new System.Drawing.Point(3, 7);
            this.gboxFilter.Name = "gboxFilter";
            this.gboxFilter.Size = new System.Drawing.Size(999, 149);
            this.gboxFilter.TabIndex = 4;
            this.gboxFilter.TabStop = false;
            this.gboxFilter.Text = "过滤器";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tboxFilterType_name);
            this.panel3.Controls.Add(this.lblFilterType_name);
            this.panel3.Controls.Add(this.cboxFilterType_name);
            this.panel3.Location = new System.Drawing.Point(8, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(323, 48);
            this.panel3.TabIndex = 4;
            // 
            // tboxFilterType_name
            // 
            this.tboxFilterType_name.Location = new System.Drawing.Point(170, 11);
            this.tboxFilterType_name.Name = "tboxFilterType_name";
            this.tboxFilterType_name.Size = new System.Drawing.Size(145, 28);
            this.tboxFilterType_name.TabIndex = 3;
            // 
            // lblFilterType_name
            // 
            this.lblFilterType_name.AutoSize = true;
            this.lblFilterType_name.Location = new System.Drawing.Point(3, 14);
            this.lblFilterType_name.Name = "lblFilterType_name";
            this.lblFilterType_name.Size = new System.Drawing.Size(80, 18);
            this.lblFilterType_name.TabIndex = 1;
            this.lblFilterType_name.Text = "采集名称";
            // 
            // cboxFilterType_name
            // 
            this.cboxFilterType_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxFilterType_name.FormattingEnabled = true;
            this.cboxFilterType_name.Items.AddRange(new object[] {
            "=",
            "like",
            "<>"});
            this.cboxFilterType_name.Location = new System.Drawing.Point(92, 11);
            this.cboxFilterType_name.Name = "cboxFilterType_name";
            this.cboxFilterType_name.Size = new System.Drawing.Size(72, 26);
            this.cboxFilterType_name.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tboxFilterCo_nums);
            this.panel2.Controls.Add(this.lblFilterCo_nums);
            this.panel2.Controls.Add(this.cboxFilterCo_nums);
            this.panel2.Location = new System.Drawing.Point(666, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(323, 48);
            this.panel2.TabIndex = 5;
            // 
            // tboxFilterCo_nums
            // 
            this.tboxFilterCo_nums.Location = new System.Drawing.Point(170, 11);
            this.tboxFilterCo_nums.Name = "tboxFilterCo_nums";
            this.tboxFilterCo_nums.Size = new System.Drawing.Size(145, 28);
            this.tboxFilterCo_nums.TabIndex = 3;
            // 
            // lblFilterCo_nums
            // 
            this.lblFilterCo_nums.AutoSize = true;
            this.lblFilterCo_nums.Location = new System.Drawing.Point(3, 14);
            this.lblFilterCo_nums.Name = "lblFilterCo_nums";
            this.lblFilterCo_nums.Size = new System.Drawing.Size(80, 18);
            this.lblFilterCo_nums.TabIndex = 1;
            this.lblFilterCo_nums.Text = "采集数量";
            // 
            // cboxFilterCo_nums
            // 
            this.cboxFilterCo_nums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxFilterCo_nums.FormattingEnabled = true;
            this.cboxFilterCo_nums.Items.AddRange(new object[] {
            "=",
            "<>",
            ">",
            "<"});
            this.cboxFilterCo_nums.Location = new System.Drawing.Point(92, 11);
            this.cboxFilterCo_nums.Name = "cboxFilterCo_nums";
            this.cboxFilterCo_nums.Size = new System.Drawing.Size(72, 26);
            this.cboxFilterCo_nums.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tboxFilterSource_site);
            this.panel1.Controls.Add(this.lblFilterSource_site);
            this.panel1.Controls.Add(this.cboxFilterSource_site);
            this.panel1.Location = new System.Drawing.Point(337, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 48);
            this.panel1.TabIndex = 4;
            // 
            // tboxFilterSource_site
            // 
            this.tboxFilterSource_site.Location = new System.Drawing.Point(170, 11);
            this.tboxFilterSource_site.Name = "tboxFilterSource_site";
            this.tboxFilterSource_site.Size = new System.Drawing.Size(145, 28);
            this.tboxFilterSource_site.TabIndex = 3;
            // 
            // lblFilterSource_site
            // 
            this.lblFilterSource_site.AutoSize = true;
            this.lblFilterSource_site.Location = new System.Drawing.Point(3, 14);
            this.lblFilterSource_site.Name = "lblFilterSource_site";
            this.lblFilterSource_site.Size = new System.Drawing.Size(80, 18);
            this.lblFilterSource_site.TabIndex = 1;
            this.lblFilterSource_site.Text = "采集来源";
            // 
            // cboxFilterSource_site
            // 
            this.cboxFilterSource_site.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxFilterSource_site.FormattingEnabled = true;
            this.cboxFilterSource_site.Items.AddRange(new object[] {
            "=",
            "like",
            "<>"});
            this.cboxFilterSource_site.Location = new System.Drawing.Point(92, 11);
            this.cboxFilterSource_site.Name = "cboxFilterSource_site";
            this.cboxFilterSource_site.Size = new System.Drawing.Size(72, 26);
            this.cboxFilterSource_site.TabIndex = 0;
            // 
            // panelFilterCo_name
            // 
            this.panelFilterCo_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilterCo_name.Controls.Add(this.tboxFilterCo_name);
            this.panelFilterCo_name.Controls.Add(this.lblFileterCo_name);
            this.panelFilterCo_name.Controls.Add(this.cboxFilterCo_name);
            this.panelFilterCo_name.Location = new System.Drawing.Point(8, 23);
            this.panelFilterCo_name.Name = "panelFilterCo_name";
            this.panelFilterCo_name.Size = new System.Drawing.Size(323, 48);
            this.panelFilterCo_name.TabIndex = 2;
            // 
            // tboxFilterCo_name
            // 
            this.tboxFilterCo_name.Location = new System.Drawing.Point(170, 11);
            this.tboxFilterCo_name.Name = "tboxFilterCo_name";
            this.tboxFilterCo_name.Size = new System.Drawing.Size(145, 28);
            this.tboxFilterCo_name.TabIndex = 3;
            // 
            // lblFileterCo_name
            // 
            this.lblFileterCo_name.AutoSize = true;
            this.lblFileterCo_name.Location = new System.Drawing.Point(3, 14);
            this.lblFileterCo_name.Name = "lblFileterCo_name";
            this.lblFileterCo_name.Size = new System.Drawing.Size(80, 18);
            this.lblFileterCo_name.TabIndex = 1;
            this.lblFileterCo_name.Text = "采集名称";
            // 
            // cboxFilterCo_name
            // 
            this.cboxFilterCo_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxFilterCo_name.FormattingEnabled = true;
            this.cboxFilterCo_name.Items.AddRange(new object[] {
            "=",
            "like",
            "<>"});
            this.cboxFilterCo_name.Location = new System.Drawing.Point(92, 11);
            this.cboxFilterCo_name.Name = "cboxFilterCo_name";
            this.cboxFilterCo_name.Size = new System.Drawing.Size(72, 26);
            this.cboxFilterCo_name.TabIndex = 0;
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
            this.tabPageDistribute.Location = new System.Drawing.Point(4, 28);
            this.tabPageDistribute.Name = "tabPageDistribute";
            this.tabPageDistribute.Size = new System.Drawing.Size(1007, 627);
            this.tabPageDistribute.TabIndex = 2;
            this.tabPageDistribute.Text = "内容分发";
            this.tabPageDistribute.UseVisualStyleBackColor = true;
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.btnSaveConfig);
            this.tabPageConfig.Controls.Add(this.gbxDatabaseSet);
            this.tabPageConfig.Location = new System.Drawing.Point(4, 28);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfig.Size = new System.Drawing.Size(1007, 627);
            this.tabPageConfig.TabIndex = 3;
            this.tabPageConfig.Text = "系统设置";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(809, 398);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(129, 36);
            this.btnSaveConfig.TabIndex = 37;
            this.btnSaveConfig.Text = "保存配置";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // gbxDatabaseSet
            // 
            this.gbxDatabaseSet.Controls.Add(this.label1);
            this.gbxDatabaseSet.Controls.Add(this.tboxPort);
            this.gbxDatabaseSet.Controls.Add(this.tboxHostName);
            this.gbxDatabaseSet.Controls.Add(this.label8);
            this.gbxDatabaseSet.Controls.Add(this.label2);
            this.gbxDatabaseSet.Controls.Add(this.tboxDbName);
            this.gbxDatabaseSet.Controls.Add(this.tboxUserName);
            this.gbxDatabaseSet.Controls.Add(this.label6);
            this.gbxDatabaseSet.Controls.Add(this.label3);
            this.gbxDatabaseSet.Controls.Add(this.label4);
            this.gbxDatabaseSet.Controls.Add(this.tboxPassword);
            this.gbxDatabaseSet.Controls.Add(this.cboxCharset);
            this.gbxDatabaseSet.Location = new System.Drawing.Point(8, 17);
            this.gbxDatabaseSet.Name = "gbxDatabaseSet";
            this.gbxDatabaseSet.Size = new System.Drawing.Size(651, 162);
            this.gbxDatabaseSet.TabIndex = 36;
            this.gbxDatabaseSet.TabStop = false;
            this.gbxDatabaseSet.Text = "数据库设置";
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
            // tboxPort
            // 
            this.tboxPort.Location = new System.Drawing.Point(471, 107);
            this.tboxPort.Name = "tboxPort";
            this.tboxPort.Size = new System.Drawing.Size(166, 28);
            this.tboxPort.TabIndex = 35;
            this.tboxPort.Text = "3306";
            // 
            // tboxHostName
            // 
            this.tboxHostName.Location = new System.Drawing.Point(155, 34);
            this.tboxHostName.Name = "tboxHostName";
            this.tboxHostName.Size = new System.Drawing.Size(166, 28);
            this.tboxHostName.TabIndex = 22;
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
            // tboxDbName
            // 
            this.tboxDbName.Location = new System.Drawing.Point(155, 107);
            this.tboxDbName.Name = "tboxDbName";
            this.tboxDbName.Size = new System.Drawing.Size(166, 28);
            this.tboxDbName.TabIndex = 31;
            // 
            // tboxUserName
            // 
            this.tboxUserName.Location = new System.Drawing.Point(155, 68);
            this.tboxUserName.Name = "tboxUserName";
            this.tboxUserName.Size = new System.Drawing.Size(166, 28);
            this.tboxUserName.TabIndex = 25;
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
            // tboxPassword
            // 
            this.tboxPassword.Location = new System.Drawing.Point(471, 68);
            this.tboxPassword.Name = "tboxPassword";
            this.tboxPassword.Size = new System.Drawing.Size(166, 28);
            this.tboxPassword.TabIndex = 27;
            // 
            // cboxCharset
            // 
            this.cboxCharset.FormattingEnabled = true;
            this.cboxCharset.Items.AddRange(new object[] {
            "utf8",
            "gb2312"});
            this.cboxCharset.Location = new System.Drawing.Point(471, 34);
            this.cboxCharset.Name = "cboxCharset";
            this.cboxCharset.Size = new System.Drawing.Size(166, 26);
            this.cboxCharset.TabIndex = 28;
            this.cboxCharset.Text = "utf8";
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
            this.gboxFilter.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFilterCo_name.ResumeLayout(false);
            this.panelFilterCo_name.PerformLayout();
            this.tabPageConfig.ResumeLayout(false);
            this.gbxDatabaseSet.ResumeLayout(false);
            this.gbxDatabaseSet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabctrMainform;
        private System.Windows.Forms.TabPage tabPageCollect;
        private System.Windows.Forms.TabPage tabPageDelWatermark;
        private System.Windows.Forms.TabPage tabPageDistribute;
        private System.Windows.Forms.TabPage tabPageConfig;
        private System.Windows.Forms.GroupBox gbxDatabaseSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxPort;
        private System.Windows.Forms.TextBox tboxHostName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tboxDbName;
        private System.Windows.Forms.TextBox tboxUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tboxPassword;
        private System.Windows.Forms.ComboBox cboxCharset;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnLoadCoconfig;
        private System.Windows.Forms.ListView listViewCollect;
        private System.Windows.Forms.ColumnHeader cid;
        private System.Windows.Forms.ColumnHeader co_name;
        private System.Windows.Forms.ColumnHeader source_lang;
        private System.Windows.Forms.ColumnHeader source_site;
        private System.Windows.Forms.ColumnHeader up_time;
        private System.Windows.Forms.ColumnHeader co_time;
        private System.Windows.Forms.ColumnHeader co_nums;
        private System.Windows.Forms.Button btnModifyCoconfig;
        private System.Windows.Forms.GroupBox gboxFilter;
        private System.Windows.Forms.ComboBox cboxFilterCo_name;
        private System.Windows.Forms.Panel panelFilterCo_name;
        private System.Windows.Forms.TextBox tboxFilterCo_name;
        private System.Windows.Forms.Label lblFileterCo_name;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tboxFilterCo_nums;
        private System.Windows.Forms.Label lblFilterCo_nums;
        private System.Windows.Forms.ComboBox cboxFilterCo_nums;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tboxFilterSource_site;
        private System.Windows.Forms.Label lblFilterSource_site;
        private System.Windows.Forms.ComboBox cboxFilterSource_site;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tboxFilterType_name;
        private System.Windows.Forms.Label lblFilterType_name;
        private System.Windows.Forms.ComboBox cboxFilterType_name;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.ColumnHeader type_name;
        private System.Windows.Forms.Button btnAddCoconfig;
        private System.Windows.Forms.Button btnCoArticles;
        private System.Windows.Forms.Button btnCopyCoconfig;
        private System.Windows.Forms.Button btnDeleteCoconfig;
    }
}


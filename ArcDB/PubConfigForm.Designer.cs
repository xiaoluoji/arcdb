namespace ArcDB
{
    partial class PubConfigForm
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
            this.tabctrPubform = new System.Windows.Forms.TabControl();
            this.tabPubConfig = new System.Windows.Forms.TabPage();
            this.gboxPubTypename = new System.Windows.Forms.GroupBox();
            this.listViewPubTypeinfo = new ArcDB.ListViewNF();
            this.pub_typeid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pub_typename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearchPubTypename = new System.Windows.Forms.Button();
            this.tboxPubTypeid = new System.Windows.Forms.TextBox();
            this.lblPubTypeid = new System.Windows.Forms.Label();
            this.tboxSearchPubTypename = new System.Windows.Forms.TextBox();
            this.lblSearchPubTypename = new System.Windows.Forms.Label();
            this.lblPubTypename = new System.Windows.Forms.Label();
            this.tboxPubTypename = new System.Windows.Forms.TextBox();
            this.gboxCoTypename = new System.Windows.Forms.GroupBox();
            this.listViewCoTypeinfo = new ArcDB.ListViewNF();
            this.co_typeid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.co_typename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearchCoTypename = new System.Windows.Forms.Button();
            this.tboxCoTypeid = new System.Windows.Forms.TextBox();
            this.lblCoTypeid = new System.Windows.Forms.Label();
            this.tboxSearchCoTypename = new System.Windows.Forms.TextBox();
            this.lblSearchCoTypename = new System.Windows.Forms.Label();
            this.lblCoTypeName = new System.Windows.Forms.Label();
            this.tboxCoTypename = new System.Windows.Forms.TextBox();
            this.gboxCoBasicinfo = new System.Windows.Forms.GroupBox();
            this.lblPubFilterKeywordsInfo = new System.Windows.Forms.Label();
            this.tboxPubFilterKeywords = new System.Windows.Forms.TextBox();
            this.lblPubFilterKeywords = new System.Windows.Forms.Label();
            this.lblRandomDateStop = new System.Windows.Forms.Label();
            this.tboxRandomDateStop = new System.Windows.Forms.TextBox();
            this.dtpRandomDateStop = new System.Windows.Forms.DateTimePicker();
            this.lblRandomDateStart = new System.Windows.Forms.Label();
            this.tboxRandomDateStart = new System.Windows.Forms.TextBox();
            this.dtpRandomDateStart = new System.Windows.Forms.DateTimePicker();
            this.tboxPubNums = new System.Windows.Forms.TextBox();
            this.lblPubName = new System.Windows.Forms.Label();
            this.tboxPubName = new System.Windows.Forms.TextBox();
            this.lblPubNums = new System.Windows.Forms.Label();
            this.tabPubTest = new System.Windows.Forms.TabPage();
            this.lblPubTestResult = new System.Windows.Forms.Label();
            this.tboxPubTestResult = new System.Windows.Forms.TextBox();
            this.btnSavePubConfig = new System.Windows.Forms.Button();
            this.btnPubTest = new System.Windows.Forms.Button();
            this.co_type_unused_nums = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pub_type_items = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabctrPubform.SuspendLayout();
            this.tabPubConfig.SuspendLayout();
            this.gboxPubTypename.SuspendLayout();
            this.gboxCoTypename.SuspendLayout();
            this.gboxCoBasicinfo.SuspendLayout();
            this.tabPubTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabctrPubform
            // 
            this.tabctrPubform.Controls.Add(this.tabPubConfig);
            this.tabctrPubform.Controls.Add(this.tabPubTest);
            this.tabctrPubform.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabctrPubform.Location = new System.Drawing.Point(0, 0);
            this.tabctrPubform.Name = "tabctrPubform";
            this.tabctrPubform.SelectedIndex = 0;
            this.tabctrPubform.Size = new System.Drawing.Size(978, 631);
            this.tabctrPubform.TabIndex = 2;
            // 
            // tabPubConfig
            // 
            this.tabPubConfig.Controls.Add(this.gboxPubTypename);
            this.tabPubConfig.Controls.Add(this.gboxCoTypename);
            this.tabPubConfig.Controls.Add(this.gboxCoBasicinfo);
            this.tabPubConfig.Location = new System.Drawing.Point(4, 28);
            this.tabPubConfig.Name = "tabPubConfig";
            this.tabPubConfig.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tabPubConfig.Size = new System.Drawing.Size(970, 599);
            this.tabPubConfig.TabIndex = 0;
            this.tabPubConfig.Text = "发布配置";
            this.tabPubConfig.UseVisualStyleBackColor = true;
            // 
            // gboxPubTypename
            // 
            this.gboxPubTypename.Controls.Add(this.listViewPubTypeinfo);
            this.gboxPubTypename.Controls.Add(this.btnSearchPubTypename);
            this.gboxPubTypename.Controls.Add(this.tboxPubTypeid);
            this.gboxPubTypename.Controls.Add(this.lblPubTypeid);
            this.gboxPubTypename.Controls.Add(this.tboxSearchPubTypename);
            this.gboxPubTypename.Controls.Add(this.lblSearchPubTypename);
            this.gboxPubTypename.Controls.Add(this.lblPubTypename);
            this.gboxPubTypename.Controls.Add(this.tboxPubTypename);
            this.gboxPubTypename.Location = new System.Drawing.Point(524, 175);
            this.gboxPubTypename.Name = "gboxPubTypename";
            this.gboxPubTypename.Size = new System.Drawing.Size(424, 412);
            this.gboxPubTypename.TabIndex = 17;
            this.gboxPubTypename.TabStop = false;
            this.gboxPubTypename.Text = "选择发布分类";
            // 
            // listViewPubTypeinfo
            // 
            this.listViewPubTypeinfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pub_typeid,
            this.pub_typename,
            this.pub_type_items});
            this.listViewPubTypeinfo.FullRowSelect = true;
            this.listViewPubTypeinfo.GridLines = true;
            this.listViewPubTypeinfo.Location = new System.Drawing.Point(9, 103);
            this.listViewPubTypeinfo.MultiSelect = false;
            this.listViewPubTypeinfo.Name = "listViewPubTypeinfo";
            this.listViewPubTypeinfo.Size = new System.Drawing.Size(407, 303);
            this.listViewPubTypeinfo.TabIndex = 16;
            this.listViewPubTypeinfo.UseCompatibleStateImageBehavior = false;
            this.listViewPubTypeinfo.View = System.Windows.Forms.View.Details;
            this.listViewPubTypeinfo.SelectedIndexChanged += new System.EventHandler(this.listViewPubTypeinfo_SelectedIndexChanged);
            // 
            // pub_typeid
            // 
            this.pub_typeid.Text = "发布分类ID";
            this.pub_typeid.Width = 120;
            // 
            // pub_typename
            // 
            this.pub_typename.Text = "发布分类名称";
            this.pub_typename.Width = 130;
            // 
            // btnSearchPubTypename
            // 
            this.btnSearchPubTypename.Location = new System.Drawing.Point(275, 66);
            this.btnSearchPubTypename.Name = "btnSearchPubTypename";
            this.btnSearchPubTypename.Size = new System.Drawing.Size(141, 31);
            this.btnSearchPubTypename.TabIndex = 15;
            this.btnSearchPubTypename.Text = "搜索";
            this.btnSearchPubTypename.UseVisualStyleBackColor = true;
            this.btnSearchPubTypename.Click += new System.EventHandler(this.btnSearchPubTypename_Click);
            // 
            // tboxPubTypeid
            // 
            this.tboxPubTypeid.Location = new System.Drawing.Point(56, 27);
            this.tboxPubTypeid.Name = "tboxPubTypeid";
            this.tboxPubTypeid.Size = new System.Drawing.Size(94, 28);
            this.tboxPubTypeid.TabIndex = 14;
            // 
            // lblPubTypeid
            // 
            this.lblPubTypeid.AutoSize = true;
            this.lblPubTypeid.Location = new System.Drawing.Point(6, 32);
            this.lblPubTypeid.Name = "lblPubTypeid";
            this.lblPubTypeid.Size = new System.Drawing.Size(44, 18);
            this.lblPubTypeid.TabIndex = 13;
            this.lblPubTypeid.Text = "ID: ";
            // 
            // tboxSearchPubTypename
            // 
            this.tboxSearchPubTypename.Location = new System.Drawing.Point(107, 69);
            this.tboxSearchPubTypename.Name = "tboxSearchPubTypename";
            this.tboxSearchPubTypename.Size = new System.Drawing.Size(161, 28);
            this.tboxSearchPubTypename.TabIndex = 3;
            // 
            // lblSearchPubTypename
            // 
            this.lblSearchPubTypename.AutoSize = true;
            this.lblSearchPubTypename.Location = new System.Drawing.Point(6, 74);
            this.lblSearchPubTypename.Name = "lblSearchPubTypename";
            this.lblSearchPubTypename.Size = new System.Drawing.Size(89, 18);
            this.lblSearchPubTypename.TabIndex = 1;
            this.lblSearchPubTypename.Text = "搜索分类:";
            // 
            // lblPubTypename
            // 
            this.lblPubTypename.AutoSize = true;
            this.lblPubTypename.Location = new System.Drawing.Point(168, 32);
            this.lblPubTypename.Name = "lblPubTypename";
            this.lblPubTypename.Size = new System.Drawing.Size(89, 18);
            this.lblPubTypename.TabIndex = 9;
            this.lblPubTypename.Text = "采集分类:";
            // 
            // tboxPubTypename
            // 
            this.tboxPubTypename.Location = new System.Drawing.Point(275, 27);
            this.tboxPubTypename.Name = "tboxPubTypename";
            this.tboxPubTypename.Size = new System.Drawing.Size(141, 28);
            this.tboxPubTypename.TabIndex = 12;
            // 
            // gboxCoTypename
            // 
            this.gboxCoTypename.Controls.Add(this.listViewCoTypeinfo);
            this.gboxCoTypename.Controls.Add(this.btnSearchCoTypename);
            this.gboxCoTypename.Controls.Add(this.tboxCoTypeid);
            this.gboxCoTypename.Controls.Add(this.lblCoTypeid);
            this.gboxCoTypename.Controls.Add(this.tboxSearchCoTypename);
            this.gboxCoTypename.Controls.Add(this.lblSearchCoTypename);
            this.gboxCoTypename.Controls.Add(this.lblCoTypeName);
            this.gboxCoTypename.Controls.Add(this.tboxCoTypename);
            this.gboxCoTypename.Location = new System.Drawing.Point(3, 175);
            this.gboxCoTypename.Name = "gboxCoTypename";
            this.gboxCoTypename.Size = new System.Drawing.Size(424, 412);
            this.gboxCoTypename.TabIndex = 15;
            this.gboxCoTypename.TabStop = false;
            this.gboxCoTypename.Text = "选择采集分类";
            // 
            // listViewCoTypeinfo
            // 
            this.listViewCoTypeinfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.co_typeid,
            this.co_typename,
            this.co_type_unused_nums});
            this.listViewCoTypeinfo.FullRowSelect = true;
            this.listViewCoTypeinfo.GridLines = true;
            this.listViewCoTypeinfo.Location = new System.Drawing.Point(9, 103);
            this.listViewCoTypeinfo.MultiSelect = false;
            this.listViewCoTypeinfo.Name = "listViewCoTypeinfo";
            this.listViewCoTypeinfo.Size = new System.Drawing.Size(407, 303);
            this.listViewCoTypeinfo.TabIndex = 16;
            this.listViewCoTypeinfo.UseCompatibleStateImageBehavior = false;
            this.listViewCoTypeinfo.View = System.Windows.Forms.View.Details;
            this.listViewCoTypeinfo.SelectedIndexChanged += new System.EventHandler(this.listViewCoTypeinfo_SelectedIndexChanged);
            // 
            // co_typeid
            // 
            this.co_typeid.Text = "采集分类ID";
            this.co_typeid.Width = 120;
            // 
            // co_typename
            // 
            this.co_typename.Text = "采集分类名称";
            this.co_typename.Width = 130;
            // 
            // btnSearchCoTypename
            // 
            this.btnSearchCoTypename.Location = new System.Drawing.Point(275, 66);
            this.btnSearchCoTypename.Name = "btnSearchCoTypename";
            this.btnSearchCoTypename.Size = new System.Drawing.Size(141, 31);
            this.btnSearchCoTypename.TabIndex = 15;
            this.btnSearchCoTypename.Text = "搜索";
            this.btnSearchCoTypename.UseVisualStyleBackColor = true;
            this.btnSearchCoTypename.Click += new System.EventHandler(this.btnSearchCoTypename_Click);
            // 
            // tboxCoTypeid
            // 
            this.tboxCoTypeid.Location = new System.Drawing.Point(56, 27);
            this.tboxCoTypeid.Name = "tboxCoTypeid";
            this.tboxCoTypeid.Size = new System.Drawing.Size(94, 28);
            this.tboxCoTypeid.TabIndex = 14;
            // 
            // lblCoTypeid
            // 
            this.lblCoTypeid.AutoSize = true;
            this.lblCoTypeid.Location = new System.Drawing.Point(6, 32);
            this.lblCoTypeid.Name = "lblCoTypeid";
            this.lblCoTypeid.Size = new System.Drawing.Size(44, 18);
            this.lblCoTypeid.TabIndex = 13;
            this.lblCoTypeid.Text = "ID: ";
            // 
            // tboxSearchCoTypename
            // 
            this.tboxSearchCoTypename.Location = new System.Drawing.Point(107, 69);
            this.tboxSearchCoTypename.Name = "tboxSearchCoTypename";
            this.tboxSearchCoTypename.Size = new System.Drawing.Size(161, 28);
            this.tboxSearchCoTypename.TabIndex = 3;
            // 
            // lblSearchCoTypename
            // 
            this.lblSearchCoTypename.AutoSize = true;
            this.lblSearchCoTypename.Location = new System.Drawing.Point(6, 74);
            this.lblSearchCoTypename.Name = "lblSearchCoTypename";
            this.lblSearchCoTypename.Size = new System.Drawing.Size(89, 18);
            this.lblSearchCoTypename.TabIndex = 1;
            this.lblSearchCoTypename.Text = "搜索分类:";
            // 
            // lblCoTypeName
            // 
            this.lblCoTypeName.AutoSize = true;
            this.lblCoTypeName.Location = new System.Drawing.Point(168, 32);
            this.lblCoTypeName.Name = "lblCoTypeName";
            this.lblCoTypeName.Size = new System.Drawing.Size(89, 18);
            this.lblCoTypeName.TabIndex = 9;
            this.lblCoTypeName.Text = "采集分类:";
            // 
            // tboxCoTypename
            // 
            this.tboxCoTypename.Location = new System.Drawing.Point(275, 27);
            this.tboxCoTypename.Name = "tboxCoTypename";
            this.tboxCoTypename.Size = new System.Drawing.Size(141, 28);
            this.tboxCoTypename.TabIndex = 12;
            // 
            // gboxCoBasicinfo
            // 
            this.gboxCoBasicinfo.Controls.Add(this.lblPubFilterKeywordsInfo);
            this.gboxCoBasicinfo.Controls.Add(this.tboxPubFilterKeywords);
            this.gboxCoBasicinfo.Controls.Add(this.lblPubFilterKeywords);
            this.gboxCoBasicinfo.Controls.Add(this.lblRandomDateStop);
            this.gboxCoBasicinfo.Controls.Add(this.tboxRandomDateStop);
            this.gboxCoBasicinfo.Controls.Add(this.dtpRandomDateStop);
            this.gboxCoBasicinfo.Controls.Add(this.lblRandomDateStart);
            this.gboxCoBasicinfo.Controls.Add(this.tboxRandomDateStart);
            this.gboxCoBasicinfo.Controls.Add(this.dtpRandomDateStart);
            this.gboxCoBasicinfo.Controls.Add(this.tboxPubNums);
            this.gboxCoBasicinfo.Controls.Add(this.lblPubName);
            this.gboxCoBasicinfo.Controls.Add(this.tboxPubName);
            this.gboxCoBasicinfo.Controls.Add(this.lblPubNums);
            this.gboxCoBasicinfo.Location = new System.Drawing.Point(3, 10);
            this.gboxCoBasicinfo.Name = "gboxCoBasicinfo";
            this.gboxCoBasicinfo.Size = new System.Drawing.Size(964, 149);
            this.gboxCoBasicinfo.TabIndex = 9;
            this.gboxCoBasicinfo.TabStop = false;
            this.gboxCoBasicinfo.Text = "基本信息";
            // 
            // lblPubFilterKeywordsInfo
            // 
            this.lblPubFilterKeywordsInfo.AutoSize = true;
            this.lblPubFilterKeywordsInfo.Location = new System.Drawing.Point(363, 111);
            this.lblPubFilterKeywordsInfo.Name = "lblPubFilterKeywordsInfo";
            this.lblPubFilterKeywordsInfo.Size = new System.Drawing.Size(260, 18);
            this.lblPubFilterKeywordsInfo.TabIndex = 23;
            this.lblPubFilterKeywordsInfo.Text = "(关键词如有多个，用\"|\"分开) ";
            // 
            // tboxPubFilterKeywords
            // 
            this.tboxPubFilterKeywords.Location = new System.Drawing.Point(137, 106);
            this.tboxPubFilterKeywords.Name = "tboxPubFilterKeywords";
            this.tboxPubFilterKeywords.Size = new System.Drawing.Size(220, 28);
            this.tboxPubFilterKeywords.TabIndex = 22;
            // 
            // lblPubFilterKeywords
            // 
            this.lblPubFilterKeywords.AutoSize = true;
            this.lblPubFilterKeywords.Location = new System.Drawing.Point(15, 111);
            this.lblPubFilterKeywords.Name = "lblPubFilterKeywords";
            this.lblPubFilterKeywords.Size = new System.Drawing.Size(116, 18);
            this.lblPubFilterKeywords.TabIndex = 21;
            this.lblPubFilterKeywords.Text = "过滤关键词: ";
            // 
            // lblRandomDateStop
            // 
            this.lblRandomDateStop.AutoSize = true;
            this.lblRandomDateStop.Location = new System.Drawing.Point(366, 70);
            this.lblRandomDateStop.Name = "lblRandomDateStop";
            this.lblRandomDateStop.Size = new System.Drawing.Size(170, 18);
            this.lblRandomDateStop.TabIndex = 19;
            this.lblRandomDateStop.Text = "发布时间区间结束: ";
            // 
            // tboxRandomDateStop
            // 
            this.tboxRandomDateStop.Location = new System.Drawing.Point(543, 65);
            this.tboxRandomDateStop.Name = "tboxRandomDateStop";
            this.tboxRandomDateStop.Size = new System.Drawing.Size(200, 28);
            this.tboxRandomDateStop.TabIndex = 20;
            // 
            // dtpRandomDateStop
            // 
            this.dtpRandomDateStop.Location = new System.Drawing.Point(745, 65);
            this.dtpRandomDateStop.Name = "dtpRandomDateStop";
            this.dtpRandomDateStop.Size = new System.Drawing.Size(200, 28);
            this.dtpRandomDateStop.TabIndex = 18;
            this.dtpRandomDateStop.ValueChanged += new System.EventHandler(this.dtpRandomDateStop_ValueChanged);
            // 
            // lblRandomDateStart
            // 
            this.lblRandomDateStart.AutoSize = true;
            this.lblRandomDateStart.Location = new System.Drawing.Point(366, 27);
            this.lblRandomDateStart.Name = "lblRandomDateStart";
            this.lblRandomDateStart.Size = new System.Drawing.Size(170, 18);
            this.lblRandomDateStart.TabIndex = 16;
            this.lblRandomDateStart.Text = "发布时间区间开始: ";
            // 
            // tboxRandomDateStart
            // 
            this.tboxRandomDateStart.Location = new System.Drawing.Point(543, 21);
            this.tboxRandomDateStart.Name = "tboxRandomDateStart";
            this.tboxRandomDateStart.Size = new System.Drawing.Size(200, 28);
            this.tboxRandomDateStart.TabIndex = 17;
            // 
            // dtpRandomDateStart
            // 
            this.dtpRandomDateStart.Location = new System.Drawing.Point(745, 21);
            this.dtpRandomDateStart.Name = "dtpRandomDateStart";
            this.dtpRandomDateStart.Size = new System.Drawing.Size(200, 28);
            this.dtpRandomDateStart.TabIndex = 15;
            this.dtpRandomDateStart.ValueChanged += new System.EventHandler(this.dtpRandomDateStart_ValueChanged);
            // 
            // tboxPubNums
            // 
            this.tboxPubNums.Location = new System.Drawing.Point(137, 65);
            this.tboxPubNums.Name = "tboxPubNums";
            this.tboxPubNums.Size = new System.Drawing.Size(220, 28);
            this.tboxPubNums.TabIndex = 11;
            this.tboxPubNums.Text = "10000";
            // 
            // lblPubName
            // 
            this.lblPubName.AutoSize = true;
            this.lblPubName.Location = new System.Drawing.Point(15, 30);
            this.lblPubName.Name = "lblPubName";
            this.lblPubName.Size = new System.Drawing.Size(98, 18);
            this.lblPubName.TabIndex = 1;
            this.lblPubName.Text = "发布名称: ";
            // 
            // tboxPubName
            // 
            this.tboxPubName.Location = new System.Drawing.Point(137, 24);
            this.tboxPubName.Name = "tboxPubName";
            this.tboxPubName.Size = new System.Drawing.Size(220, 28);
            this.tboxPubName.TabIndex = 2;
            // 
            // lblPubNums
            // 
            this.lblPubNums.AutoSize = true;
            this.lblPubNums.Location = new System.Drawing.Point(15, 71);
            this.lblPubNums.Name = "lblPubNums";
            this.lblPubNums.Size = new System.Drawing.Size(98, 18);
            this.lblPubNums.TabIndex = 3;
            this.lblPubNums.Text = "发布数量: ";
            // 
            // tabPubTest
            // 
            this.tabPubTest.Controls.Add(this.lblPubTestResult);
            this.tabPubTest.Controls.Add(this.tboxPubTestResult);
            this.tabPubTest.Location = new System.Drawing.Point(4, 28);
            this.tabPubTest.Name = "tabPubTest";
            this.tabPubTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPubTest.Size = new System.Drawing.Size(970, 599);
            this.tabPubTest.TabIndex = 2;
            this.tabPubTest.Text = "测试发布";
            this.tabPubTest.UseVisualStyleBackColor = true;
            // 
            // lblPubTestResult
            // 
            this.lblPubTestResult.AutoSize = true;
            this.lblPubTestResult.Location = new System.Drawing.Point(6, 8);
            this.lblPubTestResult.Name = "lblPubTestResult";
            this.lblPubTestResult.Size = new System.Drawing.Size(134, 18);
            this.lblPubTestResult.TabIndex = 11;
            this.lblPubTestResult.Text = "测试发布结果：";
            // 
            // tboxPubTestResult
            // 
            this.tboxPubTestResult.Location = new System.Drawing.Point(3, 33);
            this.tboxPubTestResult.Multiline = true;
            this.tboxPubTestResult.Name = "tboxPubTestResult";
            this.tboxPubTestResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tboxPubTestResult.Size = new System.Drawing.Size(959, 560);
            this.tboxPubTestResult.TabIndex = 3;
            // 
            // btnSavePubConfig
            // 
            this.btnSavePubConfig.Location = new System.Drawing.Point(327, 649);
            this.btnSavePubConfig.Name = "btnSavePubConfig";
            this.btnSavePubConfig.Size = new System.Drawing.Size(144, 33);
            this.btnSavePubConfig.TabIndex = 15;
            this.btnSavePubConfig.Text = "保存配置";
            this.btnSavePubConfig.UseVisualStyleBackColor = true;
            this.btnSavePubConfig.Click += new System.EventHandler(this.btnSavePubConfig_Click);
            // 
            // btnPubTest
            // 
            this.btnPubTest.Location = new System.Drawing.Point(477, 649);
            this.btnPubTest.Name = "btnPubTest";
            this.btnPubTest.Size = new System.Drawing.Size(144, 33);
            this.btnPubTest.TabIndex = 14;
            this.btnPubTest.Text = "测试发布";
            this.btnPubTest.UseVisualStyleBackColor = true;
            this.btnPubTest.Click += new System.EventHandler(this.btnPubTest_Click);
            // 
            // co_type_unused_nums
            // 
            this.co_type_unused_nums.Text = "未使用文章数";
            this.co_type_unused_nums.Width = 130;
            // 
            // pub_type_items
            // 
            this.pub_type_items.Text = "栏目文章数";
            this.pub_type_items.Width = 130;
            // 
            // PubConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 694);
            this.Controls.Add(this.btnSavePubConfig);
            this.Controls.Add(this.btnPubTest);
            this.Controls.Add(this.tabctrPubform);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PubConfigForm";
            this.Text = "发布规则配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PubConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.PubConfigForm_Load);
            this.tabctrPubform.ResumeLayout(false);
            this.tabPubConfig.ResumeLayout(false);
            this.gboxPubTypename.ResumeLayout(false);
            this.gboxPubTypename.PerformLayout();
            this.gboxCoTypename.ResumeLayout(false);
            this.gboxCoTypename.PerformLayout();
            this.gboxCoBasicinfo.ResumeLayout(false);
            this.gboxCoBasicinfo.PerformLayout();
            this.tabPubTest.ResumeLayout(false);
            this.tabPubTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabctrPubform;
        private System.Windows.Forms.TabPage tabPubConfig;
        private System.Windows.Forms.TabPage tabPubTest;
        private System.Windows.Forms.Label lblPubTestResult;
        private System.Windows.Forms.TextBox tboxPubTestResult;
        private System.Windows.Forms.Label lblPubNums;
        private System.Windows.Forms.TextBox tboxPubName;
        private System.Windows.Forms.Label lblPubName;
        private System.Windows.Forms.GroupBox gboxCoBasicinfo;
        private System.Windows.Forms.Button btnSavePubConfig;
        private System.Windows.Forms.Button btnPubTest;
        private System.Windows.Forms.TextBox tboxPubNums;
        private System.Windows.Forms.Label lblRandomDateStop;
        private System.Windows.Forms.TextBox tboxRandomDateStop;
        private System.Windows.Forms.DateTimePicker dtpRandomDateStop;
        private System.Windows.Forms.Label lblRandomDateStart;
        private System.Windows.Forms.TextBox tboxRandomDateStart;
        private System.Windows.Forms.DateTimePicker dtpRandomDateStart;
        private System.Windows.Forms.Button btnSearchCoTypename;
        private System.Windows.Forms.TextBox tboxCoTypeid;
        private System.Windows.Forms.Label lblCoTypeid;
        private System.Windows.Forms.TextBox tboxCoTypename;
        private System.Windows.Forms.Label lblCoTypeName;
        private System.Windows.Forms.Label lblSearchCoTypename;
        private System.Windows.Forms.TextBox tboxSearchCoTypename;
        private System.Windows.Forms.GroupBox gboxCoTypename;
        private ListViewNF listViewCoTypeinfo;
        private System.Windows.Forms.GroupBox gboxPubTypename;
        private ListViewNF listViewPubTypeinfo;
        private System.Windows.Forms.Button btnSearchPubTypename;
        private System.Windows.Forms.TextBox tboxPubTypeid;
        private System.Windows.Forms.Label lblPubTypeid;
        private System.Windows.Forms.TextBox tboxSearchPubTypename;
        private System.Windows.Forms.Label lblSearchPubTypename;
        private System.Windows.Forms.Label lblPubTypename;
        private System.Windows.Forms.TextBox tboxPubTypename;
        private System.Windows.Forms.ColumnHeader co_typeid;
        private System.Windows.Forms.ColumnHeader co_typename;
        private System.Windows.Forms.ColumnHeader pub_typeid;
        private System.Windows.Forms.ColumnHeader pub_typename;
        private System.Windows.Forms.TextBox tboxPubFilterKeywords;
        private System.Windows.Forms.Label lblPubFilterKeywords;
        private System.Windows.Forms.Label lblPubFilterKeywordsInfo;
        private System.Windows.Forms.ColumnHeader pub_type_items;
        private System.Windows.Forms.ColumnHeader co_type_unused_nums;
    }
}
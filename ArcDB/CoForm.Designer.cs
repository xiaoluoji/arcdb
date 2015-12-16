namespace ArcDB
{
    partial class CoForm
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
            this.tabctrCoform = new System.Windows.Forms.TabControl();
            this.tabCoListConfig = new System.Windows.Forms.TabPage();
            this.gboxCoArcurlGetRule = new System.Windows.Forms.GroupBox();
            this.tboxXpathArcurlNode = new System.Windows.Forms.TextBox();
            this.lblXpathArcurlNode = new System.Windows.Forms.Label();
            this.gboxCoListGetRule = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tboxMoreListPages = new System.Windows.Forms.TextBox();
            this.lblCoMoreListPages = new System.Windows.Forms.Label();
            this.lblCoListInfo = new System.Windows.Forms.Label();
            this.tboxCoStopPageNumber = new System.Windows.Forms.TextBox();
            this.lblColistPageTo = new System.Windows.Forms.Label();
            this.tboxCoStartPageNumber = new System.Windows.Forms.TextBox();
            this.lblColistPageFrom = new System.Windows.Forms.Label();
            this.lblCoListUrl = new System.Windows.Forms.Label();
            this.tboxCoListPath = new System.Windows.Forms.TextBox();
            this.gboxCoBasicinfo = new System.Windows.Forms.GroupBox();
            this.cboxCoTypeName = new System.Windows.Forms.ComboBox();
            this.lblCoTypeName = new System.Windows.Forms.Label();
            this.lblCoName = new System.Windows.Forms.Label();
            this.panelCo_Offline = new System.Windows.Forms.Panel();
            this.rbtnCo_Offline_no = new System.Windows.Forms.RadioButton();
            this.rbtnCo_Offline_yes = new System.Windows.Forms.RadioButton();
            this.tboxCoName = new System.Windows.Forms.TextBox();
            this.lblCo_offline = new System.Windows.Forms.Label();
            this.lblCoSource_Lang = new System.Windows.Forms.Label();
            this.cboxCoSource_Site = new System.Windows.Forms.ComboBox();
            this.cboxCoSource_Lang = new System.Windows.Forms.ComboBox();
            this.lblCoSource_Site = new System.Windows.Forms.Label();
            this.tabCoArcConfig = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tboxRegexParams = new System.Windows.Forms.TextBox();
            this.tboxSubNodeParams = new System.Windows.Forms.TextBox();
            this.lblRegexParams = new System.Windows.Forms.Label();
            this.lblSubNodeParams = new System.Windows.Forms.Label();
            this.gboxArcBasicinfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblArcSubpageSymbolInfo = new System.Windows.Forms.Label();
            this.tboxArcSubpageStartNum = new System.Windows.Forms.TextBox();
            this.lblArcSubpageStartNum = new System.Windows.Forms.Label();
            this.tboxArcSubpageSymbol = new System.Windows.Forms.TextBox();
            this.lblArcSubpageSymbol = new System.Windows.Forms.Label();
            this.tboxXpathContentNode = new System.Windows.Forms.TextBox();
            this.tboxXpathTitleNode = new System.Windows.Forms.TextBox();
            this.lblXpathContentNode = new System.Windows.Forms.Label();
            this.lblXpathTitleNode = new System.Windows.Forms.Label();
            this.btnCoTest = new System.Windows.Forms.Button();
            this.btnSaveCoConfig = new System.Windows.Forms.Button();
            this.tabctrCoform.SuspendLayout();
            this.tabCoListConfig.SuspendLayout();
            this.gboxCoArcurlGetRule.SuspendLayout();
            this.gboxCoListGetRule.SuspendLayout();
            this.gboxCoBasicinfo.SuspendLayout();
            this.panelCo_Offline.SuspendLayout();
            this.tabCoArcConfig.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxArcBasicinfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabctrCoform
            // 
            this.tabctrCoform.Controls.Add(this.tabCoListConfig);
            this.tabctrCoform.Controls.Add(this.tabCoArcConfig);
            this.tabctrCoform.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabctrCoform.Location = new System.Drawing.Point(0, 0);
            this.tabctrCoform.Name = "tabctrCoform";
            this.tabctrCoform.SelectedIndex = 0;
            this.tabctrCoform.Size = new System.Drawing.Size(978, 540);
            this.tabctrCoform.TabIndex = 1;
            // 
            // tabCoListConfig
            // 
            this.tabCoListConfig.Controls.Add(this.gboxCoArcurlGetRule);
            this.tabCoListConfig.Controls.Add(this.gboxCoListGetRule);
            this.tabCoListConfig.Controls.Add(this.gboxCoBasicinfo);
            this.tabCoListConfig.Location = new System.Drawing.Point(4, 28);
            this.tabCoListConfig.Name = "tabCoListConfig";
            this.tabCoListConfig.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tabCoListConfig.Size = new System.Drawing.Size(970, 508);
            this.tabCoListConfig.TabIndex = 0;
            this.tabCoListConfig.Text = "列表配置";
            this.tabCoListConfig.UseVisualStyleBackColor = true;
            // 
            // gboxCoArcurlGetRule
            // 
            this.gboxCoArcurlGetRule.Controls.Add(this.tboxXpathArcurlNode);
            this.gboxCoArcurlGetRule.Controls.Add(this.lblXpathArcurlNode);
            this.gboxCoArcurlGetRule.Location = new System.Drawing.Point(3, 377);
            this.gboxCoArcurlGetRule.Name = "gboxCoArcurlGetRule";
            this.gboxCoArcurlGetRule.Size = new System.Drawing.Size(964, 109);
            this.gboxCoArcurlGetRule.TabIndex = 11;
            this.gboxCoArcurlGetRule.TabStop = false;
            this.gboxCoArcurlGetRule.Text = "文章网址匹配规则";
            // 
            // tboxXpathArcurlNode
            // 
            this.tboxXpathArcurlNode.Location = new System.Drawing.Point(218, 40);
            this.tboxXpathArcurlNode.Name = "tboxXpathArcurlNode";
            this.tboxXpathArcurlNode.Size = new System.Drawing.Size(739, 28);
            this.tboxXpathArcurlNode.TabIndex = 15;
            // 
            // lblXpathArcurlNode
            // 
            this.lblXpathArcurlNode.AutoSize = true;
            this.lblXpathArcurlNode.Location = new System.Drawing.Point(15, 46);
            this.lblXpathArcurlNode.Name = "lblXpathArcurlNode";
            this.lblXpathArcurlNode.Size = new System.Drawing.Size(197, 18);
            this.lblXpathArcurlNode.TabIndex = 15;
            this.lblXpathArcurlNode.Text = "文章URL Xpath表达式: ";
            // 
            // gboxCoListGetRule
            // 
            this.gboxCoListGetRule.Controls.Add(this.label2);
            this.gboxCoListGetRule.Controls.Add(this.tboxMoreListPages);
            this.gboxCoListGetRule.Controls.Add(this.lblCoMoreListPages);
            this.gboxCoListGetRule.Controls.Add(this.lblCoListInfo);
            this.gboxCoListGetRule.Controls.Add(this.tboxCoStopPageNumber);
            this.gboxCoListGetRule.Controls.Add(this.lblColistPageTo);
            this.gboxCoListGetRule.Controls.Add(this.tboxCoStartPageNumber);
            this.gboxCoListGetRule.Controls.Add(this.lblColistPageFrom);
            this.gboxCoListGetRule.Controls.Add(this.lblCoListUrl);
            this.gboxCoListGetRule.Controls.Add(this.tboxCoListPath);
            this.gboxCoListGetRule.Location = new System.Drawing.Point(3, 136);
            this.gboxCoListGetRule.Name = "gboxCoListGetRule";
            this.gboxCoListGetRule.Size = new System.Drawing.Size(964, 224);
            this.gboxCoListGetRule.TabIndex = 10;
            this.gboxCoListGetRule.TabStop = false;
            this.gboxCoListGetRule.Text = "列表网址获取规则";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "（选填）";
            // 
            // tboxMoreListPages
            // 
            this.tboxMoreListPages.Location = new System.Drawing.Point(122, 101);
            this.tboxMoreListPages.Multiline = true;
            this.tboxMoreListPages.Name = "tboxMoreListPages";
            this.tboxMoreListPages.Size = new System.Drawing.Size(836, 106);
            this.tboxMoreListPages.TabIndex = 14;
            // 
            // lblCoMoreListPages
            // 
            this.lblCoMoreListPages.AutoSize = true;
            this.lblCoMoreListPages.Location = new System.Drawing.Point(15, 103);
            this.lblCoMoreListPages.Name = "lblCoMoreListPages";
            this.lblCoMoreListPages.Size = new System.Drawing.Size(98, 18);
            this.lblCoMoreListPages.TabIndex = 13;
            this.lblCoMoreListPages.Text = "手工指定: ";
            // 
            // lblCoListInfo
            // 
            this.lblCoListInfo.AutoSize = true;
            this.lblCoListInfo.Location = new System.Drawing.Point(15, 75);
            this.lblCoListInfo.Name = "lblCoListInfo";
            this.lblCoListInfo.Size = new System.Drawing.Size(917, 18);
            this.lblCoListInfo.TabIndex = 12;
            this.lblCoListInfo.Text = "(如：http://www.xx.com/test/list_(*).html 不能匹配的网址，可以在手工指定网址处添加，每行表示一个网址)";
            // 
            // tboxCoStopPageNumber
            // 
            this.tboxCoStopPageNumber.Location = new System.Drawing.Point(895, 33);
            this.tboxCoStopPageNumber.Name = "tboxCoStopPageNumber";
            this.tboxCoStopPageNumber.Size = new System.Drawing.Size(63, 28);
            this.tboxCoStopPageNumber.TabIndex = 11;
            // 
            // lblColistPageTo
            // 
            this.lblColistPageTo.AutoSize = true;
            this.lblColistPageTo.Location = new System.Drawing.Point(855, 40);
            this.lblColistPageTo.Name = "lblColistPageTo";
            this.lblColistPageTo.Size = new System.Drawing.Size(44, 18);
            this.lblColistPageTo.TabIndex = 10;
            this.lblColistPageTo.Text = "到: ";
            // 
            // tboxCoStartPageNumber
            // 
            this.tboxCoStartPageNumber.Location = new System.Drawing.Point(786, 33);
            this.tboxCoStartPageNumber.Name = "tboxCoStartPageNumber";
            this.tboxCoStartPageNumber.Size = new System.Drawing.Size(63, 28);
            this.tboxCoStartPageNumber.TabIndex = 9;
            // 
            // lblColistPageFrom
            // 
            this.lblColistPageFrom.AutoSize = true;
            this.lblColistPageFrom.Location = new System.Drawing.Point(674, 40);
            this.lblColistPageFrom.Name = "lblColistPageFrom";
            this.lblColistPageFrom.Size = new System.Drawing.Size(125, 18);
            this.lblColistPageFrom.TabIndex = 5;
            this.lblColistPageFrom.Text = "（*）表示从: ";
            // 
            // lblCoListUrl
            // 
            this.lblCoListUrl.AutoSize = true;
            this.lblCoListUrl.Location = new System.Drawing.Point(15, 40);
            this.lblCoListUrl.Name = "lblCoListUrl";
            this.lblCoListUrl.Size = new System.Drawing.Size(98, 18);
            this.lblCoListUrl.TabIndex = 3;
            this.lblCoListUrl.Text = "匹配网址: ";
            // 
            // tboxCoListPath
            // 
            this.tboxCoListPath.Location = new System.Drawing.Point(122, 33);
            this.tboxCoListPath.Name = "tboxCoListPath";
            this.tboxCoListPath.Size = new System.Drawing.Size(546, 28);
            this.tboxCoListPath.TabIndex = 4;
            // 
            // gboxCoBasicinfo
            // 
            this.gboxCoBasicinfo.Controls.Add(this.cboxCoTypeName);
            this.gboxCoBasicinfo.Controls.Add(this.lblCoTypeName);
            this.gboxCoBasicinfo.Controls.Add(this.lblCoName);
            this.gboxCoBasicinfo.Controls.Add(this.panelCo_Offline);
            this.gboxCoBasicinfo.Controls.Add(this.tboxCoName);
            this.gboxCoBasicinfo.Controls.Add(this.lblCo_offline);
            this.gboxCoBasicinfo.Controls.Add(this.lblCoSource_Lang);
            this.gboxCoBasicinfo.Controls.Add(this.cboxCoSource_Site);
            this.gboxCoBasicinfo.Controls.Add(this.cboxCoSource_Lang);
            this.gboxCoBasicinfo.Controls.Add(this.lblCoSource_Site);
            this.gboxCoBasicinfo.Location = new System.Drawing.Point(3, 10);
            this.gboxCoBasicinfo.Name = "gboxCoBasicinfo";
            this.gboxCoBasicinfo.Size = new System.Drawing.Size(964, 113);
            this.gboxCoBasicinfo.TabIndex = 9;
            this.gboxCoBasicinfo.TabStop = false;
            this.gboxCoBasicinfo.Text = "基本信息";
            // 
            // cboxCoTypeName
            // 
            this.cboxCoTypeName.FormattingEnabled = true;
            this.cboxCoTypeName.Location = new System.Drawing.Point(121, 75);
            this.cboxCoTypeName.Name = "cboxCoTypeName";
            this.cboxCoTypeName.Size = new System.Drawing.Size(142, 26);
            this.cboxCoTypeName.TabIndex = 10;
            // 
            // lblCoTypeName
            // 
            this.lblCoTypeName.AutoSize = true;
            this.lblCoTypeName.Location = new System.Drawing.Point(15, 79);
            this.lblCoTypeName.Name = "lblCoTypeName";
            this.lblCoTypeName.Size = new System.Drawing.Size(98, 18);
            this.lblCoTypeName.TabIndex = 9;
            this.lblCoTypeName.Text = "文章分类: ";
            // 
            // lblCoName
            // 
            this.lblCoName.AutoSize = true;
            this.lblCoName.Location = new System.Drawing.Point(15, 37);
            this.lblCoName.Name = "lblCoName";
            this.lblCoName.Size = new System.Drawing.Size(98, 18);
            this.lblCoName.TabIndex = 1;
            this.lblCoName.Text = "节点名称: ";
            // 
            // panelCo_Offline
            // 
            this.panelCo_Offline.Controls.Add(this.rbtnCo_Offline_no);
            this.panelCo_Offline.Controls.Add(this.rbtnCo_Offline_yes);
            this.panelCo_Offline.Location = new System.Drawing.Point(426, 71);
            this.panelCo_Offline.Name = "panelCo_Offline";
            this.panelCo_Offline.Size = new System.Drawing.Size(129, 33);
            this.panelCo_Offline.TabIndex = 8;
            // 
            // rbtnCo_Offline_no
            // 
            this.rbtnCo_Offline_no.AutoSize = true;
            this.rbtnCo_Offline_no.Location = new System.Drawing.Point(71, 6);
            this.rbtnCo_Offline_no.Name = "rbtnCo_Offline_no";
            this.rbtnCo_Offline_no.Size = new System.Drawing.Size(51, 22);
            this.rbtnCo_Offline_no.TabIndex = 1;
            this.rbtnCo_Offline_no.Text = "no";
            this.rbtnCo_Offline_no.UseVisualStyleBackColor = true;
            // 
            // rbtnCo_Offline_yes
            // 
            this.rbtnCo_Offline_yes.AutoSize = true;
            this.rbtnCo_Offline_yes.Checked = true;
            this.rbtnCo_Offline_yes.Location = new System.Drawing.Point(5, 6);
            this.rbtnCo_Offline_yes.Name = "rbtnCo_Offline_yes";
            this.rbtnCo_Offline_yes.Size = new System.Drawing.Size(60, 22);
            this.rbtnCo_Offline_yes.TabIndex = 0;
            this.rbtnCo_Offline_yes.TabStop = true;
            this.rbtnCo_Offline_yes.Text = "yes";
            this.rbtnCo_Offline_yes.UseVisualStyleBackColor = true;
            // 
            // tboxCoName
            // 
            this.tboxCoName.Location = new System.Drawing.Point(122, 31);
            this.tboxCoName.Name = "tboxCoName";
            this.tboxCoName.Size = new System.Drawing.Size(141, 28);
            this.tboxCoName.TabIndex = 2;
            // 
            // lblCo_offline
            // 
            this.lblCo_offline.AutoSize = true;
            this.lblCo_offline.Location = new System.Drawing.Point(286, 79);
            this.lblCo_offline.Name = "lblCo_offline";
            this.lblCo_offline.Size = new System.Drawing.Size(134, 18);
            this.lblCo_offline.TabIndex = 7;
            this.lblCo_offline.Text = "是否离线采集: ";
            // 
            // lblCoSource_Lang
            // 
            this.lblCoSource_Lang.AutoSize = true;
            this.lblCoSource_Lang.Location = new System.Drawing.Point(286, 37);
            this.lblCoSource_Lang.Name = "lblCoSource_Lang";
            this.lblCoSource_Lang.Size = new System.Drawing.Size(98, 18);
            this.lblCoSource_Lang.TabIndex = 3;
            this.lblCoSource_Lang.Text = "页面编码: ";
            // 
            // cboxCoSource_Site
            // 
            this.cboxCoSource_Site.FormattingEnabled = true;
            this.cboxCoSource_Site.Location = new System.Drawing.Point(656, 33);
            this.cboxCoSource_Site.Name = "cboxCoSource_Site";
            this.cboxCoSource_Site.Size = new System.Drawing.Size(301, 26);
            this.cboxCoSource_Site.TabIndex = 6;
            // 
            // cboxCoSource_Lang
            // 
            this.cboxCoSource_Lang.FormattingEnabled = true;
            this.cboxCoSource_Lang.Items.AddRange(new object[] {
            "gb2312",
            "utf8"});
            this.cboxCoSource_Lang.Location = new System.Drawing.Point(390, 33);
            this.cboxCoSource_Lang.Name = "cboxCoSource_Lang";
            this.cboxCoSource_Lang.Size = new System.Drawing.Size(130, 26);
            this.cboxCoSource_Lang.TabIndex = 4;
            // 
            // lblCoSource_Site
            // 
            this.lblCoSource_Site.AutoSize = true;
            this.lblCoSource_Site.Location = new System.Drawing.Point(552, 37);
            this.lblCoSource_Site.Name = "lblCoSource_Site";
            this.lblCoSource_Site.Size = new System.Drawing.Size(98, 18);
            this.lblCoSource_Site.TabIndex = 5;
            this.lblCoSource_Site.Text = "来源网站: ";
            // 
            // tabCoArcConfig
            // 
            this.tabCoArcConfig.Controls.Add(this.button1);
            this.tabCoArcConfig.Controls.Add(this.groupBox1);
            this.tabCoArcConfig.Controls.Add(this.gboxArcBasicinfo);
            this.tabCoArcConfig.Location = new System.Drawing.Point(4, 28);
            this.tabCoArcConfig.Name = "tabCoArcConfig";
            this.tabCoArcConfig.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tabCoArcConfig.Size = new System.Drawing.Size(970, 508);
            this.tabCoArcConfig.TabIndex = 1;
            this.tabCoArcConfig.Text = "内容配置";
            this.tabCoArcConfig.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(408, 509);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 33);
            this.button1.TabIndex = 19;
            this.button1.Text = "测试";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tboxRegexParams);
            this.groupBox1.Controls.Add(this.tboxSubNodeParams);
            this.groupBox1.Controls.Add(this.lblRegexParams);
            this.groupBox1.Controls.Add(this.lblSubNodeParams);
            this.groupBox1.Location = new System.Drawing.Point(3, 222);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(964, 267);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "需要清理的内容";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "(选填：每行为一个表达式)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "(选填：每行为一个表达式)";
            // 
            // tboxRegexParams
            // 
            this.tboxRegexParams.Location = new System.Drawing.Point(254, 149);
            this.tboxRegexParams.Multiline = true;
            this.tboxRegexParams.Name = "tboxRegexParams";
            this.tboxRegexParams.Size = new System.Drawing.Size(691, 100);
            this.tboxRegexParams.TabIndex = 17;
            // 
            // tboxSubNodeParams
            // 
            this.tboxSubNodeParams.Location = new System.Drawing.Point(254, 36);
            this.tboxSubNodeParams.Multiline = true;
            this.tboxSubNodeParams.Name = "tboxSubNodeParams";
            this.tboxSubNodeParams.Size = new System.Drawing.Size(691, 100);
            this.tboxSubNodeParams.TabIndex = 16;
            // 
            // lblRegexParams
            // 
            this.lblRegexParams.AutoSize = true;
            this.lblRegexParams.Location = new System.Drawing.Point(15, 152);
            this.lblRegexParams.Name = "lblRegexParams";
            this.lblRegexParams.Size = new System.Drawing.Size(206, 18);
            this.lblRegexParams.TabIndex = 1;
            this.lblRegexParams.Text = "待清理内容正则表达式：";
            // 
            // lblSubNodeParams
            // 
            this.lblSubNodeParams.AutoSize = true;
            this.lblSubNodeParams.Location = new System.Drawing.Point(15, 41);
            this.lblSubNodeParams.Name = "lblSubNodeParams";
            this.lblSubNodeParams.Size = new System.Drawing.Size(233, 18);
            this.lblSubNodeParams.TabIndex = 0;
            this.lblSubNodeParams.Text = "待清理子节点Xpath表达式：";
            // 
            // gboxArcBasicinfo
            // 
            this.gboxArcBasicinfo.Controls.Add(this.label1);
            this.gboxArcBasicinfo.Controls.Add(this.lblArcSubpageSymbolInfo);
            this.gboxArcBasicinfo.Controls.Add(this.tboxArcSubpageStartNum);
            this.gboxArcBasicinfo.Controls.Add(this.lblArcSubpageStartNum);
            this.gboxArcBasicinfo.Controls.Add(this.tboxArcSubpageSymbol);
            this.gboxArcBasicinfo.Controls.Add(this.lblArcSubpageSymbol);
            this.gboxArcBasicinfo.Controls.Add(this.tboxXpathContentNode);
            this.gboxArcBasicinfo.Controls.Add(this.tboxXpathTitleNode);
            this.gboxArcBasicinfo.Controls.Add(this.lblXpathContentNode);
            this.gboxArcBasicinfo.Controls.Add(this.lblXpathTitleNode);
            this.gboxArcBasicinfo.Location = new System.Drawing.Point(3, 10);
            this.gboxArcBasicinfo.Name = "gboxArcBasicinfo";
            this.gboxArcBasicinfo.Size = new System.Drawing.Size(964, 192);
            this.gboxArcBasicinfo.TabIndex = 0;
            this.gboxArcBasicinfo.TabStop = false;
            this.gboxArcBasicinfo.Text = "文章基本信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(493, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "备注：（留空则表示默认起始编号为 2）";
            // 
            // lblArcSubpageSymbolInfo
            // 
            this.lblArcSubpageSymbolInfo.AutoSize = true;
            this.lblArcSubpageSymbolInfo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblArcSubpageSymbolInfo.Location = new System.Drawing.Point(15, 155);
            this.lblArcSubpageSymbolInfo.Name = "lblArcSubpageSymbolInfo";
            this.lblArcSubpageSymbolInfo.Size = new System.Drawing.Size(332, 18);
            this.lblArcSubpageSymbolInfo.TabIndex = 22;
            this.lblArcSubpageSymbolInfo.Text = "备注：（留空表示默认分页符号为“_\"）";
            // 
            // tboxArcSubpageStartNum
            // 
            this.tboxArcSubpageStartNum.Location = new System.Drawing.Point(697, 117);
            this.tboxArcSubpageStartNum.Name = "tboxArcSubpageStartNum";
            this.tboxArcSubpageStartNum.Size = new System.Drawing.Size(248, 28);
            this.tboxArcSubpageStartNum.TabIndex = 21;
            this.tboxArcSubpageStartNum.Text = "2";
            // 
            // lblArcSubpageStartNum
            // 
            this.lblArcSubpageStartNum.AutoSize = true;
            this.lblArcSubpageStartNum.Location = new System.Drawing.Point(493, 120);
            this.lblArcSubpageStartNum.Name = "lblArcSubpageStartNum";
            this.lblArcSubpageStartNum.Size = new System.Drawing.Size(170, 18);
            this.lblArcSubpageStartNum.TabIndex = 20;
            this.lblArcSubpageStartNum.Text = "文章分页起始编号：";
            // 
            // tboxArcSubpageSymbol
            // 
            this.tboxArcSubpageSymbol.Location = new System.Drawing.Point(219, 117);
            this.tboxArcSubpageSymbol.Name = "tboxArcSubpageSymbol";
            this.tboxArcSubpageSymbol.Size = new System.Drawing.Size(248, 28);
            this.tboxArcSubpageSymbol.TabIndex = 19;
            this.tboxArcSubpageSymbol.Text = "_";
            // 
            // lblArcSubpageSymbol
            // 
            this.lblArcSubpageSymbol.AutoSize = true;
            this.lblArcSubpageSymbol.Location = new System.Drawing.Point(15, 120);
            this.lblArcSubpageSymbol.Name = "lblArcSubpageSymbol";
            this.lblArcSubpageSymbol.Size = new System.Drawing.Size(188, 18);
            this.lblArcSubpageSymbol.TabIndex = 18;
            this.lblArcSubpageSymbol.Text = "文章分页符号(选填)：";
            // 
            // tboxXpathContentNode
            // 
            this.tboxXpathContentNode.Location = new System.Drawing.Point(219, 77);
            this.tboxXpathContentNode.Name = "tboxXpathContentNode";
            this.tboxXpathContentNode.Size = new System.Drawing.Size(726, 28);
            this.tboxXpathContentNode.TabIndex = 17;
            // 
            // tboxXpathTitleNode
            // 
            this.tboxXpathTitleNode.Location = new System.Drawing.Point(219, 36);
            this.tboxXpathTitleNode.Name = "tboxXpathTitleNode";
            this.tboxXpathTitleNode.Size = new System.Drawing.Size(726, 28);
            this.tboxXpathTitleNode.TabIndex = 16;
            // 
            // lblXpathContentNode
            // 
            this.lblXpathContentNode.AutoSize = true;
            this.lblXpathContentNode.Location = new System.Drawing.Point(15, 80);
            this.lblXpathContentNode.Name = "lblXpathContentNode";
            this.lblXpathContentNode.Size = new System.Drawing.Size(197, 18);
            this.lblXpathContentNode.TabIndex = 1;
            this.lblXpathContentNode.Text = "文章内容Xpath表达式：";
            // 
            // lblXpathTitleNode
            // 
            this.lblXpathTitleNode.AutoSize = true;
            this.lblXpathTitleNode.Location = new System.Drawing.Point(15, 41);
            this.lblXpathTitleNode.Name = "lblXpathTitleNode";
            this.lblXpathTitleNode.Size = new System.Drawing.Size(197, 18);
            this.lblXpathTitleNode.TabIndex = 0;
            this.lblXpathTitleNode.Text = "文章标题Xpath表达式：";
            // 
            // btnCoTest
            // 
            this.btnCoTest.Location = new System.Drawing.Point(330, 557);
            this.btnCoTest.Name = "btnCoTest";
            this.btnCoTest.Size = new System.Drawing.Size(144, 33);
            this.btnCoTest.TabIndex = 12;
            this.btnCoTest.Text = "测试采集";
            this.btnCoTest.UseVisualStyleBackColor = true;
            this.btnCoTest.Click += new System.EventHandler(this.btnCoTest_Click);
            // 
            // btnSaveCoConfig
            // 
            this.btnSaveCoConfig.Location = new System.Drawing.Point(503, 557);
            this.btnSaveCoConfig.Name = "btnSaveCoConfig";
            this.btnSaveCoConfig.Size = new System.Drawing.Size(144, 33);
            this.btnSaveCoConfig.TabIndex = 13;
            this.btnSaveCoConfig.Text = "保存配置";
            this.btnSaveCoConfig.UseVisualStyleBackColor = true;
            this.btnSaveCoConfig.Click += new System.EventHandler(this.btnSaveCoConfig_Click);
            // 
            // CoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 613);
            this.Controls.Add(this.btnSaveCoConfig);
            this.Controls.Add(this.btnCoTest);
            this.Controls.Add(this.tabctrCoform);
            this.Name = "CoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CoForm_Closing);
            this.Load += new System.EventHandler(this.CoForm_Load);
            this.tabctrCoform.ResumeLayout(false);
            this.tabCoListConfig.ResumeLayout(false);
            this.gboxCoArcurlGetRule.ResumeLayout(false);
            this.gboxCoArcurlGetRule.PerformLayout();
            this.gboxCoListGetRule.ResumeLayout(false);
            this.gboxCoListGetRule.PerformLayout();
            this.gboxCoBasicinfo.ResumeLayout(false);
            this.gboxCoBasicinfo.PerformLayout();
            this.panelCo_Offline.ResumeLayout(false);
            this.panelCo_Offline.PerformLayout();
            this.tabCoArcConfig.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxArcBasicinfo.ResumeLayout(false);
            this.gboxArcBasicinfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabctrCoform;
        private System.Windows.Forms.TabPage tabCoListConfig;
        private System.Windows.Forms.TabPage tabCoArcConfig;
        private System.Windows.Forms.Label lblCoSource_Lang;
        private System.Windows.Forms.TextBox tboxCoName;
        private System.Windows.Forms.Label lblCoName;
        private System.Windows.Forms.ComboBox cboxCoSource_Lang;
        private System.Windows.Forms.ComboBox cboxCoSource_Site;
        private System.Windows.Forms.Label lblCoSource_Site;
        private System.Windows.Forms.Label lblCo_offline;
        private System.Windows.Forms.Panel panelCo_Offline;
        private System.Windows.Forms.RadioButton rbtnCo_Offline_no;
        private System.Windows.Forms.RadioButton rbtnCo_Offline_yes;
        private System.Windows.Forms.GroupBox gboxCoBasicinfo;
        private System.Windows.Forms.GroupBox gboxCoListGetRule;
        private System.Windows.Forms.Label lblCoListUrl;
        private System.Windows.Forms.TextBox tboxCoListPath;
        private System.Windows.Forms.Label lblColistPageFrom;
        private System.Windows.Forms.TextBox tboxCoStartPageNumber;
        private System.Windows.Forms.Label lblColistPageTo;
        private System.Windows.Forms.TextBox tboxCoStopPageNumber;
        private System.Windows.Forms.Label lblCoListInfo;
        private System.Windows.Forms.Label lblCoMoreListPages;
        private System.Windows.Forms.TextBox tboxMoreListPages;
        private System.Windows.Forms.GroupBox gboxCoArcurlGetRule;
        private System.Windows.Forms.TextBox tboxXpathArcurlNode;
        private System.Windows.Forms.Label lblXpathArcurlNode;
        private System.Windows.Forms.GroupBox gboxArcBasicinfo;
        private System.Windows.Forms.Label lblXpathTitleNode;
        private System.Windows.Forms.TextBox tboxXpathContentNode;
        private System.Windows.Forms.TextBox tboxXpathTitleNode;
        private System.Windows.Forms.Label lblXpathContentNode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tboxRegexParams;
        private System.Windows.Forms.TextBox tboxSubNodeParams;
        private System.Windows.Forms.Label lblRegexParams;
        private System.Windows.Forms.Label lblSubNodeParams;
        private System.Windows.Forms.Button btnCoTest;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tboxArcSubpageSymbol;
        private System.Windows.Forms.Label lblArcSubpageSymbol;
        private System.Windows.Forms.TextBox tboxArcSubpageStartNum;
        private System.Windows.Forms.Label lblArcSubpageStartNum;
        private System.Windows.Forms.Label lblArcSubpageSymbolInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveCoConfig;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCoTypeName;
        private System.Windows.Forms.ComboBox cboxCoTypeName;
    }
}
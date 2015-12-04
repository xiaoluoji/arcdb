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
            this.tabPageDelWatermark = new System.Windows.Forms.TabPage();
            this.tabPageDistribute = new System.Windows.Forms.TabPage();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.tboxPort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tboxDbName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxCharset = new System.Windows.Forms.ComboBox();
            this.tboxPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tboxUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxHostName = new System.Windows.Forms.TextBox();
            this.gbxDatabaseSet = new System.Windows.Forms.GroupBox();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnLoadCoconfig = new System.Windows.Forms.Button();
            this.listViewCollect = new System.Windows.Forms.ListView();
            this.cid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.co_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.source_lang = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.source_site = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.up_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.co_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.co_nums = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnModifyCoconfig = new System.Windows.Forms.Button();
            this.tabctrMainform.SuspendLayout();
            this.tabPageCollect.SuspendLayout();
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
            this.tabctrMainform.Size = new System.Drawing.Size(978, 486);
            this.tabctrMainform.TabIndex = 1;
            // 
            // tabPageCollect
            // 
            this.tabPageCollect.Controls.Add(this.btnModifyCoconfig);
            this.tabPageCollect.Controls.Add(this.listViewCollect);
            this.tabPageCollect.Controls.Add(this.btnLoadCoconfig);
            this.tabPageCollect.Location = new System.Drawing.Point(4, 28);
            this.tabPageCollect.Name = "tabPageCollect";
            this.tabPageCollect.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCollect.Size = new System.Drawing.Size(970, 454);
            this.tabPageCollect.TabIndex = 0;
            this.tabPageCollect.Text = "采集内容";
            this.tabPageCollect.UseVisualStyleBackColor = true;
            // 
            // tabPageDelWatermark
            // 
            this.tabPageDelWatermark.Location = new System.Drawing.Point(4, 28);
            this.tabPageDelWatermark.Name = "tabPageDelWatermark";
            this.tabPageDelWatermark.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDelWatermark.Size = new System.Drawing.Size(970, 454);
            this.tabPageDelWatermark.TabIndex = 1;
            this.tabPageDelWatermark.Text = "去水印";
            this.tabPageDelWatermark.UseVisualStyleBackColor = true;
            // 
            // tabPageDistribute
            // 
            this.tabPageDistribute.Location = new System.Drawing.Point(4, 28);
            this.tabPageDistribute.Name = "tabPageDistribute";
            this.tabPageDistribute.Size = new System.Drawing.Size(970, 454);
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
            this.tabPageConfig.Size = new System.Drawing.Size(970, 454);
            this.tabPageConfig.TabIndex = 3;
            this.tabPageConfig.Text = "系统设置";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // tboxPort
            // 
            this.tboxPort.Location = new System.Drawing.Point(471, 107);
            this.tboxPort.Name = "tboxPort";
            this.tboxPort.Size = new System.Drawing.Size(166, 28);
            this.tboxPort.TabIndex = 35;
            this.tboxPort.Text = "3306";
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
            // tboxDbName
            // 
            this.tboxDbName.Location = new System.Drawing.Point(155, 107);
            this.tboxDbName.Name = "tboxDbName";
            this.tboxDbName.Size = new System.Drawing.Size(166, 28);
            this.tboxDbName.TabIndex = 31;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 18);
            this.label4.TabIndex = 29;
            this.label4.Text = "Mysql Charset:";
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
            // tboxPassword
            // 
            this.tboxPassword.Location = new System.Drawing.Point(471, 68);
            this.tboxPassword.Name = "tboxPassword";
            this.tboxPassword.Size = new System.Drawing.Size(166, 28);
            this.tboxPassword.TabIndex = 27;
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
            // tboxUserName
            // 
            this.tboxUserName.Location = new System.Drawing.Point(155, 68);
            this.tboxUserName.Name = "tboxUserName";
            this.tboxUserName.Size = new System.Drawing.Size(166, 28);
            this.tboxUserName.TabIndex = 25;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "Mysql HostName:";
            // 
            // tboxHostName
            // 
            this.tboxHostName.Location = new System.Drawing.Point(155, 34);
            this.tboxHostName.Name = "tboxHostName";
            this.tboxHostName.Size = new System.Drawing.Size(166, 28);
            this.tboxHostName.TabIndex = 22;
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
            // btnLoadCoconfig
            // 
            this.btnLoadCoconfig.Location = new System.Drawing.Point(3, 339);
            this.btnLoadCoconfig.Name = "btnLoadCoconfig";
            this.btnLoadCoconfig.Size = new System.Drawing.Size(133, 37);
            this.btnLoadCoconfig.TabIndex = 1;
            this.btnLoadCoconfig.Text = "加载采集规则";
            this.btnLoadCoconfig.UseVisualStyleBackColor = true;
            this.btnLoadCoconfig.Click += new System.EventHandler(this.btnLoadCoconfig_Click);
            // 
            // listViewCollect
            // 
            this.listViewCollect.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cid,
            this.co_name,
            this.source_lang,
            this.source_site,
            this.up_time,
            this.co_time,
            this.co_nums});
            this.listViewCollect.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewCollect.FullRowSelect = true;
            this.listViewCollect.GridLines = true;
            this.listViewCollect.Location = new System.Drawing.Point(3, 3);
            this.listViewCollect.MultiSelect = false;
            this.listViewCollect.Name = "listViewCollect";
            this.listViewCollect.Size = new System.Drawing.Size(964, 317);
            this.listViewCollect.TabIndex = 2;
            this.listViewCollect.UseCompatibleStateImageBehavior = false;
            this.listViewCollect.View = System.Windows.Forms.View.Details;
            // 
            // cid
            // 
            this.cid.Text = "ID";
            this.cid.Width = 36;
            // 
            // co_name
            // 
            this.co_name.Text = "采集名称";
            this.co_name.Width = 130;
            // 
            // source_lang
            // 
            this.source_lang.Text = "编码";
            this.source_lang.Width = 50;
            // 
            // source_site
            // 
            this.source_site.Text = "采集来源";
            this.source_site.Width = 130;
            // 
            // up_time
            // 
            this.up_time.Text = "加入日期";
            this.up_time.Width = 90;
            // 
            // co_time
            // 
            this.co_time.Text = "最后采集日期";
            this.co_time.Width = 122;
            // 
            // co_nums
            // 
            this.co_nums.Text = "采集数量";
            this.co_nums.Width = 87;
            // 
            // btnModifyCoconfig
            // 
            this.btnModifyCoconfig.Location = new System.Drawing.Point(160, 339);
            this.btnModifyCoconfig.Name = "btnModifyCoconfig";
            this.btnModifyCoconfig.Size = new System.Drawing.Size(133, 37);
            this.btnModifyCoconfig.TabIndex = 3;
            this.btnModifyCoconfig.Text = "修改配置";
            this.btnModifyCoconfig.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 486);
            this.Controls.Add(this.tabctrMainform);
            this.Name = "MainForm";
            this.Text = "内容源工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_Closed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabctrMainform.ResumeLayout(false);
            this.tabPageCollect.ResumeLayout(false);
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
    }
}


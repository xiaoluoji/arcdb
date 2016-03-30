namespace ArcDB
{
    partial class ImportFromLocoy
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
            this.listViewImportLocoy = new ArcDB.ListViewNF();
            this.import_state = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.import_rule_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.import_content_tablename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.import_down_tablename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.import_need_importnums = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.co_saved_articles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time_used = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblErrorOutput = new System.Windows.Forms.Label();
            this.tboxErrorOutput = new System.Windows.Forms.TextBox();
            this.labTime = new System.Windows.Forms.Label();
            this.btnCancelAll = new System.Windows.Forms.Button();
            this.btnCancelCurrent = new System.Windows.Forms.Button();
            this.import_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.import_type_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewImportLocoy
            // 
            this.listViewImportLocoy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.import_state,
            this.id,
            this.import_rule_name,
            this.import_type_name,
            this.import_content_tablename,
            this.import_down_tablename,
            this.import_need_importnums,
            this.co_saved_articles,
            this.time_used});
            this.listViewImportLocoy.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewImportLocoy.Location = new System.Drawing.Point(0, 0);
            this.listViewImportLocoy.Name = "listViewImportLocoy";
            this.listViewImportLocoy.Size = new System.Drawing.Size(978, 439);
            this.listViewImportLocoy.TabIndex = 1;
            this.listViewImportLocoy.UseCompatibleStateImageBehavior = false;
            this.listViewImportLocoy.View = System.Windows.Forms.View.Details;
            // 
            // import_state
            // 
            this.import_state.Text = "导入状态";
            this.import_state.Width = 100;
            // 
            // id
            // 
            this.id.Text = "ID";
            // 
            // import_rule_name
            // 
            this.import_rule_name.Text = "导入规则名称";
            this.import_rule_name.Width = 120;
            // 
            // import_content_tablename
            // 
            this.import_content_tablename.Text = "导入内容表名";
            this.import_content_tablename.Width = 120;
            // 
            // import_down_tablename
            // 
            this.import_down_tablename.Text = "导入下载表名";
            this.import_down_tablename.Width = 120;
            // 
            // import_need_importnums
            // 
            this.import_need_importnums.Text = "需导入文章数";
            this.import_need_importnums.Width = 120;
            // 
            // co_saved_articles
            // 
            this.co_saved_articles.Text = "保存文章数";
            this.co_saved_articles.Width = 120;
            // 
            // time_used
            // 
            this.time_used.Text = "耗时";
            this.time_used.Width = 120;
            // 
            // lblErrorOutput
            // 
            this.lblErrorOutput.AutoSize = true;
            this.lblErrorOutput.Location = new System.Drawing.Point(0, 454);
            this.lblErrorOutput.Name = "lblErrorOutput";
            this.lblErrorOutput.Size = new System.Drawing.Size(98, 18);
            this.lblErrorOutput.TabIndex = 4;
            this.lblErrorOutput.Text = "错误日志：";
            // 
            // tboxErrorOutput
            // 
            this.tboxErrorOutput.Location = new System.Drawing.Point(0, 475);
            this.tboxErrorOutput.Multiline = true;
            this.tboxErrorOutput.Name = "tboxErrorOutput";
            this.tboxErrorOutput.Size = new System.Drawing.Size(978, 132);
            this.tboxErrorOutput.TabIndex = 3;
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(26, 627);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(62, 18);
            this.labTime.TabIndex = 11;
            this.labTime.Text = "[time]";
            // 
            // btnCancelAll
            // 
            this.btnCancelAll.Location = new System.Drawing.Point(318, 627);
            this.btnCancelAll.Name = "btnCancelAll";
            this.btnCancelAll.Size = new System.Drawing.Size(151, 40);
            this.btnCancelAll.TabIndex = 13;
            this.btnCancelAll.Text = "取消所有导入";
            this.btnCancelAll.UseVisualStyleBackColor = true;
            // 
            // btnCancelCurrent
            // 
            this.btnCancelCurrent.Location = new System.Drawing.Point(487, 627);
            this.btnCancelCurrent.Name = "btnCancelCurrent";
            this.btnCancelCurrent.Size = new System.Drawing.Size(151, 40);
            this.btnCancelCurrent.TabIndex = 12;
            this.btnCancelCurrent.Text = "取消当前任务";
            this.btnCancelCurrent.UseVisualStyleBackColor = true;
            // 
            // import_name
            // 
            this.import_name.Text = "导入名称";
            this.import_name.Width = 91;
            // 
            // import_type_name
            // 
            this.import_type_name.Text = "导入分类";
            this.import_type_name.Width = 90;
            // 
            // ImportFromLocoy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 694);
            this.Controls.Add(this.btnCancelAll);
            this.Controls.Add(this.btnCancelCurrent);
            this.Controls.Add(this.labTime);
            this.Controls.Add(this.lblErrorOutput);
            this.Controls.Add(this.tboxErrorOutput);
            this.Controls.Add(this.listViewImportLocoy);
            this.Name = "ImportFromLocoy";
            this.Text = "导入火车头数据";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListViewNF listViewImportLocoy;
        private System.Windows.Forms.ColumnHeader import_state;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader import_rule_name;
        private System.Windows.Forms.ColumnHeader import_content_tablename;
        private System.Windows.Forms.ColumnHeader import_down_tablename;
        private System.Windows.Forms.ColumnHeader import_need_importnums;
        private System.Windows.Forms.ColumnHeader co_saved_articles;
        private System.Windows.Forms.ColumnHeader time_used;
        private System.Windows.Forms.Label lblErrorOutput;
        private System.Windows.Forms.TextBox tboxErrorOutput;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Button btnCancelAll;
        private System.Windows.Forms.Button btnCancelCurrent;
        private System.Windows.Forms.ColumnHeader import_name;
        private System.Windows.Forms.ColumnHeader import_type_name;
    }
}
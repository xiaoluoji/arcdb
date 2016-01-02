namespace ArcDB
{
    partial class PubArticleForm
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
            this.listViewPubArticles = new ArcDB.ListViewNF();
            this.pub_state = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pub_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pub_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.co_typename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pub_typename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pub_nums = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pub_exported_nums = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time_used = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labTime = new System.Windows.Forms.Label();
            this.btnCancelAll = new System.Windows.Forms.Button();
            this.btnCancelCurrent = new System.Windows.Forms.Button();
            this.lblErrorOutput = new System.Windows.Forms.Label();
            this.tboxErrorOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listViewPubArticles
            // 
            this.listViewPubArticles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pub_state,
            this.pub_id,
            this.pub_name,
            this.co_typename,
            this.pub_typename,
            this.pub_nums,
            this.pub_exported_nums,
            this.time_used});
            this.listViewPubArticles.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewPubArticles.Location = new System.Drawing.Point(0, 0);
            this.listViewPubArticles.Name = "listViewPubArticles";
            this.listViewPubArticles.Size = new System.Drawing.Size(978, 439);
            this.listViewPubArticles.TabIndex = 1;
            this.listViewPubArticles.UseCompatibleStateImageBehavior = false;
            this.listViewPubArticles.View = System.Windows.Forms.View.Details;
            // 
            // pub_state
            // 
            this.pub_state.Text = "当前发布状态";
            this.pub_state.Width = 128;
            // 
            // pub_id
            // 
            this.pub_id.Text = "ID";
            // 
            // pub_name
            // 
            this.pub_name.Text = "发布名称";
            this.pub_name.Width = 91;
            // 
            // co_typename
            // 
            this.co_typename.Text = "采集分类名称";
            this.co_typename.Width = 120;
            // 
            // pub_typename
            // 
            this.pub_typename.Text = "发布分类名称";
            this.pub_typename.Width = 120;
            // 
            // pub_nums
            // 
            this.pub_nums.Text = "需发布文章数";
            this.pub_nums.Width = 120;
            // 
            // pub_exported_nums
            // 
            this.pub_exported_nums.Text = "已发布文章数";
            this.pub_exported_nums.Width = 120;
            // 
            // time_used
            // 
            this.time_used.Text = "耗时";
            this.time_used.Width = 120;
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(26, 627);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(62, 18);
            this.labTime.TabIndex = 15;
            this.labTime.Text = "[time]";
            // 
            // btnCancelAll
            // 
            this.btnCancelAll.Location = new System.Drawing.Point(318, 627);
            this.btnCancelAll.Name = "btnCancelAll";
            this.btnCancelAll.Size = new System.Drawing.Size(151, 40);
            this.btnCancelAll.TabIndex = 14;
            this.btnCancelAll.Text = "取消所有发布";
            this.btnCancelAll.UseVisualStyleBackColor = true;
            // 
            // btnCancelCurrent
            // 
            this.btnCancelCurrent.Location = new System.Drawing.Point(487, 627);
            this.btnCancelCurrent.Name = "btnCancelCurrent";
            this.btnCancelCurrent.Size = new System.Drawing.Size(151, 40);
            this.btnCancelCurrent.TabIndex = 13;
            this.btnCancelCurrent.Text = "取消当前发布";
            this.btnCancelCurrent.UseVisualStyleBackColor = true;
            // 
            // lblErrorOutput
            // 
            this.lblErrorOutput.AutoSize = true;
            this.lblErrorOutput.Location = new System.Drawing.Point(0, 454);
            this.lblErrorOutput.Name = "lblErrorOutput";
            this.lblErrorOutput.Size = new System.Drawing.Size(98, 18);
            this.lblErrorOutput.TabIndex = 12;
            this.lblErrorOutput.Text = "错误日志：";
            // 
            // tboxErrorOutput
            // 
            this.tboxErrorOutput.Location = new System.Drawing.Point(0, 475);
            this.tboxErrorOutput.Multiline = true;
            this.tboxErrorOutput.Name = "tboxErrorOutput";
            this.tboxErrorOutput.Size = new System.Drawing.Size(978, 132);
            this.tboxErrorOutput.TabIndex = 11;
            // 
            // PubArticleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 694);
            this.Controls.Add(this.labTime);
            this.Controls.Add(this.btnCancelAll);
            this.Controls.Add(this.btnCancelCurrent);
            this.Controls.Add(this.lblErrorOutput);
            this.Controls.Add(this.tboxErrorOutput);
            this.Controls.Add(this.listViewPubArticles);
            this.Name = "PubArticleForm";
            this.Text = "发布文章";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListViewNF listViewPubArticles;
        private System.Windows.Forms.ColumnHeader pub_state;
        private System.Windows.Forms.ColumnHeader pub_id;
        private System.Windows.Forms.ColumnHeader pub_name;
        private System.Windows.Forms.ColumnHeader co_typename;
        private System.Windows.Forms.ColumnHeader pub_typename;
        private System.Windows.Forms.ColumnHeader pub_nums;
        private System.Windows.Forms.ColumnHeader pub_exported_nums;
        private System.Windows.Forms.ColumnHeader time_used;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Button btnCancelAll;
        private System.Windows.Forms.Button btnCancelCurrent;
        private System.Windows.Forms.Label lblErrorOutput;
        private System.Windows.Forms.TextBox tboxErrorOutput;
    }
}
using System.Windows.Forms;

namespace ArcDB
{

    partial class CoArticleForm
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
            this.tboxErrorOutput = new System.Windows.Forms.TextBox();
            this.lblErrorOutput = new System.Windows.Forms.Label();
            this.btnCancelCurrent = new System.Windows.Forms.Button();
            this.btnCancelAll = new System.Windows.Forms.Button();
            this.labTime = new System.Windows.Forms.Label();
            this.listViewCoArticles = new ListViewNF();
            this.co_state = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.co_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.co_listpages_num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.co_get_arcs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.co_need_conums = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.co_nums = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time_used = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.co_saved_articles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // tboxErrorOutput
            // 
            this.tboxErrorOutput.Location = new System.Drawing.Point(0, 475);
            this.tboxErrorOutput.Multiline = true;
            this.tboxErrorOutput.Name = "tboxErrorOutput";
            this.tboxErrorOutput.Size = new System.Drawing.Size(978, 132);
            this.tboxErrorOutput.TabIndex = 1;
            // 
            // lblErrorOutput
            // 
            this.lblErrorOutput.AutoSize = true;
            this.lblErrorOutput.Location = new System.Drawing.Point(0, 454);
            this.lblErrorOutput.Name = "lblErrorOutput";
            this.lblErrorOutput.Size = new System.Drawing.Size(98, 18);
            this.lblErrorOutput.TabIndex = 2;
            this.lblErrorOutput.Text = "错误日志：";
            // 
            // btnCancelCurrent
            // 
            this.btnCancelCurrent.Location = new System.Drawing.Point(487, 627);
            this.btnCancelCurrent.Name = "btnCancelCurrent";
            this.btnCancelCurrent.Size = new System.Drawing.Size(151, 40);
            this.btnCancelCurrent.TabIndex = 3;
            this.btnCancelCurrent.Text = "取消当前任务";
            this.btnCancelCurrent.UseVisualStyleBackColor = true;
            this.btnCancelCurrent.Click += new System.EventHandler(this.btnCancelSellect_Click);
            // 
            // btnCancelAll
            // 
            this.btnCancelAll.Location = new System.Drawing.Point(318, 627);
            this.btnCancelAll.Name = "btnCancelAll";
            this.btnCancelAll.Size = new System.Drawing.Size(151, 40);
            this.btnCancelAll.TabIndex = 4;
            this.btnCancelAll.Text = "取消所有采集";
            this.btnCancelAll.UseVisualStyleBackColor = true;
            this.btnCancelAll.Click += new System.EventHandler(this.btnCancelAll_Click);
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(26, 627);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(62, 18);
            this.labTime.TabIndex = 10;
            this.labTime.Text = "[time]";
            // 
            // listViewCoArticles
            // 
            this.listViewCoArticles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.co_state,
            this.cid,
            this.co_name,
            this.co_listpages_num,
            this.co_get_arcs,
            this.co_need_conums,
            this.co_nums,
            this.co_saved_articles,
            this.time_used});
            this.listViewCoArticles.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewCoArticles.Location = new System.Drawing.Point(0, 0);
            this.listViewCoArticles.Name = "listViewCoArticles";
            this.listViewCoArticles.Size = new System.Drawing.Size(978, 439);
            this.listViewCoArticles.TabIndex = 0;
            this.listViewCoArticles.UseCompatibleStateImageBehavior = false;
            this.listViewCoArticles.View = System.Windows.Forms.View.Details;
            // 
            // co_state
            // 
            this.co_state.Text = "当前采集状态";
            this.co_state.Width = 128;
            // 
            // cid
            // 
            this.cid.Text = "ID";
            // 
            // co_name
            // 
            this.co_name.Text = "采集名称";
            this.co_name.Width = 91;
            // 
            // co_listpages_num
            // 
            this.co_listpages_num.Text = "列表页数";
            this.co_listpages_num.Width = 91;
            // 
            // co_get_arcs
            // 
            this.co_get_arcs.Text = "获取文章数";
            this.co_get_arcs.Width = 104;
            // 
            // co_need_conums
            // 
            this.co_need_conums.Text = "需采文章数";
            this.co_need_conums.Width = 103;
            // 
            // co_nums
            // 
            this.co_nums.Text = "已采文章数";
            this.co_nums.Width = 120;
            // 
            // time_used
            // 
            this.time_used.Text = "耗时";
            this.time_used.Width = 120;
            // 
            // co_saved_articles
            // 
            this.co_saved_articles.Text = "保存文章数";
            this.co_saved_articles.Width = 120;
            // 
            // CoArticleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 694);
            this.Controls.Add(this.labTime);
            this.Controls.Add(this.btnCancelAll);
            this.Controls.Add(this.btnCancelCurrent);
            this.Controls.Add(this.lblErrorOutput);
            this.Controls.Add(this.tboxErrorOutput);
            this.Controls.Add(this.listViewCoArticles);
            this.Name = "CoArticleForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "采集文章";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CoArticleForm_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //   private System.Windows.Forms.ListView listViewCoArticles;
        private ListViewNF listViewCoArticles;
        private System.Windows.Forms.ColumnHeader cid;
        private System.Windows.Forms.ColumnHeader co_name;
        private System.Windows.Forms.ColumnHeader co_state;
        private System.Windows.Forms.ColumnHeader co_listpages_num;
        private System.Windows.Forms.ColumnHeader co_get_arcs;
        private System.Windows.Forms.ColumnHeader co_nums;
        private System.Windows.Forms.ColumnHeader time_used;
        private System.Windows.Forms.TextBox tboxErrorOutput;
        private System.Windows.Forms.Label lblErrorOutput;
        private System.Windows.Forms.Button btnCancelCurrent;
        private System.Windows.Forms.Button btnCancelAll;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.ColumnHeader co_need_conums;
        private ColumnHeader co_saved_articles;
    }

}
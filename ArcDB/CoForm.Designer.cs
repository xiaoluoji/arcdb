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
            this.lblCoinfo = new System.Windows.Forms.Label();
            this.tabctrCoform = new System.Windows.Forms.TabControl();
            this.tabCoListConfig = new System.Windows.Forms.TabPage();
            this.tabCoArcConfig = new System.Windows.Forms.TabPage();
            this.tabctrCoform.SuspendLayout();
            this.tabCoListConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCoinfo
            // 
            this.lblCoinfo.AutoSize = true;
            this.lblCoinfo.Location = new System.Drawing.Point(26, 39);
            this.lblCoinfo.Name = "lblCoinfo";
            this.lblCoinfo.Size = new System.Drawing.Size(134, 18);
            this.lblCoinfo.TabIndex = 0;
            this.lblCoinfo.Text = "节点基本信息：";
            // 
            // tabctrCoform
            // 
            this.tabctrCoform.Controls.Add(this.tabCoListConfig);
            this.tabctrCoform.Controls.Add(this.tabCoArcConfig);
            this.tabctrCoform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabctrCoform.Location = new System.Drawing.Point(0, 0);
            this.tabctrCoform.Name = "tabctrCoform";
            this.tabctrCoform.SelectedIndex = 0;
            this.tabctrCoform.Size = new System.Drawing.Size(978, 644);
            this.tabctrCoform.TabIndex = 1;
            // 
            // tabCoListConfig
            // 
            this.tabCoListConfig.Controls.Add(this.lblCoinfo);
            this.tabCoListConfig.Location = new System.Drawing.Point(4, 28);
            this.tabCoListConfig.Name = "tabCoListConfig";
            this.tabCoListConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoListConfig.Size = new System.Drawing.Size(970, 612);
            this.tabCoListConfig.TabIndex = 0;
            this.tabCoListConfig.Text = "列表配置";
            this.tabCoListConfig.UseVisualStyleBackColor = true;
            // 
            // tabCoArcConfig
            // 
            this.tabCoArcConfig.Location = new System.Drawing.Point(4, 28);
            this.tabCoArcConfig.Name = "tabCoArcConfig";
            this.tabCoArcConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoArcConfig.Size = new System.Drawing.Size(970, 612);
            this.tabCoArcConfig.TabIndex = 1;
            this.tabCoArcConfig.Text = "内容配置";
            this.tabCoArcConfig.UseVisualStyleBackColor = true;
            // 
            // CoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 644);
            this.Controls.Add(this.tabctrCoform);
            this.Name = "CoForm";
            this.Text = "CoForm";
            this.tabctrCoform.ResumeLayout(false);
            this.tabCoListConfig.ResumeLayout(false);
            this.tabCoListConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCoinfo;
        private System.Windows.Forms.TabControl tabctrCoform;
        private System.Windows.Forms.TabPage tabCoListConfig;
        private System.Windows.Forms.TabPage tabCoArcConfig;
    }
}
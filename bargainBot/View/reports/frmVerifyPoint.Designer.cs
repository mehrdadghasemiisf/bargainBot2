namespace bargainBot.View.reports
{
    partial class frmVerifyPoint
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.RadioButton();
            this.chkNotVerify = new System.Windows.Forms.RadioButton();
            this.chkVerify = new System.Windows.Forms.RadioButton();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.تاییدامتیازToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VerifyBool = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.First_FullName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Suggest_FullName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Verify1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.chkNotVerify);
            this.groupBox1.Controls.Add(this.chkVerify);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1005, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(22, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(122, 45);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // chkAll
            // 
            this.chkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(749, 30);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(77, 28);
            this.chkAll.TabIndex = 0;
            this.chkAll.TabStop = true;
            this.chkAll.Text = "همه موارد";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // chkNotVerify
            // 
            this.chkNotVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNotVerify.AutoSize = true;
            this.chkNotVerify.Location = new System.Drawing.Point(832, 30);
            this.chkNotVerify.Name = "chkNotVerify";
            this.chkNotVerify.Size = new System.Drawing.Size(80, 28);
            this.chkNotVerify.TabIndex = 0;
            this.chkNotVerify.TabStop = true;
            this.chkNotVerify.Text = "تایید نشده";
            this.chkNotVerify.UseVisualStyleBackColor = true;
            // 
            // chkVerify
            // 
            this.chkVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVerify.AutoSize = true;
            this.chkVerify.Checked = true;
            this.chkVerify.Location = new System.Drawing.Point(918, 30);
            this.chkVerify.Name = "chkVerify";
            this.chkVerify.Size = new System.Drawing.Size(75, 28);
            this.chkVerify.TabIndex = 0;
            this.chkVerify.TabStop = true;
            this.chkVerify.Text = "تایید شده";
            this.chkVerify.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.VerifyBool,
            this.First_FullName1,
            this.Suggest_FullName1,
            this.Date,
            this.Verify1});
            this.dgv.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 81);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(1005, 698);
            this.dgv.TabIndex = 9;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.تاییدامتیازToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // تاییدامتیازToolStripMenuItem
            // 
            this.تاییدامتیازToolStripMenuItem.Name = "تاییدامتیازToolStripMenuItem";
            this.تاییدامتیازToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.تاییدامتیازToolStripMenuItem.Text = "تایید امتیاز";
            this.تاییدامتیازToolStripMenuItem.Click += new System.EventHandler(this.تاییدامتیازToolStripMenuItem_Click);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // VerifyBool
            // 
            this.VerifyBool.HeaderText = "VerifyBool";
            this.VerifyBool.Name = "VerifyBool";
            this.VerifyBool.ReadOnly = true;
            this.VerifyBool.Visible = false;
            // 
            // First_FullName1
            // 
            this.First_FullName1.DataPropertyName = "First_FullName";
            this.First_FullName1.HeaderText = "کاربر ثبت کننده";
            this.First_FullName1.Name = "First_FullName1";
            this.First_FullName1.ReadOnly = true;
            // 
            // Suggest_FullName1
            // 
            this.Suggest_FullName1.DataPropertyName = "Suggest_FullName";
            this.Suggest_FullName1.HeaderText = "کاربر معرفی شده";
            this.Suggest_FullName1.Name = "Suggest_FullName1";
            this.Suggest_FullName1.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "تاریخ";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Verify1
            // 
            this.Verify1.DataPropertyName = "Verify";
            this.Verify1.HeaderText = "وضعیت";
            this.Verify1.Name = "Verify1";
            this.Verify1.ReadOnly = true;
            // 
            // frmVerifyPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 779);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("IRANSans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "frmVerifyPoint";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "سیستم امتیازبندی معرفی ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.RadioButton chkAll;
        private System.Windows.Forms.RadioButton chkNotVerify;
        private System.Windows.Forms.RadioButton chkVerify;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem تاییدامتیازToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn VerifyBool;
        private System.Windows.Forms.DataGridViewTextBoxColumn First_FullName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Suggest_FullName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Verify1;
    }
}
namespace bargainBot.View.frmUsers
{
    partial class FrmRobotUseres
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSumPriceGaranty = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AliasNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FamilyUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceGarranty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Garranty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisterDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Verify = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ویرایشToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.واریزیابرداشتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.نمایشکمسیونهایToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.اضافهکمکردنامتیازToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حذفکاربرازسیستمToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "جستجو";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(700, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(263, 30);
            this.textBox1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSumPriceGaranty);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1200, 77);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "جستجو";
            // 
            // lblSumPriceGaranty
            // 
            this.lblSumPriceGaranty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumPriceGaranty.Font = new System.Drawing.Font("IRANSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSumPriceGaranty.Location = new System.Drawing.Point(187, 26);
            this.lblSumPriceGaranty.Name = "lblSumPriceGaranty";
            this.lblSumPriceGaranty.Size = new System.Drawing.Size(489, 34);
            this.lblSumPriceGaranty.TabIndex = 4;
            this.lblSumPriceGaranty.Text = "جمع کل وجه تضمین : 0 تومان";
            this.lblSumPriceGaranty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(980, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "نام کاربری : ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.AliasNames,
            this.NameUser,
            this.FamilyUser,
            this.PriceGarranty,
            this.Garranty,
            this.Mobile,
            this.BankCard,
            this.RegisterDate,
            this.Verify});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(1200, 719);
            this.dataGridView1.TabIndex = 4;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "آی دی";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // AliasNames
            // 
            this.AliasNames.DataPropertyName = "AliasNames";
            this.AliasNames.HeaderText = "نام مستعار";
            this.AliasNames.Name = "AliasNames";
            this.AliasNames.ReadOnly = true;
            // 
            // NameUser
            // 
            this.NameUser.DataPropertyName = "Name";
            this.NameUser.HeaderText = "نام";
            this.NameUser.Name = "NameUser";
            this.NameUser.ReadOnly = true;
            // 
            // FamilyUser
            // 
            this.FamilyUser.DataPropertyName = "Family";
            this.FamilyUser.HeaderText = "نام خانوادگی";
            this.FamilyUser.Name = "FamilyUser";
            this.FamilyUser.ReadOnly = true;
            // 
            // PriceGarranty
            // 
            this.PriceGarranty.DataPropertyName = "PriceGarranty";
            this.PriceGarranty.HeaderText = "وجه تضمین";
            this.PriceGarranty.Name = "PriceGarranty";
            this.PriceGarranty.ReadOnly = true;
            // 
            // Garranty
            // 
            this.Garranty.DataPropertyName = "Garranty";
            this.Garranty.HeaderText = "پله تضمین";
            this.Garranty.Name = "Garranty";
            this.Garranty.ReadOnly = true;
            // 
            // Mobile
            // 
            this.Mobile.DataPropertyName = "Mobile";
            this.Mobile.HeaderText = "موبایل";
            this.Mobile.Name = "Mobile";
            this.Mobile.ReadOnly = true;
            // 
            // BankCard
            // 
            this.BankCard.DataPropertyName = "BankCard";
            this.BankCard.HeaderText = "کارت ملت";
            this.BankCard.Name = "BankCard";
            this.BankCard.ReadOnly = true;
            // 
            // RegisterDate
            // 
            this.RegisterDate.DataPropertyName = "RegisterDate";
            this.RegisterDate.HeaderText = "تاریخ ثبت نام";
            this.RegisterDate.Name = "RegisterDate";
            this.RegisterDate.ReadOnly = true;
            // 
            // Verify
            // 
            this.Verify.DataPropertyName = "Verify";
            this.Verify.HeaderText = "تایید";
            this.Verify.Name = "Verify";
            this.Verify.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ویرایشToolStripMenuItem,
            this.حذفکاربرازسیستمToolStripMenuItem,
            this.toolStripSeparator2,
            this.واریزیابرداشتToolStripMenuItem,
            this.toolStripSeparator1,
            this.نمایشکمسیونهایToolStripMenuItem,
            this.toolStripSeparator3,
            this.اضافهکمکردنامتیازToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 154);
            // 
            // ویرایشToolStripMenuItem
            // 
            this.ویرایشToolStripMenuItem.Name = "ویرایشToolStripMenuItem";
            this.ویرایشToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.ویرایشToolStripMenuItem.Text = "ویرایش ";
            this.ویرایشToolStripMenuItem.Click += new System.EventHandler(this.ویرایشToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // واریزیابرداشتToolStripMenuItem
            // 
            this.واریزیابرداشتToolStripMenuItem.Name = "واریزیابرداشتToolStripMenuItem";
            this.واریزیابرداشتToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.واریزیابرداشتToolStripMenuItem.Text = "واریز یا برداشت";
            this.واریزیابرداشتToolStripMenuItem.Click += new System.EventHandler(this.واریزیابرداشتToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // نمایشکمسیونهایToolStripMenuItem
            // 
            this.نمایشکمسیونهایToolStripMenuItem.Name = "نمایشکمسیونهایToolStripMenuItem";
            this.نمایشکمسیونهایToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.نمایشکمسیونهایToolStripMenuItem.Text = "نمایش سوابق";
            this.نمایشکمسیونهایToolStripMenuItem.Click += new System.EventHandler(this.نمایشکمسیونهایToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // اضافهکمکردنامتیازToolStripMenuItem
            // 
            this.اضافهکمکردنامتیازToolStripMenuItem.Name = "اضافهکمکردنامتیازToolStripMenuItem";
            this.اضافهکمکردنامتیازToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.اضافهکمکردنامتیازToolStripMenuItem.Text = "اضافه / کم کردن امتیاز";
            this.اضافهکمکردنامتیازToolStripMenuItem.Click += new System.EventHandler(this.اضافهکمکردنامتیازToolStripMenuItem_Click);
            // 
            // حذفکاربرازسیستمToolStripMenuItem
            // 
            this.حذفکاربرازسیستمToolStripMenuItem.Name = "حذفکاربرازسیستمToolStripMenuItem";
            this.حذفکاربرازسیستمToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.حذفکاربرازسیستمToolStripMenuItem.Text = "حذف کاربر از سیستم ";
            this.حذفکاربرازسیستمToolStripMenuItem.Click += new System.EventHandler(this.حذفکاربرازسیستمToolStripMenuItem_Click);
            // 
            // FrmRobotUseres
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 796);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("IRANSans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmRobotUseres";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت کاربران";
            this.Load += new System.EventHandler(this.FrmRobotUseres_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ویرایشToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem واریزیابرداشتToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem نمایشکمسیونهایToolStripMenuItem;
        private System.Windows.Forms.Label lblSumPriceGaranty;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem اضافهکمکردنامتیازToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn AliasNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn FamilyUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceGarranty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Garranty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisterDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Verify;
        private System.Windows.Forms.ToolStripMenuItem حذفکاربرازسیستمToolStripMenuItem;
    }
}
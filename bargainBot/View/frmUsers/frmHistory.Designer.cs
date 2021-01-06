namespace bargainBot.View.frmUsers
{
    partial class frmHistory
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvCommision = new System.Windows.Forms.DataGridView();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvTransaction = new System.Windows.Forms.DataGridView();
            this.Price2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTime2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionType_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSumGarantyPrice = new System.Windows.Forms.Label();
            this.lblSumAllVariz = new System.Windows.Forms.Label();
            this.lblSumBardasht = new System.Windows.Forms.Label();
            this.lblSumVariz = new System.Windows.Forms.Label();
            this.tabPageOpenSellBuy = new System.Windows.Forms.TabPage();
            this.dgvOpenSellBuy = new System.Windows.Forms.DataGridView();
            this.Id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NowMazane = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageCloseBarg = new System.Windows.Forms.TabPage();
            this.dgvCloseBag = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCountBag = new System.Windows.Forms.Label();
            this.lblSumSood = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price2222 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price2Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tasvie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8NowMazane = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommision)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPageOpenSellBuy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpenSellBuy)).BeginInit();
            this.tabPageCloseBarg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCloseBag)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPageOpenSellBuy);
            this.tabControl1.Controls.Add(this.tabPageCloseBarg);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1066, 818);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvCommision);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1058, 781);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "کمسیون ها";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Enter += new System.EventHandler(this.TabPage1_Enter);
            // 
            // dgvCommision
            // 
            this.dgvCommision.AllowUserToAddRows = false;
            this.dgvCommision.AllowUserToDeleteRows = false;
            this.dgvCommision.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCommision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommision.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Price,
            this.DateTime});
            this.dgvCommision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCommision.Location = new System.Drawing.Point(3, 3);
            this.dgvCommision.Name = "dgvCommision";
            this.dgvCommision.ReadOnly = true;
            this.dgvCommision.Size = new System.Drawing.Size(1052, 775);
            this.dgvCommision.TabIndex = 0;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "مبلغ";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // DateTime
            // 
            this.DateTime.DataPropertyName = "DateTime";
            this.DateTime.HeaderText = "تاریخ";
            this.DateTime.Name = "DateTime";
            this.DateTime.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvTransaction);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1058, 781);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "کلیه واریزی / دریافتی کاربر";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.TabPage2_Enter);
            // 
            // dgvTransaction
            // 
            this.dgvTransaction.AllowUserToAddRows = false;
            this.dgvTransaction.AllowUserToDeleteRows = false;
            this.dgvTransaction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransaction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Price2,
            this.Disc,
            this.DateTime2,
            this.TransactionType_Id});
            this.dgvTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransaction.Location = new System.Drawing.Point(3, 3);
            this.dgvTransaction.Name = "dgvTransaction";
            this.dgvTransaction.Size = new System.Drawing.Size(1052, 697);
            this.dgvTransaction.TabIndex = 1;
            // 
            // Price2
            // 
            this.Price2.DataPropertyName = "Price";
            this.Price2.HeaderText = "مبلغ ";
            this.Price2.Name = "Price2";
            // 
            // Disc
            // 
            this.Disc.DataPropertyName = "Disc";
            this.Disc.HeaderText = "توضیحات";
            this.Disc.Name = "Disc";
            // 
            // DateTime2
            // 
            this.DateTime2.DataPropertyName = "DateTime";
            this.DateTime2.HeaderText = "تاریخ تراکنش";
            this.DateTime2.Name = "DateTime2";
            // 
            // TransactionType_Id
            // 
            this.TransactionType_Id.DataPropertyName = "TransactionType_Id";
            this.TransactionType_Id.HeaderText = "TransactionType_Id";
            this.TransactionType_Id.Name = "TransactionType_Id";
            this.TransactionType_Id.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSumGarantyPrice);
            this.groupBox2.Controls.Add(this.lblSumAllVariz);
            this.groupBox2.Controls.Add(this.lblSumBardasht);
            this.groupBox2.Controls.Add(this.lblSumVariz);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 700);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1052, 78);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // lblSumGarantyPrice
            // 
            this.lblSumGarantyPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumGarantyPrice.Location = new System.Drawing.Point(6, 51);
            this.lblSumGarantyPrice.Name = "lblSumGarantyPrice";
            this.lblSumGarantyPrice.Size = new System.Drawing.Size(388, 24);
            this.lblSumGarantyPrice.TabIndex = 1;
            this.lblSumGarantyPrice.Text = "وجه تضمین جاری : ";
            // 
            // lblSumAllVariz
            // 
            this.lblSumAllVariz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumAllVariz.Location = new System.Drawing.Point(3, 20);
            this.lblSumAllVariz.Name = "lblSumAllVariz";
            this.lblSumAllVariz.Size = new System.Drawing.Size(388, 24);
            this.lblSumAllVariz.TabIndex = 1;
            this.lblSumAllVariz.Text = "جمع کل : 0 ";
            // 
            // lblSumBardasht
            // 
            this.lblSumBardasht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumBardasht.Location = new System.Drawing.Point(661, 51);
            this.lblSumBardasht.Name = "lblSumBardasht";
            this.lblSumBardasht.Size = new System.Drawing.Size(388, 24);
            this.lblSumBardasht.TabIndex = 1;
            this.lblSumBardasht.Text = "جمع برداشت ها : ";
            // 
            // lblSumVariz
            // 
            this.lblSumVariz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumVariz.Location = new System.Drawing.Point(658, 20);
            this.lblSumVariz.Name = "lblSumVariz";
            this.lblSumVariz.Size = new System.Drawing.Size(388, 24);
            this.lblSumVariz.TabIndex = 1;
            this.lblSumVariz.Text = "جمع واریز ها : ";
            // 
            // tabPageOpenSellBuy
            // 
            this.tabPageOpenSellBuy.Controls.Add(this.dgvOpenSellBuy);
            this.tabPageOpenSellBuy.Location = new System.Drawing.Point(4, 33);
            this.tabPageOpenSellBuy.Name = "tabPageOpenSellBuy";
            this.tabPageOpenSellBuy.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOpenSellBuy.Size = new System.Drawing.Size(1058, 781);
            this.tabPageOpenSellBuy.TabIndex = 2;
            this.tabPageOpenSellBuy.Text = "معاملات باز";
            this.tabPageOpenSellBuy.UseVisualStyleBackColor = true;
            this.tabPageOpenSellBuy.Enter += new System.EventHandler(this.TabPageOpenSellBuy_Enter);
            // 
            // dgvOpenSellBuy
            // 
            this.dgvOpenSellBuy.AllowUserToAddRows = false;
            this.dgvOpenSellBuy.AllowUserToDeleteRows = false;
            this.dgvOpenSellBuy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOpenSellBuy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOpenSellBuy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id1,
            this.Date,
            this.Price11,
            this.FullName2,
            this.Type,
            this.NowMazane});
            this.dgvOpenSellBuy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOpenSellBuy.Location = new System.Drawing.Point(3, 3);
            this.dgvOpenSellBuy.Name = "dgvOpenSellBuy";
            this.dgvOpenSellBuy.ReadOnly = true;
            this.dgvOpenSellBuy.Size = new System.Drawing.Size(1052, 775);
            this.dgvOpenSellBuy.TabIndex = 1;
            // 
            // Id1
            // 
            this.Id1.DataPropertyName = "Id";
            this.Id1.HeaderText = "سند";
            this.Id1.Name = "Id1";
            this.Id1.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "تاریخ";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Price11
            // 
            this.Price11.DataPropertyName = "Price";
            this.Price11.HeaderText = "مبلغ باز شدن";
            this.Price11.Name = "Price11";
            this.Price11.ReadOnly = true;
            // 
            // FullName2
            // 
            this.FullName2.DataPropertyName = "FullName2";
            this.FullName2.HeaderText = "طرف دوم معامله";
            this.FullName2.Name = "FullName2";
            this.FullName2.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "نوع";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // NowMazane
            // 
            this.NowMazane.DataPropertyName = "NowMazane";
            this.NowMazane.HeaderText = "مظنه در لحظه معامله";
            this.NowMazane.Name = "NowMazane";
            this.NowMazane.ReadOnly = true;
            // 
            // tabPageCloseBarg
            // 
            this.tabPageCloseBarg.Controls.Add(this.dgvCloseBag);
            this.tabPageCloseBarg.Controls.Add(this.groupBox1);
            this.tabPageCloseBarg.Location = new System.Drawing.Point(4, 33);
            this.tabPageCloseBarg.Name = "tabPageCloseBarg";
            this.tabPageCloseBarg.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCloseBarg.Size = new System.Drawing.Size(1058, 781);
            this.tabPageCloseBarg.TabIndex = 3;
            this.tabPageCloseBarg.Text = "معاملات بسته شده ";
            this.tabPageCloseBarg.UseVisualStyleBackColor = true;
            this.tabPageCloseBarg.Enter += new System.EventHandler(this.TabPageCloseBarg_Enter);
            // 
            // dgvCloseBag
            // 
            this.dgvCloseBag.AllowUserToAddRows = false;
            this.dgvCloseBag.AllowUserToDeleteRows = false;
            this.dgvCloseBag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCloseBag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCloseBag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Date22,
            this.Price2222,
            this.Price2Column4,
            this.Sod,
            this.FullName22,
            this.Tasvie,
            this.Column7Type,
            this.Column8NowMazane});
            this.dgvCloseBag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCloseBag.Location = new System.Drawing.Point(3, 3);
            this.dgvCloseBag.Name = "dgvCloseBag";
            this.dgvCloseBag.ReadOnly = true;
            this.dgvCloseBag.Size = new System.Drawing.Size(1052, 709);
            this.dgvCloseBag.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCountBag);
            this.groupBox1.Controls.Add(this.lblSumSood);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 712);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1052, 66);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblCountBag
            // 
            this.lblCountBag.AutoSize = true;
            this.lblCountBag.Location = new System.Drawing.Point(6, 27);
            this.lblCountBag.Name = "lblCountBag";
            this.lblCountBag.Size = new System.Drawing.Size(89, 24);
            this.lblCountBag.TabIndex = 0;
            this.lblCountBag.Text = "تعداد معامله : 0";
            // 
            // lblSumSood
            // 
            this.lblSumSood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumSood.Location = new System.Drawing.Point(660, 27);
            this.lblSumSood.Name = "lblSumSood";
            this.lblSumSood.Size = new System.Drawing.Size(386, 24);
            this.lblSumSood.TabIndex = 0;
            this.lblSumSood.Text = "مجموع سود / ضرر : 0 تومان";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            this.Column1.HeaderText = "سند";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Date22
            // 
            this.Date22.DataPropertyName = "Date";
            this.Date22.HeaderText = "تاریخ";
            this.Date22.Name = "Date22";
            this.Date22.ReadOnly = true;
            // 
            // Price2222
            // 
            this.Price2222.DataPropertyName = "Price";
            this.Price2222.HeaderText = "مبلغ باز شدن";
            this.Price2222.Name = "Price2222";
            this.Price2222.ReadOnly = true;
            // 
            // Price2Column4
            // 
            this.Price2Column4.DataPropertyName = "Price2";
            this.Price2Column4.HeaderText = "مبلغ بسته شدن";
            this.Price2Column4.Name = "Price2Column4";
            this.Price2Column4.ReadOnly = true;
            // 
            // Sod
            // 
            this.Sod.DataPropertyName = "Sod";
            this.Sod.HeaderText = "سود/زیان";
            this.Sod.Name = "Sod";
            this.Sod.ReadOnly = true;
            // 
            // FullName22
            // 
            this.FullName22.DataPropertyName = "FullName2";
            this.FullName22.HeaderText = "طرف دوم معامله";
            this.FullName22.Name = "FullName22";
            this.FullName22.ReadOnly = true;
            // 
            // Tasvie
            // 
            this.Tasvie.DataPropertyName = "Tasvie";
            this.Tasvie.HeaderText = "زمان تسویه";
            this.Tasvie.Name = "Tasvie";
            this.Tasvie.ReadOnly = true;
            // 
            // Column7Type
            // 
            this.Column7Type.DataPropertyName = "Type";
            this.Column7Type.HeaderText = "نوع";
            this.Column7Type.Name = "Column7Type";
            this.Column7Type.ReadOnly = true;
            // 
            // Column8NowMazane
            // 
            this.Column8NowMazane.DataPropertyName = "NowMazane";
            this.Column8NowMazane.HeaderText = "مظنه در لحظه معامله";
            this.Column8NowMazane.Name = "Column8NowMazane";
            this.Column8NowMazane.ReadOnly = true;
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 818);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("IRANSans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "frmHistory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تاریخچه کاربر";
            this.Load += new System.EventHandler(this.FrmHistory_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommision)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabPageOpenSellBuy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpenSellBuy)).EndInit();
            this.tabPageCloseBarg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCloseBag)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvCommision;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvTransaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionType_Id;
        private System.Windows.Forms.TabPage tabPageOpenSellBuy;
        private System.Windows.Forms.DataGridView dgvOpenSellBuy;
        private System.Windows.Forms.TabPage tabPageCloseBarg;
        private System.Windows.Forms.DataGridView dgvCloseBag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price11;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn NowMazane;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCountBag;
        private System.Windows.Forms.Label lblSumSood;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSumVariz;
        private System.Windows.Forms.Label lblSumGarantyPrice;
        private System.Windows.Forms.Label lblSumAllVariz;
        private System.Windows.Forms.Label lblSumBardasht;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price2222;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price2Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sod;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tasvie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8NowMazane;
    }
}
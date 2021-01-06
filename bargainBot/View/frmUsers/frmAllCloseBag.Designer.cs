namespace bargainBot.View.frmUsers
{
    partial class frmAllCloseBag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAllCloseBag));
            this.lblSumOpen = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price2222 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price2Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tasvie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8NowMazane = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSumClose = new System.Windows.Forms.Label();
            this.lblSumCommision = new System.Windows.Forms.Label();
            this.lblSumZararOutCommision = new System.Windows.Forms.Label();
            this.lblSumSoodOutCommision = new System.Windows.Forms.Label();
            this.lblSumZarar = new System.Windows.Forms.Label();
            this.lblCountAll = new System.Windows.Forms.Label();
            this.lblCountSell = new System.Windows.Forms.Label();
            this.lblCountBuy = new System.Windows.Forms.Label();
            this.lblSumSood = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDateEnd = new FreeControls.PersianDateTimePicker();
            this.txtDateStart = new FreeControls.PersianDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSumOpen
            // 
            this.lblSumOpen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSumOpen.Font = new System.Drawing.Font("IRANSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSumOpen.Location = new System.Drawing.Point(860, 26);
            this.lblSumOpen.Name = "lblSumOpen";
            this.lblSumOpen.Size = new System.Drawing.Size(336, 34);
            this.lblSumOpen.TabIndex = 5;
            this.lblSumOpen.Text = "جمع مبالغ باز شدن : 0 تومان";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(906, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "الی";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1116, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "از تاریخ : ";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 31);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Date22,
            this.Price2222,
            this.Price2Column4,
            this.Sod,
            this.FullName1,
            this.FullName22,
            this.Tasvie,
            this.Column7Type,
            this.Column8NowMazane,
            this.Comision});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 69);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(1234, 541);
            this.dgv.TabIndex = 9;
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
            // FullName1
            // 
            this.FullName1.DataPropertyName = "FullName1";
            this.FullName1.HeaderText = "طرف اول معامله";
            this.FullName1.Name = "FullName1";
            this.FullName1.ReadOnly = true;
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
            // Comision
            // 
            this.Comision.DataPropertyName = "Comision";
            this.Comision.HeaderText = "کمسیون";
            this.Comision.Name = "Comision";
            this.Comision.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSumClose);
            this.groupBox2.Controls.Add(this.lblSumCommision);
            this.groupBox2.Controls.Add(this.lblSumZararOutCommision);
            this.groupBox2.Controls.Add(this.lblSumSoodOutCommision);
            this.groupBox2.Controls.Add(this.lblSumZarar);
            this.groupBox2.Controls.Add(this.lblCountAll);
            this.groupBox2.Controls.Add(this.lblCountSell);
            this.groupBox2.Controls.Add(this.lblCountBuy);
            this.groupBox2.Controls.Add(this.lblSumSood);
            this.groupBox2.Controls.Add(this.lblSumOpen);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 610);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1234, 175);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // lblSumClose
            // 
            this.lblSumClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSumClose.Font = new System.Drawing.Font("IRANSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSumClose.Location = new System.Drawing.Point(860, 77);
            this.lblSumClose.Name = "lblSumClose";
            this.lblSumClose.Size = new System.Drawing.Size(336, 32);
            this.lblSumClose.TabIndex = 5;
            this.lblSumClose.Text = "جمع مبالغ بسته شدن : 0 تومان";
            // 
            // lblSumCommision
            // 
            this.lblSumCommision.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSumCommision.Font = new System.Drawing.Font("IRANSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSumCommision.ForeColor = System.Drawing.Color.Purple;
            this.lblSumCommision.Location = new System.Drawing.Point(860, 130);
            this.lblSumCommision.Name = "lblSumCommision";
            this.lblSumCommision.Size = new System.Drawing.Size(336, 35);
            this.lblSumCommision.TabIndex = 5;
            this.lblSumCommision.Text = "جمع کارمزدها : 0 تومان";
            // 
            // lblSumZararOutCommision
            // 
            this.lblSumZararOutCommision.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSumZararOutCommision.Font = new System.Drawing.Font("IRANSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSumZararOutCommision.ForeColor = System.Drawing.Color.Green;
            this.lblSumZararOutCommision.Location = new System.Drawing.Point(193, 130);
            this.lblSumZararOutCommision.Name = "lblSumZararOutCommision";
            this.lblSumZararOutCommision.Size = new System.Drawing.Size(552, 35);
            this.lblSumZararOutCommision.TabIndex = 5;
            this.lblSumZararOutCommision.Text = "جمع مبالغ ضرر بدون احتساب کارمزد : 0 تومان";
            // 
            // lblSumSoodOutCommision
            // 
            this.lblSumSoodOutCommision.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSumSoodOutCommision.Font = new System.Drawing.Font("IRANSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSumSoodOutCommision.ForeColor = System.Drawing.Color.Green;
            this.lblSumSoodOutCommision.Location = new System.Drawing.Point(193, 95);
            this.lblSumSoodOutCommision.Name = "lblSumSoodOutCommision";
            this.lblSumSoodOutCommision.Size = new System.Drawing.Size(552, 35);
            this.lblSumSoodOutCommision.TabIndex = 5;
            this.lblSumSoodOutCommision.Text = "جمع مبالغ سود بدون احتساب کارمزد : 0 تومان";
            // 
            // lblSumZarar
            // 
            this.lblSumZarar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSumZarar.Font = new System.Drawing.Font("IRANSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSumZarar.ForeColor = System.Drawing.Color.Navy;
            this.lblSumZarar.Location = new System.Drawing.Point(193, 60);
            this.lblSumZarar.Name = "lblSumZarar";
            this.lblSumZarar.Size = new System.Drawing.Size(552, 35);
            this.lblSumZarar.TabIndex = 5;
            this.lblSumZarar.Text = "جمع مبالغ ضرر با احتساب کارمزد : 0 تومان";
            // 
            // lblCountAll
            // 
            this.lblCountAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCountAll.Font = new System.Drawing.Font("IRANSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCountAll.Location = new System.Drawing.Point(12, 116);
            this.lblCountAll.Name = "lblCountAll";
            this.lblCountAll.Size = new System.Drawing.Size(152, 32);
            this.lblCountAll.TabIndex = 5;
            this.lblCountAll.Text = "تعداد کل : 0";
            // 
            // lblCountSell
            // 
            this.lblCountSell.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCountSell.Font = new System.Drawing.Font("IRANSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCountSell.Location = new System.Drawing.Point(12, 74);
            this.lblCountSell.Name = "lblCountSell";
            this.lblCountSell.Size = new System.Drawing.Size(152, 32);
            this.lblCountSell.TabIndex = 5;
            this.lblCountSell.Text = "تعداد فروش : 0";
            // 
            // lblCountBuy
            // 
            this.lblCountBuy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCountBuy.Font = new System.Drawing.Font("IRANSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCountBuy.Location = new System.Drawing.Point(12, 26);
            this.lblCountBuy.Name = "lblCountBuy";
            this.lblCountBuy.Size = new System.Drawing.Size(152, 34);
            this.lblCountBuy.TabIndex = 5;
            this.lblCountBuy.Text = "تعداد خرید : 0";
            // 
            // lblSumSood
            // 
            this.lblSumSood.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSumSood.Font = new System.Drawing.Font("IRANSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSumSood.ForeColor = System.Drawing.Color.Navy;
            this.lblSumSood.Location = new System.Drawing.Point(193, 26);
            this.lblSumSood.Name = "lblSumSood";
            this.lblSumSood.Size = new System.Drawing.Size(552, 34);
            this.lblSumSood.TabIndex = 5;
            this.lblSumSood.Text = "جمع مبالغ سود با احتساب کارمزد : 0 تومان ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDateEnd);
            this.groupBox1.Controls.Add(this.txtDateStart);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1234, 69);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "جستجو";
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.BackColor = System.Drawing.Color.White;
            this.txtDateEnd.Font = new System.Drawing.Font("IRANSans-Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDateEnd.Location = new System.Drawing.Point(723, 26);
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.ShowTime = false;
            this.txtDateEnd.Size = new System.Drawing.Size(175, 29);
            this.txtDateEnd.TabIndex = 7;
            this.txtDateEnd.Value = ((FreeControls.PersianDateClass)(resources.GetObject("txtDateEnd.Value")));
            // 
            // txtDateStart
            // 
            this.txtDateStart.BackColor = System.Drawing.Color.White;
            this.txtDateStart.Font = new System.Drawing.Font("IRANSans-Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDateStart.Location = new System.Drawing.Point(935, 26);
            this.txtDateStart.Name = "txtDateStart";
            this.txtDateStart.ShowTime = false;
            this.txtDateStart.Size = new System.Drawing.Size(175, 29);
            this.txtDateStart.TabIndex = 8;
            this.txtDateStart.Value = ((FreeControls.PersianDateClass)(resources.GetObject("txtDateStart.Value")));
            // 
            // frmAllCloseBag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 785);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("IRANSans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmAllCloseBag";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Text = "گزارش معاملات بسته شده";
            this.Load += new System.EventHandler(this.FrmAllCloseBag_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSumOpen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSumClose;
        private System.Windows.Forms.Label lblSumZarar;
        private System.Windows.Forms.Label lblCountAll;
        private System.Windows.Forms.Label lblCountSell;
        private System.Windows.Forms.Label lblCountBuy;
        private System.Windows.Forms.Label lblSumSood;
        private System.Windows.Forms.Label lblSumZararOutCommision;
        private System.Windows.Forms.Label lblSumSoodOutCommision;
        private System.Windows.Forms.Label lblSumCommision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price2222;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price2Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sod;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tasvie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8NowMazane;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comision;
        private FreeControls.PersianDateTimePicker txtDateEnd;
        private FreeControls.PersianDateTimePicker txtDateStart;
    }
}
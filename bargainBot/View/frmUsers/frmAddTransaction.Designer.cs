namespace bargainBot.View.frmUsers
{
    partial class frmAddTransaction
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
            this.chkVariz = new System.Windows.Forms.RadioButton();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.chkBardasht = new System.Windows.Forms.RadioButton();
            this.txtDisc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkVariz
            // 
            this.chkVariz.AutoSize = true;
            this.chkVariz.Checked = true;
            this.chkVariz.Font = new System.Drawing.Font("IRANSans-Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkVariz.ForeColor = System.Drawing.Color.Green;
            this.chkVariz.Location = new System.Drawing.Point(369, 23);
            this.chkVariz.Name = "chkVariz";
            this.chkVariz.Size = new System.Drawing.Size(65, 35);
            this.chkVariz.TabIndex = 0;
            this.chkVariz.TabStop = true;
            this.chkVariz.Text = "واریز";
            this.chkVariz.UseVisualStyleBackColor = true;
            this.chkVariz.CheckedChanged += new System.EventHandler(this.ChkVariz_CheckedChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("IRANSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPrice.Location = new System.Drawing.Point(194, 94);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(277, 36);
            this.txtPrice.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(477, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "مبلغ : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "ثبت";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // chkBardasht
            // 
            this.chkBardasht.AutoSize = true;
            this.chkBardasht.Font = new System.Drawing.Font("IRANSans-Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkBardasht.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkBardasht.Location = new System.Drawing.Point(226, 23);
            this.chkBardasht.Name = "chkBardasht";
            this.chkBardasht.Size = new System.Drawing.Size(87, 35);
            this.chkBardasht.TabIndex = 0;
            this.chkBardasht.Text = "برداشت";
            this.chkBardasht.UseVisualStyleBackColor = true;
            this.chkBardasht.CheckedChanged += new System.EventHandler(this.ChkBardasht_CheckedChanged);
            // 
            // txtDisc
            // 
            this.txtDisc.FormattingEnabled = true;
            this.txtDisc.Items.AddRange(new object[] {
            "واریز وجه",
            "برداشت وجه",
            "برداشت سود"});
            this.txtDisc.Location = new System.Drawing.Point(194, 155);
            this.txtDisc.Name = "txtDisc";
            this.txtDisc.Size = new System.Drawing.Size(277, 31);
            this.txtDisc.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(477, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "توضیح";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "تومان";
            // 
            // frmAddTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 272);
            this.Controls.Add(this.txtDisc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.chkBardasht);
            this.Controls.Add(this.chkVariz);
            this.Font = new System.Drawing.Font("IRANSans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddTransaction";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "واریز و برداشت  وجه تضمین";
            this.Load += new System.EventHandler(this.FrmAddTransaction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton chkVariz;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton chkBardasht;
        private System.Windows.Forms.ComboBox txtDisc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
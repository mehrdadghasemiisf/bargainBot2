namespace bargainBot.View.frmUsers
{
    partial class frmAddOrRemovePoint
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.rbAdd = new System.Windows.Forms.RadioButton();
            this.rbRemo = new System.Windows.Forms.RadioButton();
            this.lblPointsTest = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "ثبت";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(444, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "امتیاز";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(308, 93);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 36);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rbAdd
            // 
            this.rbAdd.AutoSize = true;
            this.rbAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbAdd.Location = new System.Drawing.Point(169, 97);
            this.rbAdd.Name = "rbAdd";
            this.rbAdd.Size = new System.Drawing.Size(98, 32);
            this.rbAdd.TabIndex = 3;
            this.rbAdd.TabStop = true;
            this.rbAdd.Text = "اضافه کردن";
            this.rbAdd.UseVisualStyleBackColor = true;
            // 
            // rbRemo
            // 
            this.rbRemo.AutoSize = true;
            this.rbRemo.ForeColor = System.Drawing.Color.Red;
            this.rbRemo.Location = new System.Drawing.Point(64, 97);
            this.rbRemo.Name = "rbRemo";
            this.rbRemo.Size = new System.Drawing.Size(82, 32);
            this.rbRemo.TabIndex = 3;
            this.rbRemo.TabStop = true;
            this.rbRemo.Text = "کم کردن";
            this.rbRemo.UseVisualStyleBackColor = true;
            // 
            // lblPointsTest
            // 
            this.lblPointsTest.Location = new System.Drawing.Point(281, 216);
            this.lblPointsTest.Name = "lblPointsTest";
            this.lblPointsTest.Size = new System.Drawing.Size(242, 31);
            this.lblPointsTest.TabIndex = 1;
            this.lblPointsTest.Text = "مجموع امتیازات : 0 امتیاز ";
            // 
            // frmAddOrRemovePoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 263);
            this.Controls.Add(this.rbRemo);
            this.Controls.Add(this.rbAdd);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lblPointsTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("IRANSans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmAddOrRemovePoint";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اضافه و حذف امتیاز";
            this.Load += new System.EventHandler(this.FrmAddOrRemovePoint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.RadioButton rbAdd;
        private System.Windows.Forms.RadioButton rbRemo;
        private System.Windows.Forms.Label lblPointsTest;
    }
}
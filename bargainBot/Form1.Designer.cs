namespace bargainBot
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MsMain = new System.Windows.Forms.MenuStrip();
            this.mnUseres = new System.Windows.Forms.ToolStripMenuItem();
            this.mnManageUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnReportbargain = new System.Windows.Forms.ToolStripMenuItem();
            this.لیستمعاملاتبازToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.لیستمعاملاتبستهشدهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.گزارشواریزبرداشتهاToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.لیستمعاملاتحراجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.سیستمامتیازبندیمعرفیToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تنظیماتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تنظیمتلورانسToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ایجادنسخهپشتیبانازاطلاعاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.mnStatusOnline = new System.Windows.Forms.ToolStripMenuItem();
            this.mnStatusOfline = new System.Windows.Forms.ToolStripMenuItem();
            this.خروجازتلگرامToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBarMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusBot = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lalMazaneCurent = new System.Windows.Forms.Label();
            this.txtMazane = new System.Windows.Forms.TextBox();
            this.txtTasvie = new System.Windows.Forms.TextBox();
            this.btnTasvie = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkOffRobot = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTasvieMovaghat = new System.Windows.Forms.TextBox();
            this.btnTasvieMovaghat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSendMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.chkPinMessage = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ریستکلیاطلاعاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MsMain.SuspendLayout();
            this.StatusBarMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // MsMain
            // 
            this.MsMain.Font = new System.Drawing.Font("IRANSans-Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnUseres,
            this.mnReport,
            this.تنظیماتToolStripMenuItem,
            this.mnStatus,
            this.خروجازتلگرامToolStripMenuItem});
            this.MsMain.Location = new System.Drawing.Point(0, 0);
            this.MsMain.Name = "MsMain";
            this.MsMain.Size = new System.Drawing.Size(1081, 32);
            this.MsMain.TabIndex = 0;
            this.MsMain.Text = "menuStrip1";
            this.MsMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MsMain_ItemClicked);
            // 
            // mnUseres
            // 
            this.mnUseres.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnManageUser});
            this.mnUseres.Name = "mnUseres";
            this.mnUseres.Size = new System.Drawing.Size(61, 28);
            this.mnUseres.Text = "عضویت";
            // 
            // mnManageUser
            // 
            this.mnManageUser.Name = "mnManageUser";
            this.mnManageUser.Size = new System.Drawing.Size(153, 28);
            this.mnManageUser.Text = "مدیریت اعضا ";
            this.mnManageUser.Click += new System.EventHandler(this.MnManageUser_Click);
            // 
            // mnReport
            // 
            this.mnReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnReportbargain,
            this.لیستمعاملاتبازToolStripMenuItem,
            this.لیستمعاملاتبستهشدهToolStripMenuItem,
            this.گزارشواریزبرداشتهاToolStripMenuItem,
            this.لیستمعاملاتحراجToolStripMenuItem,
            this.سیستمامتیازبندیمعرفیToolStripMenuItem});
            this.mnReport.Name = "mnReport";
            this.mnReport.Size = new System.Drawing.Size(133, 28);
            this.mnReport.Text = "مدیریت و گزارش ها";
            // 
            // mnReportbargain
            // 
            this.mnReportbargain.Name = "mnReportbargain";
            this.mnReportbargain.Size = new System.Drawing.Size(222, 28);
            this.mnReportbargain.Text = "گزارش کمسیون ها";
            this.mnReportbargain.Click += new System.EventHandler(this.MnReportbargain_Click);
            // 
            // لیستمعاملاتبازToolStripMenuItem
            // 
            this.لیستمعاملاتبازToolStripMenuItem.Name = "لیستمعاملاتبازToolStripMenuItem";
            this.لیستمعاملاتبازToolStripMenuItem.Size = new System.Drawing.Size(222, 28);
            this.لیستمعاملاتبازToolStripMenuItem.Text = "لیست معاملات باز";
            this.لیستمعاملاتبازToolStripMenuItem.Click += new System.EventHandler(this.لیستمعاملاتبازToolStripMenuItem_Click);
            // 
            // لیستمعاملاتبستهشدهToolStripMenuItem
            // 
            this.لیستمعاملاتبستهشدهToolStripMenuItem.Name = "لیستمعاملاتبستهشدهToolStripMenuItem";
            this.لیستمعاملاتبستهشدهToolStripMenuItem.Size = new System.Drawing.Size(222, 28);
            this.لیستمعاملاتبستهشدهToolStripMenuItem.Text = "لیست معاملات بسته شده ";
            this.لیستمعاملاتبستهشدهToolStripMenuItem.Click += new System.EventHandler(this.لیستمعاملاتبستهشدهToolStripMenuItem_Click);
            // 
            // گزارشواریزبرداشتهاToolStripMenuItem
            // 
            this.گزارشواریزبرداشتهاToolStripMenuItem.Name = "گزارشواریزبرداشتهاToolStripMenuItem";
            this.گزارشواریزبرداشتهاToolStripMenuItem.Size = new System.Drawing.Size(222, 28);
            this.گزارشواریزبرداشتهاToolStripMenuItem.Text = "گزارش واریز/برداشت ها";
            this.گزارشواریزبرداشتهاToolStripMenuItem.Click += new System.EventHandler(this.گزارشواریزبرداشتهاToolStripMenuItem_Click);
            // 
            // لیستمعاملاتحراجToolStripMenuItem
            // 
            this.لیستمعاملاتحراجToolStripMenuItem.Name = "لیستمعاملاتحراجToolStripMenuItem";
            this.لیستمعاملاتحراجToolStripMenuItem.Size = new System.Drawing.Size(222, 28);
            this.لیستمعاملاتحراجToolStripMenuItem.Text = "لیست معاملات حراج ";
            this.لیستمعاملاتحراجToolStripMenuItem.Click += new System.EventHandler(this.لیستمعاملاتحراجToolStripMenuItem_Click);
            // 
            // سیستمامتیازبندیمعرفیToolStripMenuItem
            // 
            this.سیستمامتیازبندیمعرفیToolStripMenuItem.Name = "سیستمامتیازبندیمعرفیToolStripMenuItem";
            this.سیستمامتیازبندیمعرفیToolStripMenuItem.Size = new System.Drawing.Size(222, 28);
            this.سیستمامتیازبندیمعرفیToolStripMenuItem.Text = "سیستم امتیازبندی معرفی";
            this.سیستمامتیازبندیمعرفیToolStripMenuItem.Click += new System.EventHandler(this.سیستمامتیازبندیمعرفیToolStripMenuItem_Click);
            // 
            // تنظیماتToolStripMenuItem
            // 
            this.تنظیماتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.تنظیمتلورانسToolStripMenuItem,
            this.ایجادنسخهپشتیبانازاطلاعاتToolStripMenuItem,
            this.ریستکلیاطلاعاتToolStripMenuItem});
            this.تنظیماتToolStripMenuItem.Name = "تنظیماتToolStripMenuItem";
            this.تنظیماتToolStripMenuItem.Size = new System.Drawing.Size(69, 28);
            this.تنظیماتToolStripMenuItem.Text = "تنظیمات";
            // 
            // تنظیمتلورانسToolStripMenuItem
            // 
            this.تنظیمتلورانسToolStripMenuItem.Name = "تنظیمتلورانسToolStripMenuItem";
            this.تنظیمتلورانسToolStripMenuItem.Size = new System.Drawing.Size(247, 28);
            this.تنظیمتلورانسToolStripMenuItem.Text = "تنظیم تلورانس و حراج";
            this.تنظیمتلورانسToolStripMenuItem.Click += new System.EventHandler(this.تنظیمتلورانسToolStripMenuItem_Click);
            // 
            // ایجادنسخهپشتیبانازاطلاعاتToolStripMenuItem
            // 
            this.ایجادنسخهپشتیبانازاطلاعاتToolStripMenuItem.Name = "ایجادنسخهپشتیبانازاطلاعاتToolStripMenuItem";
            this.ایجادنسخهپشتیبانازاطلاعاتToolStripMenuItem.Size = new System.Drawing.Size(247, 28);
            this.ایجادنسخهپشتیبانازاطلاعاتToolStripMenuItem.Text = "ایجاد نسخه پشتیبان از اطلاعات";
            this.ایجادنسخهپشتیبانازاطلاعاتToolStripMenuItem.Click += new System.EventHandler(this.ایجادنسخهپشتیبانازاطلاعاتToolStripMenuItem_Click);
            // 
            // mnStatus
            // 
            this.mnStatus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnStatusOnline,
            this.mnStatusOfline});
            this.mnStatus.ForeColor = System.Drawing.Color.Blue;
            this.mnStatus.Name = "mnStatus";
            this.mnStatus.Size = new System.Drawing.Size(92, 28);
            this.mnStatus.Text = "وضعیت ربات";
            this.mnStatus.Visible = false;
            // 
            // mnStatusOnline
            // 
            this.mnStatusOnline.ForeColor = System.Drawing.Color.Green;
            this.mnStatusOnline.Name = "mnStatusOnline";
            this.mnStatusOnline.Size = new System.Drawing.Size(114, 28);
            this.mnStatusOnline.Text = "آنلاین";
            this.mnStatusOnline.Click += new System.EventHandler(this.MnStatusOnline_Click);
            // 
            // mnStatusOfline
            // 
            this.mnStatusOfline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mnStatusOfline.Name = "mnStatusOfline";
            this.mnStatusOfline.Size = new System.Drawing.Size(114, 28);
            this.mnStatusOfline.Text = "آفلاین";
            // 
            // خروجازتلگرامToolStripMenuItem
            // 
            this.خروجازتلگرامToolStripMenuItem.Name = "خروجازتلگرامToolStripMenuItem";
            this.خروجازتلگرامToolStripMenuItem.Size = new System.Drawing.Size(95, 28);
            this.خروجازتلگرامToolStripMenuItem.Text = "خروج از ربات";
            this.خروجازتلگرامToolStripMenuItem.Click += new System.EventHandler(this.خروجازتلگرامToolStripMenuItem_Click);
            // 
            // StatusBarMain
            // 
            this.StatusBarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblStatusBot,
            this.toolStripStatusLabel2});
            this.StatusBarMain.Location = new System.Drawing.Point(0, 683);
            this.StatusBarMain.Name = "StatusBarMain";
            this.StatusBarMain.Size = new System.Drawing.Size(1081, 22);
            this.StatusBarMain.TabIndex = 1;
            this.StatusBarMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(82, 17);
            this.toolStripStatusLabel1.Text = "وضعیت ربات : ";
            // 
            // lblStatusBot
            // 
            this.lblStatusBot.ForeColor = System.Drawing.Color.Red;
            this.lblStatusBot.Name = "lblStatusBot";
            this.lblStatusBot.Size = new System.Drawing.Size(56, 17);
            this.lblStatusBot.Text = "آفلاین . . . ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(282, 17);
            this.toolStripStatusLabel2.Text = "طراحی شده توسط گروه نرم افزاری آکسان www.Acsan.ir";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Font = new System.Drawing.Font("IRANSans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdate.Location = new System.Drawing.Point(639, 99);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(215, 39);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "بروزرسانی مظنه پله ای و حراج";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // lalMazaneCurent
            // 
            this.lalMazaneCurent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lalMazaneCurent.Font = new System.Drawing.Font("IRANSans-Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lalMazaneCurent.ForeColor = System.Drawing.Color.ForestGreen;
            this.lalMazaneCurent.Location = new System.Drawing.Point(707, 56);
            this.lalMazaneCurent.Name = "lalMazaneCurent";
            this.lalMazaneCurent.Size = new System.Drawing.Size(362, 40);
            this.lalMazaneCurent.TabIndex = 4;
            this.lalMazaneCurent.Text = "مظنه فعلی : 0";
            // 
            // txtMazane
            // 
            this.txtMazane.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMazane.Font = new System.Drawing.Font("IRANSans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtMazane.Location = new System.Drawing.Point(860, 99);
            this.txtMazane.Name = "txtMazane";
            this.txtMazane.Size = new System.Drawing.Size(202, 39);
            this.txtMazane.TabIndex = 3;
            // 
            // txtTasvie
            // 
            this.txtTasvie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTasvie.Font = new System.Drawing.Font("IRANSans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTasvie.Location = new System.Drawing.Point(860, 191);
            this.txtTasvie.Name = "txtTasvie";
            this.txtTasvie.Size = new System.Drawing.Size(202, 39);
            this.txtTasvie.TabIndex = 3;
            // 
            // btnTasvie
            // 
            this.btnTasvie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTasvie.Font = new System.Drawing.Font("IRANSans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnTasvie.Location = new System.Drawing.Point(707, 191);
            this.btnTasvie.Name = "btnTasvie";
            this.btnTasvie.Size = new System.Drawing.Size(147, 39);
            this.btnTasvie.TabIndex = 5;
            this.btnTasvie.Text = "انجام تسویه هفتگی";
            this.btnTasvie.UseVisualStyleBackColor = true;
            this.btnTasvie.Click += new System.EventHandler(this.BtnTasvie_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("IRANSans-Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.MediumOrchid;
            this.label1.Location = new System.Drawing.Point(707, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 40);
            this.label1.TabIndex = 4;
            this.label1.Text = "تسویه هفتگی : ";
            // 
            // chkOffRobot
            // 
            this.chkOffRobot.AutoSize = true;
            this.chkOffRobot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkOffRobot.Location = new System.Drawing.Point(12, 56);
            this.chkOffRobot.Name = "chkOffRobot";
            this.chkOffRobot.Size = new System.Drawing.Size(115, 28);
            this.chkOffRobot.TabIndex = 6;
            this.chkOffRobot.Text = "اتاق خاموش شود";
            this.chkOffRobot.UseVisualStyleBackColor = true;
            this.chkOffRobot.CheckedChanged += new System.EventHandler(this.ChkOffRobot_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("IRANSans-Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Violet;
            this.label2.Location = new System.Drawing.Point(707, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(362, 40);
            this.label2.TabIndex = 4;
            this.label2.Text = "تسویه موقت : ";
            // 
            // txtTasvieMovaghat
            // 
            this.txtTasvieMovaghat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTasvieMovaghat.Font = new System.Drawing.Font("IRANSans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTasvieMovaghat.Location = new System.Drawing.Point(860, 306);
            this.txtTasvieMovaghat.Name = "txtTasvieMovaghat";
            this.txtTasvieMovaghat.Size = new System.Drawing.Size(202, 39);
            this.txtTasvieMovaghat.TabIndex = 3;
            // 
            // btnTasvieMovaghat
            // 
            this.btnTasvieMovaghat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTasvieMovaghat.Font = new System.Drawing.Font("IRANSans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnTasvieMovaghat.Location = new System.Drawing.Point(707, 306);
            this.btnTasvieMovaghat.Name = "btnTasvieMovaghat";
            this.btnTasvieMovaghat.Size = new System.Drawing.Size(147, 39);
            this.btnTasvieMovaghat.TabIndex = 5;
            this.btnTasvieMovaghat.Text = "انجام تسویه موقت";
            this.btnTasvieMovaghat.UseVisualStyleBackColor = true;
            this.btnTasvieMovaghat.Click += new System.EventHandler(this.BtnTasvieMovaghat_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("IRANSans-Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.DarkOrange;
            this.label3.Location = new System.Drawing.Point(707, 409);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(362, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "ارسال پیام در گروه : ";
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendMessage.Font = new System.Drawing.Font("IRANSans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSendMessage.Location = new System.Drawing.Point(860, 452);
            this.txtSendMessage.Multiline = true;
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(202, 169);
            this.txtSendMessage.TabIndex = 3;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMessage.Font = new System.Drawing.Font("IRANSans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSendMessage.Location = new System.Drawing.Point(707, 582);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(147, 39);
            this.btnSendMessage.TabIndex = 5;
            this.btnSendMessage.Text = "ارسال پیام";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.BtnSendMessage_Click);
            // 
            // chkPinMessage
            // 
            this.chkPinMessage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkPinMessage.AutoSize = true;
            this.chkPinMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.chkPinMessage.Location = new System.Drawing.Point(761, 548);
            this.chkPinMessage.Name = "chkPinMessage";
            this.chkPinMessage.Size = new System.Drawing.Size(93, 28);
            this.chkPinMessage.TabIndex = 6;
            this.chkPinMessage.Text = "پیام پین شود";
            this.chkPinMessage.UseVisualStyleBackColor = true;
            this.chkPinMessage.CheckedChanged += new System.EventHandler(this.ChkPinMessage_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipTitle = "ربات معامله گر";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ربات معامله گر";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon1_DoubleClick);
            // 
            // ریستکلیاطلاعاتToolStripMenuItem
            // 
            this.ریستکلیاطلاعاتToolStripMenuItem.Name = "ریستکلیاطلاعاتToolStripMenuItem";
            this.ریستکلیاطلاعاتToolStripMenuItem.Size = new System.Drawing.Size(247, 28);
            this.ریستکلیاطلاعاتToolStripMenuItem.Text = "ریست کلی اطلاعات";
            this.ریستکلیاطلاعاتToolStripMenuItem.Click += new System.EventHandler(this.ریستکلیاطلاعاتToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 705);
            this.Controls.Add(this.chkPinMessage);
            this.Controls.Add(this.chkOffRobot);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.btnTasvieMovaghat);
            this.Controls.Add(this.btnTasvie);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtSendMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTasvieMovaghat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTasvie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lalMazaneCurent);
            this.Controls.Add(this.txtMazane);
            this.Controls.Add(this.StatusBarMain);
            this.Controls.Add(this.MsMain);
            this.Font = new System.Drawing.Font("IRANSans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MsMain;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ربات معامله گر";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.MaximizedBoundsChanged += new System.EventHandler(this.Form1_MaximizedBoundsChanged);
            this.MinimumSizeChanged += new System.EventHandler(this.Form1_MinimumSizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MsMain.ResumeLayout(false);
            this.MsMain.PerformLayout();
            this.StatusBarMain.ResumeLayout(false);
            this.StatusBarMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MsMain;
        private System.Windows.Forms.ToolStripMenuItem mnUseres;
        private System.Windows.Forms.ToolStripMenuItem mnManageUser;
        private System.Windows.Forms.ToolStripMenuItem mnReport;
        private System.Windows.Forms.ToolStripMenuItem mnReportbargain;
        private System.Windows.Forms.StatusStrip StatusBarMain;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusBot;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem mnStatus;
        private System.Windows.Forms.ToolStripMenuItem mnStatusOnline;
        private System.Windows.Forms.ToolStripMenuItem mnStatusOfline;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lalMazaneCurent;
        private System.Windows.Forms.TextBox txtMazane;
        private System.Windows.Forms.TextBox txtTasvie;
        private System.Windows.Forms.Button btnTasvie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkOffRobot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTasvieMovaghat;
        private System.Windows.Forms.Button btnTasvieMovaghat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSendMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.CheckBox chkPinMessage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem تنظیماتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تنظیمتلورانسToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem لیستمعاملاتبازToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem لیستمعاملاتبستهشدهToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem خروجازتلگرامToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem گزارشواریزبرداشتهاToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem لیستمعاملاتحراجToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ایجادنسخهپشتیبانازاطلاعاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem سیستمامتیازبندیمعرفیToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem ریستکلیاطلاعاتToolStripMenuItem;
    }
}


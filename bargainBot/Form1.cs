using bargainBot.Models;
using bargainBot.Repository;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Export;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace bargainBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static ITelegramBotClient botClient;
        SettingsBot Settings_All;
        readonly utility.UtilityRepository Utility = new utility.UtilityRepository();
        SettingBotRepository settingBotRepository;
        private ReplyKeyboardMarkup mainKeyboardMarkup;
        string TotalChatId = "";

        //مبلغ کمسیون ها 
        readonly int ComisionPrice = 10000;
        readonly double ComisionPrice_Double = 10;

        bool _RobotIsOff = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime ExpierTime = new DateTime(2019, 10, 13, 1, 1, 1);
            if (DateTime.Now >= ExpierTime)
            {
                throw new Exception("Call Support");
                return;
            }


            try
            {
                settingBotRepository = new SettingBotRepository();
                Settings_All = settingBotRepository.GetSetting();
                lalMazaneCurent.Text = "مظنه فعلی : " + Settings_All.Mazane;
                mainKeyboardMarkup = new ReplyKeyboardMarkup();
                KeyboardButton[] row1 =
                {
                new KeyboardButton("👨🏻‍💻 وضعیت"), new KeyboardButton("📔 دفتر کل" ),
            };
                KeyboardButton[] row2 =
                {
                new KeyboardButton("📚 حسابداری"),new KeyboardButton("💡 راهنما")
            };
                KeyboardButton[] row3 =
               {
                new KeyboardButton("😊 اطلاعات شخصی"),new KeyboardButton("📃 درباره ما")
            };
                KeyboardButton[] row4 =
            {
                new KeyboardButton("📌 معاملات حراج"),new KeyboardButton("💡 راهنما سیستم امتیازبندی")
            };
                KeyboardButton[] row5 =
         {
                new KeyboardButton("👨🏻‍💻 ارتباط با پشتیبانی"),   new KeyboardButton("👨‍💼 ارتباط با مدیریت")
            };
                KeyboardButton[] row6 =
       {
                new KeyboardButton("🧾 ارسال فیش واریز / تسویه")
            };
                mainKeyboardMarkup.Keyboard = new KeyboardButton[][]
                {
                row1 , row2,row3,row4,row5,row6
                };
                MnStatusOnline_Click(null, null);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        private async void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            DateTime myTime_now = DateTime.Now;
            try
            {
                DateTime ExpierTime = new DateTime(2019, 10, 13, 1, 1, 1);
                if (DateTime.Now >= ExpierTime)
                {
                    throw new Exception("Call Support");
                    return;
                }


                SettingBotRepository botRepository = new SettingBotRepository();

                SettingsBot My_Settings = botRepository.GetSetting();





                if (e.Message.Chat.Type == ChatType.Private)//حسابداری
                {
                    try
                    {
                        using (UserBargainRepository userinfoRepository = new UserBargainRepository())
                        {

                            BargainSuccessRepository BargainSuccessRepository_2 = new BargainSuccessRepository();

                            UserPointRepository userPointRepository = new UserPointRepository();
                            UserBargain infoUser = userinfoRepository.GetUserWithUserIdTelegram(e.Message.From.Id);
                            if (e.Message.Text.ToLower().Contains("/start"))
                            {
                                if (!userinfoRepository.CheckExist(e.Message.From.Id))
                                {
                                    #region کاربر تایید نشده
                                    try
                                    {
                                        await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                    }
                                    catch { }
                                    await botClient.SendTextMessageAsync(e.Message.From.Id, Utility.MessageHelp(My_Settings), ParseMode.Html, true, false, 0);
                                    userinfoRepository.AddUser(new Models.UserBargain
                                    {
                                        Chatid = e.Message.Chat.Id.ToString(),
                                        PriceGarranty = 0,
                                        RegisterDate = myTime_now,
                                        Username = e.Message.From.Id.ToString(),
                                        Verify = false,
                                        Userid = e.Message.From.Id,

                                    });

                                    await userinfoRepository.Save();
                                    #endregion
                                    await botClient.SendTextMessageAsync(e.Message.From.Id, "لطفاً نام مسعار خود را وارد کنید ، این نام در معاملات اتاق نمایش داده میشود : ", ParseMode.Html, true, false, 0);

                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(e.Message.From.Id, $"🆗 ثبت نام شما قبلاً با کد کاربری {infoUser.Id} و نام مستعار {infoUser.AliasNames} انجام شده است ،اگر نام کاربری شما تایید نشده است  لطفاً جهت تایید به مدیر پیام دهید همچنین جهت اسفاده درست از اتاق راهنما را مطالعه فرمایید ", ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                                }

                            }
                            else if (e.Message.Text == "👨🏻‍💻 وضعیت")
                            {

                                StringBuilder builder = new StringBuilder();
                                builder.AppendLine("📃 وضعیت شما");
                                builder.AppendLine("");
                                builder.AppendLine("💵 موجودی نقدی : " + infoUser.PriceGarranty.ToString("N0") + "تومان");
                                builder.AppendLine("");
                                builder.AppendLine("🔶 موجودی ابشده : " + infoUser.Garranty.ToString() + "واحد");
                                builder.AppendLine("");
                                //  builder.AppendLine("🔶 موجودی ابشده : " + infoUser.Gold.ToString());
                                builder.AppendLine("");
                                try
                                {
                                    builder.AppendLine("🔵 معامله خرید باز :" + BargainSuccessRepository_2.Count_Buy(infoUser.Id) + "   میانگین خرید : " + BargainSuccessRepository_2.AverageBuy(infoUser.Id).ToString("N0"));
                                    builder.AppendLine("");
                                }
                                catch { }
                                try
                                {
                                    builder.AppendLine("🔴 معامله فروش باز : " + BargainSuccessRepository_2.Count_sel(infoUser.Id) + "   میانگین فروش : " + BargainSuccessRepository_2.AverageSell(infoUser.Id).ToString("N0"));
                                }
                                catch { }
                                builder.AppendLine("Ⓜ️ مظنه : " + My_Settings.Mazane + " Ⓜ️");
                                builder.AppendLine("");
                                try
                                {
                                    builder.AppendLine("مجموع امتیاز : " + (userPointRepository.CountPoint(infoUser.Id) * 10) + " امتیاز");
                                }
                                catch { }
                                await botClient.SendTextMessageAsync(e.Message.From.Id, builder.ToString(), ParseMode.Html, true, false, 0, mainKeyboardMarkup);




                            }
                            else if (e.Message.Text.ToLower().StartsWith("m") && infoUser.IsAdmin)
                            {
                                string[] mytext_arry = e.Message.Text.Split(':');
                                if (Utility.CheckNumberChar(mytext_arry[1]))
                                {
                                    txtMazane.Text = mytext_arry[1];
                                    BtnUpdate_Click(null, null);
                                    await botClient.SendTextMessageAsync(e.Message.From.Id, "مظنه جدید : " + mytext_arry[1], ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                                }

                            }
                            else if (e.Message.Text == "😊 اطلاعات شخصی")
                            {
                                StringBuilder builder = new StringBuilder();

                                builder.AppendLine("🏤اطلاعات شما در اتاق معاملات");
                                builder.AppendLine("");
                                builder.AppendLine("نام و نام خانوادگی : " + infoUser.Name + " " + infoUser.Family);
                                builder.AppendLine("");
                                builder.AppendLine("نام مستعار : " + infoUser.AliasNames);
                                builder.AppendLine("");
                                builder.AppendLine("کد کاربری : " + infoUser.Id);
                                builder.AppendLine("");
                                builder.AppendLine("شماره موبایل : " + infoUser.Mobile);
                                builder.AppendLine("");
                                builder.AppendLine("شماره کارت :" + infoUser.BankCard);
                                builder.AppendLine("");
                                builder.AppendLine("وضعیت کاربری : " + (infoUser.Verify ? "فعال" : "غیرفعال"));
                                builder.AppendLine("");
                                builder.AppendLine("مجموع امتیاز : " + (userPointRepository.CountPoint(infoUser.Id) * 10) + " امتیاز");
                                await botClient.SendTextMessageAsync(e.Message.From.Id, builder.ToString(), ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                            }
                            else if (e.Message.Text == "💡 راهنما")
                            {
                                await botClient.SendTextMessageAsync(e.Message.From.Id, Utility.MessageHelp(My_Settings), ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                            }
                            else if (e.Message.Text == "📃 درباره ما")
                            {
                                await botClient.SendTextMessageAsync(e.Message.From.Id, Utility.MessageAboutMe(My_Settings), ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                            }
                            else if (e.Message.Text == "📔 دفتر کل")
                            {
                                List<ViewModels.BargainSuccessReportViewModel> bargainSuccessViewModels_List = BargainSuccessRepository_2.GetClose_BargainSuccessReportViews(infoUser.Id);

                                if (bargainSuccessViewModels_List.Count > 0)
                                {
                                    StiReport report = new StiReport();
                                    report.Load("Report.mrt");
                                    report.RegBusinessObject("bargainSuccessViewModels_List", bargainSuccessViewModels_List);

                                    report.Compile();
                                    report.Render();

                                    report.ExportDocument(StiExportFormat.Pdf, $"doc//{infoUser.Userid}.pdf");
                                    using (Stream stream = System.IO.File.OpenRead($"doc//{infoUser.Userid}.pdf"))
                                    {
                                        DateTime sdate = myTime_now.AddMonths(-1);
                                        DateTime edate = myTime_now;
                                        await botClient.SendDocumentAsync(e.Message.From.Id,
               new InputOnlineFile(stream, $"{infoUser.Userid}.pdf"), "دفتر کل  : " + infoUser.AliasNames + "  از تاریخ : " + Utility.Convert2Shamsi(sdate) + "  الی " + Utility.Convert2Shamsi(edate) + " تعداد صفحات :  " + report.Pages.Count.ToString());
                                        await botClient.SendTextMessageAsync(e.Message.From.Id, "جهت دریافت دفتر کل فایل بالا را دانلود کنید", ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                                    }

                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(e.Message.From.Id, "معامله ای در یک ماه گذشته جهت تهیه دفتر کل وجود ندارد", ParseMode.Html, true, false, 0, mainKeyboardMarkup);


                                }

                            }
                            else if (e.Message.Text == "📌 معاملات حراج")
                            {
                                List<ViewModels.BargainSuccessReportViewModel> bargainSuccessViewModels_List = BargainSuccessRepository_2.GetOnSale_BargainSuccessReportViews(infoUser.Id);

                                if (bargainSuccessViewModels_List.Count > 0)
                                {
                                    StiReport report = new StiReport();
                                    report.Load("Report.mrt");
                                    report.RegBusinessObject("bargainSuccessViewModels_List", bargainSuccessViewModels_List);

                                    report.Compile();
                                    report.Render();

                                    report.ExportDocument(StiExportFormat.Pdf, $"doc//{infoUser.Userid}.pdf");
                                    using (Stream stream = System.IO.File.OpenRead($"doc//{infoUser.Userid}.pdf"))
                                    {
                                        DateTime sdate = myTime_now.AddMonths(-1);
                                        DateTime edate = myTime_now;
                                        await botClient.SendDocumentAsync(e.Message.From.Id,
               new InputOnlineFile(stream, $"{infoUser.Userid}.pdf"), "معاملات حراج  : " + infoUser.AliasNames + " تعداد صفحات :  " + report.Pages.Count.ToString());
                                        await botClient.SendTextMessageAsync(e.Message.From.Id, "لیست معاملات حراج در اتاق اصلی", ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                                    }

                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(e.Message.From.Id, "معامله ای برای حراج وجود ندارد", ParseMode.Html, true, false, 0, mainKeyboardMarkup);


                                }

                            }
                            else if (e.Message.Text == "📚 حسابداری")
                            {
                                using (TransactionRepository transactionRepository = new TransactionRepository())
                                {
                                    DateTime lm = myTime_now.AddMonths(-1);
                                    var tmp = transactionRepository.Search(lm, DateTime.Now, infoUser.Id);
                                    List<ViewModels.TransactionViewModel> TransactionViewModel_list = new List<ViewModels.TransactionViewModel>();
                                    if (tmp.Count > 0)
                                    {
                                        foreach (var item in tmp)
                                        {
                                            ViewModels.TransactionViewModel model_tr = new ViewModels.TransactionViewModel();
                                            model_tr.DateTime = Utility.Convert2Shamsi(item.DateTime) + " " + item.DateTime.ToShortTimeString();
                                            model_tr.Disc = item.Disc;
                                            model_tr.Price = item.Price;
                                            if (item.TransactionType_Id == 1)
                                            {
                                                model_tr.TypeName = "واریز";
                                                model_tr.mande = TransactionViewModel_list.Sum(x => x.Price) + model_tr.Price;
                                            }
                                            else
                                            {
                                                model_tr.TypeName = "برداشت";
                                                model_tr.mande = TransactionViewModel_list.Sum(x => x.Price) - model_tr.Price;

                                            }
                                            TransactionViewModel_list.Add(model_tr);
                                        }// end for

                                        StiReport report = new StiReport();
                                        report.Load("Report-trans.mrt");
                                        report.RegBusinessObject("TransactionViewModel", TransactionViewModel_list);
                                        // report.Variables.Add("mande", infoUser.PriceGarranty.ToString() + "تومان");
                                        report.Compile();
                                        report.Render();
                                        report.ExportDocument(StiExportFormat.ImageJpeg, $"doctrans//{infoUser.Userid}.jpg");
                                        using (Stream stream = System.IO.File.OpenRead($"doctrans//{infoUser.Userid}.jpg"))
                                        {
                                            DateTime sdate = myTime_now.AddMonths(-1);
                                            DateTime edate = myTime_now;
                                            await botClient.SendPhotoAsync(
                                               chatId: e.Message.From.Id,
                                               photo: stream, "'حسابداری  : " + infoUser.AliasNames + "  از تاریخ : " + Utility.Convert2Shamsi(sdate) + "  الی " + Utility.Convert2Shamsi(edate), ParseMode.Default, false, 0, mainKeyboardMarkup
                                            );
                                            await botClient.SendTextMessageAsync(e.Message.From.Id, "جهت دریافت تراکنش های یک ماه اخیر فایل بالا را دانلود کنید", ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                                        }
                                    }
                                    else
                                    {


                                        await botClient.SendTextMessageAsync(e.Message.From.Id, "تراکنش مالی در یک ماه گذشته جهت تهیه حسابداری وجود ندارد", ParseMode.Html, true, false, 0, mainKeyboardMarkup);


                                    }
                                }

                            }
                            else if (e.Message.Text == "👨🏻‍💻 ارتباط با پشتیبانی")
                            {
                                StringBuilder builder = new StringBuilder();
                                builder.AppendLine("");
                                builder.AppendLine("👥لطفا نظرات و انتقادات و مشکلات  خود را مطرح کنید تا در اولین فرصت بعد از بررسی نتیجه اعلام خواهد شد.");
                                builder.AppendLine("👨🏻‍💻 @ARTIMANAccountants");
                                builder.AppendLine("");
                                await botClient.SendTextMessageAsync(e.Message.From.Id, builder.ToString(), ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                            }
                            else if (e.Message.Text == "👨‍💼 ارتباط با مدیریت")
                            {
                                StringBuilder builder = new StringBuilder();
                                builder.AppendLine("");
                                builder.AppendLine("⚠️با توجه به ترافیک کاری مدیریت جهت دریافت سریع پاسخ لطفا قبل از ارتباط با مدیریت نقطه نظر های خود را با واحد پشتیبان مطرح نمایید. ");
                                builder.AppendLine("👨🏻‍💻 @ARTIMANAccountants");
                                builder.AppendLine("");
                                await botClient.SendTextMessageAsync(e.Message.From.Id, builder.ToString(), ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                            }
                            else if (e.Message.Text == "🧾 ارسال فیش واریز / تسویه")
                            {
                                StringBuilder builder = new StringBuilder();
                                builder.AppendLine("");
                                builder.AppendLine("🔸لطفا بعد از واریز وجه  از طریق  شماره  های اعلامی فیش واریزی خود را به آی دی پشتیبان ارسال نمایید");
                                builder.AppendLine("");
                                builder.AppendLine("بانک ملت به نام لیلا صفرزاده");
                                builder.AppendLine("شماره حساب :   8378443623");
                                builder.AppendLine("شماره کارت : 6104337629935907 ");
                                builder.AppendLine("کد شبا : IR210120010000008378443623 ");
                                builder.AppendLine("بیعانه صد گرم ۱/۵ میلیون تومان ");
                                builder.AppendLine("بیعانه یک کیلو ۱۵ میلیون تومان ");
                                builder.AppendLine("لطفا پس از واریز وجه فیش واریزی ارسال کنید برای حسابداری ");
                                builder.AppendLine("آیدی حسابدار ↙️ ");
                                builder.AppendLine("@ARTIMANAccountants");
                                builder.AppendLine("");
                                await botClient.SendTextMessageAsync(e.Message.From.Id, builder.ToString(), ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                            }
                            else if (e.Message.Text == "💡 راهنما سیستم امتیازبندی")
                            {
                                await botClient.SendTextMessageAsync(e.Message.From.Id, Utility.MessageHelpPoint(), ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                            }
                            //else if (infoUser.IsNowSuggestWait)
                            //{

                            //    if (Utility.CheckNumberChar(e.Message.Text.Trim()))
                            //    {
                            //        long SuggestUserid = long.Parse(e.Message.Text.Trim());

                            //        UserBargain userBargainSuggest = userinfoRepository.GetUserWithMyID(SuggestUserid);

                            //        if (userBargainSuggest.Id != infoUser.Id)
                            //        {

                            //            if (userBargainSuggest != null)
                            //            {
                            //                if (userPointRepository.Add(new UserPoint
                            //                {
                            //                    Date = DateTime.Now,
                            //                    IsVerify = false,
                            //                    UserBargain_Id_1 = infoUser.Id,
                            //                    UserBargain_Id_2 = SuggestUserid,
                            //                }))
                            //                {
                            //                    await userPointRepository.Save();
                            //                    infoUser.IsNowSuggestWait = false;
                            //                    await userinfoRepository.UpdateAsync(infoUser);
                            //                    await botClient.SendTextMessageAsync(e.Message.From.Id, "🤩 امتیاز مربوط به معرفی کاربر برای شما منظور شد و پس از تایید مدیر به امتیاز شما اضافه خواهد شد", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                            //                }
                            //                else
                            //                {
                            //                    await botClient.SendTextMessageAsync(e.Message.From.Id, "این کد کاربری قبلاً اعلام شده است ", ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                            //                }



                            //            }
                            //            else
                            //            {
                            //                await botClient.SendTextMessageAsync(e.Message.From.Id, "کاربری با این کد معرف پیدا نشد ", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                            //            }
                            //        }
                            //        else
                            //        {
                            //            await botClient.SendTextMessageAsync(e.Message.From.Id, "کاربری با این کد معرف پیدا نشد ", ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                            //        }
                            //    }
                            //    else
                            //    {
                            //        await botClient.SendTextMessageAsync(e.Message.From.Id, "کد معرف اشتباه است، دوباره تلاش کنید", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                            //    }
                            //}
                            else//تغییر اطلاعات کاربر 
                            {
                                try
                                {
                                    UserBargain myuser = userinfoRepository.GetUserWithUserIdTelegram(e.Message.From.Id);
                                    if (string.IsNullOrEmpty(myuser.AliasNames))
                                    {

                                        if (!userinfoRepository.ExistAliasName(e.Message.Text.Trim()))
                                        {
                                            myuser.AliasNames = e.Message.Text.Trim();
                                            await userinfoRepository.UpdateAsync(myuser);
                                            await botClient.SendTextMessageAsync(e.Message.From.Id, "نام خود را به فارسی وارد کنید : ", ParseMode.Html, true, false, 0);
                                        }
                                        else
                                        {
                                            await botClient.SendTextMessageAsync(e.Message.From.Id, "نام مستعار انتخابی تکراری است، لطفاً یک نام دیگر انتخاب کنید : ", ParseMode.Html, true, false, 0);

                                        }

                                    }
                                    else if (string.IsNullOrEmpty(myuser.Name))
                                    {
                                        myuser.Name = e.Message.Text;
                                        await userinfoRepository.UpdateAsync(myuser);
                                        await botClient.SendTextMessageAsync(e.Message.From.Id, "نام خانوادگی خود را به فارسی وارد کنید : ", ParseMode.Html, true, false, 0);

                                    }
                                    else if (string.IsNullOrEmpty(myuser.Family))
                                    {
                                        myuser.Family = e.Message.Text;
                                        await userinfoRepository.UpdateAsync(myuser);
                                        await botClient.SendTextMessageAsync(e.Message.From.Id, "شماره موبایل خود را وارد کنید : ", ParseMode.Html, true, false, 0);

                                    }

                                    else if (string.IsNullOrEmpty(myuser.Mobile))
                                    {
                                        myuser.Mobile = e.Message.Text;
                                        await userinfoRepository.UpdateAsync(myuser);
                                        await botClient.SendTextMessageAsync(e.Message.From.Id, "شماره کارت بانک خود را وارد کنید : ", ParseMode.Html, true, false, 0);
                                    }
                                    else if (string.IsNullOrEmpty(myuser.BankCard))
                                    {
                                        myuser.BankCard = e.Message.Text;
                                        await userinfoRepository.UpdateAsync(myuser);
                                        StringBuilder builder = new StringBuilder();
                                        builder.AppendLine("✅ مراحل ثبت نام شما با موفقیت انجام شد .");
                                        builder.AppendLine("");
                                        builder.AppendLine("جهت تکمیل عضویت لطفا وجه تضمین را به شماره کارت ذیل واریز  و تصویر فیش آن را به آی دی پشتیبانی ارسال فرمایید");
                                        builder.AppendLine(" ");
                                        builder.AppendLine("");
                                        builder.AppendLine("-------------");
                                        builder.AppendLine("");
                                        builder.AppendLine("🏤اطلاعات شما در اتاق معاملات");
                                        builder.AppendLine("");
                                        builder.AppendLine("نام و نام خانوادگی : " + infoUser.Name + " " + infoUser.Family);
                                        builder.AppendLine("");
                                        builder.AppendLine("کد کاربری : " + infoUser.Id);
                                        builder.AppendLine("");
                                        builder.AppendLine("شماره موبایل : " + infoUser.Mobile);
                                        builder.AppendLine("");
                                        builder.AppendLine("شماره کارت :" + infoUser.BankCard);
                                        builder.AppendLine("");
                                        builder.AppendLine("وضعیت کاربری : " + (infoUser.Verify ? "فعال" : "غیرفعال"));
                                        builder.AppendLine("");

                                        await botClient.SendTextMessageAsync(e.Message.From.Id, builder.ToString(), ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                                        await botClient.SendTextMessageAsync(e.Message.From.Id, "در صورتی که معرف دارید کد کاربری آن را وارد نمایید درغیر این صورت منتظر تایید مدیر بمانید ", ParseMode.Html, true, false, 0, mainKeyboardMarkup);



                                    }
                                    else if (!userPointRepository.ExistVerifyPoint(myuser.Id) && myuser.IsNowSuggestWait == false)
                                    {

                                        if (Utility.CheckNumberChar(Utility.ToENNumber(e.Message.Text.Trim())))
                                        {
                                            long SuggestUserid = long.Parse(Utility.ToENNumber(e.Message.Text.Trim()));

                                            UserBargain userBargainSuggest = userinfoRepository.GetUserWithMyID(SuggestUserid);

                                            if (userBargainSuggest != null)
                                            {
                                                if (userBargainSuggest.Id != myuser.Id)
                                                {
                                                    if (SuggestUserid != myuser.Id)
                                                    {
                                                        userPointRepository.Add(new UserPoint
                                                        {
                                                            Date = myTime_now,
                                                            IsVerify = false,
                                                            UserBargain_Id_1 = SuggestUserid,
                                                            UserBargain_Id_2 = myuser.Id,
                                                        });

                                                        myuser.IsNowSuggestWait = true;
                                                        await userinfoRepository.UpdateAsync(myuser);


                                                        await userPointRepository.Save();
                                                        await botClient.SendTextMessageAsync(e.Message.From.Id, "کد کاربر با موفقیت ثبت شد ", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                                                        try
                                                        {
                                                            await botClient.SendTextMessageAsync(userBargainSuggest.Chatid, "🤩 امتیاز مربوط به معرفی کاربر برای شما منظور شد و پس از تایید مدیر به امتیاز شما اضافه خواهد شد", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                                                        }
                                                        catch
                                                        {
                                                            await botClient.SendTextMessageAsync(userBargainSuggest.Userid, "🤩 امتیاز مربوط به معرفی کاربر برای شما منظور شد و پس از تایید مدیر به امتیاز شما اضافه خواهد شد", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        await botClient.SendTextMessageAsync(e.Message.From.Id, "❌" + "امکان ثبت امتیاز برای خودتان وجود ندارد ", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                                                    }
                                                }
                                                else
                                                {
                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, "❌" + "امکان ثبت امتیاز برای خودتان وجود ندارد ", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                                                }
                                            }
                                            else
                                            {
                                                await botClient.SendTextMessageAsync(e.Message.From.Id, "❌" + "کاربری با این کد معرف پیدا نشد ", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                                            }

                                        }
                                        else
                                        {
                                            await botClient.SendTextMessageAsync(e.Message.From.Id, "❌" + "کد معرف اشتباه است، دوباره تلاش کنید", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                                        }
                                    }
                                }
                                catch
                                {

                                }
                            }

                        }
                    }
                    catch
                    {
                        await botClient.SendTextMessageAsync(e.Message.From.Id, "⚙️" + "سیستم مشغول میباشد ، لطفاً چنددقیقه دیگر مجدد تلاش کنید ، از صبرشما سپاسگزاریم", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                    }




                }
                else //مدیریت گروه
                {
                    if (_RobotIsOff)
                    {
                        try
                        {
                            await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                        }
                        catch { }
                        try
                        {
                            await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "در حال حاضر اتاق معاملات غیرفعال می باشد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                        }
                        catch { }
                        return;
                    }
                    using (UserBargainRepository user = new UserBargainRepository())
                    {
                        using (SellBuyRepository sellBuyRepository = new SellBuyRepository())
                        {

                            BargainSuccessRepository BargainSuccessRepository = new BargainSuccessRepository();

                            using (ComisonRepository comisonRepository = new ComisonRepository())
                            {

                                try
                                {
                                    if (e.Message.Type != MessageType.Text)
                                    {
                                        await botClient.DeleteMessageAsync(chatId: e.Message.Chat.Id, e.Message.MessageId);
                                        return;

                                    }
                                }
                                catch { }
                                if (e.Message.Text != null)
                                {
                                    //try
                                    //{
                                    //    if (e.Message.Text.Length <= 3 && e.Message.ReplyToMessage == null)
                                    //    {
                                    //        try
                                    //        {
                                    //            await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                    //        }
                                    //        catch { }
                                    //        return;
                                    //    }
                                    //}
                                    //catch { }

                                    if (e.Message.Text == "م")
                                    {
                                        //اعلام مظنه
                                        try
                                        {
                                            await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                        }
                                        catch { }

                                        await botClient.SendTextMessageAsync(chatId: e.Message.Chat.Id, $"Ⓜ️ مظنه : {Settings_All.Mazane.ToString()} Ⓜ️", ParseMode.Default, false, true);

                                        return;

                                    }

                                    if (!user.CheckUserVerify(e.Message.From.Id))
                                    {
                                        #region کاربر تایید نشده
                                        try
                                        {
                                            await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                        }
                                        catch { }
                                        await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "ابتدا نام کاربری خود را توسط مدیر تایید کنید", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                        return;
                                        #endregion
                                    }
                                    else
                                    {
                                        if (e.Message.ReplyToMessage != null)
                                        {



                                            if (e.Message.Text.Length >= 3)
                                            {
                                                try
                                                {
                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                }
                                                catch { }
                                                try
                                                {
                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "لطفاً جهت روش صحیح خرید/فروش به راهنما مراجعه فرمایید", ParseMode.Default, false, true, 0, mainKeyboardMarkup);

                                                }
                                                catch { }
                                                return;
                                            }

                                            SellBuy orginalLafz = sellBuyRepository.GetLafzByMessageId(e.Message.ReplyToMessage.MessageId);
                                            if (orginalLafz == null)
                                            {
                                                try
                                                {
                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                }
                                                catch { }
                                                //try
                                                //{
                                                //    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + " لفظ انتخابی شما قبلاً منقضی شده است . امکان خرید/فروش این لفظ وجود ندارد .", ParseMode.Default, false, true, 0);

                                                //}
                                                //catch { }
                                                //try
                                                //{
                                                //    if (!e.Message.ReplyToMessage.Text.Trim().EndsWith("*") && !e.Message.ReplyToMessage.Text.Trim().StartsWith("🛒"))
                                                //    {
                                                //        StringBuilder ExpierText = new StringBuilder();
                                                //        ExpierText.AppendLine(e.Message.ReplyToMessage.Text);
                                                //        ExpierText.AppendLine("🗑*منقضی شد*");
                                                //        //string ExpierText = e.Message.ReplyToMessage.Text+ + "*منقضی شد*";
                                                //        await botClient.EditMessageTextAsync(TotalChatId, e.Message.ReplyToMessage.MessageId, ExpierText.ToString().Trim(), ParseMode.Default, true);
                                                //    }

                                                //}
                                                //catch { }
                                                return;
                                            }

                                            TimeSpan timeSpan2 = DateTime.Now - orginalLafz.DateTime;

                                            if (timeSpan2.Minutes >= 1)
                                            {
                                                try
                                                {
                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                }
                                                catch { }
                                                try
                                                {
                                                    //    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "لطفاً جهت استفاده صحیح از اتاق معاملات به راهنما ربات مراجعه فرمایید . تمامی لفظ ها بعد از 1 دقیقه منقضی می شود", ParseMode.Default, false, true, 0);

                                                    try
                                                    {
                                                        if (!e.Message.ReplyToMessage.Text.Trim().EndsWith("*"))
                                                        {
                                                            StringBuilder ExpierText = new StringBuilder();
                                                            ExpierText.AppendLine(e.Message.ReplyToMessage.Text);
                                                            ExpierText.AppendLine("🗑*منقضی شد*");
                                                            //string ExpierText = e.Message.ReplyToMessage.Text+ + "*منقضی شد*";
                                                            await botClient.EditMessageTextAsync(TotalChatId, e.Message.ReplyToMessage.MessageId, ExpierText.ToString().Trim(), ParseMode.Default, true);
                                                        }
                                                    }
                                                    catch { }
                                                }
                                                catch { }
                                                return;
                                            }

                                            if (BargainSuccessRepository.CountSellId(orginalLafz.Id, orginalLafz.UserBargain_Id) >= orginalLafz.Count)
                                            {
                                                try
                                                {
                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                }
                                                catch { }
                                                await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                return;
                                            }




                                            UserBargain CurentUserRequest = user.GetUser(e.Message.From.Id);

                                            if (orginalLafz.UserBargain_Id == CurentUserRequest.Id && (System.Text.Encoding.UTF8.GetString(System.Text.Encoding.UTF8.GetBytes(e.Message.Text)) != System.Text.Encoding.UTF8.GetString(System.Text.Encoding.UTF8.GetBytes("ن"))))
                                            {
                                                try
                                                {
                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                }
                                                catch { }
                                                await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید و فروش لفظ خود را ندارید", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                return;
                                            }



                                            #region قطعی شدن و بسته شدن خرید یا فروش
                                            if (!Utility.CheckNumberChar(Utility.ToENNumber(e.Message.Text.Trim()).ToString()))
                                            {
                                                TimeSpan timeSpan = DateTime.Now - orginalLafz.DateTime;
                                                if (timeSpan.Minutes < 2)
                                                {
                                                    if ((System.Text.Encoding.UTF8.GetString(System.Text.Encoding.UTF8.GetBytes(e.Message.Text)) == System.Text.Encoding.UTF8.GetString(System.Text.Encoding.UTF8.GetBytes("ن"))) && (orginalLafz.UserBargain.Userid == CurentUserRequest.Userid) && !BargainSuccessRepository.Exist_Success(orginalLafz.Id))
                                                    {
                                                        try
                                                        {
                                                            await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                        }
                                                        catch { }

                                                        if (sellBuyRepository.Delete(orginalLafz.Id))
                                                        {

                                                            //await botClient.SendTextMessageAsync(chatId: e.Message.Chat.Id, "❌ کاربر لفظ را لغو نموده است", ParseMode.Default, false, true, int.Parse(orginalLafz.MessageId.ToString()));
                                                            try
                                                            {
                                                                await botClient.DeleteMessageAsync(e.Message.Chat.Id, int.Parse(orginalLafz.MessageId.ToString()));
                                                                await sellBuyRepository.Save();
                                                            }
                                                            catch
                                                            {
                                                                await botClient.SendTextMessageAsync(chatId: e.Message.Chat.Id, "❌ کاربر لفظ را لغو نموده است", ParseMode.Default, false, true, int.Parse(orginalLafz.MessageId.ToString()));
                                                                await sellBuyRepository.Save();

                                                            }
                                                            return;
                                                        }
                                                        else
                                                        {
                                                            await botClient.SendTextMessageAsync(CurentUserRequest.Userid, "⚠️ امکان لغو لفظ وجود ندارد", ParseMode.Default, false, true, int.Parse(orginalLafz.MessageId.ToString()), mainKeyboardMarkup);
                                                            return;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        //فرمت اشتباه است
                                                        try
                                                        {
                                                            await botClient.SendTextMessageAsync(e.Message.From.Id, "⚠️ فرمت وارد شده اشتباه است", ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                                                        }
                                                        catch { }
                                                        try
                                                        {
                                                            await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                        }
                                                        catch { }
                                                        return;
                                                        #endregion
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                int RequestUserNumber = -1;
                                                try
                                                {
                                                    RequestUserNumber = int.Parse(Utility.ToENNumber(e.Message.Text.Trim()));
                                                }
                                                catch
                                                {
                                                    try
                                                    {
                                                        await botClient.SendTextMessageAsync(e.Message.From.Id, "⚠️ فرمت وارد شده اشتباه است", ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                                                    }
                                                    catch { }
                                                    try
                                                    {
                                                        await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                    }
                                                    catch { }
                                                    return;
                                                }
                                                //درخواست درست




                                                if (orginalLafz != null)
                                                {
                                                    if (RequestUserNumber > orginalLafz.Count)
                                                    {
                                                        try
                                                        {
                                                            await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                        }
                                                        catch { }
                                                        await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                        return;
                                                    }




                                                    TimeSpan timeSpan = DateTime.Now - orginalLafz.DateTime;
                                                    if (timeSpan.Minutes < 1)
                                                    {

                                                        //چک کردن تعداد سهم 
                                                        if (RequestUserNumber > CurentUserRequest.Garranty)
                                                        {
                                                            try
                                                            {
                                                                await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                            }
                                                            catch { }
                                                            await botClient.SendTextMessageAsync(CurentUserRequest.Userid, " ⚠️ " + "مقدار اعتبار شما برای انجام این معامله کافی نیست", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                            return;
                                                        }
                                                        //خرید یا فروش اینجا انجام میشه : معامله قطعی میشه 
                                                        StringBuilder strMsg = new StringBuilder();
                                                        BargainSuccess bargainSuccess = new BargainSuccess();
                                                        BargainSuccess bargainSuccess_2 = new BargainSuccess();

                                                        bargainSuccess_2.count = bargainSuccess.count = 1;
                                                        bargainSuccess_2.DateTime = bargainSuccess.DateTime = myTime_now;

                                                        bargainSuccess_2.SellBuy_Id = bargainSuccess.SellBuy_Id = orginalLafz.Id;
                                                        bargainSuccess_2.NowMazane = bargainSuccess.NowMazane = int.Parse(My_Settings.Mazane.ToString());

                                                        //  bargainSuccess.FirstUserBargain_1 = orginalLafz.UserBargain;
                                                        //    bargainSuccess.SecendUserBargain_2 = CurentUserRequest;
                                                        bargainSuccess.UserBargain_Id_1 = orginalLafz.UserBargain.Id;
                                                        bargainSuccess.UserBargain_Id_2 = CurentUserRequest.Id;

                                                        //   bargainSuccess_2.FirstUserBargain_1 = CurentUserRequest;
                                                        //  bargainSuccess_2.SecendUserBargain_2 = orginalLafz.UserBargain;
                                                        bargainSuccess_2.UserBargain_Id_1 = CurentUserRequest.Id;
                                                        bargainSuccess_2.UserBargain_Id_2 = orginalLafz.UserBargain.Id;





                                                        if (orginalLafz.SellBuyType_Id == 1)
                                                        {
                                                            #region لفظ اصلی فروش

                                                            //    int opencount = BargainSuccessRepository.Count_sel(CurentUserRequest.Id);
                                                            //if (RequestUserNumber > opencount && opencount > 0)
                                                            //{
                                                            //    try
                                                            //    {
                                                            //        await botClient.SendTextMessageAsync(e.Message.From.Id, $" ⛔️ لطفاً ابتدا {opencount} معاملات باز خود را تعیین تکلیف نمائید", ParseMode.Html, true, false);
                                                            //    }
                                                            //    catch { }
                                                            //    try
                                                            //    {
                                                            //        await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                            //    }
                                                            //    catch { }
                                                            //    return;
                                                            //}

                                                            if ((orginalLafz.Remain - RequestUserNumber) < 0)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }
                                                            if (orginalLafz.Remain <= 0)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }

                                                            if (BargainSuccessRepository.Count_sel(1, orginalLafz.Id) > orginalLafz.Count)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }
                                                            if (BargainSuccessRepository.Count_sel(1, orginalLafz.Id) + RequestUserNumber > orginalLafz.Count)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }


                                                            if (BargainSuccessRepository.Count_sel_Open_WithSellId(orginalLafz.Id) >= orginalLafz.Count)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }
                                                            if (BargainSuccessRepository.Count_sel_Open_WithSellId(orginalLafz.Id) + RequestUserNumber > orginalLafz.Count)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }

                                                            if (BargainSuccessRepository.Count_Buy_Open_WithSellId(orginalLafz.Id) >= orginalLafz.Count)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }
                                                            if (BargainSuccessRepository.Count_Buy_Open_WithSellId(orginalLafz.Id) + RequestUserNumber > orginalLafz.Count)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }


                                                            if (BargainSuccessRepository.Count_Buy(CurentUserRequest.Id) >= CurentUserRequest.Garranty)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                await botClient.SendTextMessageAsync(CurentUserRequest.Userid, " ⚠️ " + "مقدار اعتبار شما برای انجام این معامله کافی نیست", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                return;
                                                            }
                                                            if (BargainSuccessRepository.Count_Buy(CurentUserRequest.Id) + RequestUserNumber > CurentUserRequest.Garranty)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                await botClient.SendTextMessageAsync(CurentUserRequest.Userid, " ⚠️ " + "مقدار اعتبار شما برای انجام این معامله کافی نیست", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                return;
                                                            }


                                                            if (BargainSuccessRepository.Count_sel(orginalLafz.UserBargain.Id) >= orginalLafz.UserBargain.Garranty)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(orginalLafz.UserBargain.Userid, " ⚠️ " + "مقدار اعتبار شما برای انجام این معامله کافی نیست", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }
                                                            if (BargainSuccessRepository.Count_sel(orginalLafz.UserBargain.Id) + RequestUserNumber > orginalLafz.UserBargain.Garranty)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(orginalLafz.UserBargain.Userid, " ⚠️ " + "مقدار اعتبار شما برای انجام این معامله کافی نیست", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }



                                                            //لفظ اصلی فروش بوده
                                                            strMsg.AppendLine($"🔵  خریدار : {CurentUserRequest.AliasNames}");
                                                            strMsg.AppendLine($"🔴  فروشنده : {orginalLafz.UserBargain.AliasNames}");
                                                            strMsg.AppendLine("🛒" + $"تعداد: {RequestUserNumber} قیمت: {(orginalLafz.Price * 1000).ToString("N0")}");
                                                            strMsg.AppendLine($"✅ تسویه شنبه ای :  {  Utility.Convert2Shamsi(myTime_now)} ✅");
                                                            strMsg.AppendLine("⏱" + $"زمان ثبت : {Utility.Convert2Shamsi(bargainSuccess.DateTime)} {bargainSuccess.DateTime.ToShortTimeString()}");
                                                            bargainSuccess_2.Tasvie = bargainSuccess.Tasvie = myTime_now;

                                                            bargainSuccess.SellBuyType_Id = 1;
                                                            bargainSuccess_2.SellBuyType_Id = 2;

                                                            //  decimal Sood_1_buy = BargainSuccessRepository.Average_open_buy(bargainSuccess.UserBargain_Id_1.Value);

                                                            List<BargainSuccess> success_org_list = BargainSuccessRepository.Update_finishBasket_Buy(orginalLafz.Price, orginalLafz.UserBargain_Id, RequestUserNumber);
                                                            BargainSuccessRepository.SaveNotAsync();
                                                            int MyResult_org_buy_count = RequestUserNumber - success_org_list.Count;
                                                            if (success_org_list.Count <= 0)
                                                            {
                                                                for (int i = 1; i <= MyResult_org_buy_count; i++)
                                                                {
                                                                    BargainSuccessRepository.Add(bargainSuccess);
                                                                    BargainSuccessRepository.SaveNotAsync();

                                                                }
                                                            }
                                                            StringBuilder sb_sood_buy = new StringBuilder();
                                                            StringBuilder sb_sood_sell = new StringBuilder();

                                                            if (success_org_list.Count > 0)
                                                            {

                                                                foreach (var item in success_org_list)
                                                                {
                                                                    double val_sod_1 = 0;
                                                                    val_sod_1 = orginalLafz.Price - item.SellBuy.Price;
                                                                    val_sod_1 *= 23;
                                                                    sb_sood_buy.AppendLine("🤝 " + $"معامله {item.SellBuy.Price.ToString("N0")} شما در عدد {orginalLafz.Price.ToString("N0")}  با موفقیت به پایان رسید");
                                                                    DateTime H1315 = new DateTime(item.DateTime.Year, item.DateTime.Month, item.DateTime.Day, 13, 15, 00);
                                                                    //if (H1315 >= item.DateTime && H1315 <= DateTime.Now)
                                                                    val_sod_1 -= ComisionPrice_Double;

                                                                    comisonRepository.Add(new Consion
                                                                    {
                                                                        BargainSuccess_Id = item.Id,
                                                                        Price = ComisionPrice,
                                                                        DateTime = DateTime.Now

                                                                    });
                                                                    await comisonRepository.Save();

                                                                    val_sod_1 *= 1000;

                                                                    if (val_sod_1 > 0)
                                                                    {
                                                                        sb_sood_buy.AppendLine("🙋🏻‍♂️" + "سود شما از این معامله با احتساب کارمزد: " + val_sod_1.ToString("N0"));

                                                                    }
                                                                    else
                                                                    {
                                                                        sb_sood_buy.AppendLine("🤦🏻‍♂️ " + "ضرر شما از این معامله با احتساب کارمزد: " + val_sod_1.ToString("N0"));

                                                                    }
                                                                    item.FirstUserBargain_1.PriceGarranty += long.Parse(val_sod_1.ToString());
                                                                    BargainSuccessRepository.SaveNotAsync();
                                                                    user.SaveNotAsync();
                                                                    item.Sod = int.Parse(val_sod_1.ToString());
                                                                    BargainSuccessRepository.SaveNotAsync();

                                                                }

                                                            }



                                                            //طرف دوم 

                                                            // decimal Sood_2_sell = BargainSuccessRepository.Average_open_Sell(bargainSuccess_2.UserBargain_Id_1.Value);

                                                            List<BargainSuccess> success_2_list = BargainSuccessRepository.Update_finishBasket_sel(orginalLafz.Price, CurentUserRequest.Id, RequestUserNumber);
                                                            BargainSuccessRepository.SaveNotAsync();


                                                            int MyResult_2_sel_count = RequestUserNumber - success_2_list.Count;
                                                            if (success_2_list.Count <= 0)
                                                            {
                                                                for (int i = 1; i <= MyResult_2_sel_count; i++)
                                                                {
                                                                    BargainSuccessRepository.Add(bargainSuccess_2);
                                                                    BargainSuccessRepository.SaveNotAsync();


                                                                }
                                                            }


                                                            if (success_2_list.Count > 0)
                                                            {
                                                                foreach (var item in success_2_list)
                                                                {
                                                                    double val_sod_2 = 0;


                                                                    val_sod_2 = item.SellBuy.Price - orginalLafz.Price;


                                                                    val_sod_2 *= 23;
                                                                    sb_sood_sell.AppendLine("🤝 " + $"معامله {item.SellBuy.Price.ToString("N0")} شما عدد {orginalLafz.Price.ToString("N0")} با موفقیت به پایان رسید");



                                                                    DateTime H1315 = new DateTime(item.DateTime.Year, item.DateTime.Month, item.DateTime.Day, 13, 15, 00);

                                                                    //if (H1315 >= item.DateTime && H1315 <= myTime_now)
                                                                    //{
                                                                    //بعد از 1:15
                                                                    val_sod_2 -= ComisionPrice_Double;


                                                                    //}
                                                                    //else
                                                                    //{
                                                                    //    ComisionPrice = 10000;
                                                                    //    val_sod_2 -= 10;
                                                                    //}

                                                                    comisonRepository.Add(new Consion
                                                                    {
                                                                        BargainSuccess_Id = item.Id,
                                                                        Price = ComisionPrice,
                                                                        DateTime = myTime_now

                                                                    });
                                                                    await comisonRepository.Save();
                                                                    val_sod_2 *= 1000;

                                                                    if (val_sod_2 > 0)
                                                                    {
                                                                        sb_sood_sell.AppendLine("🙋🏻‍♂️" + "سود شما از این معامله با احتساب کارمزد: " + val_sod_2.ToString("N0"));

                                                                    }
                                                                    else
                                                                    {
                                                                        sb_sood_sell.AppendLine("🤦🏻‍♂️ " + "ضرر شما از این معامله با احتساب کارمزد: " + val_sod_2.ToString("N0"));

                                                                    }
                                                                    item.FirstUserBargain_1.PriceGarranty += long.Parse(val_sod_2.ToString());
                                                                    BargainSuccessRepository.SaveNotAsync();
                                                                    user.SaveNotAsync();
                                                                    item.Sod = int.Parse(val_sod_2.ToString());
                                                                    BargainSuccessRepository.SaveNotAsync();
                                                                }


                                                            }

                                                            //await user.Save();
                                                            //   await BargainSuccessRepository.Save();
                                                            //  await comisonRepository.Save();


                                                            #region بعد از بسته شدن دوباره میانگین را بهش اعلام کنه 
                                                            bargainSuccess.FirstUserBargain_1 = user.GetUserWithMyID(orginalLafz.UserBargain.Id);
                                                            bargainSuccess.SecendUserBargain_2 = user.GetUserWithMyID(CurentUserRequest.Id);


                                                            bargainSuccess_2.FirstUserBargain_1 = user.GetUserWithMyID(CurentUserRequest.Id);
                                                            bargainSuccess_2.SecendUserBargain_2 = user.GetUserWithMyID(orginalLafz.UserBargain.Id);



                                                            StringBuilder callmarginMSG_1 = new StringBuilder();
                                                            if (success_org_list.Count > 0)
                                                            {
                                                                callmarginMSG_1.AppendLine(sb_sood_buy.ToString());
                                                            }
                                                            if (MyResult_org_buy_count > 0)
                                                            {
                                                                callmarginMSG_1.AppendLine("🔴" + $" {RequestUserNumber} پله فروش   " + (orginalLafz.Price * 1000).ToString("N0") + " قطعی شد");
                                                                callmarginMSG_1.AppendLine("");
                                                                callmarginMSG_1.AppendLine("📣این معامله در صورت عدم بسته شدن توسط شما ، جهت حفظ حد سود و ضرر از ۹۰٪ مبلغ بیعانه حجم این معامله ،به حراج گذاشته خواهد شد که در مظنه های زیر صورت میپذیرد. ");
                                                                callmarginMSG_1.AppendLine($"📉 + {My_Settings.Mazane + My_Settings.OnSaleTelorans}");
                                                                callmarginMSG_1.AppendLine("");
                                                                callmarginMSG_1.AppendLine($"📈 - {My_Settings.Mazane - My_Settings.OnSaleTelorans}");
                                                                callmarginMSG_1.AppendLine("");




                                                            }

                                                            try
                                                            {

                                                                callmarginMSG_1.AppendLine("🔵 معامله خرید باز :" + BargainSuccessRepository.Count_Buy(orginalLafz.UserBargain.Id));

                                                            }
                                                            catch { }
                                                            try
                                                            {
                                                                callmarginMSG_1.AppendLine("  میانگین خرید : " + BargainSuccessRepository.AverageBuy(orginalLafz.UserBargain.Id).ToString("N0"));
                                                            }
                                                            catch { }
                                                            callmarginMSG_1.AppendLine("");

                                                            try
                                                            {
                                                                callmarginMSG_1.AppendLine("🔴 معامله فروش باز : " + BargainSuccessRepository.Count_sel(orginalLafz.UserBargain.Id));
                                                            }
                                                            catch { }
                                                            try
                                                            {
                                                                callmarginMSG_1.AppendLine("میانگین فروش : " + BargainSuccessRepository.AverageSell(orginalLafz.UserBargain.Id).ToString("N0"));
                                                            }
                                                            catch { }

                                                            UserBargainRepository bargainRepository_Sec_2 = new UserBargainRepository();

                                                            UserBargain userBargain_Balance_2 = bargainRepository_Sec_2.GetUserWithMyID(orginalLafz.UserBargain.Id);

                                                            callmarginMSG_1.AppendLine("💵 " + "موجودی  آبشده  : " + userBargain_Balance_2.Garranty);
                                                            callmarginMSG_1.AppendLine("");
                                                            callmarginMSG_1.AppendLine($"💵 موجودی نقدی : {userBargain_Balance_2.PriceGarranty.ToString("N0")} تومان");

                                                            await botClient.SendTextMessageAsync(bargainSuccess.FirstUserBargain_1.Userid, callmarginMSG_1.ToString(), ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                                                            StringBuilder callmarginMSG_2 = new StringBuilder();
                                                            if (success_2_list.Count > 0)
                                                            {
                                                                callmarginMSG_2.AppendLine(sb_sood_sell.ToString());
                                                            }
                                                            if (MyResult_2_sel_count > 0)
                                                            {
                                                                callmarginMSG_2.AppendLine("🔵" + $" {RequestUserNumber} پله خرید   " + (orginalLafz.Price * 1000).ToString("N0") + " قطعی شد");
                                                                callmarginMSG_2.AppendLine("");
                                                                callmarginMSG_2.AppendLine("📣این معامله در صورت عدم بسته شدن توسط شما ، جهت حفظ حد سود و ضرر از ۹۰٪ مبلغ بیعانه حجم این معامله ،به حراج گذاشته خواهد شد که در مظنه های زیر صورت میپذیرد. ");
                                                                callmarginMSG_2.AppendLine($"📉 + {My_Settings.Mazane + My_Settings.OnSaleTelorans}");
                                                                callmarginMSG_2.AppendLine("");
                                                                callmarginMSG_2.AppendLine($"📈 - {My_Settings.Mazane - My_Settings.OnSaleTelorans}");
                                                                callmarginMSG_2.AppendLine("");

                                                            }
                                                            try
                                                            {
                                                                callmarginMSG_2.AppendLine("🔵 معامله خرید باز :" + BargainSuccessRepository.Count_Buy(CurentUserRequest.Id));
                                                            }
                                                            catch
                                                            { }
                                                            try
                                                            {
                                                                callmarginMSG_2.AppendLine("میانگین خرید : " + BargainSuccessRepository.AverageBuy(CurentUserRequest.Id).ToString("N0"));
                                                            }
                                                            catch
                                                            { }

                                                            callmarginMSG_2.AppendLine("");



                                                            try
                                                            {
                                                                callmarginMSG_2.AppendLine("🔴 معامله فروش باز : " + BargainSuccessRepository.Count_sel(CurentUserRequest.Id));
                                                            }
                                                            catch { }
                                                            try
                                                            {
                                                                callmarginMSG_2.AppendLine("میانگین فروش : " + BargainSuccessRepository.AverageSell(CurentUserRequest.Id).ToString("N0"));
                                                            }
                                                            catch { }
                                                            UserBargainRepository bargainRepository_Sec_3 = new UserBargainRepository();

                                                            UserBargain userBargain_Balance_3 = bargainRepository_Sec_3.GetUserWithMyID(CurentUserRequest.Id);

                                                            callmarginMSG_2.AppendLine("💵 " + "موجودی  آبشده  : " + userBargain_Balance_3.Garranty);
                                                            callmarginMSG_2.AppendLine("");
                                                            callmarginMSG_2.AppendLine($"💵 موجودی نقدی : {userBargain_Balance_3.PriceGarranty.ToString("N0")} تومان");

                                                            await botClient.SendTextMessageAsync(bargainSuccess_2.FirstUserBargain_1.Userid, callmarginMSG_2.ToString(), ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                                                            #endregion

                                                            try
                                                            {

                                                                int Remi = sellBuyRepository.UpdateRemin(orginalLafz.Id, RequestUserNumber, orginalLafz.Count);

                                                                if (Remi >= 0)
                                                                {

                                                                    await botClient.EditMessageTextAsync(chatId: e.Message.Chat.Id, int.Parse(orginalLafz.MessageId.ToString()), $"🔴 {orginalLafz.UserBargain.AliasNames} : {orginalLafz.Count} ف {orginalLafz.Price} (مانده : {Remi} زمان : {DateTime.Now.ToString("hh:mm:ss.fff tt")}) ⏳");


                                                                }

                                                            }
                                                            catch
                                                            {
                                                                //  await botClient.SendTextMessageAsync(chatId: e.Message.Chat.Id, ex.Message, ParseMode.Default, false, true, int.Parse(orginalLafz.MessageId.ToString()));


                                                            }

                                                            #endregion
                                                        }
                                                        else if (orginalLafz.SellBuyType_Id == 2)
                                                        {
                                                            #region لفظ اصلی خرید

                                                            //   int opencount = BargainSuccessRepository.Count_Buy(CurentUserRequest.Id);
                                                            //if (RequestUserNumber > opencount && opencount > 0)
                                                            //{
                                                            //    try
                                                            //    {
                                                            //        await botClient.SendTextMessageAsync(e.Message.From.Id, $" ⛔️ لطفاً ابتدا{opencount} معاملات باز خود را تعیین تکلیف نمائید", ParseMode.Html, true, false);
                                                            //    }
                                                            //    catch { }
                                                            //    try
                                                            //    {
                                                            //        await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                            //    }
                                                            //    catch { }
                                                            //    return;
                                                            //}

                                                            if ((orginalLafz.Remain - RequestUserNumber) < 0)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }
                                                            if (orginalLafz.Remain <= 0)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }


                                                            if (BargainSuccessRepository.Count_Buy(orginalLafz.UserBargain.Id, orginalLafz.Id) > orginalLafz.Count)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }
                                                            if (BargainSuccessRepository.Count_Buy(orginalLafz.UserBargain.Id, orginalLafz.Id) + RequestUserNumber > orginalLafz.Count)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }



                                                            if (BargainSuccessRepository.Count_Buy_Open_WithSellId(orginalLafz.Id) >= orginalLafz.Count)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }
                                                            if (BargainSuccessRepository.Count_Buy_Open_WithSellId(orginalLafz.Id) + RequestUserNumber > orginalLafz.Count)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }

                                                            if (BargainSuccessRepository.Count_sel_Open_WithSellId(orginalLafz.Id) >= orginalLafz.Count)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }
                                                            if (BargainSuccessRepository.Count_sel_Open_WithSellId(orginalLafz.Id) + RequestUserNumber > orginalLafz.Count)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, " ⚠️ " + "امکان خرید/ فروش این لفظ وجود ندارد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }

                                                            if (BargainSuccessRepository.Count_sel(CurentUserRequest.Id) >= CurentUserRequest.Garranty)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                await botClient.SendTextMessageAsync(CurentUserRequest.Userid, " ⚠️ " + "مقدار اعتبار شما برای انجام این معامله کافی نیست", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                return;
                                                            }
                                                            if (BargainSuccessRepository.Count_sel(CurentUserRequest.Id) + RequestUserNumber > CurentUserRequest.Garranty)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                await botClient.SendTextMessageAsync(CurentUserRequest.Userid, " ⚠️ " + "مقدار اعتبار شما برای انجام این معامله کافی نیست", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                return;
                                                            }

                                                            if (BargainSuccessRepository.Count_Buy(orginalLafz.UserBargain_Id) >= orginalLafz.UserBargain.Garranty)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(orginalLafz.UserBargain.Userid, " ⚠️ " + "مقدار اعتبار شما برای انجام این معامله کافی نیست", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }
                                                            if (BargainSuccessRepository.Count_Buy(orginalLafz.UserBargain_Id) + RequestUserNumber > orginalLafz.UserBargain.Garranty)
                                                            {
                                                                try
                                                                {
                                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(orginalLafz.UserBargain.Userid, " ⚠️ " + "مقدار اعتبار شما برای انجام این معامله کافی نیست", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                                                                }
                                                                catch { }
                                                                return;
                                                            }

                                                            //لفظ اصلی خرید



                                                            strMsg.AppendLine($"🔵  خریدار : {orginalLafz.UserBargain.AliasNames}");

                                                            strMsg.AppendLine($"🔴  فروشنده : {CurentUserRequest.AliasNames}");
                                                            strMsg.AppendLine("🛒" + $"تعداد: {RequestUserNumber} قیمت: {(orginalLafz.Price * 1000).ToString("N0")}");
                                                            strMsg.AppendLine($"✅تسویه شنبه ای :  {  Utility.Convert2Shamsi(myTime_now)}✅");
                                                            strMsg.AppendLine("⏱" + $"زمان ثبت : {Utility.Convert2Shamsi(bargainSuccess.DateTime)} {bargainSuccess.DateTime.ToShortTimeString()}");
                                                            bargainSuccess_2.Tasvie = bargainSuccess.Tasvie = DateTime.Now;
                                                            bargainSuccess.SellBuyType_Id = 2;
                                                            bargainSuccess_2.SellBuyType_Id = 1;
                                                            //   decimal Sood_1_sel = BargainSuccessRepository.Average_open_Sell(bargainSuccess.UserBargain_Id_1.Value);

                                                            List<BargainSuccess> success_org_list = BargainSuccessRepository.Update_finishBasket_sel(orginalLafz.Price, orginalLafz.UserBargain_Id, RequestUserNumber);
                                                            BargainSuccessRepository.SaveNotAsync();
                                                            int myresult_org_sel = RequestUserNumber - success_org_list.Count;
                                                            if (success_org_list.Count <= 0)
                                                            {
                                                                for (int i = 1; i <= myresult_org_sel; i++)
                                                                {
                                                                    BargainSuccessRepository.Add(bargainSuccess);
                                                                    BargainSuccessRepository.SaveNotAsync();


                                                                }
                                                            }
                                                            StringBuilder sb_sood = new StringBuilder();
                                                            StringBuilder sb_sood_2 = new StringBuilder();
                                                            StringBuilder sb_sood_1 = new StringBuilder();

                                                            if (success_org_list.Count > 0)
                                                            {

                                                                foreach (var item in success_org_list)
                                                                {
                                                                    double val_sod_1 = 0;


                                                                    val_sod_1 = item.SellBuy.Price - orginalLafz.Price;


                                                                    val_sod_1 *= 23;
                                                                    sb_sood_2.AppendLine("🤝 " + $"معامله {item.SellBuy.Price.ToString("N0")} شما در عدد {orginalLafz.Price.ToString("N0")} با موفقیت به پایان رسید");

                                                                    DateTime H1315 = new DateTime(item.DateTime.Year, item.DateTime.Month, item.DateTime.Day, 13, 15, 00);

                                                                    //if (H1315 >= item.DateTime && H1315 <= myTime_now)
                                                                    //{
                                                                    val_sod_1 -= ComisionPrice_Double;


                                                                    //}
                                                                    //else
                                                                    //{
                                                                    //    ComisionPrice = 10000;
                                                                    //    val_sod_1 -= 10;
                                                                    //}

                                                                    comisonRepository.Add(new Consion
                                                                    {
                                                                        BargainSuccess_Id = item.Id,
                                                                        Price = ComisionPrice,
                                                                        DateTime = myTime_now

                                                                    });
                                                                    val_sod_1 *= 1000;
                                                                    if (val_sod_1 > 0)
                                                                    {
                                                                        sb_sood_2.AppendLine("🙋🏻‍♂️" + "سود شما از این معامله با احتساب کارمزد: " + val_sod_1.ToString("N0"));

                                                                    }
                                                                    else
                                                                    {
                                                                        sb_sood_2.AppendLine("🤦🏻‍♂️ " + "ضرر شما از این معامله با احتساب کارمزد: " + val_sod_1.ToString("N0"));

                                                                    }
                                                                    item.FirstUserBargain_1.PriceGarranty += long.Parse(val_sod_1.ToString());
                                                                    BargainSuccessRepository.SaveNotAsync();
                                                                    user.SaveNotAsync();
                                                                    item.Sod = int.Parse(val_sod_1.ToString());
                                                                    await comisonRepository.Save();
                                                                    BargainSuccessRepository.SaveNotAsync();
                                                                }


                                                            }

                                                            //   decimal Sood_2_buy = BargainSuccessRepository.Average_open_buy(bargainSuccess_2.UserBargain_Id_1.Value);

                                                            List<BargainSuccess> success_2_list = BargainSuccessRepository.Update_finishBasket_Buy(orginalLafz.Price, CurentUserRequest.Id, RequestUserNumber);
                                                            BargainSuccessRepository.SaveNotAsync();
                                                            int myresult_2_buy = RequestUserNumber - success_2_list.Count;

                                                            if (success_2_list.Count <= 0)
                                                            {
                                                                for (int i = 1; i <= myresult_2_buy; i++)
                                                                {
                                                                    BargainSuccessRepository.Add(bargainSuccess_2);
                                                                    BargainSuccessRepository.SaveNotAsync();

                                                                }
                                                            }



                                                            if (success_2_list.Count > 0)
                                                            {
                                                                foreach (var item in success_2_list)
                                                                {
                                                                    double val_sod_2 = 0;

                                                                    val_sod_2 = orginalLafz.Price - item.SellBuy.Price;

                                                                    val_sod_2 *= 23;
                                                                    sb_sood_1.AppendLine("🤝 " + $"معامله {item.SellBuy.Price.ToString("N0")} شما در عدد {orginalLafz.Price.ToString("N0")} با موفقیت به پایان رسید");

                                                                    DateTime H1315 = new DateTime(item.DateTime.Year, item.DateTime.Month, item.DateTime.Day, 13, 15, 00);

                                                                    //if (H1315 >= item.DateTime && H1315 <= DateTime.Now)
                                                                    //{
                                                                    val_sod_2 -= ComisionPrice_Double;


                                                                    //}
                                                                    //else
                                                                    //{
                                                                    //    ComisionPrice = 10000;

                                                                    //    val_sod_2 -= 10;


                                                                    //}


                                                                    comisonRepository.Add(new Consion
                                                                    {
                                                                        BargainSuccess_Id = item.Id,
                                                                        Price = ComisionPrice,
                                                                        DateTime = myTime_now

                                                                    });
                                                                    await comisonRepository.Save();

                                                                    val_sod_2 *= 1000;

                                                                    if (val_sod_2 > 0)
                                                                    {
                                                                        sb_sood_1.AppendLine("🙋🏻‍♂️" + "سود شما از این معامله با احتساب کارمزد: " + val_sod_2.ToString("N0"));

                                                                    }
                                                                    else
                                                                    {
                                                                        sb_sood_1.AppendLine("🤦🏻‍♂️ " + "ضرر شما از این معامله با احتساب کارمزد: " + val_sod_2.ToString("N0"));

                                                                    }
                                                                    item.FirstUserBargain_1.PriceGarranty += long.Parse(val_sod_2.ToString());
                                                                    BargainSuccessRepository.SaveNotAsync();
                                                                    user.SaveNotAsync();
                                                                    item.Sod = int.Parse(val_sod_2.ToString());
                                                                    BargainSuccessRepository.SaveNotAsync();
                                                                }


                                                            }

                                                            //محاسبه سود  و ذخیره در وجه تضمین
                                                            // await user.Save();
                                                            // await BargainSuccessRepository.Save();
                                                            //  await comisonRepository.Save();




                                                            //سود و ضرر و پیام مناسب با میانگیت تولید و به طرفین اعلام میشود
                                                            #region بعد از بسته شدن دوباره میانگین را بهش اعلام کنه 

                                                            bargainSuccess.FirstUserBargain_1 = user.GetUserWithMyID(orginalLafz.UserBargain.Id);
                                                            bargainSuccess.SecendUserBargain_2 = user.GetUserWithMyID(CurentUserRequest.Id);


                                                            bargainSuccess_2.FirstUserBargain_1 = user.GetUserWithMyID(CurentUserRequest.Id);
                                                            bargainSuccess_2.SecendUserBargain_2 = user.GetUserWithMyID(orginalLafz.UserBargain.Id);



                                                            StringBuilder callmarginMSG_1 = new StringBuilder();
                                                            if (success_org_list.Count > 0)
                                                            {
                                                                callmarginMSG_1.AppendLine(sb_sood_2.ToString());
                                                            }
                                                            if (myresult_org_sel > 0)
                                                            {
                                                                callmarginMSG_1.AppendLine("🔵" + $" {RequestUserNumber} پله خرید   " + (orginalLafz.Price * 1000).ToString("N0") + " قطعی شد");
                                                                callmarginMSG_1.AppendLine("");
                                                                callmarginMSG_1.AppendLine("📣این معامله در صورت عدم بسته شدن توسط شما ، جهت حفظ حد سود و ضرر از ۹۰٪ مبلغ بیعانه حجم این معامله ،به حراج گذاشته خواهد شد که در مظنه های زیر صورت میپذیرد. ");
                                                                callmarginMSG_1.AppendLine("");
                                                                callmarginMSG_1.AppendLine($"📉 + {My_Settings.Mazane + My_Settings.OnSaleTelorans}");
                                                                callmarginMSG_1.AppendLine("");
                                                                callmarginMSG_1.AppendLine($"📈 - {My_Settings.Mazane - My_Settings.OnSaleTelorans}");
                                                            }
                                                            try
                                                            {
                                                                callmarginMSG_1.AppendLine("🔵 معامله خرید باز :" + BargainSuccessRepository.Count_Buy(orginalLafz.UserBargain.Id));
                                                            }
                                                            catch
                                                            { }
                                                            try
                                                            {
                                                                callmarginMSG_1.AppendLine("میانگین خرید : " + BargainSuccessRepository.AverageBuy(orginalLafz.UserBargain.Id).ToString("N0"));
                                                            }
                                                            catch
                                                            { }
                                                            callmarginMSG_1.AppendLine("");

                                                            try
                                                            {
                                                                callmarginMSG_1.AppendLine("🔴 معامله فروش باز : " + BargainSuccessRepository.Count_sel(orginalLafz.UserBargain.Id));
                                                            }
                                                            catch { }
                                                            try
                                                            {
                                                                callmarginMSG_1.AppendLine("میانگین فروش : " + BargainSuccessRepository.AverageSell(orginalLafz.UserBargain.Id).ToString("N0"));
                                                            }
                                                            catch { }
                                                            UserBargainRepository bargainRepository_Sec = new UserBargainRepository();

                                                            UserBargain userBargain_Balance = bargainRepository_Sec.GetUserWithMyID(orginalLafz.UserBargain.Id);

                                                            callmarginMSG_1.AppendLine("💵 " + "موجودی  آبشده  : " + userBargain_Balance.Garranty);
                                                            callmarginMSG_1.AppendLine("");
                                                            callmarginMSG_1.AppendLine($"💵 موجودی نقدی : {userBargain_Balance.PriceGarranty.ToString("N0")} تومان");

                                                            callmarginMSG_1.AppendLine("");

                                                            await botClient.SendTextMessageAsync(bargainSuccess.FirstUserBargain_1.Userid, callmarginMSG_1.ToString(), ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                                                            StringBuilder callmarginMSG_2 = new StringBuilder();
                                                            if (success_2_list.Count > 0)
                                                            {
                                                                callmarginMSG_2.AppendLine(sb_sood_1.ToString());
                                                            }
                                                            if (myresult_2_buy > 0)
                                                            {
                                                                callmarginMSG_2.AppendLine("🔴" + $" {RequestUserNumber} پله فروش   " + (orginalLafz.Price * 1000).ToString("N0") + " قطعی شد");
                                                                callmarginMSG_2.AppendLine("");
                                                                callmarginMSG_2.AppendLine("📣این معامله در صورت عدم بسته شدن توسط شما ، جهت حفظ حد سود و ضرر از ۹۰٪ مبلغ بیعانه حجم این معامله ،به حراج گذاشته خواهد شد که در مظنه های زیر صورت میپذیرد. ");
                                                                callmarginMSG_2.AppendLine("");
                                                                callmarginMSG_2.AppendLine($"📉 + {My_Settings.Mazane + My_Settings.OnSaleTelorans}");
                                                                callmarginMSG_2.AppendLine("");
                                                                callmarginMSG_2.AppendLine($"📈 - {My_Settings.Mazane - My_Settings.OnSaleTelorans}");
                                                                callmarginMSG_2.AppendLine("");

                                                            }
                                                            try
                                                            {
                                                                callmarginMSG_2.AppendLine("🔵 معامله خرید باز :" + BargainSuccessRepository.Count_Buy(CurentUserRequest.Id));
                                                            }
                                                            catch { }
                                                            try
                                                            {
                                                                callmarginMSG_2.AppendLine("میانگین خرید : " + BargainSuccessRepository.AverageBuy(CurentUserRequest.Id).ToString("N0"));
                                                            }
                                                            catch { }

                                                            callmarginMSG_2.AppendLine("");

                                                            try
                                                            {
                                                                callmarginMSG_2.AppendLine("🔴 معامله فروش باز : " + BargainSuccessRepository.Count_sel(CurentUserRequest.Id));

                                                            }
                                                            catch { }
                                                            try
                                                            {
                                                                callmarginMSG_2.AppendLine("میانگین فروش : " + BargainSuccessRepository.AverageSell(CurentUserRequest.Id).ToString("N0"));

                                                            }
                                                            catch { }



                                                            UserBargainRepository bargainRepository_Sec_1 = new UserBargainRepository();

                                                            UserBargain userBargain_Balance_1 = bargainRepository_Sec_1.GetUserWithMyID(CurentUserRequest.Id);

                                                            callmarginMSG_2.AppendLine("💵 " + "موجودی  آبشده  : " + userBargain_Balance_1.Garranty);
                                                            callmarginMSG_2.AppendLine("");
                                                            callmarginMSG_2.AppendLine($"💵 موجودی نقدی : {userBargain_Balance_1.PriceGarranty.ToString("N0")} تومان");




                                                            await botClient.SendTextMessageAsync(bargainSuccess_2.FirstUserBargain_1.Userid, callmarginMSG_2.ToString(), ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                                                            #endregion
                                                            try
                                                            {

                                                                int remi = sellBuyRepository.UpdateRemin(orginalLafz.Id, RequestUserNumber, orginalLafz.Count);
                                                                if (remi >= 0)
                                                                {
                                                                    await botClient.EditMessageTextAsync(chatId: e.Message.Chat.Id, int.Parse(orginalLafz.MessageId.ToString()), $"🔵 {orginalLafz.UserBargain.AliasNames} : {orginalLafz.Count} خ {orginalLafz.Price} (مانده : {remi} زمان : {DateTime.Now.ToString("hh:mm:ss.fff tt")}) ⏳");
                                                                }


                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                await botClient.SendTextMessageAsync(chatId: e.Message.Chat.Id, ex.Message, ParseMode.Default, false, true, int.Parse(orginalLafz.MessageId.ToString()));
                                                            }
                                                            #endregion
                                                        }

                                                        var mymsg = await botClient.SendTextMessageAsync(chatId: e.Message.Chat.Id, strMsg.ToString(), ParseMode.Html, true, false);
                                                        ///

                                                        try
                                                        {
                                                            await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                        }
                                                        catch { }
                                                        return;

                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                        }
                                                        catch { }
                                                        await botClient.SendTextMessageAsync(chatId: e.Message.Chat.Id, "زمان منقضی شده است", ParseMode.Default, false, true, int.Parse(orginalLafz.MessageId.ToString()));
                                                        return;

                                                    }
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                    }
                                                    catch { }
                                                    return;
                                                }

                                            }

                                        }
                                        else if (e.Message.Text.Length > 3)
                                        {
                                            #region ارسال لفظ
                                            //لفظ
                                            string RecMessage = e.Message.Text;

                                            RecMessage = RecMessage.Replace(" ", "");
                                            bool price = false, isPriceError = false;

                                            string sahm = "", selBuy = "", mablagh = "";
                                            foreach (char item in RecMessage)
                                            {

                                                string myitem = Utility.ToENNumber(item.ToString());
                                                if (Utility.CheckNumberChar(myitem.ToString()) && !price)
                                                {
                                                    sahm += myitem;
                                                }
                                                else if (!Utility.CheckNumberChar(myitem.ToString()) && !price)
                                                {
                                                    selBuy = myitem.ToString();
                                                    price = true;
                                                }
                                                else if (Utility.CheckNumberChar(myitem.ToString()) && price)
                                                {
                                                    mablagh += myitem;
                                                }
                                                else
                                                {
                                                    //فرمت اشتباه است 
                                                    isPriceError = true;
                                                    continue;
                                                }//end check text
                                            }

                                            if (mablagh.Length == 3)
                                            {
                                                mablagh = My_Settings.Mazane.ToString()[0] + mablagh;
                                            }
                                            else if (mablagh.Length == 2)
                                            {
                                                mablagh = My_Settings.Mazane.ToString()[0].ToString() + "" + My_Settings.Mazane.ToString()[1].ToString() + "" + mablagh;

                                            }


                                            if (!isPriceError)
                                            {
                                                //همه چی اوکی هست
                                                int myprice = -1;
                                                try
                                                {
                                                    myprice = int.Parse(mablagh);
                                                }
                                                catch { }

                                                int mySahm = -1;
                                                try
                                                {
                                                    mySahm = int.Parse(sahm);
                                                }
                                                catch { }



                                                UserBargain userBargain = user.GetUser(e.Message.From.Id);



                                                if (mySahm > userBargain.Garranty || myprice == -1 || mySahm == -1)// بررسی اینکه بیش از وجه تضمینش چیزی اضافه کار نکنه
                                                {
                                                    try
                                                    {
                                                        var mymsg = await botClient.SendTextMessageAsync(e.Message.From.Id, " ⛔️ شما اجازه ارسال بیش از وجه تضمین ندارید.", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                                                    }
                                                    catch { }
                                                    try
                                                    {
                                                        await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                    }
                                                    catch { }
                                                    return;
                                                }
                                                long MinMazane = My_Settings.Mazane - My_Settings.Telorans;

                                                long MaxMazane = My_Settings.Mazane + My_Settings.Telorans;
                                                long FixPrice = (myprice);
                                                if (!(FixPrice >= MinMazane && FixPrice <= MaxMazane))  //در محدوده تلورانس نباشه
                                                {
                                                    try
                                                    {
                                                        var mymsg = await botClient.SendTextMessageAsync(e.Message.From.Id, $"⛔️ محدوده مجاز لفظ دهی {MinMazane} الی {MaxMazane} ", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                                                    }
                                                    catch { }
                                                    try
                                                    {
                                                        await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                    }
                                                    catch { }
                                                    return;
                                                }



                                                if (selBuy == "ف" && myprice > 0)
                                                {

                                                    int opencount = BargainSuccessRepository.Count_Buy(userBargain.Id);
                                                    //if (mySahm > opencount && opencount > 0)
                                                    //{
                                                    //    try
                                                    //    {
                                                    //        await botClient.SendTextMessageAsync(e.Message.From.Id, $" ⛔️ لطفاً ابتدا {opencount} معاملات باز خود را تعیین تکلیف نمائید", ParseMode.Html, true, false);
                                                    //    }
                                                    //    catch { }
                                                    //    try
                                                    //    {
                                                    //        await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                    //    }
                                                    //    catch { }
                                                    //    return;
                                                    //}


                                                    if (BargainSuccessRepository.Count_sel(userBargain.Id) >= userBargain.Garranty)// بررسی اینکه بیش از وجه تضمینش چیزی اضافه کار نکنه
                                                    {
                                                        try
                                                        {
                                                            await botClient.SendTextMessageAsync(e.Message.From.Id, " ⛔️ شما اجازه ارسال بیش از وجه تضمین را ندارید", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                                                        }
                                                        catch { }
                                                        try
                                                        {
                                                            await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                        }
                                                        catch { }
                                                        return;
                                                    }
                                                    if (BargainSuccessRepository.Count_sel(userBargain.Id) + mySahm > userBargain.Garranty)// بررسی اینکه بیش از وجه تضمینش چیزی اضافه کار نکنه
                                                    {
                                                        try
                                                        {
                                                            await botClient.SendTextMessageAsync(e.Message.From.Id, " ⛔️ شما اجازه ارسال بیش از وجه تضمین را ندارید", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                                                        }
                                                        catch { }
                                                        try
                                                        {
                                                            await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                        }
                                                        catch { }
                                                        return;
                                                    }

                                                    string msgtext;


                                                    int count_temp_lafz = sellBuyRepository.DeleteTemp(userBargain.Id, 1, myTime_now.AddMinutes(-1));
                                                    if (count_temp_lafz > 0)
                                                    {
                                                        await sellBuyRepository.Save();
                                                        //  await botClient.SendTextMessageAsync(e.Message.From.Id, $" 🗑 {count_temp_lafz} لفظ فروش بدون معامله قبلی شما منقضی شد", ParseMode.Html, true, false);

                                                    }
                                                    int mySendedLafzCount = sellBuyRepository.CountOpenLafz(myTime_now.AddMinutes(-1), userBargain, 1) + mySahm;
                                                    if (mySendedLafzCount > userBargain.Garranty)
                                                    {
                                                        try
                                                        {
                                                            await botClient.SendTextMessageAsync(e.Message.From.Id, " ⛔️ شما اجازه ارسال بیش از وجه تضمین را ندارید", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                                                        }
                                                        catch { }
                                                        try
                                                        {
                                                            await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                        }
                                                        catch { }
                                                        return;
                                                    }

                                                    msgtext = $"🔴 {userBargain.AliasNames} : {sahm} ف {mablagh} ⏳";
                                                    var mymsg = await botClient.SendTextMessageAsync(chatId: e.Message.Chat.Id, msgtext, ParseMode.Html, true, false);

                                                    SellBuy sellBuy = new SellBuy
                                                    {
                                                        Count = mySahm,
                                                        Remain = mySahm,
                                                        DateTime = myTime_now,
                                                        MessageId = mymsg.MessageId,
                                                        Price = myprice,
                                                        UserBargain_Id = userBargain.Id,
                                                        SellBuyType_Id = 1,
                                                    };
                                                    sellBuyRepository.Add(sellBuy);
                                                    await sellBuyRepository.Save();

                                                    try
                                                    {
                                                        await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                    }
                                                    catch { }
                                                }
                                                else if (selBuy == "خ" && myprice > 0)
                                                {

                                                    int opencount = BargainSuccessRepository.Count_sel(userBargain.Id);
                                                    //if (mySahm > opencount && opencount > 0)
                                                    //{
                                                    //    try
                                                    //    {
                                                    //        await botClient.SendTextMessageAsync(e.Message.From.Id, $" ⛔️ لطفاً ابتدا {opencount} معاملات باز خود را تعیین تکلیف نمائید", ParseMode.Html, true, false);
                                                    //    }
                                                    //    catch { }
                                                    //    try
                                                    //    {
                                                    //        await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                    //    }
                                                    //    catch { }
                                                    //    return;
                                                    //}


                                                    if (BargainSuccessRepository.Count_Buy(userBargain.Id) >= userBargain.Garranty)// بررسی اینکه بیش از وجه تضمینش چیزی اضافه کار نکنه
                                                    {
                                                        try
                                                        {
                                                            await botClient.SendTextMessageAsync(e.Message.From.Id, " ⛔️ شما اجازه ارسال بیش از وجه تضمین را ندارید", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                                                        }
                                                        catch { }
                                                        try
                                                        {
                                                            await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                        }
                                                        catch { }
                                                        return;
                                                    }
                                                    if (BargainSuccessRepository.Count_Buy(userBargain.Id) + mySahm > userBargain.Garranty)// بررسی اینکه بیش از وجه تضمینش چیزی اضافه کار نکنه
                                                    {
                                                        try
                                                        {
                                                            await botClient.SendTextMessageAsync(e.Message.From.Id, " ⛔️ شما اجازه ارسال بیش از وجه تضمین را ندارید", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                                                        }
                                                        catch { }
                                                        try
                                                        {
                                                            await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                        }
                                                        catch { }
                                                        return;
                                                    }
                                                    string msgtext;


                                                    int count_temp_lafz = sellBuyRepository.DeleteTemp(userBargain.Id, 2, myTime_now.AddMinutes(-1));
                                                    if (count_temp_lafz > 0)
                                                    {
                                                        await sellBuyRepository.Save();
                                                        //  await botClient.SendTextMessageAsync(e.Message.From.Id, $" 🗑 {count_temp_lafz} لفظ فروش بدون معامله قبلی شما منقضی شد", ParseMode.Html, true, false);

                                                    }
                                                    int mySendedLafzCount = sellBuyRepository.CountOpenLafz(myTime_now.AddMinutes(-1), userBargain, 2) + mySahm;
                                                    if (mySendedLafzCount > userBargain.Garranty)
                                                    {
                                                        try
                                                        {
                                                            await botClient.SendTextMessageAsync(e.Message.From.Id, " ⛔️ شما اجازه ارسال بیش از وجه تضمین را ندارید", ParseMode.Html, true, false, 0, mainKeyboardMarkup);
                                                        }
                                                        catch { }
                                                        try
                                                        {
                                                            await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                        }
                                                        catch { }
                                                        return;
                                                    }

                                                    msgtext = $"🔵  {userBargain.AliasNames} : {sahm} خ {mablagh} ⏳ ";

                                                    var mymsg = await botClient.SendTextMessageAsync(chatId: e.Message.Chat.Id, msgtext, ParseMode.Html, true, false);

                                                    SellBuy sellBuy = new SellBuy
                                                    {
                                                        Count = mySahm,
                                                        Remain = mySahm,
                                                        DateTime = myTime_now,
                                                        MessageId = mymsg.MessageId,
                                                        Price = myprice,
                                                        UserBargain_Id = userBargain.Id,
                                                        SellBuyType_Id = 2,
                                                    };
                                                    sellBuyRepository.Add(sellBuy);
                                                    await sellBuyRepository.Save();
                                                    try
                                                    {
                                                        await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                    }
                                                    catch { }
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        await botClient.SendTextMessageAsync(e.Message.From.Id, $"فرمت وارد شده صحیح نیست ، لطفاً برای اطلاعات بیشتر به راهنما داخل ربات حسابداری مراجعه فرمایید . {My_Settings.Mazane}فرمت صحیح ارسال لفظ به عنوان مثال : 1ف", ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                                                    }
                                                    catch { }
                                                    try
                                                    {
                                                        await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                    }
                                                    catch { }
                                                }
                                            }
                                            else
                                            {
                                                //فرمت اشتباه است
                                                try
                                                {
                                                    await botClient.SendTextMessageAsync(e.Message.From.Id, $"فرمت وارد شده صحیح نیست \n فرمت صحیح ارسال لفظ به عنوان مثال : 1ف{My_Settings.Mazane}", ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                                                }
                                                catch { }
                                                try
                                                {
                                                    await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                                }
                                                catch { }
                                            }



                                        }
                                        else
                                        {
                                            //فرمت اشتباه است
                                            try
                                            {
                                                await botClient.SendTextMessageAsync(e.Message.From.Id, $"فرمت وارد شده صحیح نیست \n فرمت صحیح ارسال لفظ به عنوان مثال : {My_Settings.Mazane}", ParseMode.Html, true, false, 0, mainKeyboardMarkup);

                                            }
                                            catch { }
                                            try
                                            {
                                                await botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                                            }
                                            catch { }
                                            #endregion
                                        }
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        await botClient.DeleteMessageAsync(chatId: e.Message.Chat.Id, e.Message.MessageId);
                                    }
                                    catch { }
                                    return;
                                }
                            }

                        }
                    }


                    #region CallMargin
                    TimeSpan timeSpan3 = DateTime.Now - My_Settings.LastOnSale;

                    if (timeSpan3.Minutes > 3)
                    {
                        My_Settings.LastOnSale = DateTime.Now;
                        await botRepository.Save();
                        My_Settings = botRepository.GetSetting();
                        BargainSuccessRepository bargainSuccessRepository = new BargainSuccessRepository();
                        SellBuyRepository sellBuyRepository = new SellBuyRepository();
                        List<BargainSuccess> CallMarginOnSale = bargainSuccessRepository.GetAllOnSale();

                        if (CallMarginOnSale.Count > 0)
                        {
                            foreach (BargainSuccess item in CallMarginOnSale)
                            {
                                string CallMarginMSG = "";
                                int CallMarginType = 1, CllMarginMazane = int.Parse(My_Settings.Mazane.ToString()) - 5;
                                if (item.SellBuyType_Id == 1)
                                {
                                    //خرید
                                    CallMarginType = 2;
                                    CallMarginMSG = $"🔵 (حراج) {item.FirstUserBargain_1.AliasNames} : 1 خ {CllMarginMazane} ⏳🤖";
                                }
                                else
                                {
                                    //فروش
                                    CallMarginMSG = $"🔴 (حراج) {item.FirstUserBargain_1.AliasNames} : 1 ف {CllMarginMazane} ⏳🤖";
                                    CallMarginType = 1;
                                }



                                var mymsg = await botClient.SendTextMessageAsync(chatId: e.Message.Chat.Id, CallMarginMSG, ParseMode.Default, true, false);

                                SellBuy sellBuy = new SellBuy
                                {
                                    Count = 1,
                                    Remain = 1,
                                    DateTime = DateTime.Now,
                                    MessageId = mymsg.MessageId,
                                    Price = CllMarginMazane,
                                    UserBargain_Id = item.FirstUserBargain_1.Id,
                                    SellBuyType_Id = CallMarginType,
                                };
                                sellBuyRepository.Add(sellBuy);
                                await sellBuyRepository.Save();
                            }


                        }

                    }
                    #endregion
                }//پایان شرط مدیریت گروه
            }
            catch
            {
                try
                {
                    await botClient.DeleteMessageAsync(chatId: e.Message.Chat.Id, e.Message.MessageId);
                }
                catch { }
            }
            finally
            {

            }

        }



        private void MnStatusOnline_Click(object sender, EventArgs e)
        {
            try
            {
                if (botClient == null)
                {
                    botClient = new TelegramBotClient("974027017:AAGDqni7GthDS40301sUW1DD6AQR9mcOkCU"); //Test
                    TotalChatId = "-1001242524144"; //Test


                    //botClient = new TelegramBotClient("929956508:AAF6VvNopvZhXUajMSsLGJ0q4xy-5Crr8Zw");//Real
                    //TotalChatId = "-349555002";//Real

                    var me = botClient.GetMeAsync().Result;


                    botClient.OnMessage += BotClient_OnMessage;
                    botClient.StartReceiving();

                    notifyIcon1.Text = lblStatusBot.Text = "ربات آنلاین است . . . " + " | " + me.Username;
                    lblStatusBot.ForeColor = Color.Green;
                    mnStatusOnline.Checked = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {


            SettingBotRepository botRepository = new SettingBotRepository();
            SettingsBot Settings = botRepository.GetSetting();
            int mazane_feli = int.Parse(Settings.Mazane.ToString());
            int mazane_new = int.Parse(txtMazane.Text);
            int mines = mazane_feli - mazane_new;
            _RobotIsOff = true;
            btnUpdate.Enabled = false;
            BargainSuccessRepository BargainSuccessRepository = new BargainSuccessRepository();
            if (mines > 0)//+
            {
                for (int i = 1; i <= mines; i++)
                {
                    int CurentMazane = mazane_feli - i;
                    lalMazaneCurent.Text = "مظنه فعلی : " + CurentMazane;
                    settingBotRepository.UpdateMazane(int.Parse(CurentMazane.ToString()));
                    await settingBotRepository.Save();
                    var AllowCallMargin = BargainSuccessRepository.GetAllCallMargin();
                    foreach (var item in AllowCallMargin)
                    {
                        int myMazane = item.NowMazane;
                        int minMazane = myMazane - Settings.OnSaleTelorans;
                        int maxMazane = myMazane + Settings.OnSaleTelorans;
                        if (CurentMazane == minMazane || CurentMazane == maxMazane)
                        {
                            item.OnSale = true;
                            await BargainSuccessRepository.Save();
                            try
                            {
                                await botClient.SendTextMessageAsync(item.FirstUserBargain_1.Userid, $"📣🤖 معامله {item.SellBuy.SellBuyType.Name}  {item.SellBuy.Price} شما جهت حفظ حد سود و ضرر توسط ربات به صورت خودکار به حراج گذاشته شد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                            }
                            catch { }

                        }//end if
                    }//end  for

                }
            }
            else//-
            {
                for (int i = 1; i <= Math.Abs(mines); i++)
                {
                    int CurentMazane = mazane_feli + i;
                    lalMazaneCurent.Text = "مظنه فعلی : " + CurentMazane;
                    settingBotRepository.UpdateMazane(int.Parse(CurentMazane.ToString()));
                    await settingBotRepository.Save();
                    var AllowCallMargin = BargainSuccessRepository.GetAllCallMargin();
                    foreach (var item in AllowCallMargin)
                    {
                        int myMazane = item.NowMazane;
                        int minMazane = myMazane - Settings.OnSaleTelorans;
                        int maxMazane = myMazane + Settings.OnSaleTelorans;


                        if (CurentMazane == minMazane || CurentMazane == maxMazane)
                        {

                            item.OnSale = true;
                            await BargainSuccessRepository.Save();
                            try
                            {
                                await botClient.SendTextMessageAsync(item.FirstUserBargain_1.Userid, $"📣🤖 معامله {item.SellBuy.SellBuyType.Name}  {item.SellBuy.Price} شما جهت حفظ حد سود و ضرر توسط ربات به صورت خودکار به حراج گذاشته شد", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                            }
                            catch { }

                        }//end if
                    }//end  for

                }
            }


            _RobotIsOff = false;
            lalMazaneCurent.Text = "مظنه فعلی : " + txtMazane.Text;
            try
            {
                Task<Telegram.Bot.Types.Message> message1 = botClient.SendTextMessageAsync(TotalChatId, $"Ⓜ️ مظنه : {mazane_new.ToString()} Ⓜ️", ParseMode.Default, false, false);
                await botClient.PinChatMessageAsync(message1.Result.Chat.Id, message1.Result.MessageId);
            }
            catch { }
            txtMazane.Text = "";
            btnUpdate.Enabled = true;


        }

        private async void BtnTasvie_Click(object sender, EventArgs e)
        {


            if (long.Parse(txtTasvie.Text) > 0)
            {

                _RobotIsOff = true;
                btnTasvie.Enabled = false;

                BargainSuccessRepository bargainSuccessRepository = new BargainSuccessRepository();
                UserBargainRepository userBargainRepository = new UserBargainRepository();
                ComisonRepository comisonRepository = new ComisonRepository();
                List<BargainSuccess> AllowCallMargin = bargainSuccessRepository.GetAllCallMargin();
                foreach (var item in AllowCallMargin)
                {

                    item.Price2 = int.Parse(txtTasvie.Text);

                    item.Tasvie = DateTime.Now;
                    double SoodCallMarin = 0;
                    if (item.SellBuyType_Id == 1)
                    {
                        SoodCallMarin = item.SellBuy.Price - int.Parse(txtTasvie.Text);
                    }
                    else
                    {
                        SoodCallMarin = int.Parse(txtTasvie.Text) - item.SellBuy.Price;

                    }
                    SoodCallMarin *= 23;

                    DateTime H1315 = new DateTime(item.DateTime.Year, item.DateTime.Month, item.DateTime.Day, 13, 15, 00);



                    //if (H1315 >= item.DateTime && H1315 <= DateTime.Now)
                    //{

                    SoodCallMarin -= ComisionPrice_Double;


                    //}
                    //else
                    //{
                    //    ComisionPrice = 10000;
                    //    SoodCallMarin -= 10;
                    //}


                    comisonRepository.Add(new Consion
                    {
                        BargainSuccess_Id = item.Id,
                        Price = ComisionPrice,
                        DateTime = DateTime.Now

                    });
                    await comisonRepository.Save();

                    SoodCallMarin *= 1000;
                    item.Sod = int.Parse(SoodCallMarin.ToString());
                    await bargainSuccessRepository.Save();
                    //محاسبه سود  و ذخیره در وجه تضمین
                    item.FirstUserBargain_1.PriceGarranty += long.Parse(SoodCallMarin.ToString());
                    await bargainSuccessRepository.Save();
                    await userBargainRepository.Save();

                    try
                    {
                        await botClient.SendTextMessageAsync(item.FirstUserBargain_1.Userid, $"🧮 با توجه به اینکه شما نسبت به بستن معامله خود تا زمان تسویه اقدام نکردید ، معامله {item.SellBuy.Price} با نرخ تسویه هفتگی {txtTasvie.Text} بسته شد . لذا جهت مشاهده وضعیت خود به دفتر کل مراجعه فرمایید  ", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                    }
                    catch { }

                }//end  for
                try
                {
                    Task<Telegram.Bot.Types.Message> message = botClient.SendTextMessageAsync(TotalChatId, $"🧮 تسویه هفتگی : {txtTasvie.Text}", ParseMode.Default, false, false);
                    await botClient.PinChatMessageAsync(message.Result.Chat.Id, message.Result.MessageId);
                }
                catch { }
                txtTasvie.Text = "";
                _RobotIsOff = false;
                btnTasvie.Enabled = true;
            }

        }



        private void MnManageUser_Click(object sender, EventArgs e)
        {
            View.frmUsers.FrmRobotUseres frm = new View.frmUsers.FrmRobotUseres();
            frm.Show();

        }

        private async void BtnTasvieMovaghat_Click(object sender, EventArgs e)
        {

            if (long.Parse(txtTasvieMovaghat.Text) > 0)
            {

                _RobotIsOff = true;
                btnTasvieMovaghat.Enabled = false;


                BargainSuccessRepository bargainSuccessRepository = new BargainSuccessRepository();
                UserBargainRepository userBargainRepository = new UserBargainRepository();
                ComisonRepository comisonRepository = new ComisonRepository();
                List<BargainSuccess> AllowCallMargin = bargainSuccessRepository.GetAllCallMargin();
                foreach (var item in AllowCallMargin)
                {

                    item.Price2 = int.Parse(txtTasvieMovaghat.Text);
                    item.Tasvie = DateTime.Now;

                    double SoodCallMarin = 0;
                    if (item.SellBuyType_Id == 1)
                    {
                        SoodCallMarin = item.SellBuy.Price - int.Parse(txtTasvieMovaghat.Text);
                    }
                    else
                    {
                        SoodCallMarin = int.Parse(txtTasvieMovaghat.Text) - item.SellBuy.Price;

                    }
                    SoodCallMarin *= 23;

                    DateTime H1315 = new DateTime(item.DateTime.Year, item.DateTime.Month, item.DateTime.Day, 13, 15, 00);



                    //if (H1315 >= item.DateTime && H1315 <= DateTime.Now)
                    //{

                    SoodCallMarin -= ComisionPrice_Double;


                    //}
                    //else
                    //{
                    //    ComisionPrice = 10000;
                    //    SoodCallMarin -= 10;
                    //}


                    comisonRepository.Add(new Consion
                    {
                        BargainSuccess_Id = item.Id,
                        Price = ComisionPrice,
                        DateTime = DateTime.Now

                    });
                    await comisonRepository.Save();

                    SoodCallMarin *= 1000;
                    item.Sod = int.Parse(SoodCallMarin.ToString());
                    await bargainSuccessRepository.Save();
                    //محاسبه سود  و ذخیره در وجه تضمین
                    item.FirstUserBargain_1.PriceGarranty += long.Parse(SoodCallMarin.ToString());
                    await bargainSuccessRepository.Save();
                    await userBargainRepository.Save();
                    try
                    {
                        await botClient.SendTextMessageAsync(item.FirstUserBargain_1.Userid, $"🧮 با توجه به اینکه شما نسبت به بستن معامله خود تا زمان تسویه اقدام نکردید ، معامله {item.SellBuy.Price} با نرخ تسویه موقت {txtTasvieMovaghat.Text} بسته شد . لذا جهت مشاهده وضعیت خود به دفتر کل مراجعه فرمایید  ", ParseMode.Default, false, true, 0, mainKeyboardMarkup);
                    }
                    catch { }

                }//end  for
                try
                {
                    Task<Telegram.Bot.Types.Message> message = botClient.SendTextMessageAsync(TotalChatId, $"🧮 تسویه موقت : {txtTasvieMovaghat.Text}", ParseMode.Default, false, false);
                    await botClient.PinChatMessageAsync(message.Result.Chat.Id, message.Result.MessageId);
                }
                catch { }
                txtTasvieMovaghat.Text = "";
                _RobotIsOff = false;
                btnTasvieMovaghat.Enabled = true;
            }


        }

        private void BtnSendMessage_Click(object sender, EventArgs e)
        {


            if (txtSendMessage.Text != "")
            {

                Task<Telegram.Bot.Types.Message> message = botClient.SendTextMessageAsync(TotalChatId, txtSendMessage.Text, ParseMode.Html, false, false);
                if (chkPinMessage.Checked)
                {
                    botClient.PinChatMessageAsync(message.Result.Chat.Id, message.Result.MessageId);
                }
                txtSendMessage.Text = "";
            }
            else
            {
                MessageBox.Show("لطفاً پیام را وارد کنید");
            }

        }

        private void ChkPinMessage_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkOffRobot_CheckedChanged(object sender, EventArgs e)
        {
            _RobotIsOff = chkOffRobot.Checked;
        }

        private void MnReportbargain_Click(object sender, EventArgs e)
        {
            View.reports.frmReportComsion frmReportComsion = new View.reports.frmReportComsion();
            frmReportComsion.Show();
        }

        private void تنظیمتلورانسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.frmTelorans frmTelorans = new View.frmTelorans();
            frmTelorans.Show();
        }

        private void لیستمعاملاتبازToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.frmUsers.frmAllOpenBag frmAllOpenBag = new View.frmUsers.frmAllOpenBag();
            frmAllOpenBag.Show();
        }

        private void لیستمعاملاتبستهشدهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.frmUsers.frmAllCloseBag frmAllCloseBag = new View.frmUsers.frmAllCloseBag();
            frmAllCloseBag.Show();
        }


        private void خروجازتلگرامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("آیا برای خروج مطمئن هستید ؟ ربات غیر فعال می شود  ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void گزارشواریزبرداشتهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.reports.frmAllTransaction frmAllTransaction = new View.reports.frmAllTransaction();
            frmAllTransaction.Show();
        }

        private void لیستمعاملاتحراجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.reports.frmReportAllOnSale frmReportAllOnSale = new View.reports.frmReportAllOnSale();
            frmReportAllOnSale.Show();
        }

        private void ایجادنسخهپشتیبانازاطلاعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Context.mydbContext mydb = new Context.mydbContext();
                SaveFileDialog save = new SaveFileDialog();
                save.Title = "Backup Save ";
                save.Filter = "*.bak|*.bak";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    mydb.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, "BACKUP DATABASE " + mydb.Database.Connection.Database + " TO DISK = '" + save.FileName + "' WITH FORMAT ");
                    MessageBox.Show("نسخه پشتیبان با موفقیت ایجاد شد");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MsMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void سیستمامتیازبندیمعرفیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.reports.frmVerifyPoint frmVerifyPoint = new View.reports.frmVerifyPoint();
            frmVerifyPoint.Show();
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void Form1_MaximizedBoundsChanged(object sender, EventArgs e)
        {

        }

        private void Form1_MinimumSizeChanged(object sender, EventArgs e)
        {
            Hide();
            ShowInTaskbar = false;
        }

        private void ریستکلیاطلاعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا برای حذف کامل اطلاعات مطمن هستید ؟   ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (MessageBox.Show("با حذف اطلاعات دیگر قادر به بازیابی آنها نیستید   ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Repository.BargainSuccessRepository bargainSuccessRepository = new BargainSuccessRepository();
                    bargainSuccessRepository.DeleteAll();
                    Repository.SellBuyRepository sellBuyRepository = new SellBuyRepository();
                    sellBuyRepository.DeleteAll();
                    Repository.UserPointRepository userPointRepository = new UserPointRepository();
                    userPointRepository.DeleteAll();
                    Repository.UserBargainRepository userBargainRepository = new UserBargainRepository();
                    userBargainRepository.DeleteAll();
                    MessageBox.Show("اطلاعات با موفقیت حذف شد");
                }
            }
        }
    }
}


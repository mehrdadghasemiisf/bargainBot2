using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.utility
{
    public class UtilityRepository
    {
        public bool CheckNumberChar(string input)
        {
            return int.TryParse(input, out int result);
        }
        public string Convert2Shamsi(DateTime miladi)
        {
            try
            {

                PersianCalendar pc = new PersianCalendar();
                int m = pc.GetMonth(miladi);
                int dy = pc.GetDayOfMonth(miladi);

                return pc.GetYear(miladi) + "/" + ((m < 10) ? "0" + m.ToString() : m.ToString()).ToString() + "/" + ((dy < 10) ? "0" + dy.ToString() : dy.ToString()).ToString();
            }
            catch
            {
                return null;
            }
        }
        public  DateTime ShamsiTOMiladi(string shamsi)
        {
            try
            {
                PersianCalendar s = new PersianCalendar();
                int y, m, d;
                string[] sp = shamsi.Split('/');
                int.TryParse(sp[0], out y);
                int.TryParse(sp[1], out m);
                int.TryParse(sp[2], out d);

                return s.ToDateTime(y, m, d, 0, 0, 0, 0);
            }
            catch
            {
                return DateTime.Now;
            }
        }
        public string ToENNumber(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";


            input = input.Replace("۰", "0");
            input = input.Replace("١", "1");
            input = input.Replace("٢", "2");
            input = input.Replace("٣", "3");
            input = input.Replace("٤", "4");
            input = input.Replace("٥", "5");
            input = input.Replace("٦", "6");
            input = input.Replace("٧", "7");
            input = input.Replace("٨", "8");
            input = input.Replace("٩", "9");
            //فارسی
            input = input.Replace("۰", "0");
            input = input.Replace("۱", "1");
            input = input.Replace("۲", "2");
            input = input.Replace("۳", "3");
            input = input.Replace("۴", "4");
            input = input.Replace("۵", "5");
            input = input.Replace("۶", "6");
            input = input.Replace("۷", "7");
            input = input.Replace("۸", "8");
            input = input.Replace("۹", "9");

            string EnglishNumbers = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    EnglishNumbers += char.GetNumericValue(input, i);
                }
                else
                {
                    EnglishNumbers += input[i].ToString();
                }
            }



            return EnglishNumbers;
        }

        public string MessageHelp(Models.SettingsBot settings)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("💎⚖️قوانین اتاق معاملاتی آرتیمان ⚖️💎");
          
            return builder.ToString();
        }

        public string MessageAboutMe(Models.SettingsBot settings)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("اتاق معاملاتی آرتیمان");
            builder.AppendLine("");
            builder.AppendLine("🔹🔳🔸برای سیستم امتیاز دهی برای هر کاربر یک کد منحصر بفرد در نظر گرفته میشود که در زمان ثبت نام توسط کاربر جدید درج میگردد و برای معرف امتیاز در نظر گرفته شده بعد از تکمیل ثبت نام لحاظ میگردد");
            builder.AppendLine("🔹🔳🔸برای رعایت حریم خصوصی، در لحظه ثبت نام  کاربران میتوانند از اسم‌مستعار برای خود استفاده نمایند");
            builder.AppendLine("");
            builder.AppendLine("____");
            builder.AppendLine("");
            builder.AppendLine("🔹♦️🔸معاملگر میتواند با تایپ عبارت ( ۱خ سه رقم آخر مظنه) پوزیشن خرید و یا (۱ف سه رقم آخر مظنه) پوزیشن فروش باز نمایید.");
            builder.AppendLine("");
            builder.AppendLine("🔹♦️🔸هر لفظ جهت معامله تنها دو/۲ دقیقه اعتبار دارد . لفظ در صورت معامله تحت هیچ شرایطی حذف یا ابطال نمی‌شود.در صورتی که زیر دو/۲ دقیقه لفظ توسط کاربر دیگری گرفته نشود میتوان با ریپلای کردن حرف ن به لفظ اعلامی لفظ را کنسل کرد.");
            builder.AppendLine("");
            builder.AppendLine("____");
            builder.AppendLine("");
            builder.AppendLine("🔹🔵🔸حداقل معاملات ۱۰۰ گرم( یک واحد)میباشد.");
            builder.AppendLine("");
            builder.AppendLine("🔹🔵🔸بیعانه  هر ۱۰۰ گرم ۱/00۰/۰۰۰ تومان می باشد.");
            builder.AppendLine("");
            builder.AppendLine("🔹🔵🔸کمیسیون هر کیلو در جمع خرید و فروش  هر ۱۰۰ گرم ۱۰/۰۰۰ تومان می‌باشد.");
            builder.AppendLine("");
            builder.AppendLine("____");
            builder.AppendLine("");
            builder.AppendLine("🔸🔴🔹حد سود هر معامله برابر با وجه تضمین بوده");
            builder.AppendLine("🔸🔴🔹 و حد ضرر هر معامله ۹۰ درصد وجه تضمین بوده و با توجه به اخطار توسط سیستم و عدم توجه معاملگر مال حراج گذاشته خواهد شد.");
            builder.AppendLine("");
            builder.AppendLine("____");
            builder.AppendLine("");
            builder.AppendLine("🔸⚪️🔹امکان دریافت فیزیکی طلا آبشده و سکه در صورت درخواست و تسویه در محل مغازه مهیا  می باشد.");
            builder.AppendLine("");
            builder.AppendLine("🔸⚪️🔹تمامی خرید و فروش ها در صورت بسته نشدن معاملات یا عدم درخواست فیزیکی در هر شنبه  در ساعت ۱۳:۱۵ بر پایه خرید نقدی تهران تسویه خواهد خورد.");
            builder.AppendLine("");
            builder.AppendLine("____");
            builder.AppendLine("🔸🔘🔹تسویه فقط هر شنبه با نرخ پله خواهد بود.");
            builder.AppendLine("");
            builder.AppendLine("🔸🔘🔹پس از تسویه معاملات در هر هفته ربات سود یا ضرر معاملات را ثبت و به وجه تضمین اضافه یا کسر میکند.");
            builder.AppendLine("");
            builder.AppendLine("🔸🔘🔹جهت دریافت وجه تضمین یا سود بعد از تسویه اتاق در هر جمعه به حسابداری اطلاع دهید و در  روز تسویه  واریزی انجام خواهد شد.");
            builder.AppendLine("");
            builder.AppendLine("____");
            builder.AppendLine("");
            builder.AppendLine("🔸▫️🔹ساعت کار اتاق از 10 صبح تا 24  می‌باشد.");
            builder.AppendLine("");
            builder.AppendLine("🔸▫️🔹در صورت تمایل به تحویل فیزیکی کالا خریداری شده بعد از  واریز۸۰درصد مبلغ معامله گر حداکثر تا ۲۴ ساعت از لحظه ثبت  حق مراجعه به ادرس مغازه جهت تحویل فیزیکی دارد در غیر اینصورت جنس خریداری شده به قیمت روز به حراج گزاشته میشود.");
            builder.AppendLine("");
            builder.AppendLine("____");
            builder.AppendLine("");
            builder.AppendLine("🔸◾️🔹 این گروه معاملاتی تابع قوانین و مقررات جمهوری اسلامی ایران  است. تمامی معاملات  براساس اسم واقعی همكاران صورت گرفته و اسم همكاران با کارت بانکی بايد همخوانی داشته باشد.");
            builder.AppendLine("");
            builder.AppendLine("🔸◾️🔹گروه هیچ گونه مسئولیتی در خصوص قطعی نت سرعت کم نت و مشکلات مربوط به فیلترینگ ندارد.");
            builder.AppendLine("");
            builder.AppendLine("🔸◾️🔹معاملات گروه براساس مواد ١٠ و ١٩٠ قانون مدنی و قانون تجارت الکترونیک صورت گرفته و  همكاران با ورود و ثبت نام در  گروه و تایید دکمه قبول ، علم و آگاهی و رضایت خویش را از نحوه و کیفیت معاملات و سایر موارد منعکس در فوق  را  اعلام و حق هرگونه اعتراض را از خود سلب مینماید .");
            builder.AppendLine("");
            return builder.ToString();
        }


        public string MessageHelpPoint()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("😳در صورت رسیدن امتیاز هر کاربر به عدد حد نصاب لازم میتواند به اختیار از افر های زیر استفاده کند.");
            builder.AppendLine("🤗تخفیف در حق کمسیون در معاملات تا ۴ تومن در معاملات به مدت یک ماه=۱۰۰امتیاز");
            builder.AppendLine("");
            builder.AppendLine("🤭حق استفاده از اهرم لوریج (معامله تا سه برابر وجه تضمین سپرده شده)=۷۰ امتیاز");
            builder.AppendLine("");
            builder.AppendLine("😋یک‌وعده شام به همراه خانواده (حداکثر ۴ نفر)در لاکچری ترین رستوران شهر به حساب طلاذین=۱۳۰امتیاز");
            builder.AppendLine("");
            builder.AppendLine("🤯شرکت در قرعه کشی ماهانه برای یک‌سفر تک نفره تفریحی=۴۰۰ امتیاز");
            builder.AppendLine("");
            builder.AppendLine("________________");
            builder.AppendLine("");
            builder.AppendLine("🤩نحوه سیستم امتیازدهی 🤩");
            builder.AppendLine("");
            builder.AppendLine("📝هر کاربر میتواند به ازای معاملات درست ثبت شده در اتاق دمو توسط ادمین اتاق تستی= تا حداکثر ۲۰ امتیاز کسب کنید.");
            builder.AppendLine("");
            builder.AppendLine(" 🤝معرفی نفر فعال برای عضویت به");
            builder.AppendLine("");
            builder.AppendLine(" اعضای هر نفر= ۱۰ امتیاز");
            builder.AppendLine("👍اعضا کانال وی ای پی = ۵امتیاز ");
            builder.AppendLine("");
            builder.AppendLine("🤚معاملات بیش از ۱۰ کیلو در هفته =۲۰امتیاز");

            return builder.ToString();
        }


    }
}

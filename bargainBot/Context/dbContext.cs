using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.Context
{
    public class mydbContext : DbContext
    {
        public IDbSet<Models.UserBargain> UserBargains { get; set; }
        public IDbSet<Models.SettingsBot> SettingsBot { get; set; }
        public IDbSet<Models.SellBuy> SellBuy { get; set; }
        public IDbSet<Models.SellBuyType> SellBuyType { get; set; }
        public IDbSet<Models.BargainSuccess> BargainSuccess { get; set; }
        public IDbSet<Models.Consion> Consion { get; set; }


        public IDbSet<Models.Transaction> Transaction { get; set; }
        public IDbSet<Models.TransactionType> TransactionType { get; set; }
        public IDbSet<Models.UserPoint> UserPoint { get; set; }

        public mydbContext() : base("con")
        {
            Database.SetInitializer(new OnlineAcademyDBInitializer());
        }
    }

    public class OnlineAcademyDBInitializer : CreateDatabaseIfNotExists<mydbContext>
    {
        protected override void Seed(mydbContext context)
        {
            IList<Models.SellBuyType> defaultStandardsdays = new List<Models.SellBuyType>();

            defaultStandardsdays.Add(new Models.SellBuyType() { Id = 1, Name = "فروش" });
            defaultStandardsdays.Add(new Models.SellBuyType { Id = 2, Name = "خرید" });


            foreach (var item in defaultStandardsdays)
            {
                context.SellBuyType.Add(item);
            }





            base.Seed(context);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.Models
{
    public class BargainSuccess
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("SellBuy")]
        public long SellBuy_Id { get; set; }
        public virtual SellBuy SellBuy { get; set; }
        public DateTime DateTime { get; set; }
        public int count { get; set; }
        //تاریخ تسویه
        public DateTime Tasvie { get; set; }

        [ForeignKey("FirstUserBargain_1")]
        public long? UserBargain_Id_1 { get; set; }
        public virtual UserBargain FirstUserBargain_1 { get; set; }

        [ForeignKey("SecendUserBargain_2")]
        public long? UserBargain_Id_2 { get; set; }
        public virtual UserBargain SecendUserBargain_2 { get; set; }


        public int SellBuyType_Id { get; set; }
        public int Price2 { get; set; }
        public int Sod { get; set; }
        public int NowMazane { get; set; }

        public bool OnSale { get; set; }

    }
}

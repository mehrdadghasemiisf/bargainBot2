using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.Models
{
    public class SellBuy
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("UserBargain")]
        public long UserBargain_Id { get; set; }
        public virtual UserBargain UserBargain { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public long MessageId { get; set; }
        public DateTime DateTime { get; set; }

        [ForeignKey("SellBuyType")]
        public int SellBuyType_Id { get; set; }
        public virtual SellBuyType SellBuyType { get; set; }
        /// <summary>
        /// مانده سهم 
        /// </summary>
        public int Remain { get; set; }
    }
}

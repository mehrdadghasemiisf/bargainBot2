using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime DateTime { get; set; }
        public string Disc { get; set; }

        [ForeignKey("UserBargain")]
        public long UserBargain_Id { get; set; }
        public virtual UserBargain UserBargain { get; set; }


        [ForeignKey("TransactionType")]
        public int TransactionType_Id { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}

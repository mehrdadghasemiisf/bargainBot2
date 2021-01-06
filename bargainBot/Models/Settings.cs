using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.Models
{
    public class SettingsBot
    {
        [Key]
        public int id { get; set; }
        public int Price { get; set; }
        public int PriceCount { get; set; }
        public long Mazane { get; set; }
        public long Telorans { get; set; }

        public bool IsOpen { get; set; }

        public int OnSaleTelorans { get; set; }
        public DateTime LastOnSale { get; set; }
    }
}

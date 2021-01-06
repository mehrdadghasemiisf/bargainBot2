using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.Models
{
    public class SellBuyType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

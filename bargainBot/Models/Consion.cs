using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.Models
{
    public class Consion
    {

        public long Id { get; set; }

        [ForeignKey("BargainSuccess")]
        public long BargainSuccess_Id { get; set; }
        public virtual BargainSuccess BargainSuccess { get; set; }

        public int  Price { get; set; }
        public DateTime DateTime { get; set; }


    }
}

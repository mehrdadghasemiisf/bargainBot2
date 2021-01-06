using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.ViewModels
{
    public class BargainSuccessReportViewModel
    {
        public long Id { get; set; }
        public string Date { get; set; }
        public int Price_Buy { get; set; }
        public int Price_Sell { get; set; }
        public int Sod { get; set; }
        public int Comision { get; set; }
    }
}

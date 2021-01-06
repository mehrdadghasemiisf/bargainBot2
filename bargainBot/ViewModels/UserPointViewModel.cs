using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.ViewModels
{
    public class UserPointViewModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string First_FullName { get; set; }
        public string Suggest_FullName { get; set; }
        public string Verify { get; set; }
        public bool VerifyBool { get; set; }
    }
}

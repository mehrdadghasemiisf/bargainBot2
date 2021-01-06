using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.Models
{
    public class UserPoint
    {
        public int Id { get; set; }
        /// <summary>
        /// ای دی ثبت نام کننده
        /// </summary>
        [ForeignKey("FirstUserBargain_1")]
        public long? UserBargain_Id_1 { get; set; }
        public virtual UserBargain FirstUserBargain_1 { get; set; }

        /// <summary>
        /// آی دی معرف
        /// </summary>
        [ForeignKey("SecendUserBargain_2")]
        public long? UserBargain_Id_2 { get; set; }
        public virtual UserBargain SecendUserBargain_2 { get; set; }
        public DateTime Date { get; set; }
        public bool IsVerify { get; set; } = false;

        [NotMapped]
        public string DateString
        {
            get
            {
                try
                {
                    utility.UtilityRepository utility = new utility.UtilityRepository();
                   return utility.Convert2Shamsi(Date);
                }
                catch
                {
                    return "0000/00/00";

                }
            }
        }
    }
}

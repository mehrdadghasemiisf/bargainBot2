using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.Models
{
    public class UserBargain
    {
        //  private Repository.SettingBotRepository settingBotRepository;
        public UserBargain()
        {
            //   settingBotRepository = new Repository.SettingBotRepository();
        }
        [Key]
        public long Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Family { get; set; }
        [MaxLength(11)]
        public string Mobile { get; set; }
        public string BankCard { get; set; }
        public string Username { get; set; }
        public string Chatid { get; set; }
        public long Userid { get; set; }
        public DateTime RegisterDate { get; set; }
        [NotMapped]
        public long Garranty
        {
            get
            {
                try
                {
                    return PriceGarranty / 1000000;
                }
                catch
                {
                    return 0;

                }
            }
        }
        [NotMapped]
        public long Gold
        {
            get
            {
                try
                {
                    return Garranty*100;
                }
                catch
                {
                    return 0;

                }
            }
        }


        public long PriceGarranty { get; set; }
        public bool Verify { get; set; }

        [InverseProperty("FirstUserBargain_1")]
        public virtual ICollection<BargainSuccess> BargainSuccessAsFirstUser { get; set; }
        [InverseProperty("SecendUserBargain_2")]
        public virtual ICollection<BargainSuccess> BargainSuccessAsSecendUser { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsNowSuggestWait { get; set; } = false;

        public string AliasNames { get; set; } = "";


    }
}

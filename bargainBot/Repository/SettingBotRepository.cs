using bargainBot.Context;
using bargainBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.Repository
{
    public class SettingBotRepository
    {
        mydbContext _mydb;
        public SettingBotRepository()
        {
            _mydb = new mydbContext();
        }

        public SettingsBot GetSetting()
        {
            return _mydb.SettingsBot.FirstOrDefault();
        }

        public SettingsBot UpdateMazane(int Mazane)
        {
            var tmp = _mydb.SettingsBot.FirstOrDefault();
            tmp.Mazane = Mazane;
            return tmp;
        }
        public async Task Save()
        {
            var task = _mydb.SaveChangesAsync();
            try
            {
                await task;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

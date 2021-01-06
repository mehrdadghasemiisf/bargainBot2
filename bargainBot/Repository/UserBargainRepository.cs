using bargainBot.Context;
using bargainBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.Repository
{
    public class UserBargainRepository : IDisposable
    {
        mydbContext _mydb;
        public UserBargainRepository()
        {
            _mydb = new mydbContext();
        }

        public bool ExistAliasName(string name)
        {
            return _mydb.UserBargains.Any(x => x.AliasNames == name.Trim());
        }

        public UserBargain GetFirstAdmin()
        {
            return _mydb.UserBargains.FirstOrDefault(x => x.IsAdmin);
        }
        public void DeleteAll()
        {
            _mydb.Database.ExecuteSqlCommand("delete  from UserBargains");
        }

        public List<UserBargain> SearchUsers(string key)
        {

            return _mydb.UserBargains.Where(x => (x.Family.Contains(key) || x.Name.Contains(key) || key == "" || x.AliasNames.Contains(key))).OrderByDescending(x => x.RegisterDate).ToList();


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">ای دی داخلی</param>
        public bool DeleteUser(long id)
        {
            if (!_mydb.UserBargains.Any(x => x.Userid == id))
            {
                var tmp = _mydb.UserBargains.FirstOrDefault(x => x.Id == id);
                if(tmp!=null)
                {
                    _mydb.UserBargains.Remove(tmp);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }



        public void AddUser(UserBargain user)
        {
            if (!_mydb.UserBargains.Any(x => x.Userid == user.Userid))
            {
                _mydb.UserBargains.Add(user);
            }
        }

        public UserBargain GetUser(long UserId)
        {
            return _mydb.UserBargains.FirstOrDefault(x => x.Userid == UserId);
        }

        public UserBargain GetUserWithMyID(long id)
        {
            return _mydb.UserBargains.FirstOrDefault(x => x.Id == id);
        }

        public UserBargain GetUserWithUserIdTelegram(long userid)
        {
            return _mydb.UserBargains.FirstOrDefault(x => x.Userid == userid);

        }

        public async Task<UserBargain> UpdateAsync(UserBargain UserBargain)
        {
            UserBargain myuser = GetUserWithUserIdTelegram(UserBargain.Userid);

            myuser.Name = UserBargain.Name;
            myuser.Family = UserBargain.Family;
            myuser.Mobile = UserBargain.Mobile;
            myuser.BankCard = UserBargain.BankCard;
            myuser.Verify = UserBargain.Verify;
            await Save();
            return myuser;

        }

        public UserBargain Update(UserBargain UserBargain)
        {
            UserBargain myuser = GetUserWithMyID(UserBargain.Id);

            myuser.Name = UserBargain.Name;
            myuser.Family = UserBargain.Family;
            myuser.Mobile = UserBargain.Mobile;
            myuser.BankCard = UserBargain.BankCard;
            myuser.Verify = UserBargain.Verify;
            myuser.IsAdmin = UserBargain.IsAdmin;
            myuser.AliasNames = UserBargain.AliasNames;
            Save();
            return myuser;

        }

        public bool CheckUserVerify(long UserId)
        {
            return _mydb.UserBargains.Any(x => x.Userid == UserId && x.Verify == true);
        }

        public bool CheckExist(long UserId)
        {
            return _mydb.UserBargains.Any(x => x.Userid == UserId);
        }


        public UserBargain Update_Sod(long id, int Sood)
        {
            var tmp = _mydb.UserBargains.FirstOrDefault(x => x.Id == id);
            if (tmp != null)
            {
                tmp.PriceGarranty += Sood;

                return tmp;
            }
            else
            {
                return null;
            }
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

        public void SaveNotAsync()
        {
             _mydb.SaveChanges();
        }


        public void Dispose()
        {
            _mydb = null;
        }
    }
}

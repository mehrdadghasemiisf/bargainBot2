using bargainBot.Context;
using bargainBot.Models;
using bargainBot.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.Repository
{
    public class UserPointRepository : IDisposable
    {
        mydbContext _mydb;
        public UserPointRepository()
        {
            _mydb = new mydbContext();
        }
        public void DeleteAll()
        {
            _mydb.Database.ExecuteSqlCommand("delete  from UserPoints");
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
        public void Save2()
        {
           _mydb.SaveChanges();
           
        }
        public void Dispose()
        {
            _mydb = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid">ای دی داخلی</param>
        /// <returns></returns>
        public bool ExistVerifyPoint(long userid)
        {
            return _mydb.UserPoint.Any(x => x.UserBargain_Id_1 == userid);
        }

        public bool Add(UserPoint userPoint)
        {

            _mydb.UserPoint.Add(userPoint);
            return true;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid">ای دی داخلی</param>
        /// <returns></returns>
        public List<UserPoint> GetUserPoints(long userid)
        {
            return _mydb.UserPoint.Where(x => x.UserBargain_Id_1 == userid && x.IsVerify).OrderByDescending(x => x.Id).ToList();
        }
        public List<UserPointViewModel> GetUserPointsTrue()
        {
            var tmp = _mydb.UserPoint.Where(x => x.IsVerify).OrderByDescending(x => x.Id).ToList();
            List<UserPointViewModel> userPointViewModels_list = new List<UserPointViewModel>();
            foreach (UserPoint item in tmp)
            {
                userPointViewModels_list.Add(new UserPointViewModel
                {
                    Date = item.DateString,
                    First_FullName = item.FirstUserBargain_1.Name + " " + item.FirstUserBargain_1.Family,
                    Id = item.Id,
                    Suggest_FullName = item.SecendUserBargain_2.Name + " " + item.SecendUserBargain_2.Family,
                    Verify = item.IsVerify ? "تایید شده" : "تایید نشده",
                    VerifyBool = item.IsVerify

                });
            }
            return userPointViewModels_list;
        }
        public List<UserPointViewModel> GetUserPointsFalse()
        {
            var tmp = _mydb.UserPoint.Where(x => !x.IsVerify).OrderByDescending(x => x.Id).ToList();
            List<UserPointViewModel> userPointViewModels_list = new List<UserPointViewModel>();
            foreach (UserPoint item in tmp)
            {
                userPointViewModels_list.Add(new UserPointViewModel
                {
                    Date = item.DateString,
                    First_FullName = item.FirstUserBargain_1.Name + " " + item.FirstUserBargain_1.Family,
                    Id = item.Id,
                    Suggest_FullName = item.SecendUserBargain_2.Name + " " + item.SecendUserBargain_2.Family,
                    Verify = item.IsVerify ? "تایید شده" : "تایید نشده",
                    VerifyBool = item.IsVerify

                });
            }
            return userPointViewModels_list;
        }
        public List<UserPointViewModel> GetUserPointsAll()
        {

            var tmp = _mydb.UserPoint.OrderByDescending(x => x.Id).ToList();
            List<UserPointViewModel> userPointViewModels_list = new List<UserPointViewModel>();
            foreach (UserPoint item in tmp)
            {
                userPointViewModels_list.Add(new UserPointViewModel
                {
                    Date = item.DateString,
                    First_FullName = item.FirstUserBargain_1.Name + " " + item.FirstUserBargain_1.Family,
                    Id = item.Id,
                    Suggest_FullName = item.SecendUserBargain_2.Name + " " + item.SecendUserBargain_2.Family,
                    Verify = item.IsVerify ? "تایید شده" : "تایید نشده",
                    VerifyBool = item.IsVerify
                });
            }
            return userPointViewModels_list;
        }
        public UserPoint GetUserPoint(int Pointid)
        {
            return _mydb.UserPoint.FirstOrDefault(x => x.Id == Pointid);
        }

        public async Task<UserPoint> UpdateAsync(UserPoint userPoint)
        {
            UserPoint mypoint = GetUserPoint(userPoint.Id);

            mypoint.Date = userPoint.Date;
            mypoint.IsVerify = userPoint.IsVerify;
            await Save();
            return mypoint;

        }

        public UserPoint Update(UserPoint userPoint)
        {
            UserPoint mypoint = GetUserPoint(userPoint.Id);

            mypoint.Date = userPoint.Date;
            mypoint.IsVerify = userPoint.IsVerify;
            return mypoint;

        }

        public async Task<UserPoint> UserPointAsync(UserPoint userPoint)
        {
            UserPoint mypoint = GetUserPoint(userPoint.Id);

            mypoint.Date = userPoint.Date;
            mypoint.IsVerify = userPoint.IsVerify;
            await Save();
            return mypoint;

        }
        public async Task<bool> DeleteAsync(int pointid)
        {
            UserPoint mypoint = GetUserPoint(pointid);
            _mydb.UserPoint.Remove(mypoint);
            await Save();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid">ای دی داخلی</param>
        /// <returns></returns>
        public int CountPoint(long userid)
        {
            return _mydb.UserPoint.Count(x => x.UserBargain_Id_1 == userid && x.IsVerify);
        }

        public bool DeleteFirst(long userid)
        {
            var tmp = _mydb.UserPoint.FirstOrDefault(x => x.IsVerify && x.UserBargain_Id_1 == userid);
            UserPoint mypoint = _mydb.UserPoint.Remove(tmp);
            _mydb.UserPoint.Remove(mypoint);
            return true;
        }




    }
}

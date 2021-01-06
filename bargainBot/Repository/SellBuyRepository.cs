using bargainBot.Context;
using bargainBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.Repository
{

    public class SellBuyRepository : IDisposable
    {
        mydbContext _mydb;
        public SellBuyRepository()
        {
            _mydb = new mydbContext();
        }

        public SellBuy Add(SellBuy sellBuy)
        {
            return _mydb.SellBuy.Add(sellBuy);
        }
        public SellBuy GetSellBuy(long selbuyid)
        {
            return _mydb.SellBuy.FirstOrDefault(x => x.Id == selbuyid);
        }


        public int UpdateRemin(long LafzId, int RequestNumber, int count)
        {
           
                if (count == 0)
                {
                    return 0;
                }
                if (RequestNumber == 0)
                {
                    return 0;
                }
                var tmp = _mydb.SellBuy.FirstOrDefault(x => x.Id == LafzId);
                if (tmp != null)
                {
                    if (tmp.Remain <= 0)
                    {
                        return 0;
                    }
                    int rem = tmp.Remain - RequestNumber;
                    tmp.Remain = rem;
                    SaveNotAsync();
                    return rem;

                }
                else
                {
                    return 0;
                }
           
        }

        public bool Delete(long sellbuyID)
        {
            if (!_mydb.BargainSuccess.Any(x => x.SellBuy_Id == sellbuyID))
            {
                var tmp = _mydb.SellBuy.FirstOrDefault(x => x.Id == sellbuyID);
                _mydb.SellBuy.Remove(tmp);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DeleteAll()
        {
            _mydb.Database.ExecuteSqlCommand("delete  from SellBuys");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <param name="user"></param>
        /// <param name="type">1=Sel & 2=Buy</param>
        /// <returns></returns>
        public int CountOpenLafz(DateTime time, UserBargain user, int type)
        {
            var tmp_sel = _mydb.SellBuy.Where(x => x.DateTime >= time && x.UserBargain_Id == user.Id && x.SellBuyType_Id == type);

            int selbuy_count = 0;
            try
            {
                selbuy_count = tmp_sel.Sum(x => x.Count);
            }
            catch { }
            int bargen_count = 0;
            foreach (var item in tmp_sel)
            {
                try
                {
                    bargen_count += _mydb.BargainSuccess.Where(x => x.SellBuy_Id == item.Id && x.Price2 == 0).Sum(x => x.count);
                }
                catch { }
            }

            return selbuy_count - bargen_count;

        }

        public SellBuy GetLafzByMessageId(long messageid)
        {

            return _mydb.SellBuy.FirstOrDefault(x => x.MessageId == messageid);
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


        public int DeleteTemp(long user_id, int SelBuyType, DateTime time)
        {

            var tmp = _mydb.SellBuy.Where(x => !_mydb.BargainSuccess.Any(y => y.SellBuy_Id == x.Id) && x.SellBuyType_Id == SelBuyType && x.UserBargain_Id == user_id && x.DateTime <= time);

            foreach (var item in tmp)
            {
                _mydb.SellBuy.Remove(item);
            }
            return tmp.Count();
        }
    }
}

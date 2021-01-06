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
    public class BargainSuccessRepository
    {
        mydbContext _mydb;
        public BargainSuccessRepository()
        {
            _mydb = new mydbContext();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_id">آی دی داخلی</param>
        /// <returns></returns>
        public List<BargainSuccessReportViewModel> GetClose_BargainSuccessReportViews(long user_id)
        {

            var tmp = _mydb.BargainSuccess.Where(x => x.UserBargain_Id_1 == user_id).OrderByDescending(x => x.Id).ToList();
            List<BargainSuccessReportViewModel> bargainSuccessViewModel_list = new List<BargainSuccessReportViewModel>();
            ComisonRepository comisonRepository = new ComisonRepository();
            utility.UtilityRepository utility = new utility.UtilityRepository();
            foreach (BargainSuccess item in tmp)
            {
                BargainSuccessReportViewModel successViewModel = new BargainSuccessReportViewModel();
                successViewModel.Date = utility.Convert2Shamsi(item.DateTime) + " " + item.DateTime.ToShortTimeString();
                successViewModel.Id = item.Id;
                try

                {
                    successViewModel.Sod = item.Sod;
                }
                catch
                {
                    successViewModel.Sod = 0;

                }
                try
                {
                    successViewModel.Comision = comisonRepository.Get(item).Price;
                }
                catch
                {
                    successViewModel.Comision = 0;
                }
                if (item.SellBuyType_Id == 1)
                {
                    try
                    {
                        successViewModel.Price_Sell = item.SellBuy.Price;
                    }
                    catch
                    {
                        successViewModel.Price_Sell = 0;

                    }
                    try

                    {
                        successViewModel.Price_Buy = item.Price2;
                    }
                    catch
                    {
                        successViewModel.Price_Buy = 0;

                    }

                }
                else
                {
                    try
                    {
                        successViewModel.Price_Sell = item.Price2;
                    }
                    catch
                    {
                        successViewModel.Price_Sell = 0;


                    }
                    try
                    {
                        successViewModel.Price_Buy = item.SellBuy.Price;
                    }
                    catch
                    {
                        successViewModel.Price_Buy = 0;

                    }
                }
                bargainSuccessViewModel_list.Add(successViewModel);

            }
            return bargainSuccessViewModel_list;



        }



        public async Task<bool> Delete(long id)
        {
            BargainSuccess ss = _mydb.BargainSuccess.Find(id);
            _mydb.BargainSuccess.Remove(ss);
            var task = _mydb.SaveChangesAsync();
            try
            {
                await task;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid">ای دی داخلی</param>
        /// <returns></returns>
        public long AverageBuy(long userid)
        {
            var tmp = _mydb.BargainSuccess.Where(x => x.Price2 == 0 && x.UserBargain_Id_1 == userid && x.SellBuyType_Id == 2).ToList();

            return tmp.Sum(x => x.SellBuy.Price) / tmp.Count;



        }

        public long AverageSell(long userid)
        {
            var tmp = _mydb.BargainSuccess.Where(x => x.Price2 == 0 && x.UserBargain_Id_1 == userid && x.SellBuyType_Id == 1).ToList();

            return tmp.Sum(x => x.SellBuy.Price) / tmp.Count;



        }


        public void DeleteAll()
        {
            _mydb.Database.ExecuteSqlCommand("delete  from BargainSuccesses");
        }





        public List<BargainSuccess> GetAllCallMargin()
        {
            return _mydb.BargainSuccess.Where(x => x.Price2 == 0).ToList();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid">آی دی داخلی</param>
        /// <returns></returns>
        public List<ViewModels.BargainSuccessViewModel> GetAllOpenSellBuy(long userid)
        {
            var tmp = _mydb.BargainSuccess.Where(x => x.Price2 == 0 && x.UserBargain_Id_1 == userid).OrderByDescending(x => x.Id).ToList();
            List<BargainSuccessViewModel> bargainSuccessViewModel_list = new List<BargainSuccessViewModel>();
            foreach (BargainSuccess item in tmp)
            {
                BargainSuccessViewModel successViewModel = new BargainSuccessViewModel();
                successViewModel.Date = item.DateTime.ToString();
                successViewModel.FullName1 = item.FirstUserBargain_1.Name + " " + item.FirstUserBargain_1.Family;
                successViewModel.FullName2 = item.SecendUserBargain_2.Name + " " + item.SecendUserBargain_2.Family;
                successViewModel.Id = item.Id;
                successViewModel.Price = item.SellBuy.Price;
                successViewModel.Sod = item.Sod;
                if (item.SellBuyType_Id == 1)
                {
                    successViewModel.Type = "فروش";
                }
                else
                {
                    successViewModel.Type = "خرید";
                }
                successViewModel.NowMazane = item.NowMazane;
                bargainSuccessViewModel_list.Add(successViewModel);

            }
            return bargainSuccessViewModel_list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid">آی دی داخلی</param>
        /// <returns></returns>
        public List<ViewModels.BargainSuccessViewModel> GetAllOpenSellBuy(DateTime DateStart, DateTime DateEnd)
        {
            var tmp = _mydb.BargainSuccess.Where(x => x.Price2 == 0 && (x.DateTime >= DateStart && x.DateTime <= DateEnd)).OrderByDescending(x => x.Id).ToList();
            List<BargainSuccessViewModel> bargainSuccessViewModel_list = new List<BargainSuccessViewModel>();
            utility.UtilityRepository utility = new utility.UtilityRepository();
            foreach (BargainSuccess item in tmp)
            {
                BargainSuccessViewModel successViewModel = new BargainSuccessViewModel();
                successViewModel.Date = utility.Convert2Shamsi(item.DateTime);
                successViewModel.FullName1 = item.FirstUserBargain_1.Name + " " + item.FirstUserBargain_1.Family;
                successViewModel.FullName2 = item.SecendUserBargain_2.Name + " " + item.SecendUserBargain_2.Family;
                successViewModel.Id = item.Id;
                successViewModel.Price = item.SellBuy.Price;
                successViewModel.Sod = item.Sod;
                if (item.SellBuyType_Id == 1)
                {
                    successViewModel.Type = "فروش";
                }
                else
                {
                    successViewModel.Type = "خرید";
                }
                successViewModel.NowMazane = item.NowMazane;
                bargainSuccessViewModel_list.Add(successViewModel);

            }
            return bargainSuccessViewModel_list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid">آی دی داخلی</param>
        /// <returns></returns>
        public List<ViewModels.BargainSuccessViewModel> GetAllCloseBag(long userid)
        {
            var tmp = _mydb.BargainSuccess.Where(x => x.Price2 > 0 && x.UserBargain_Id_1 == userid).OrderByDescending(x => x.Id).ToList();
            List<BargainSuccessViewModel> bargainSuccessViewModel_list = new List<BargainSuccessViewModel>();
            utility.UtilityRepository utility = new utility.UtilityRepository();

            foreach (BargainSuccess item in tmp)
            {
                BargainSuccessViewModel successViewModel = new BargainSuccessViewModel();
                successViewModel.Date = utility.Convert2Shamsi(item.DateTime);
                successViewModel.Tasvie = utility.Convert2Shamsi(item.Tasvie);
                successViewModel.FullName1 = item.FirstUserBargain_1.Name + " " + item.FirstUserBargain_1.Family;
                successViewModel.FullName2 = item.SecendUserBargain_2.Name + " " + item.SecendUserBargain_2.Family;
                successViewModel.Id = item.Id;
                successViewModel.Price = item.SellBuy.Price;
                successViewModel.Price2 = item.Price2;
                successViewModel.Sod = item.Sod;
                if (item.SellBuyType_Id == 1)
                {
                    successViewModel.Type = "فروش";
                }
                else
                {
                    successViewModel.Type = "خرید";
                }
                successViewModel.NowMazane = item.NowMazane;
                bargainSuccessViewModel_list.Add(successViewModel);

            }
            return bargainSuccessViewModel_list;
        }

        public List<ViewModels.BargainSuccessViewModel> GetAllCloseBag(DateTime dateStart, DateTime dateEnd)
        {
            var tmp = _mydb.BargainSuccess.Where(x => x.Price2 > 0 && (x.DateTime >= dateStart && x.DateTime <= dateEnd)).OrderByDescending(x => x.Id).ToList();
            List<BargainSuccessViewModel> bargainSuccessViewModel_list = new List<BargainSuccessViewModel>();
            ComisonRepository comisonRepository = new ComisonRepository();
            utility.UtilityRepository utility = new utility.UtilityRepository();

            foreach (BargainSuccess item in tmp)
            {
                BargainSuccessViewModel successViewModel = new BargainSuccessViewModel();
                successViewModel.Date = utility.Convert2Shamsi(item.DateTime);
                successViewModel.Tasvie = utility.Convert2Shamsi(item.Tasvie);
                successViewModel.FullName1 = item.FirstUserBargain_1.Name + " " + item.FirstUserBargain_1.Family;
                successViewModel.FullName2 = item.SecendUserBargain_2.Name + " " + item.SecendUserBargain_2.Family;
                successViewModel.Id = item.Id;
                successViewModel.Price = item.SellBuy.Price;
                successViewModel.Price2 = item.Price2;
                successViewModel.Sod = item.Sod;
                successViewModel.TypeID = item.SellBuyType_Id;

                successViewModel.Comision = comisonRepository.Get(item).Price;
                if (item.SellBuyType_Id == 1)
                {
                    successViewModel.Type = "فروش";
                }
                else
                {
                    successViewModel.Type = "خرید";
                }
                successViewModel.NowMazane = item.NowMazane;
                bargainSuccessViewModel_list.Add(successViewModel);

            }
            return bargainSuccessViewModel_list;
        }


        public void UpdateSod(List<BargainSuccess> BargainSuccess, int sod)
        {
            foreach (var item in BargainSuccess)
            {
                item.Sod = sod;
                //var tmp = _mydb.BargainSuccess.FirstOrDefault(x => x.Id == item.Id);
                //if (tmp != null)
                //{
                //    tmp.Sod = sod;
                // //   await Save();
                //}
            }

        }

        public bool Exist_Success(long SelBuyId)
        {
            return _mydb.BargainSuccess.Any(x => x.SellBuy_Id == SelBuyId);
        }


        public int CountSellId(long selid, long user_id)
        {
            return _mydb.BargainSuccess.Count(x => x.SellBuy_Id == selid && x.UserBargain_Id_1 == user_id);
        }

        public BargainSuccess Add(BargainSuccess bargainSuccess)
        {
            return _mydb.BargainSuccess.Add(bargainSuccess);

        }

        public List<BargainSuccess> GetListLastMonth(long UserId)
        {
            DateTime lm = DateTime.Now.AddMonths(-1);
            return _mydb.BargainSuccess.Where(x => x.FirstUserBargain_1.Userid == UserId && x.Price2 != 0 && x.DateTime >= lm && x.DateTime <= DateTime.Now).ToList();

        }


        public List<BargainSuccess> GetAll()
        {
            return _mydb.BargainSuccess.ToList();
        }

        //public decimal Average_open_buy(long userid)
        //{
        //    //   var tmp = _mydb.BargainSuccess.(x => x.UserBargain_Id_1 == userid && x.Price2 == 0 && x.SellBuyType_Id == 2);

        //    var items = _mydb.BargainSuccess
        //.Where(x => x.UserBargain_Id_1 == userid && x.SellBuyType_Id == 2 && x.Price2 == 0)
        //.Select(store => new { store.SellBuy.Price });


        //    decimal mysum = 0;

        //    foreach (var item in items)
        //    {
        //        mysum += item.Price;
        //    }

        //    if (mysum <= 0)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return mysum / items.Count();
        //    }
        //}

        ////public decimal Average_open_buy_2(long userid)
        ////{
        ////    //   var tmp = _mydb.BargainSuccess.(x => x.UserBargain_Id_1 == userid && x.Price2 == 0 && x.SellBuyType_Id == 2);

        ////    var items = _mydb.BargainSuccess
        ////.Where(x => x.UserBargain_Id_1 == userid && x.SellBuyType_Id == 2 && x.Price2 == 0)
        ////.Select(store => new { store.SellBuy.Price });


        ////    decimal mysum = 0;

        ////    foreach (var item in items)
        ////    {
        ////        mysum += item.Price;
        ////    }

        ////    if (mysum <= 0)
        ////    {
        ////        return 0;
        ////    }
        ////    else
        ////    {
        ////        return mysum / items.Count();
        ////    }
        ////}

        //public decimal Average_open_Sell(long userid)
        //{
        //    //   var tmp = _mydb.BargainSuccess.(x => x.UserBargain_Id_1 == userid && x.Price2 == 0 && x.SellBuyType_Id == 2);

        //    var items = _mydb.BargainSuccess
        //.Where(x => x.UserBargain_Id_1 == userid && x.SellBuyType_Id == 1 && x.Price2 == 0)
        //.Select(store => new { store.SellBuy.Price });


        //    decimal mysum = 0;

        //    foreach (var item in items)
        //    {
        //        mysum += item.Price;
        //    }

        //    if (mysum <= 0)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return mysum / items.Count();
        //    }
        //}

        ////public decimal Average_open_Sell_2(long userid)
        ////{
        ////    //   var tmp = _mydb.BargainSuccess.(x => x.UserBargain_Id_1 == userid && x.Price2 == 0 && x.SellBuyType_Id == 2);

        ////    var items = _mydb.BargainSuccess
        ////.Where(x => x.UserBargain_Id_1 == userid && x.SellBuyType_Id == 1 && x.Price2 == 0)
        ////.Select(store => new { store.SellBuy.Price });


        ////    decimal mysum = 0;

        ////    foreach (var item in items)
        ////    {
        ////        mysum += item.Price;
        ////    }

        ////    if (mysum <= 0)
        ////    {
        ////        return 0;
        ////    }
        ////    else
        ////    {
        ////        return mysum / items.Count();
        ////    }
        ////}


        public List<BargainSuccess> Update_finishBasket_sel(int price, long userid, int ReqCount)
        {
            var tmp = _mydb.BargainSuccess.Where(x => x.UserBargain_Id_1 == userid && x.Price2 == 0 && x.SellBuyType_Id == 1).Take(ReqCount);
            if (tmp != null)
            {
                foreach (var item in tmp)
                {
                    item.Price2 = price;
                    item.Tasvie = DateTime.Now;
                }

                return tmp.ToList();
            }
            else
            {
                return null;
            }
        }
        public List<BargainSuccess> Update_finishBasket_Buy(int price, long userid, int ReqCount)
        {
            var tmp = _mydb.BargainSuccess.Where(x => x.UserBargain_Id_1 == userid && x.Price2 == 0 && x.SellBuyType_Id == 2).Take(ReqCount);
            if (tmp != null)
            {
                foreach (var item in tmp)
                {
                    item.Price2 = price;
                    item.Tasvie = DateTime.Now;


                }

                return tmp.ToList();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid">آی دی داخلی</param>
        /// <returns></returns>
        public int Count_sel(long userid)
        {
            try
            {
                return _mydb.BargainSuccess.Where(x => x.UserBargain_Id_1 == userid && x.SellBuyType_Id == 1 && x.Price2 == 0).Count();
            }
            catch { return 0; }
        }

        public int Count_sel(long userid, long selbuyId)
        {
            try
            {
                return _mydb.BargainSuccess .Where(x => x.SellBuy_Id == selbuyId && x.SellBuyType_Id == 1).Count();
            }
            catch { return 0; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid">آی دی داخلی</param>
        /// <returns></returns>
        public int Count_Buy(long
            userid)
        {
            try
            {
                return _mydb.BargainSuccess.Where(x => x.UserBargain_Id_1 == userid && x.SellBuyType_Id == 2 && x.Price2 == 0).Count();
            }
            catch
            {
                return 0;
            }
        }

        public int Count_Buy(long
         userid, long selbuyId)
        {
            try
            {
                return _mydb.BargainSuccess
         .Where(x => x.SellBuy_Id == selbuyId && x.SellBuyType_Id == 2).Count();
            }
            catch { return 0; }
        }



        public int Count_sel_Open_WithSellId(long SellId)
        {
            try
            {
                return _mydb.BargainSuccess
            .Where(x => x.SellBuy_Id == SellId && x.SellBuyType_Id == 1 && x.Price2 == 0)
            .Count();
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid">آی دی داخلی</param>
        /// <returns></returns>
        public int Count_Buy_Open_WithSellId(long
            SellId)
        {
            try
            {
                return _mydb.BargainSuccess
         .Where(x => x.SellBuy_Id == SellId && x.SellBuyType_Id == 2 && x.Price2 == 0)
         .Count();
            }
            catch {
                return 0;
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




        public List<BargainSuccess> GetAllOnSale()
        {
            return _mydb.BargainSuccess.Where(x => x.Price2 == 0 && x.OnSale).ToList();
        }

        public List<ViewModels.BargainSuccessViewModel> GetAllOnSaleReport()
        {
            var tmp = _mydb.BargainSuccess.Where(x => x.Price2 == 0 && x.OnSale).OrderByDescending(x => x.Id).ToList();
            List<BargainSuccessViewModel> bargainSuccessViewModel_list = new List<BargainSuccessViewModel>();
            utility.UtilityRepository utility = new utility.UtilityRepository();
            foreach (BargainSuccess item in tmp)
            {
                BargainSuccessViewModel successViewModel = new BargainSuccessViewModel();
                successViewModel.Date = utility.Convert2Shamsi(item.DateTime);
                successViewModel.FullName1 = item.FirstUserBargain_1.Name + " " + item.FirstUserBargain_1.Family;
                successViewModel.FullName2 = item.SecendUserBargain_2.Name + " " + item.SecendUserBargain_2.Family;
                successViewModel.Id = item.Id;
                successViewModel.Price = item.SellBuy.Price;
                successViewModel.Sod = item.Sod;
                if (item.SellBuyType_Id == 1)
                {
                    successViewModel.Type = "فروش";
                }
                else
                {
                    successViewModel.Type = "خرید";
                }
                successViewModel.NowMazane = item.NowMazane;
                bargainSuccessViewModel_list.Add(successViewModel);

            }
            return bargainSuccessViewModel_list;
        }
        public List<ViewModels.BargainSuccessViewModel> GetAllOnSaleReport(long user_id)
        {
            var tmp = _mydb.BargainSuccess.Where(x => x.Price2 == 0 && x.OnSale && x.UserBargain_Id_1 == user_id).OrderByDescending(x => x.Id).ToList();
            List<BargainSuccessViewModel> bargainSuccessViewModel_list = new List<BargainSuccessViewModel>();
            utility.UtilityRepository utility = new utility.UtilityRepository();
            foreach (BargainSuccess item in tmp)
            {
                BargainSuccessViewModel successViewModel = new BargainSuccessViewModel();
                successViewModel.Date = utility.Convert2Shamsi(item.DateTime);
                successViewModel.FullName1 = item.FirstUserBargain_1.Name + " " + item.FirstUserBargain_1.Family;
                successViewModel.FullName2 = item.SecendUserBargain_2.Name + " " + item.SecendUserBargain_2.Family;
                successViewModel.Id = item.Id;
                successViewModel.Price = item.SellBuy.Price;
                successViewModel.Sod = item.Sod;
                if (item.SellBuyType_Id == 1)
                {
                    successViewModel.Type = "فروش";
                }
                else
                {
                    successViewModel.Type = "خرید";
                }
                successViewModel.NowMazane = item.NowMazane;
                bargainSuccessViewModel_list.Add(successViewModel);

            }
            return bargainSuccessViewModel_list;
        }


        public List<BargainSuccessReportViewModel> GetOnSale_BargainSuccessReportViews(long user_id)
        {

            var tmp = _mydb.BargainSuccess.Where(x => x.Price2 == 0 && x.OnSale && x.UserBargain_Id_1 == user_id).OrderByDescending(x => x.Id).ToList();
            List<BargainSuccessReportViewModel> bargainSuccessViewModel_list = new List<BargainSuccessReportViewModel>();
            ComisonRepository comisonRepository = new ComisonRepository();
            utility.UtilityRepository utility = new utility.UtilityRepository();
            foreach (BargainSuccess item in tmp)
            {
                BargainSuccessReportViewModel successViewModel = new BargainSuccessReportViewModel();
                successViewModel.Date = utility.Convert2Shamsi(item.DateTime) + " " + item.DateTime.ToShortTimeString();
                successViewModel.Id = item.Id;

                if (item.SellBuyType_Id == 1)
                {
                    try
                    {
                        successViewModel.Price_Sell = item.SellBuy.Price;
                    }
                    catch
                    {
                        successViewModel.Price_Sell = 0;

                    }
                    try

                    {
                        successViewModel.Price_Buy = item.Price2;
                    }
                    catch
                    {
                        successViewModel.Price_Buy = 0;

                    }

                }
                else
                {
                    try
                    {
                        successViewModel.Price_Sell = item.Price2;
                    }
                    catch
                    {
                        successViewModel.Price_Sell = 0;


                    }
                    try
                    {
                        successViewModel.Price_Buy = item.SellBuy.Price;
                    }
                    catch
                    {
                        successViewModel.Price_Buy = 0;

                    }
                }
                bargainSuccessViewModel_list.Add(successViewModel);

            }
            return bargainSuccessViewModel_list;



        }



    }
}

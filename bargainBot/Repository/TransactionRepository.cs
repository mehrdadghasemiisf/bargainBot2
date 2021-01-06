using bargainBot.Context;
using bargainBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.Repository
{
    public class TransactionRepository : IDisposable
    {
        mydbContext _mydb;
        public TransactionRepository()
        {
            _mydb = new mydbContext();
        }


        public List<Transaction> GetAll(long userid)
        {
            return _mydb.Transaction.Where(x => x.UserBargain_Id == userid).ToList();
        }



        public List<Transaction> Search(DateTime StartDate, DateTime EndDate,long user_id)
        {
            return _mydb.Transaction.Where(x => x.DateTime >= StartDate && x.DateTime <= EndDate && x.UserBargain_Id==user_id).ToList();
        }

        public List<Transaction> Search(DateTime StartDate, DateTime EndDate)
        {
            return _mydb.Transaction.Where(x => x.DateTime >= StartDate && x.DateTime <= EndDate).ToList();
        }




        public Transaction Add(Transaction Transaction)
        {

            UserBargainRepository userBargainRepository = new UserBargainRepository();

            UserBargain userBargain = userBargainRepository.GetUserWithMyID(Transaction.UserBargain_Id);

            if (Transaction.TransactionType_Id == 1)
            {
                userBargain.PriceGarranty += Transaction.Price;

            }
            else if (Transaction.TransactionType_Id == 2)
            {
                userBargain.PriceGarranty -= Transaction.Price;

            }

            var tmp= _mydb.Transaction.Add(Transaction);
            Save();
            userBargainRepository.Save();

            return tmp;


        }


        public void Dispose()
        {
            _mydb = null;
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

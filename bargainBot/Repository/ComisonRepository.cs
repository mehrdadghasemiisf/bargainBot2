using bargainBot.Context;
using bargainBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bargainBot.Repository
{
    public class ComisonRepository : IDisposable
    {
        mydbContext _mydb;
        public ComisonRepository()
        {
            _mydb = new mydbContext();
        }
        public Consion Add(Consion consion)
        {
            if (!_mydb.Consion.Any(x => x.BargainSuccess_Id == consion.BargainSuccess_Id))
            {
                return _mydb.Consion.Add(consion);
            }
            else
            {
                return consion;
            }
        }

        public void Dispose()
        {
            _mydb = null;
        }

        public Consion Get(BargainSuccess BargainSuccess)
        {
            return _mydb.Consion.FirstOrDefault(x => x.BargainSuccess_Id == BargainSuccess.Id);
        }

        public List< Consion> GetAll(long user_id)
        {
            return _mydb.Consion.Where(x => x.BargainSuccess.UserBargain_Id_1 == user_id).ToList();
        }

        public List<Consion> Search(DateTime StartDate,DateTime EndDate)
        {
            return _mydb.Consion.Where(x => x.DateTime>=StartDate && x.DateTime<=EndDate).ToList();
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

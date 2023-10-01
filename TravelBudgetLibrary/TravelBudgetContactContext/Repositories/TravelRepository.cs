using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetModels.Models;

namespace TravelBudgetContactContext.Repositories
{
    public class TravelRepository
    {
        public ContactContext _db { get; set; }
        public TravelRepository(ContactContext db)
        {
            _db = db;
        }

        public List<Travel> GetAllTravels()
        {
            var result = _db.Travels.ToList();

            return result;
        }
        public bool Create(Travel travel)
        {
            try
            {
                _db.Travels.Add(travel);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }

}

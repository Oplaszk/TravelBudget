using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetModels.Models;

namespace TravelBudgetContactContext.Repositories
{
    public class CountryRepository
    {
        public ContactContext _db { get; set; }

        public CountryRepository(ContactContext db)
        {
            _db = db;
        }

        public List<Country> GetAllCountries()
        {
            return _db.Countries.ToList();
        }
    }
}

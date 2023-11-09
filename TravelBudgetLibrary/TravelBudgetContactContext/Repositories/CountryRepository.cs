using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetContactContext.Response.DTO;
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

        // Aktualnie metoda ta jest niewykorzystywana a jest powiązana z CountryDTO.
        //public List<CountryDTO> GetAllCountries()
        //{
        //    return _db.Countries.Include(c => c.Continent).Select(d => new CountryDTO
        //    {
        //        Id = d.Id,
        //        CountryName = d.Name,
        //        ContinentName = d.Continent.Name
        //    }).ToList();
        //}
        public List<Country> GetAllCountries()
        {
            return _db.Countries.ToList();
        }

        //public Country GetCountryById(int id)
        //{
        //    return _db.Countries.Single(c => c.Id == id);
        //}
    }
}

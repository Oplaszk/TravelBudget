using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetContactContext.Repositories.Interfaces;
using TravelBudgetContactContext.Response.DTO;
using TravelBudgetModels.Models;

namespace TravelBudgetContactContext.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        public DBContact _db { get; set; }

        public CountryRepository(DBContact db)
        {
            _db = db;
        }

        // Aktualnie metoda ta jest niewykorzystywana a jest powiązana z CountryDTO.
        public IEnumerable<CountryDTO> GetAllCountriesDTO()
        {
            return _db.Countries.Select(d => new CountryDTO
            {
                Id = d.Id,
                CountryName = d.Name,
                Code = d.Code
            }).ToList();
        }
        public List<Country> GetAllCountries()
        {
            return _db.Countries.ToList();
        }
    }
}

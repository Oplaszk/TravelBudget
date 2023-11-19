using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CountryRepository> _logger;
        public CountryRepository(DBContact db, ILogger<CountryRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        // Aktualnie metoda ta jest niewykorzystywana a jest powiązana z CountryDTO.
        public IEnumerable<CountryDTO> GetAllCountriesDTO()
        {
            try
            {
                var countriesDTO = _db.Countries.Select(d => new CountryDTO 
                { Id = d.Id, CountryName = d.Name, Code = d.Code }).ToList();

                return countriesDTO;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "En error occurred while retriving countries with DTO from database");
                return Enumerable.Empty<CountryDTO>();
            }

        }
        //public List<Country> GetAllCountries()
        //{
        //    return _db.Countries.ToList();
        //}
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetDBContact.Repositories.Interfaces;
using TravelBudgetDBContact.Response.DTO;
using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories
{
    public class CountryRepository : BaseRepository, ICountryRepository
    {
        public CountryRepository(DBContact db, ILogger<CountryRepository> logger) : base(db, logger)
        {
        }
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
                _logger.LogError(ex, "En error occurred while retrieving countries with DTO from database");
                return Enumerable.Empty<CountryDTO>();
            }

        }
        public string GetCurrencyCodeByCountryId(int countryId)
        {
            try
            {
                return _db.Countries.Include(c => c.Currency).FirstOrDefault(c => c.Id == countryId).Currency.Code;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "En error occurred while retriving currency code from the database");
                return null;
            }
        }
    }
}

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
        private readonly ILogger<CountryRepository> _logger;
        public CountryRepository(DBContact db, ILogger<CountryRepository> logger) : base(db)
        {
            _logger = logger;
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
                _logger.LogError(ex, "En error occurred while retriving countries with DTO from database");
                return Enumerable.Empty<CountryDTO>();
            }

        }
    }
}

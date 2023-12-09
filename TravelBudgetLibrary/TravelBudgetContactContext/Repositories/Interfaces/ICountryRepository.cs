using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetDBContact.Response.DTO;
using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        public IEnumerable<CountryDTO> GetAllCountriesDTO();
        public string GetCurrencyCodeByCountryId(int countryId);
        //public List<Country> GetAllCountries();
    }
}

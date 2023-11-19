using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetContactContext.Response.DTO;
using TravelBudgetModels.Models;

namespace TravelBudgetContactContext.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        public IEnumerable<CountryDTO> GetAllCountriesDTO();
        //public List<Country> GetAllCountries();
    }
}

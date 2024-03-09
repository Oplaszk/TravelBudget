using TravelBudgetDBContact.Response.DTO;
using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<CountryDTO> GetAllCountriesDTO();
        string GetCurrencyCodeByCountryId(int countryId);
        List<Country> GetCountriesByIds(List<int> countryIds);
    }
}

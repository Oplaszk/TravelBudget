using TravelBudgetDBContact.Response.DTO;
using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<CountryDTO> GetAllCountriesDTO();
        string GetCurrencyCodeByCountryId(int countryId);
        ICollection<Country> GetCountriesByIds(ICollection<int> countryIds);
        ICollection<int> GetIdsByCountries(ICollection<Country> countries);
    }
}

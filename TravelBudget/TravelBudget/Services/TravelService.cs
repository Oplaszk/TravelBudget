using Microsoft.AspNetCore.Mvc.Rendering;
using TravelBudget.ViewModels;
using TravelBudgetDBContact.Repositories.Interfaces;

namespace TravelBudget.Services
{
    public class TravelService(ICountryRepository countryRepository, ITravelRepository travelRepository) 
    {
        public void PopulateCountriesSelectList(TravelViewModel travelViewModel)
        {
            var countries = countryRepository.GetAllCountriesDTO();
            travelViewModel.CountriesSelectList.Clear();

            foreach (var country in countries)
            {
                travelViewModel.CountriesSelectList.Add(new SelectListItem
                {
                    Text = country.CountryWithCode,
                    Value = country.Id.ToString()
                });
            }
        }
    }
}

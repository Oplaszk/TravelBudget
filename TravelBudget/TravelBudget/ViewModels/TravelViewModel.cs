using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using TravelBudgetDBModels.Models;

namespace TravelBudget.ViewModels
{
    public class TravelViewModel
    {
        public IEnumerable<Travel>? Travels { get; set; }
        public Travel? Travel { get; set; } = new Travel {StartingDate = DateTime.Now, FinishDate = DateTime.Now };
        public List<string> SelectedCountries { get; set; } = new List<string>();
        public List<int> SelectedCountriesId { get; set; } = new List<int>();

        [DisplayName("CountriesList")]
        public List<SelectListItem> CountriesSelectList { get; set; } = new List<SelectListItem>();  
    }
}

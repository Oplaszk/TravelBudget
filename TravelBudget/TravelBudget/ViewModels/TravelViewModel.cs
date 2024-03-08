using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TravelBudgetDBModels.Models;

namespace TravelBudget.ViewModels
{
    public class TravelViewModel
    {
        public IEnumerable<Travel>? Travels { get; set; }
        public Travel? Travel { get; set; } = new Travel {StartingDate = DateTime.Now, FinishDate = DateTime.Now };
        public List<string> SelectedCountries { get; set; } = new List<string>();

        [DisplayName("CountriesList")]
        public List<SelectListItem> CountriesSelectList { get; set; } = new List<SelectListItem>();  
    }
}

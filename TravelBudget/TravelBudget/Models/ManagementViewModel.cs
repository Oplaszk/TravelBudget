using System.ComponentModel.DataAnnotations;
using TravelBudgetContactContext.Response.DTO;
using TravelBudgetModels.Models;

namespace TravelBudget.Models
{
    public class ManagementViewModel
    {
        [Display(Name = "Create new category:")]
        public IEnumerable<Category> Categories { get; set; }
        public Category Category { get; set; }
    }
}

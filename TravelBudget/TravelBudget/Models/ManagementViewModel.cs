using System.ComponentModel.DataAnnotations;
using TravelBudgetContactContext.Response.DTO;
using TravelBudgetModels.Models;

namespace TravelBudget.Models
{
    public class ManagementViewModel
    {
        [Display(Name = "Add New Category:")]
        public IEnumerable<Category> Categories { get; set; }
        public Category Category { get; set; }
    }
}

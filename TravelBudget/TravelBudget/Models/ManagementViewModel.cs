using System.ComponentModel.DataAnnotations;
using TravelBudgetContactContext.Response.DTO;
using TravelBudgetModels.Models;

namespace TravelBudget.Models
{
    public class ManagementViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Category Category { get; set; }
    }
}

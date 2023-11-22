using System.ComponentModel.DataAnnotations;
using TravelBudgetContactContext.Response.DTO;
using TravelBudgetModels.Models;

namespace TravelBudget.Models
{
    public class ManagementViewModel
    {
        public IEnumerable<Category> CategoryOptions { get; set; } 
        public Category Category { get; set; } = new Category();
    }
}

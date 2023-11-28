using System.ComponentModel.DataAnnotations;
using TravelBudgetDBContact.Response.DTO;
using TravelBudgetDBModels.Models;

namespace TravelBudget.Models
{
    public class ManagementViewModel
    {
        public IEnumerable<Category> CategoryOptions { get; set; } 
        public Category Category { get; set; } = new Category();
    }
}

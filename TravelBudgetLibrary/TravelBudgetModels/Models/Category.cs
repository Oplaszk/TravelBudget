using System.ComponentModel.DataAnnotations;

namespace TravelBudgetDBModels.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<Expense> Expenses { get; set; }   
    }
}

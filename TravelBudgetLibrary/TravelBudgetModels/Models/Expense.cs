using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBudgetModels.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; } = new DateTime();
        [DisplayName(displayName: "Category")]
        public int CategoryId { get; set; }
        [NotMapped]
        public List<Category> CategoryOptions { get; set; } = new List<Category>(); // dodałem instancje
        public int TravelId { get; set; }
        [DisplayName(displayName: "Country")]
        public int CountryId { get; set; } 
        public Category Category { get; set; }
        public Travel Travel { get; set; }
    }
}

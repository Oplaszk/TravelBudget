using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBudgetDBModels.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Description can not be longer then 50 characters")]
        public string? Description { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double? Price { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime? Date { get; set; }
        [DisplayName(displayName: "Category Options")]

        // EntityFramework configuration section

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } 

        [ForeignKey("TravelId")]
        public int TravelId { get; set; }
        public Travel Travel { get; set; }

        [DisplayName(displayName: "Country Options")]
        [ForeignKey("CountryId")]
        public int CountryId { get; set; }      
        public Country Country { get; set; } 
    }
}

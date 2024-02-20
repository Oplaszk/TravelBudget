using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBudgetDBModels.Models
{
    public class Travel
    {
        public int? Id { get; set; }
        public DateTime StartingDate { get; set; } = new DateTime();
        public DateTime FinishDate { get; set; } = new DateTime();
        public string? Name { get; set; }

        [StringLength(300, ErrorMessage = "Description can not be longer then 300 characters")]
        public string? Description { get; set; }
        public bool Active { get; set; }
        public string UserId { get; set; }

        // EntityFramework configuration section

        [ForeignKey("CommentId")]
        public int? CommentId { get; set; } 
        public Comment? Comment { get; set; } 
        public ICollection<Expense>? Expenses { get; set; } 
        public ICollection<Country>? Countries { get; set; }   

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBudgetModels.Models
{
    public class Travel
    {
        public int Id { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartingDate { get; set; } = new DateTime();

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FinishDate { get; set; } = new DateTime();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }

        [ForeignKey("CommentId")]
        public int? CommentId { get; set; } // Klucz obcy
        public Comment Comment { get; set; } // Wartość nawigacyjna
        public ICollection<Expense> Expenses { get; set; } 
        public ICollection<Country> Countries { get; set; }   

    }
}

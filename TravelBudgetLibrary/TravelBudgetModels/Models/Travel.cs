﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBudgetDBModels.Models
{
    public class Travel
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartingDate { get; set; } = new DateTime();

        [DataType(DataType.DateTime)]
        public DateTime FinishDate { get; set; } = new DateTime();
        public string? Name { get; set; }

        [StringLength(300, ErrorMessage = "Description can not be longer then 50 characters")]
        public string? Description { get; set; }
        public bool Active { get; set; }
        public string UserId { get; set; }

        // EntityFramework configuration section

        [ForeignKey("CommentId")]
        public int? CommentId { get; set; } // Klucz obcy
        public Comment Comment { get; set; } // Wartość nawigacyjna
        public ICollection<Expense> Expenses { get; set; } 
        public ICollection<Country> Countries { get; set; }   

    }
}

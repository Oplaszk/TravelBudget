﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBudgetModels.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; } = new DateTime();
        [DisplayName(displayName: "Category Options")]
        public int CategoryId { get; set; }
        public int TravelId { get; set; }
        [DisplayName(displayName: "Country")]
        public int CountryId { get; set; } 
        public Category Category { get; set; }
        public Travel Travel { get; set; }
    }
}

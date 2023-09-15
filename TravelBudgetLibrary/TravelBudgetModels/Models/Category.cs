﻿namespace TravelBudgetModels.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}

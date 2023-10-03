﻿namespace TravelBudgetModels.Models
{
    public class Travel
    {
        public int Id { get; set; }
        public DateTime StartingDate { get; set; } = new DateTime();
        public DateTime FinishDate { get; set; } = new DateTime();
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int? CommentId { get; set; }
        public Comment Comment { get; set; }
        public List<Expense> Expenses { get; set; } = new List<Expense>();
        public List<Country> Countries { get; set; } = new List<Country>();  

    }
}

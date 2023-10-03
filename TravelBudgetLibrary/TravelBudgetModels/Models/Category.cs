namespace TravelBudgetModels.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<Expense> Expenses { get; set; } = new List<Expense>();   
    }
}

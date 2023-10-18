using TravelBudgetModels.Models;

namespace TravelBudget.Models
{
    public class ExpenseViewModel
    {
        IEnumerable<Expense> Expenses { get; set; }
        IEnumerable<Category> CategoryOptions { get; set; } = new List<Category>();
    }
}

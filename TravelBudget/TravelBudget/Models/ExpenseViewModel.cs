using TravelBudgetModels.Models;

namespace TravelBudget.Models
{
    public class ExpenseViewModel
    {
        IEnumerable<Expense> expenses { get; set; }
        IEnumerable<Category> CategoryOptions { get; set; }
    }
}

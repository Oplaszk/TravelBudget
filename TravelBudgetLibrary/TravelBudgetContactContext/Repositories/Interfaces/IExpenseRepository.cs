using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories.Interfaces
{
    public interface IExpenseRepository
    {
        List<Expense> GetExpensesByTravelId(int travelId);
        List<Expense> GetAllExpenses();
        Expense GetExpenseById(int expenseId);
        bool SaveExpenseToDB(Expense expense);
        bool UpdateExpense(Expense expense);
        bool DeleteExpense(Expense expense);
    }
}

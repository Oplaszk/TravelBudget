using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories.Interfaces
{
    public interface IExpenseRepository
    {
        public List<Expense> GetExpensesByTravelId(int travelId);
        public List<Expense> GetAllExpenses();
        public Expense GetExpenseById(int expenseId);
        public bool SaveExpenseToDB(Expense expense);
        public bool UpdateExpense(Expense expense);
        public bool DeleteExpense(Expense expense);
    }
}

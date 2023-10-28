using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetModels.Models;

namespace TravelBudgetContactContext.Repositories
{
    public class ExpenseRepository
    {
        public ContactContext _db { get; set; }
        public ExpenseRepository(ContactContext db)
        {
            _db = db;
        }

        #region EXPENSE SECTION
        public List<Expense> GetExpensesByTravelId(int travelId)
        {
            return _db.Expenses.Where(e => e.TravelId == travelId).ToList();
        }
        public bool AddExpense(Expense expense)
        {
            try
            {
                _db.Expenses.Add(expense);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateExpense(Expense expense)
        {
            try
            {
                _db.Expenses.Update(expense);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteExpense(Expense expense)
        {
            try
            {
                _db.Expenses.Remove(expense);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion
    }
}

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
        public IEnumerable<Expense> GetAllExpenses()
        {
            return _db.Expenses.ToList();
        }
        public Expense GetExpenseById(int expenseId)
        {
            return _db.Expenses.Single(e => e.Id == expenseId);
        }
        public bool SaveExpenseToDB(Expense expense)
        {
            try
            {
                _db.Expenses.Add(expense);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
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
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
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
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
                return false;
            }
        }
        #endregion
    }
}

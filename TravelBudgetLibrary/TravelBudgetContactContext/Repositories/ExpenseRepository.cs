using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TravelBudgetDBContact.Repositories.Interfaces;
using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories
{
    public class ExpenseRepository : BaseRepository, IExpenseRepository
    {
        private readonly ILogger<ExpenseRepository> _logger;
        public ExpenseRepository(DBContact db, ILogger<ExpenseRepository> logger, IMapper mapper) : base(db, logger, mapper)
        {

        }
        public List<Expense> GetExpensesByTravelId(int travelId)
        {
            try
            {
                return _db.Expenses.Include(a => a.Category).Include(b => b.Country)
                        .ThenInclude(a => a.Currency)
                        .Where(e => e.TravelId == travelId).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving expenses from the database.");
                return new List<Expense>();
            }

        }
        public List<Expense> GetAllExpenses()
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
    }
}

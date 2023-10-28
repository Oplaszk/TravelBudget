using Microsoft.AspNetCore.Mvc;
using TravelBudget.Models;
using TravelBudgetContactContext.Repositories;
using TravelBudgetModels.Models;

namespace TravelBudget.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpenseViewModel _expenseViewModel;
        private readonly ExpenseRepository _expenseRepository;
        public ExpenseController(ExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
            _expenseViewModel = new ExpenseViewModel();
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        #region EXPENSE SECTION
        #region CREATE section
        [HttpGet]
        public IActionResult AddExpense()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddExpense(Expense expense)
        {
            return RedirectToAction("Index");
        }
        #endregion
        #endregion
    }
}

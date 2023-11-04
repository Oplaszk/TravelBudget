using Microsoft.AspNetCore.Mvc;
using TravelBudget.Models;
using TravelBudgetContactContext.Repositories;
using TravelBudgetModels.Models;

namespace TravelBudget.Controllers
{
    public class DetailController : Controller
    {
        private readonly ExpenseViewModel _expenseViewModel;
        private readonly ExpenseRepository _expenseRepository;
        public DetailController(ExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
            _expenseViewModel = new ExpenseViewModel();
        }
        #region READ section
        public IActionResult Details(int Id)
        {
            var expenses = _expenseRepository.GetExpensesByTravelId(Id);
            _expenseViewModel.Expenses = expenses;

            return View(_expenseViewModel);
        }
        public IActionResult Delete(int Id)
        {
            var expenseToDetele = _expenseRepository.GetAllExpenses().Single(e => e.Id == Id);
            _expenseRepository.DeleteExpense(expenseToDetele);
            int travelId = expenseToDetele.TravelId;

            return RedirectToAction("Details", new {id = travelId });
        }
        //[HttpGet]
        //public IActionResult Update(int Id)
        //{
        //    var expense = _expenseRepository.GetExpensesByTravelId(travelId);
        //    _expenseViewModel

        //    return RedirectToAction("Expense","AddExpense");
        //}
        //[HttpPost]
        //public IActionResult Update()
        //{
        //    return RedirectToAction("Details");
        //}
        #endregion
    }
}

using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using TravelBudget.Models;
using TravelBudgetContactContext.Repositories;
using TravelBudgetModels.Models;

namespace TravelBudget.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpenseViewModel _expenseViewModel;
        private readonly ExpenseRepository _expenseRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly CountryRepository _countryRepository;
        public ExpenseController(ExpenseRepository expenseRepository, CategoryRepository categoryRepository, CountryRepository countryRepository)
        {
            _expenseRepository = expenseRepository;
            _categoryRepository = categoryRepository;
            _countryRepository = countryRepository;
            _expenseViewModel = new ExpenseViewModel();
        }
        #region CREATE section
        [HttpGet]
        public IActionResult AddExpense(int id)
        {
            _expenseViewModel.CategoryOptions = _categoryRepository.GetAllCategories();
            _expenseViewModel.Countries = _countryRepository.GetAllCountries();
            if (id == 0)
            {

            }
            //if (id > 0)
            //{
            //    var existingExpense = _expenseRepository.GetExpenseById(id);
            //    if (existingExpense != null)
            //    {
            //        _expenseViewModel.Expense = existingExpense;
            //    }
            //}
            //else
            //{
            //    _expenseViewModel.Expense = new Expense();
            //}
            _expenseViewModel.TravelId = id;

            return View(_expenseViewModel);
        }

        [HttpPost]
        public IActionResult AddExpense(ExpenseViewModel expenseViewModel)
        {
            int Id = expenseViewModel.TravelId;

            if (expenseViewModel.Expense.Id != null)
            {
                _expenseRepository.UpdateExpense(expenseViewModel.Expense);
            }
            else
            {
                expenseViewModel.Expense.TravelId = Id;
                _expenseRepository.SaveExpenseToDB(expenseViewModel.Expense);
            }

            return RedirectToAction("Details", "Detail", new { id = Id });
        }
        public IActionResult Delete(int id) 
        {
            var expenseToDetele = _expenseRepository.GetAllExpenses().Single(e => e.Id == id);
            _expenseRepository.DeleteExpense(expenseToDetele);
            int travelId = expenseToDetele.TravelId;

            return RedirectToAction("Details", "Detail", new { id = travelId });
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var expenseToUpdate = _expenseRepository.GetExpenseById(id);
            _expenseViewModel.Expense = expenseToUpdate;
            int travelId = _expenseViewModel.TravelId;

            return RedirectToAction("AddExpense", travelId/*_expenseViewModel*/);
        }
        //[HttpPost]
        //public IActionResult Update()
        //{
        //    return RedirectToAction("Details");
        //}
        #endregion
    }
}

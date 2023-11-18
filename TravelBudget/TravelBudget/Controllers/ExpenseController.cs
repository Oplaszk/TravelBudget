using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using TravelBudget.Models;
using TravelBudgetContactContext.Repositories;
using TravelBudgetContactContext.Repositories.Interfaces;
using TravelBudgetModels.Models;

namespace TravelBudget.Controllers
{
    public class ExpenseController : Controller
    {      
        private readonly IExpenseRepository _expenseRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ExpenseViewModel _expenseViewModel;
        public ExpenseController(IExpenseRepository expenseRepository, ICategoryRepository categoryRepository, ICountryRepository countryRepository)
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
            _expenseViewModel.Countries = _countryRepository.GetAllCountriesDTO();
            _expenseViewModel.TravelId = id;

            return View(_expenseViewModel);
        }

        [HttpPost]
        public IActionResult AddExpense(ExpenseViewModel expenseViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            int Id = expenseViewModel.TravelId;
            expenseViewModel.Expense.TravelId = Id;

            _expenseRepository.SaveExpenseToDB(expenseViewModel.Expense);

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

            var viewModel = new ExpenseViewModel
            {
                Expense = expenseToUpdate,
                CategoryOptions = _categoryRepository.GetAllCategories(),
                Countries = _countryRepository.GetAllCountriesDTO(),
                TravelId = expenseToUpdate.TravelId
                };
                return View("AddExpense", viewModel); // Teoretycznie Expense.TravelId jest tutaj wypełnione a mimo to odczytuje mi formularz z Update 
        }
        [HttpPost]
        public IActionResult Update(ExpenseViewModel expenseToUpdate)
        {
            int travelId = expenseToUpdate.TravelId;
            expenseToUpdate.Expense.TravelId = travelId;

            _expenseRepository.UpdateExpense(expenseToUpdate.Expense);

            return RedirectToAction("Details", "Detail", new { id = travelId });
        }
        #endregion
    }
}

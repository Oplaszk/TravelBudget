using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using TravelBudget.ViewModels;
using TravelBudgetDBContact.Repositories;
using TravelBudgetDBContact.Repositories.Interfaces;
using TravelBudgetDBModels.Models;

namespace TravelBudget.Controllers
{
    public class ExpenseController : BaseController
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ExpenseViewModel _expenseViewModel;
        public ExpenseController(IExpenseRepository expenseRepository, ICategoryRepository categoryRepository, ICountryRepository countryRepository, ILogger<ExpenseController> logger) : base(logger)
        {
            _expenseRepository = expenseRepository;
            _categoryRepository = categoryRepository;
            _countryRepository = countryRepository;
            _expenseViewModel = new ExpenseViewModel();
        }
        #region CREATE Section
        [HttpGet]
        public IActionResult AddExpense(int id)
        {
            _expenseViewModel.CategoryOptions = _categoryRepository.GetAllCategories();
            _expenseViewModel.Countries = _countryRepository.GetAllCountriesDTO();
            _expenseViewModel.TravelId = id;

            return View(_expenseViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddExpense(ExpenseViewModel expenseViewModel)
        {
            if (ModelState.IsValid)
            {
                int Id = expenseViewModel.TravelId;
                expenseViewModel.Expense.TravelId = Id;
                expenseViewModel.Expense.CurrencyCode = _countryRepository.GetCurrencyCodeByCountryId(expenseViewModel.Expense.CountryId);

                _expenseRepository.SaveExpenseToDB(expenseViewModel.Expense);
                return RedirectToAction("Details", "Detail", new { id = Id });
            }

            expenseViewModel.CategoryOptions = _categoryRepository.GetAllCategories();
            expenseViewModel.Countries = _countryRepository.GetAllCountriesDTO();

            return View("AddExpense", expenseViewModel);

        }
        #endregion
        #region DELETE Section
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var expenseToDetele = _expenseRepository.GetAllExpenses().Single(e => e.Id == id);
            _expenseRepository.DeleteExpense(expenseToDetele);
            int travelId = expenseToDetele.TravelId;

            return RedirectToAction("Details", "Detail", new { id = travelId });
        }
        #endregion
        #region UPDATE Section
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
        [ValidateAntiForgeryToken]
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

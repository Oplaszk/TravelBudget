﻿using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
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
            _expenseViewModel.TravelId = id;

            return View(_expenseViewModel);
        }
        [HttpPost]
        public IActionResult AddExpense(ExpenseViewModel expenseViewModel)
        {
            int Id = expenseViewModel.TravelId;
            expenseViewModel.Expense.TravelId = Id;
            _expenseRepository.SaveExpenseToDB(expenseViewModel.Expense);

            return RedirectToAction("Details", "Detail", new { id = Id });
        }
        #endregion
    }
}

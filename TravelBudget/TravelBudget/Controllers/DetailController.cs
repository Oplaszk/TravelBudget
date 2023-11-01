﻿using Microsoft.AspNetCore.Mvc;
using TravelBudget.Models;
using TravelBudgetContactContext.Repositories;

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
        public IActionResult Details()
        {
            var expenses = _expenseRepository.GetAll();
            _expenseViewModel.Expenses = expenses;

            return View(_expenseViewModel);
        }
        #endregion
    }
}

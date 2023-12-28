using Microsoft.AspNetCore.Mvc;
using TravelBudget.ViewModels;
using TravelBudgetDBContact.Repositories;
using TravelBudgetDBContact.Repositories.Interfaces;
using TravelBudgetDBModels.Models;

namespace TravelBudget.Controllers
{
    public class DetailController : BaseController
    {
        private readonly ExpenseViewModel _expenseViewModel;
        private readonly IExpenseRepository _expenseRepository;
        public DetailController(IExpenseRepository expenseRepository, ILogger<DetailController> logger) : base(logger)
        {
            _expenseRepository = expenseRepository;
            _expenseViewModel = new ExpenseViewModel();
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            var expenses = _expenseRepository.GetExpensesByTravelId(Id);
            _expenseViewModel.Expenses = expenses;

            return View(_expenseViewModel);
        }
    }
}

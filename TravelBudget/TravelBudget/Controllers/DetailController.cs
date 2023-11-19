using Microsoft.AspNetCore.Mvc;
using TravelBudget.Models;
using TravelBudgetContactContext.Repositories;
using TravelBudgetContactContext.Repositories.Interfaces;
using TravelBudgetModels.Models;

namespace TravelBudget.Controllers
{
    public class DetailController : Controller
    {
        private readonly ExpenseViewModel _expenseViewModel;
        private readonly IExpenseRepository _expenseRepository;
        public DetailController(IExpenseRepository expenseRepository)
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

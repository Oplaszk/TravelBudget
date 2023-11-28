using Microsoft.AspNetCore.Mvc;
using TravelBudget.Models;
using TravelBudgetDBContact.Repositories;
using TravelBudgetDBContact.Repositories.Interfaces;
using TravelBudgetDBModels.Models;

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
        [HttpGet]
        public IActionResult FilterLocation(int id)
        {
            return null;
        }
    }
}

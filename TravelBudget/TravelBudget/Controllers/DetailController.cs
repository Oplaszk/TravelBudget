using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelBudget.ViewModels;
using TravelBudgetDBContact.Repositories.Interfaces;

namespace TravelBudget.Controllers
{
    public class DetailController(IExpenseRepository expenseRepository, ILogger<DetailController> logger, IMapper mapper) : BaseController(logger, mapper)
    {
        private readonly ExpenseViewModel _expenseViewModel = new ExpenseViewModel();

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var expenses = expenseRepository.GetExpensesByTravelId(Id);
            _expenseViewModel.Expenses = expenses;

            return View(_expenseViewModel);
        }
    }
}

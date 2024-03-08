using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelBudget.ViewModels;
using TravelBudgetDBContact.Repositories.Interfaces;

namespace TravelBudget.Controllers
{
    public class DetailController : BaseController
    {
        private readonly ExpenseViewModel _expenseViewModel;
        private readonly IExpenseRepository _expenseRepository;
        public DetailController(IExpenseRepository expenseRepository, ILogger<DetailController> logger, IMapper mapper) : base(logger, mapper)
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

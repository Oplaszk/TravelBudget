using Microsoft.AspNetCore.Mvc;
using TravelBudgetDBContact.Repositories.Interfaces;

namespace TravelBudget.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IExpenseRepository _expenseRepository;
        public StatisticsController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public IActionResult Statistics()
        {
            return View();
        }
    }
}

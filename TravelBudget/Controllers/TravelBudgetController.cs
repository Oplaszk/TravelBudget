using Microsoft.AspNetCore.Mvc;

namespace TravelBudget.Controllers
{
    public class TravelBudgetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

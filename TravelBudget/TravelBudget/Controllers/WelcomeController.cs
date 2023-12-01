using Microsoft.AspNetCore.Mvc;

namespace TravelBudget.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

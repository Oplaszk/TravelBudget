using Microsoft.AspNetCore.Mvc;

namespace TravelBudget.Controllers
{
    public class CurrentTravelsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

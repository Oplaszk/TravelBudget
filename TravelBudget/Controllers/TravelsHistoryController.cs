using Microsoft.AspNetCore.Mvc;

namespace TravelBudget.Controllers
{
    public class TravelsHistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

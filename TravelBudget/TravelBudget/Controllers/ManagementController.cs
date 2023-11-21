using Microsoft.AspNetCore.Mvc;

namespace TravelBudget.Controllers
{
    public class ManagementController : Controller
    {
        [HttpGet]
        public IActionResult Zone()
        {
            return View();
        }
    }
}

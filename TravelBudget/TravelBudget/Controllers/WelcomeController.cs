using Microsoft.AspNetCore.Mvc;

namespace TravelBudget.Controllers
{
    public class WelcomeController : BaseController
    {
        public WelcomeController(ILogger<WelcomeController> logger) : base(logger)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

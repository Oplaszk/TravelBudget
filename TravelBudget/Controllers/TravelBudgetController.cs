using Microsoft.AspNetCore.Mvc;
using System.Net;

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


using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace TravelBudget.Controllers
{
    public class WelcomeController(ILogger<WelcomeController> logger, IMapper mapper) : BaseController(logger, mapper)
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

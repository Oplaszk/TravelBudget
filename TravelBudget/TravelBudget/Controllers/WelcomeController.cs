using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace TravelBudget.Controllers
{
    public class WelcomeController : BaseController
    {
        public WelcomeController(ILogger<WelcomeController> logger, IMapper mapper) : base(logger, mapper)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

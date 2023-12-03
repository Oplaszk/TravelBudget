using Microsoft.AspNetCore.Mvc;
using TravelBudgetDBContact.Repositories;
using TravelBudgetDBContact.Repositories.Interfaces;

namespace TravelBudget.Controllers
{
    public class StatisticsController : BaseController
    {
        private readonly IStatisticsRepository _statisticsRepository;
        public StatisticsController(IStatisticsRepository statisticsRepository, ILogger<StatisticsController> logger) : base(logger)
        {
            _statisticsRepository = statisticsRepository;
        }
        public IActionResult Statistics()
        {
            return View();
        }
    }
}

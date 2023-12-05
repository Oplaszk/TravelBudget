using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using TravelBudget.Models;
using TravelBudgetDBContact.Repositories;
using TravelBudgetDBContact.Repositories.Interfaces;

namespace TravelBudget.Controllers
{
    public class StatisticsController : BaseController
    {
        private readonly IStatisticsRepository _statisticsRepository;
        private readonly StatisticsViewModel _statisticsViewModel;
        public StatisticsController(IStatisticsRepository statisticsRepository, ILogger<StatisticsController> logger) : base(logger)
        {
            _statisticsRepository = statisticsRepository;
            _statisticsViewModel = new StatisticsViewModel();
        }
        public IActionResult Statistics()
        {           
            var theMostExpensiveTravel = _statisticsRepository.GetTheMostExpensiveTravel();
            _statisticsViewModel.TheMostExpensiveTravel = theMostExpensiveTravel;

            var TheCheapestTravel = _statisticsRepository.TheCheapestTravel();
            _statisticsViewModel.TheCheapestTravel = TheCheapestTravel;

            var TheLongestTravel = _statisticsRepository.TheLongestTravel();
            _statisticsViewModel.TheLongestTravel = TheLongestTravel;

            var TheShortestTravel = _statisticsRepository.TheShortestTravel();
            _statisticsViewModel.TheShortestTravel = TheShortestTravel;

            return View(_statisticsViewModel);
        }
    }
}

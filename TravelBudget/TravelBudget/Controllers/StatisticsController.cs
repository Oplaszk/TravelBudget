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
            _statisticsViewModel.TheMostExpensiveTravel.DescribedTravel = _statisticsRepository.GetTheMostExpensiveTravel();

            _statisticsViewModel.TheCheapestTravel.DescribedTravel = _statisticsRepository.TheCheapestTravel();
 
            var totalCostMax = _statisticsRepository.GetTotalCostByTravel(_statisticsViewModel.TheMostExpensiveTravel.DescribedTravel);
            _statisticsViewModel.TheMostExpensiveTravel.TotalCost = totalCostMax;

            var totalCostMin = _statisticsRepository.GetTotalCostByTravel(_statisticsViewModel.TheCheapestTravel.DescribedTravel);
            _statisticsViewModel.TheCheapestTravel.TotalCost = totalCostMin;

            _statisticsViewModel.TheLongestTravel.DescribedTravel = _statisticsRepository.TheLongestTravel();

            _statisticsViewModel.TheShortestTravel.DescribedTravel = _statisticsRepository.TheShortestTravel();

            return View(_statisticsViewModel);
        }
    }
}

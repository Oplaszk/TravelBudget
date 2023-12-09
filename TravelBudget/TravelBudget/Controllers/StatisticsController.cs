using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using TravelBudget.ViewModels.Statistics;
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

            _statisticsViewModel.TheMostExpensiveTravel.SummaryTotal = _statisticsViewModel.TheMostExpensiveTravel.TotalCostWithCurrency;
            _statisticsViewModel.TheCheapestTravel.SummaryTotal = _statisticsViewModel.TheCheapestTravel.TotalCostWithCurrency;

            _statisticsViewModel.TheLongestTravel.DescribedTravel = _statisticsRepository.TheLongestTravel();
            _statisticsViewModel.TheShortestTravel.DescribedTravel = _statisticsRepository.TheShortestTravel();

            _statisticsViewModel.TheLongestTravel.SummaryTotal = _statisticsViewModel.TheLongestTravel.DurationTime;
            _statisticsViewModel.TheShortestTravel.SummaryTotal = _statisticsViewModel.TheShortestTravel.DurationTime;

            return View(_statisticsViewModel);
        }
    }
}

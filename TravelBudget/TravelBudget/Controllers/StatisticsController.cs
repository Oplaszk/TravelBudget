using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _statisticsViewModel.TheMostExpensiveTravel.DescribedTravel = _statisticsRepository.GetTheMostExpensiveTravel(userId);
            _statisticsViewModel.TheCheapestTravel.DescribedTravel = _statisticsRepository.TheCheapestTravel(userId);

            _statisticsViewModel.TheMostExpensiveTravel.SummaryTotal = _statisticsViewModel.TheMostExpensiveTravel.TotalCostWithCurrency;
            _statisticsViewModel.TheCheapestTravel.SummaryTotal = _statisticsViewModel.TheCheapestTravel.TotalCostWithCurrency;

            _statisticsViewModel.TheLongestTravel.DescribedTravel = _statisticsRepository.TheLongestTravel(userId);
            _statisticsViewModel.TheShortestTravel.DescribedTravel = _statisticsRepository.TheShortestTravel(userId);

            _statisticsViewModel.TheLongestTravel.SummaryTotal = _statisticsViewModel.TheLongestTravel.DurationTime;
            _statisticsViewModel.TheShortestTravel.SummaryTotal = _statisticsViewModel.TheShortestTravel.DurationTime;

            _statisticsViewModel.Countries = _statisticsRepository.GetTheMostVisitedCountries(userId);

            _statisticsViewModel.TotalCostFromAllTravels = _statisticsRepository.GetTotalCostFromAllTravels(userId);

            return View(_statisticsViewModel);
        }
    }
}

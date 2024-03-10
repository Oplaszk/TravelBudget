using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TravelBudget.ViewModels.Statistics;
using TravelBudgetDBContact.Repositories.Interfaces;

namespace TravelBudget.Controllers
{
    public class StatisticsController(IStatisticsRepository statisticsRepository, ILogger<StatisticsController> logger, IMapper mapper) : BaseController(logger, mapper)
    {
        private readonly StatisticsViewModel _statisticsViewModel = new StatisticsViewModel();

        public IActionResult Statistics()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _statisticsViewModel.TheMostExpensiveTravel.DescribedTravel = statisticsRepository.GetTheMostExpensiveTravel(userId);
            _statisticsViewModel.TheCheapestTravel.DescribedTravel = statisticsRepository.TheCheapestTravel(userId);

            _statisticsViewModel.TheMostExpensiveTravel.SummaryTotal = _statisticsViewModel.TheMostExpensiveTravel.TotalCostWithCurrency;
            _statisticsViewModel.TheCheapestTravel.SummaryTotal = _statisticsViewModel.TheCheapestTravel.TotalCostWithCurrency;

            _statisticsViewModel.TheLongestTravel.DescribedTravel = statisticsRepository.TheLongestTravel(userId);
            _statisticsViewModel.TheShortestTravel.DescribedTravel = statisticsRepository.TheShortestTravel(userId);

            _statisticsViewModel.TheLongestTravel.SummaryTotal = _statisticsViewModel.TheLongestTravel.DurationTime;
            _statisticsViewModel.TheShortestTravel.SummaryTotal = _statisticsViewModel.TheShortestTravel.DurationTime;

            _statisticsViewModel.Countries = statisticsRepository.GetTheMostVisitedCountries(userId);

            _statisticsViewModel.TotalCostFromAllTravels = statisticsRepository.GetTotalCostFromAllTravels(userId);

            return View(_statisticsViewModel);
        }
    }
}

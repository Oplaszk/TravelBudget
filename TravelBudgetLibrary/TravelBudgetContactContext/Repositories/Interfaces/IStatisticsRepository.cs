using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories.Interfaces
{
    public interface IStatisticsRepository
    {
        Travel GetTheMostExpensiveTravel(string userId);
        Travel TheCheapestTravel(string userId);
        Travel TheLongestTravel(string userId);
        Travel TheShortestTravel(string userId);
        List<Country> GetTheMostVisitedCountries(string userId);
        double GetTotalCostFromAllTravels(string userId);
    }
}

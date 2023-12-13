using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories.Interfaces
{
    public interface IStatisticsRepository
    {
        public Travel GetTheMostExpensiveTravel(string userId);
        public Travel TheCheapestTravel(string userId);
        public Travel TheLongestTravel(string userId);
        public Travel TheShortestTravel(string userId);
        public List<Country> GetTheMostVisitedCountries(string userId);
        public double GetTotalCostFromAllTravels(string userId);
    }
}

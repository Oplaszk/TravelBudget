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
        public Travel GetTheMostExpensiveTravel();
        public Travel TheCheapestTravel();
        public Travel TheLongestTravel();
        public Travel TheShortestTravel();
    }
}

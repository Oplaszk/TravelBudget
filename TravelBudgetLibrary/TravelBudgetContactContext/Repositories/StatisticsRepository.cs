using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetDBContact.Repositories.Interfaces;
using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories
{
    public class StatisticsRepository : BaseRepository, IStatisticsRepository
    {
        public StatisticsRepository(DBContact db, ILogger<StatisticsRepository> logger) : base(db, logger)
        {
        }
        public Travel GetTheMostExpensiveTravel()
        {
            try
            {
                var travel = _db.Travels.Where(t => t.Expenses.Any())
                .OrderByDescending(t => t.Expenses.Sum(e => e.Price ?? 0)).FirstOrDefault();

                return travel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "En error occured while retrieving travel from the database.");
                return new Travel();
            }
        }
        //public Travel TheCheapestTravel()
        //{
        //    return null;
        //}

        //public Travel TheLongestTravel()
        //{
        //    return null;
        //}
    }
}

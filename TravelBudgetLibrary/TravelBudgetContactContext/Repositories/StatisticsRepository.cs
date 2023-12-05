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
                var TheMostExpensiveTravel = _db.Travels.Where(t => t.Expenses.Any())
                .OrderByDescending(t => t.Expenses.Sum(e => e.Price ?? 0)).FirstOrDefault();

                return TheMostExpensiveTravel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "En error occured while retrieving travel from the database.");
                return new Travel();
            }
        }
        public Travel TheCheapestTravel()
        {
            try
            {
                var TheCheapestTravelravel = _db.Travels.Where(t => t.Expenses.Any())
                .OrderBy(t => t.Expenses.Sum(e => e.Price ?? 0)).FirstOrDefault();

                return TheCheapestTravelravel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "En error occured while retrieving travel from the database.");
                return new Travel();
            }
        }

        public Travel TheLongestTravel()
        {
            try
            {
                var TheLongestTravel = _db.Travels.Where(t => t.StartingDate != null && t.FinishDate != null)
                .AsEnumerable().OrderByDescending(t => (t.FinishDate - t.StartingDate)).FirstOrDefault();

                return TheLongestTravel;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");

                return new Travel();
            }
        }
        public Travel TheShortestTravel()
        {
            try
            {
                var TheShortestTravel = _db.Travels.Where(t => (t.StartingDate != null && t.FinishDate != null))
                .AsEnumerable().OrderBy(t => (t.FinishDate - t.StartingDate)).FirstOrDefault();

                return TheShortestTravel;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");

                return new Travel();
            }
        }
    }
}

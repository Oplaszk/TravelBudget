using Microsoft.EntityFrameworkCore;
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
                var theMostExpensiveTravel = _db.Travels.Include(e => e.Expenses).Where(t => t.Expenses.Any())
                .OrderByDescending(t => t.Expenses.Sum(e => e.Price ?? 0)).FirstOrDefault();

                return theMostExpensiveTravel;
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
                var theCheapestTravel = _db.Travels.Include(e => e.Expenses).Where(t => t.Expenses.Any())
                .OrderBy(t => t.Expenses.Sum(e => e.Price ?? 0)).FirstOrDefault();

                return theCheapestTravel;
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
                var theLongestTravel = _db.Travels
                .AsEnumerable().OrderByDescending(t => (t.FinishDate - t.StartingDate)).FirstOrDefault();

                return theLongestTravel;
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
                var theShortestTravel = _db.Travels
                .AsEnumerable().OrderBy(t => (t.FinishDate - t.StartingDate)).FirstOrDefault();

                return theShortestTravel;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");

                return new Travel();
            }
        }
        public double GetTotalCostByTravel(Travel travel)
        {
            try
            {
                return travel.Expenses.Sum(e => e.Price ?? 0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "En error occured while retrieving travel total cost.");
                return 0;
            }
        }
        public string GetTimeSpanByTravel(Travel travel)
        {
            try
            {
                var test = (travel.FinishDate - travel.StartingDate);
                return test.ToString(@"dd") + " days " + test.ToString(@"hh") + " h " + test.ToString(@"mm") + " min";

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "En error occured while retrieving travel time span.");
                return TimeSpan.Zero.ToString();
            }
        }
    }
}

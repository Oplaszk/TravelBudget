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
        public Travel GetTheMostExpensiveTravel(string userId)
        {
            try
            {
                var theMostExpensiveTravel = _db.Travels.Where(t => t.UserId == userId).Include(e => e.Expenses)
                    .ThenInclude(e => e.Country)
                    .ThenInclude(e => e.Currency)
                    .Where(t => t.Expenses.Any())
                    .OrderByDescending(t => t.Expenses.Sum(e => e.Price ?? 0)).FirstOrDefault();

                return theMostExpensiveTravel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "En error occured while retrieving travel from the database.");
                return new Travel();
            }
        }
        public Travel TheCheapestTravel(string userId)
        {
            try
            {
                var theCheapestTravel = _db.Travels.Where(t => t.UserId == userId).Include(e => e.Expenses)
                    .ThenInclude(e => e.Country)
                    .ThenInclude(e => e.Currency)
                    .Where(t => t.Expenses.Any())
                    .OrderBy(t => t.Expenses.Sum(e => e.Price ?? 0)).FirstOrDefault();

                return theCheapestTravel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "En error occured while retrieving travel from the database.");
                return new Travel();
            }
        }
        public Travel TheLongestTravel(string userId)
        {
            try
            {
                var theLongestTravel = _db.Travels.Where(t => t.UserId == userId)
                .AsEnumerable().OrderByDescending(t => (t.FinishDate - t.StartingDate)).FirstOrDefault();

                return theLongestTravel;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");

                return new Travel();
            }
        }
        public Travel TheShortestTravel(string userId)
        {
            try
            {
                var theShortestTravel = _db.Travels.Where(t => t.UserId == userId)
                .AsEnumerable().OrderBy(t => (t.FinishDate - t.StartingDate)).FirstOrDefault();

                return theShortestTravel;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");

                return new Travel();
            }
        }
        public List<Country> GetTheMostVisitedCountries(string userId)
        {
            var mostVisitedCountries = _db.Travels.Where(t => t.UserId == userId)
            .Include(t => t.Expenses)
            .ThenInclude(e => e.Country)
            .SelectMany(t => t.Expenses.Select(e => e.Country))
            .GroupBy(c => c.Id) 
            .OrderByDescending(group => group.Count()) 
            .Select(group => group.First()).Take(3)
            .ToList();

            return mostVisitedCountries;
        }
        public double GetTotalCostFromAllTravels(string userId)
        {
            var travelsExpenses = _db.Travels
                  .Where(t => t.UserId == userId)
                  .Select(t => t.Expenses.Sum(e => e.Price ?? 0))
                  .ToList(); 

            var totalCostFromAllTravels = travelsExpenses.Sum();
            return totalCostFromAllTravels;
        }
    }
}

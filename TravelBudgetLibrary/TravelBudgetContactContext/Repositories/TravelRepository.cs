using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetContactContext.Repositories.Interfaces;
using TravelBudgetModels.Models;

namespace TravelBudgetContactContext.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        private readonly ILogger<TravelRepository> _logger;
        public DBContact _db { get; set; }
        public TravelRepository(DBContact db, ILogger<TravelRepository> logger)
        {
            _logger = logger;
            _db = db;
        }
        public List<Travel> GetAllTravels()
        {
            try
            {
                var listOfTravels = _db.Travels.ToList();
                return listOfTravels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving travels from the database.");
                return new List<Travel>();
            }
        }
        public bool SaveTravelToDB(Travel travel)
        {
            try
            {
                _db.Travels.Add(travel);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the travel to the database");
                return false;
            }
        }
        public Travel GetById(int id)
        {
            try
            {
                var travel = _db.Travels.Where(a => a.Id == id).FirstOrDefault();
                return travel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving travel from the database.");
                return new Travel();
            }

        }
        public bool UpdateTravel(Travel travel)
        {
            try
            {
                _db.Travels.Update(travel);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "An error occurred while updating travel from the database.");
                return false;
            }
            
        }
        public bool DeleteTravel(Travel travel)
        {
            try
            {
                _db.Travels.Remove(travel);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting travel from the database.");
                return false;
            }
        }
        public bool EndTravel(Travel travel)
        {
            try
            {
                travel.Active = false;
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while moving the travel to History Travels.");
                return false;
            }
        }
        public bool RetrieveTravel(Travel travel)
        {
            try
            {
                travel.Active = true;
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retriving the travel from Travels History to Current Travels.");
                return false;
            }
            
        }      
    }
}



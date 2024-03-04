using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TravelBudgetDBContact.Repositories.Interfaces;
using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories
{
    public class TravelRepository : BaseRepository, ITravelRepository
    {
        public TravelRepository(DBContact db, ILogger<TravelRepository> logger) : base(db, logger)
        {
        }
        public List<Travel> GetAllTravels(string userId, bool active)
        {
            try
            {
                var listOfTravels = _db.Travels.Where(t => t.UserId == userId && t.Active == active).ToList();
                return listOfTravels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving travels from the database.");
                return new List<Travel>();
            }
        }
        public bool SaveTravelToDB(Travel travel, List<string> selectedCountryIds)
        {
            try
            {
                _db.Travels.Add(travel);
                _db.SaveChanges();

                if (selectedCountryIds != null && selectedCountryIds.Any())
                {
                    var selectedCountries = _db.Countries.Where(c => selectedCountryIds.Contains(c.Id.ToString())).ToList();
                    travel.Countries = selectedCountries;
                    _db.SaveChanges();
                }

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



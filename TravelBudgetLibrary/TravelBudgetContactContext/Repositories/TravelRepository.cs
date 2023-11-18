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
        public DBContact _db { get; set; }
        public TravelRepository(DBContact db)
        {
            _db = db;
        }
        public List<Travel> GetAllTravels()
        {
            var result = _db.Travels.ToList();

            return result;
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
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }
        public Travel GetById(int id)
        {
            try
            {
                return _db.Travels.Where(a => a.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return new Travel();
            }

        }
        public bool UpdateTravel(Travel travel)
        {
            try
            {
                // Update jest wbudowaną metodą w Entity Framework
                _db.Travels.Update(travel);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine("An error occurred: " + ex.Message);
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
                Console.WriteLine("An error occurred: " + ex.Message);
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
                Console.WriteLine("An error occurred: " + ex.Message);
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
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
            
        }      
    }
}



using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetModels.Models;

namespace TravelBudgetContactContext.Repositories
{
    public class TravelRepository
    {
        public ContactContext _db { get; set; }
        public TravelRepository(ContactContext db)
        {
            _db = db;
        }
        public List<Travel> GetAllTravels()
        {
            // "Travels" odnosi się w tym przypadku do tabeli o tej nazwie która znajduje się w naszej bazie danych. 
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



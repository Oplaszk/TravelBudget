using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetModels.Models;

namespace TravelBudgetContactContext.Repositories
{
    public class CategoryRepository
    {
        public ContactContext _db { get; set; }

        public CategoryRepository(ContactContext db)
        {
            _db = db;
        }
        
        public List<Category> GetAllCategories()
        {
            return _db.Categories.ToList();
        }
        ////public Category GetCategoryById(int id)
        ////{
        ////    return _db.Categories.Single(c => c.Id == id);
        ////}
    }
}

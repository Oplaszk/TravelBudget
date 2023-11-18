using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBudgetContactContext.Repositories.Interfaces;
using TravelBudgetModels.Models;

namespace TravelBudgetContactContext.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public DBContact _db { get; set; }

        public CategoryRepository(DBContact db)
        {
            _db = db;
        }

        public List<Category> GetAllCategories()
        {
            return _db.Categories.ToList();
        }

    }
}

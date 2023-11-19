using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CategoryRepository> _logger;
        public CategoryRepository(DBContact db, ILogger<CategoryRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public List<Category> GetAllCategories()
        {
            try
            {
                var categories = _db.Categories.ToList();
                return categories;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "En error occurred while retriving categories from database");
                return new List<Category>();
            }
        }
    }
}

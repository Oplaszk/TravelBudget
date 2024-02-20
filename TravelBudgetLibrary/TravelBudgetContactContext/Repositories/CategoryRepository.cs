using Microsoft.Extensions.Logging;
using TravelBudgetDBContact.Repositories.Interfaces;
using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(DBContact db, ILogger<CategoryRepository> logger) : base(db, logger)
        {
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
        public bool CreateNewCategory(Category model)
        {
            try
            {
                _db.Categories.Add(model);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding category model to the database");
                return false;
            }
        }
        public bool DeleteCategory(Category model)
        {
            try
            {
                _db.Categories.Remove(model);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting category model from database");
                return false;
            }

        }
    }
}

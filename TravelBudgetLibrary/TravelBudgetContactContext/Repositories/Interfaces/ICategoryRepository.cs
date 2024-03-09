using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        bool CreateNewCategory(Category model);
        bool DeleteCategory(Category model);
    }
}

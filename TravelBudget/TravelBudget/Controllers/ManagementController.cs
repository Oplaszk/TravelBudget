using Microsoft.AspNetCore.Mvc;
using TravelBudget.ViewModels;
using TravelBudget.ViewModels.Enums;
using TravelBudgetDBContact.Repositories.Interfaces;
using TravelBudgetDBModels.Models;

namespace TravelBudget.Controllers
{
    public class ManagementController : BaseController
    {
        private readonly ManagementViewModel _managementViewModel;
        private readonly ICategoryRepository _categoryRepository;

        public ManagementController(ICategoryRepository categoryRepository, ILogger<ManagementController> logger) : base(logger)
        {
            _managementViewModel = new ManagementViewModel();
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult ManageZone()
        {
            _managementViewModel.CategoryOptions = _categoryRepository.GetAllCategories();

            return View(_managementViewModel);
        }
        [HttpPost]
        public IActionResult CreateCategory(ManagementViewModel model)
        {
            try
            {
                var newCategory = model.Category;
                _categoryRepository.CreateNewCategory(newCategory);

                Notify("New Category created successfully!");
            }
            catch (Exception) 
            {
                Notify("Error while saving category", notificationType: NotificationType.error);
            }
            
            return RedirectToAction(nameof(ManageZone));
 
        }
        [HttpGet]
        public IActionResult DeleteCategory(ManagementViewModel model)
        {
            try
            {
                int indexToDelete = model.Category.Id;
                var categoryToDelete = _categoryRepository.GetAllCategories().FirstOrDefault(c => c.Id == indexToDelete);
                _categoryRepository.DeleteCategory(categoryToDelete);

                Notify("Category type deleted successfully!");
            }
            catch (Exception)
            {
                Notify("Error while deleting category", notificationType: NotificationType.error);
            }

            return RedirectToAction(nameof(ManageZone));
        }
    }
}

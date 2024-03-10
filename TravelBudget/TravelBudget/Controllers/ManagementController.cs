using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelBudget.ViewModels;
using TravelBudget.ViewModels.Enums;
using TravelBudgetDBContact.Repositories.Interfaces;

namespace TravelBudget.Controllers
{
    public class ManagementController(ICategoryRepository categoryRepository, ILogger<ManagementController> logger, IMapper mapper) : BaseController(logger, mapper)
    {
        private readonly ManagementViewModel _managementViewModel = new ManagementViewModel();

        [HttpGet]
        public IActionResult ManageZone()
        {
            _managementViewModel.CategoryOptions = categoryRepository.GetAllCategories();

            return View(_managementViewModel);
        }
        [HttpPost]
        public IActionResult CreateCategory(ManagementViewModel model)
        {
            try
            {
                var newCategory = model.Category;
                categoryRepository.CreateNewCategory(newCategory);

                PopUpNotification("New Category created successfully!");
            }
            catch (Exception) 
            {
                PopUpNotification("Error while saving category", notificationType: NotificationType.error);
            }
            
            return RedirectToAction(nameof(ManageZone));
 
        }
        [HttpGet]
        public IActionResult DeleteCategory(ManagementViewModel model)
        {
            try
            {
                int indexToDelete = model.Category.Id;
                var categoryToDelete = categoryRepository.GetAllCategories().FirstOrDefault(c => c.Id == indexToDelete);
                categoryRepository.DeleteCategory(categoryToDelete);

                PopUpNotification("Category type deleted successfully!");
            }
            catch (Exception)
            {
                PopUpNotification("Error while deleting category", notificationType: NotificationType.error);
            }

            return RedirectToAction(nameof(ManageZone));
        }
    }
}

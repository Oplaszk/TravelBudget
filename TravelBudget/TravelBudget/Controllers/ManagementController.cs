using Microsoft.AspNetCore.Mvc;
using TravelBudget.Models;
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
        public IActionResult ManageZone(ManagementViewModel model)
        {
            var newCategory = model.Category;
            _categoryRepository.CreateNewCategory(newCategory);

            return RedirectToAction("ManageZone"); 
        }
        [HttpGet]
        public IActionResult DeleteCategory(ManagementViewModel model)
        {
            int indexToDelete = model.Category.Id;
            var categoryToDelete = _categoryRepository.GetAllCategories().FirstOrDefault(c => c.Id == indexToDelete);
            _categoryRepository.DeleteCategory(categoryToDelete);

            return RedirectToAction("ManageZone"); 
        }
    }
}

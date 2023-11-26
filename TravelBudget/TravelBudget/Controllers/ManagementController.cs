using Microsoft.AspNetCore.Mvc;
using TravelBudget.Models;
using TravelBudgetContactContext.Repositories.Interfaces;
using TravelBudgetModels.Models;

namespace TravelBudget.Controllers
{
    public class ManagementController : Controller
    {
        private readonly ManagementViewModel _managementViewModel;
        private readonly ICategoryRepository _categoryRepository;

        public ManagementController(ICategoryRepository categoryRepository)
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

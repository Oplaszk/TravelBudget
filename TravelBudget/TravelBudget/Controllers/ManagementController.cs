using Microsoft.AspNetCore.Mvc;
using TravelBudget.Models;
using TravelBudgetContactContext.Repositories.Interfaces;
using TravelBudgetModels.Models;

namespace TravelBudget.Controllers
{
    public class ManagementController : Controller
    {
        private readonly ManagementViewModel _managementViewModel;
        private readonly IManagementRepository _managementRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ManagementController(IManagementRepository managementRepository, ICategoryRepository categoryRepository)
        {
            _managementViewModel = new ManagementViewModel();
            _managementRepository = managementRepository;
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult NewCategory()
        {
            _managementViewModel.CategoryOptions = _categoryRepository.GetAllCategories();
            return View(_managementViewModel);
        }
        [HttpPost]
        public IActionResult NewCategory(ManagementViewModel model)
        {
            var newCategory = model.Category;
            _managementRepository.CreateNewCategory(newCategory);
            return View(); 
        }
        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            var categoryToDelete = _categoryRepository.GetAllCategories().FirstOrDefault(c => c.Id == id);
            _managementRepository.DeleteCategory(categoryToDelete);
            return View(); 
        }
    }
}

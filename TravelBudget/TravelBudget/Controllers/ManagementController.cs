using Microsoft.AspNetCore.Mvc;
using TravelBudget.Models;
using TravelBudgetContactContext.Repositories.Interfaces;

namespace TravelBudget.Controllers
{
    public class ManagementController : Controller
    {
        private readonly ManagementViewModel _managementViewModel;
        private readonly IManagementRepository _managementRepository;
        public ManagementController(IManagementRepository managementRepository)
        {
            _managementViewModel = new ManagementViewModel();
            _managementRepository = managementRepository;
        }
        [HttpGet]
        public IActionResult ManageZone()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult ManageZone(ManagementViewModel model)
        //{
        //    return View(); ;
        //}
    }
}

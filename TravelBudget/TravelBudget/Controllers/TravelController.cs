using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TravelBudget.ViewModels;
using TravelBudgetDBContact.Repositories.Interfaces;

namespace TravelBudget.Controllers
{
    [Authorize]
    public class TravelController : BaseController
    {
        private readonly ITravelRepository _travelRepository;
        private readonly TravelViewModel _travelViewModel;

        public TravelController(ITravelRepository travelRepository, ILogger<TravelController> logger) : base(logger)
        {
            _travelRepository = travelRepository;
            _travelViewModel = new TravelViewModel();
        }

        [HttpGet]
        public IActionResult Index(bool active)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var activeTravels = _travelRepository
            .GetAllTravels(userId, active);

            _travelViewModel.Travels = activeTravels;
            _travelViewModel.Travel.Active = active;

            return View(_travelViewModel);
        }

        #region CREATE Section

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TravelViewModel travelViewModel)
        {
            if (ModelState.IsValid)
            {
                _travelRepository.SaveTravelToDB(travelViewModel.Travel);
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion CREATE Section

        #region UPDATE Section

        [HttpGet]
        public IActionResult Update(int id)
        {
            var travel = _travelRepository.GetById((int)id);
            _travelViewModel.Travel = travel;

            return View("Create", _travelViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(TravelViewModel travelViewModel)
        {
            _travelRepository.UpdateTravel(travelViewModel.Travel);
            return RedirectToAction("Index");
        }

        #endregion UPDATE Section

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var travel = _travelRepository.GetById(id);
            _travelRepository.DeleteTravel(travel);

            return Ok();
        }

        [HttpGet]
        public IActionResult End(int id)
        {
            var selected = _travelRepository.GetById(id);
            _travelRepository.EndTravel(selected);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Retrieve(int id)
        {
            var selected = _travelRepository.GetById(id);
            _travelRepository.RetrieveTravel(selected);
            return RedirectToAction("Index");
        }
    }


}
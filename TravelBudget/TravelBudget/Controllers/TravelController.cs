using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Security.Claims;
using TravelBudget.ViewModels;
using TravelBudget.ViewModels.Enums;
using TravelBudgetDBContact.Repositories.Interfaces;

namespace TravelBudget.Controllers
{
    [Authorize]
    public class TravelController : BaseController
    {
        private readonly ITravelRepository _travelRepository;
        private readonly TravelViewModel _travelViewModel;
        private readonly ICountryRepository _countryRepository;

        public TravelController(ITravelRepository travelRepository, ICountryRepository countryRepository, ILogger<TravelController> logger) : base(logger)
        {
            _travelRepository = travelRepository;
            _countryRepository = countryRepository;
            _travelViewModel = new TravelViewModel();
        }

        [HttpGet]
        public IActionResult Index(bool active)
        {
            ModelState.Clear();
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
            var countries = _countryRepository.GetAllCountriesDTO();

            foreach (var country in countries)
            {
                _travelViewModel.CountriesSelectList.Add(new SelectListItem {Text = country.CountryWithCode, Value = country.Id.ToString() });
            }

            return View(_travelViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TravelViewModel travelViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _travelRepository.SaveTravelToDB(travelViewModel.Travel);
                    bool status = travelViewModel.Travel.Active; 
                    Notify("Travel has been created successfully");

                    return RedirectToAction("Index", "Travel", new {active = status});
                }
            }
            catch (Exception)
            {
                Notify("Error occurred while creating the travel", notificationType: NotificationType.error);
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
            try
            {
                _travelRepository.UpdateTravel(travelViewModel.Travel);

                Notify("Travel has been updated successfully");

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                Notify("Error occurred while updating the travel", notificationType: NotificationType.error);
            }
            return View();
        }

        #endregion UPDATE Section

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {               
                var travelToDelete = _travelRepository.GetById(id);

                TempData["TravelToDelete"] = JsonConvert.SerializeObject(travelToDelete);

                _travelRepository.DeleteTravel(travelToDelete);

                bool status = false;

                return RedirectToAction("Index","Travel", new {active = status});
            }
            catch (Exception)
            {
                Notify("Error occurred while deleting travel", notificationType: NotificationType.error);
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult End(int id)
        {
            try
            {
                var selected = _travelRepository.GetById(id);
                _travelRepository.EndTravel(selected);

                Notify("Your travel has been wrapped up");

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                Notify("Error occurred while wrapping up the travel", notificationType: NotificationType.error);
            }
            return View(nameof(Index));
        }

        [HttpGet]
        public IActionResult Retrieve(int id)
        {
            try
            {
                var selected = _travelRepository.GetById(id);
                _travelRepository.RetrieveTravel(selected);

                Notify("Your travel has been retrieved successfully");

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                Notify("Error occurred while wrapping up the travel", notificationType: NotificationType.error);
            }
            return View(nameof(Index));
        }
    }


}
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Security.Claims;
using TravelBudget.Services;
using TravelBudget.ViewModels;
using TravelBudget.ViewModels.Enums;
using TravelBudgetDBContact.Repositories.Interfaces;


namespace TravelBudget.Controllers
{
    [Authorize]
    public class TravelController(ITravelRepository travelRepository, ICountryRepository countryRepository,
    ILogger<TravelController> logger, IMapper mapper, TravelService travelService) : BaseController(logger, mapper)
    {
        private readonly TravelViewModel _travelViewModel = new TravelViewModel();
        private readonly TravelService _travelService = travelService;

        [HttpGet]
        public IActionResult Index(bool active)
        {
            ModelState.Clear();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var activeTravels = travelRepository
            .GetAllTravels(userId, active);

            _travelViewModel.Travels = activeTravels;
            _travelViewModel.Travel.Active = active;

            return View(_travelViewModel);
        }

        #region CREATE Section

        [HttpGet]
        public IActionResult Create()
        {
            PopulateCountriesSelectList();
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
                    var selectedCountriesId = travelViewModel.SelectedCountriesId.ToList();

                    travelRepository.SaveTravelToDB(travelViewModel.Travel, selectedCountriesId);

                    PopUpNotification("Travel has been created successfully");

                    return RedirectToAction("Index", "Travel");
                }
            }
            catch (Exception)
            {
                PopUpNotification("Error occurred while creating the travel", notificationType: NotificationType.error);
                _travelService.PopulateCountriesSelectList(travelViewModel);
            }

            return View("Create", travelViewModel);
        }

        #endregion CREATE Section

        #region UPDATE Section
        private void PopulateCountriesSelectList()
        {
            var countries = countryRepository.GetAllCountriesDTO();
            _travelViewModel.CountriesSelectList.Clear();

            foreach (var country in countries)
            {
                _travelViewModel.CountriesSelectList.Add(new SelectListItem
                {
                    Text = country.CountryWithCode,
                    Value = country.Id.ToString()                
                });
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var travel = travelRepository.GetTravelById((int)id);
            _travelViewModel.Travel = travel;

            _travelViewModel.SelectedCountriesId = travel.Countries.Select(c => c.Id).ToList();

            _travelViewModel.CountriesSelectList = countryRepository.GetAllCountriesDTO().Select(c =>
            new SelectListItem
            {
                Text = c.CountryWithCode,
                Value = c.Id.ToString(),
            }).ToList();

            return View("Create", _travelViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(TravelViewModel travelViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var selectedCountries = travelViewModel.SelectedCountries;
                    travelRepository.UpdateTravel(travelViewModel.Travel, selectedCountries);

                    PopUpNotification("Travel has been updated successfully");

                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {
                PopUpNotification("Error occurred while updating the travel", notificationType: NotificationType.error);
            }
            return View();
        }

        #endregion UPDATE Section

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {               
                var travelToDelete = travelRepository.GetTravelById(id);

                TempData["TravelToDelete"] = JsonConvert.SerializeObject(travelToDelete);

                travelRepository.DeleteTravel(travelToDelete);

                bool status = false;

                return RedirectToAction("Index","Travel", new {active = status});
            }
            catch (Exception)
            {
                PopUpNotification("Error occurred while deleting travel", notificationType: NotificationType.error);
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult End(int id)
        {
            try
            {
                var selected = travelRepository.GetTravelById(id);
                travelRepository.EndTravel(selected);

                PopUpNotification("Your travel has been wrapped up");

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                PopUpNotification("Error occurred while wrapping up the travel", notificationType: NotificationType.error);
            }
            return View(nameof(Index));
        }

        [HttpGet]
        public IActionResult Retrieve(int id)
        {
            try
            {
                var selected = travelRepository.GetTravelById(id);
                travelRepository.RetrieveTravel(selected);

                PopUpNotification("Your travel has been retrieved successfully");

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                PopUpNotification("Error occurred while wrapping up the travel", notificationType: NotificationType.error);
            }
            return View(nameof(Index));
        }
    }
}
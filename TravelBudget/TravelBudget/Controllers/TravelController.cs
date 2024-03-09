using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Security.Claims;
using TravelBudget.ViewModels;
using TravelBudget.ViewModels.Enums;
using TravelBudgetDBContact.Repositories.Interfaces;
using TravelBudgetDBContact.Response.DTO;
using TravelBudgetDBModels.Models;

namespace TravelBudget.Controllers
{
    [Authorize]
    public class TravelController : BaseController
    {
        private readonly ITravelRepository _travelRepository;
        private readonly TravelViewModel _travelViewModel;
        private readonly ICountryRepository _countryRepository;

        public TravelController(ITravelRepository travelRepository, ICountryRepository countryRepository,
        ILogger<TravelController> logger, IMapper mapper) : base(logger, mapper)
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
        private void PopulateCountriesSelectList()
        {
            var countries = _countryRepository.GetAllCountriesDTO();
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
        private void PopulatePresentCountriesSelectList(ICollection<Country>? countries, TravelViewModel travelViewModelToUpdate)
        {
            _travelViewModel.CountriesSelectList.Clear();

            var countriesSelectList = new List<SelectListItem>();
            foreach (var country in countries)
            {
                var listItem = new SelectListItem
                {
                    Value = country.Id.ToString(),
                    Text = $"{country.Name} ({country.Code})",
                    Selected = true
                };
                countriesSelectList.Add(listItem);

                travelViewModelToUpdate.CountriesSelectList = countriesSelectList;
            }
        }

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

                    _travelRepository.SaveTravelToDB(travelViewModel.Travel, selectedCountriesId);

                    PopUpNotification("Travel has been created successfully");

                    return RedirectToAction("Index", "Travel");
                }
            }
            catch (Exception)
            {
                PopUpNotification("Error occurred while creating the travel", notificationType: NotificationType.error);
                PopulateCountriesSelectList();
            }

            return View("Create", travelViewModel);
        }

        #endregion CREATE Section

        #region UPDATE Section

        [HttpGet]
        public IActionResult Update(int id)
        {
            var travel = _travelRepository.GetTravelById((int)id);
            var travelViewModelToUpdate = _travelViewModel;
            travelViewModelToUpdate.Travel = travel;

            var travelCountries = travel.Countries;

            PopulatePresentCountriesSelectList(travelCountries, travelViewModelToUpdate);

            return View("Create", travelViewModelToUpdate);
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
                    _travelRepository.UpdateTravel(travelViewModel.Travel, selectedCountries);

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
                var travelToDelete = _travelRepository.GetTravelById(id);

                TempData["TravelToDelete"] = JsonConvert.SerializeObject(travelToDelete);

                _travelRepository.DeleteTravel(travelToDelete);

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
                var selected = _travelRepository.GetTravelById(id);
                _travelRepository.EndTravel(selected);

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
                var selected = _travelRepository.GetTravelById(id);
                _travelRepository.RetrieveTravel(selected);

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
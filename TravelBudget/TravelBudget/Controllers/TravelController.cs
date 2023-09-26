using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using TravelBudget.Models;
using TravelBudgetContactContext.Repositories;
using TravelBudgetModels.Models;

namespace TravelBudget.Controllers
{
    public class TravelController : Controller
    {
        TravelRepository _travelRepository { get; set; }
        public TravelController(TravelRepository travelRepository)
        {
            _travelRepository = travelRepository;   
        }
        public IActionResult Index()
        {
            var travelsFromDB = _travelRepository.GetAllTravel();
            var activeTravels = travelsFromDB.Where(t => t.Active == true).ToList();
            TravelViewModel travelViewModel = new TravelViewModel();
            travelViewModel.Travels = activeTravels;
  
            return View(travelViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Travel travel)
        {
            return View();
        }

        public IActionResult History()
        {
            var travelsFromDB = _travelRepository.GetAllTravel();
            var inactiveTravels = travelsFromDB.Where(t => t.Active == false).ToList();
            TravelViewModel travelViewModel = new TravelViewModel();
            travelViewModel.Travels = inactiveTravels;

            return View(travelViewModel);
        }
    }
}

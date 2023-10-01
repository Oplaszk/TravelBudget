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
            //var travelsFromDB = _travelRepository.GetAllTravels();
            var activeTravels = _travelRepository.GetAllTravels().Where(t => t.Active == true);// usunąlem .ToList(); na końcu, a
            TravelViewModel travelViewModel = new TravelViewModel();
            travelViewModel.Travels = activeTravels;
  
            return View(travelViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Travel travel)
        {
            _travelRepository.Create(travel);
            return View();
        }

        public IActionResult History()
        {
            var travelsFromDB = _travelRepository.GetAllTravels();
            var inactiveTravels = travelsFromDB.Where(t => t.Active == false).ToList();
            TravelViewModel travelViewModel = new TravelViewModel();
            travelViewModel.Travels = inactiveTravels;

            return View(travelViewModel);
        }
    }
}

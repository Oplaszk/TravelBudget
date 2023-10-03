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
            var activeTravels = _travelRepository.GetAllTravels().Where(t => t.Active == true);
            TravelViewModel travelViewModel = new TravelViewModel();
            travelViewModel.Travels = activeTravels;

            return View(travelViewModel);
        }

        public IActionResult History()
        {
            var travelsFromDB = _travelRepository.GetAllTravels();
            var inactiveTravels = travelsFromDB.Where(t => t.Active == false).ToList();
            TravelViewModel travelViewModel = new TravelViewModel();
            travelViewModel.Travels = inactiveTravels;

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
            _travelRepository.SaveToDB(travel);
            if (travel.Active == true)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("History");
        }

        
        public IActionResult Edit(int id)
        {
            var travel = _travelRepository.GetById((int)id);
            return View("Create", travel);
        }

        [HttpPost]
        public IActionResult Edit(Travel travel)
        {
            _travelRepository.UpdateTravel(travel);
            return RedirectToAction("Index");
        }


    }
}

﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using TravelBudget.ViewModels;
using TravelBudgetDBContact.Repositories;
using TravelBudgetDBContact.Repositories.Interfaces;
using TravelBudgetDBModels.Models;

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
        #region READ Section
        [HttpGet]
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var activeTravels = _travelRepository
            .GetAllTravels(userId, true);

            _travelViewModel.Travels = activeTravels;

            return View(_travelViewModel);
        }
        [HttpGet]
        public IActionResult History()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var inactiveTravels = _travelRepository
            .GetAllTravels(userId, false).Where(t => t.Active == false);
            _travelViewModel.Travels = inactiveTravels;

            return View(_travelViewModel);
        }
        #endregion
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
            _travelRepository.SaveTravelToDB(travelViewModel.Travel);
            if (travelViewModel.Travel.Active == true)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("History");
        }
        #endregion
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
        #endregion
        #region DELETE Section
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var travel = _travelRepository.GetById(id);
            _travelRepository.DeleteTravel(travel);
            return RedirectToAction("History");
        }
        #endregion
        #region End Travel Section
        [HttpGet]
        public IActionResult End(int id)
        {
            var selected = _travelRepository.GetById(id);
            _travelRepository.EndTravel(selected);
            return RedirectToAction("History");
        }
        #endregion
        #region Retrieve Travel Section
        [HttpGet]
        public IActionResult Retrieve(int id)
        {
            var selected = _travelRepository.GetById(id);
            _travelRepository.RetrieveTravel(selected);
            return RedirectToAction("Index");
        }
        #endregion
    }
}

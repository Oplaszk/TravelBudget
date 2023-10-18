﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
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
        private readonly TravelRepository _travelRepository;
        private readonly TravelViewModel _travelViewModel;
        private readonly ExpenseViewModel _expenseViewModel;
        public TravelController(TravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
            _travelViewModel = new TravelViewModel();
        }
        #region TRAVEL SECTION
        #region READ section
        public IActionResult Index()
        {
            var activeTravels = _travelRepository.GetAllTravels().Where(t => t.Active == true);
            _travelViewModel.Travels = activeTravels;
            return View(_travelViewModel);
        }

        public IActionResult History()
        {
            var travelsFromDB = _travelRepository.GetAllTravels();
            var inactiveTravels = travelsFromDB.Where(t => t.Active == false);
            _travelViewModel.Travels = inactiveTravels;
            return View(_travelViewModel);
        }
        #endregion
        #region CREATE section
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Travel travel)
        {
            _travelRepository.CreateTravel(travel);
            if (travel.Active == true)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("History");
        }
        #endregion
        #region UPDATE section
        public IActionResult Update(int id)
        {
            var travel = _travelRepository.GetById((int)id);
            return View("Create", travel);
        }

        [HttpPost]
        public IActionResult Update(Travel travel)
        {
            _travelRepository.UpdateTravel(travel);
            return RedirectToAction("Index");
        }
        #endregion
        #region DELETE section
        public IActionResult Delete(int id)
        {
            {
                var travel = _travelRepository.GetById(id);
                _travelRepository.DeleteTravel(travel);
                return RedirectToAction("History");
            }
        }
            #endregion
        #region End Travel section
            public IActionResult End(int id)
        {
            var selected = _travelRepository.GetById(id);
            _travelRepository.EndTravel(selected);
            return RedirectToAction("History");
        }
        #endregion
        #region Retrieve Travel section
        public IActionResult Retrieve(int id)
        {
            var selected = _travelRepository.GetById(id);
            _travelRepository.RetrieveTravel(selected);
            return RedirectToAction("Index");
        }
        #endregion
        #endregion
        #region EXPENSE SECTION
        [HttpGet]
        public IActionResult AddExpense()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddExpense(Expense expense)
        {
            return RedirectToAction("Index");
        }
        #endregion
    }
}

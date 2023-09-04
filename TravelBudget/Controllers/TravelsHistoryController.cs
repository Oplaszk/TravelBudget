﻿using Microsoft.AspNetCore.Mvc;
using TravelBudget.Models.TravelsHistoryModels;

namespace TravelBudget.Controllers
{
    public class TravelsHistoryController : Controller
    {
        public IActionResult Index()
        {
            List<TravelsHistory> travelsHistory = new List<TravelsHistory>()
            {
                 new TravelsHistory()
                 {
                     Country = "Italy",
                     Continent = "Europe",
                     StartingDate = new DateTime(2023, 10, 10),
                     FinishDate = new DateTime(2023, 10, 15)
                 },
                 new TravelsHistory() 
                 {
                     Country = "Jordan",
                     Continent = "Asia",
                     StartingDate = new DateTime(2023, 12, 6),
                     FinishDate = new DateTime(2023, 12, 12)
                 }
            };

            return View(travelsHistory);
        }
    }
}

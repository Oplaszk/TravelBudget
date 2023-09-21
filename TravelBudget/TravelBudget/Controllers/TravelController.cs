using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TravelBudget.Models;
using TravelBudgetModels.Models;

namespace TravelBudget.Controllers
{
    public class TravelController : Controller
    {
        public IActionResult Index()
        {
            TravelViewModel travelViewModel = new TravelViewModel
            {
               Travels = new List<Travel>
                {
                    new Travel
                    {
                        Id = 1,
                        StartingDate = new DateTime(2023, 10, 10, 06, 15, 0),
                        FinishDate = new DateTime(2023, 10, 20, 06, 15, 0),
                        Name = "Adventure to Sardinia",
                        Description = "Visiting the whole island",
                        Active = true
                    },
                    new Travel
                    {
                        Id = 2,
                        StartingDate = new DateTime(2022, 08, 16, 06, 15, 0),
                        FinishDate = new DateTime(2022, 08, 25, 06, 15, 0),
                        Name = "Jordan trip",
                        Description = "Trip to Jordan with strangers",
                        Active = true
                    }
                }
            };

            return View(travelViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult History()
        {
            List<Travel> travelsHistory = new List<Travel>
            {
                new Travel
                {
                    Id = 1,
                    StartingDate = new DateTime(2022, 12, 16, 06, 15, 0),
                    FinishDate = new DateTime(2022, 12, 20, 06, 15, 0),
                    Name = "Adventure to Sicily",
                    Description = "Visiting at least half of the island",
                    Active = false
                },
                new Travel
                {
                    Id = 2,
                    StartingDate = new DateTime(2022, 08, 16, 06, 15, 0),
                    FinishDate = new DateTime(2022, 08, 25, 06, 15, 0),
                    Name = "Balkans conquering",
                    Description = "Visiting 4 different countries in the Balkans",
                    Active = false
                }
            };

            return View(travelsHistory);
        }
    }
}

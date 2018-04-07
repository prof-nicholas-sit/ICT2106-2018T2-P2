﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Models;
using UsageStatistics.Models;

namespace UsageStatistics.Controllers
{
    public class EnergyAdviseController : Controller
    {
        protected Session _session;

        // GET: EnergyUsage
        public ActionResult Index(int month = 1)
        {
            _session = Session.getInstance;

            if (_session != null)
            {
                EnergyAdvise energyAdvise = new EnergyAdvise(month);

                switch (month)
                {
                    case 1:
                        energyAdvise.month = "Jan";
                        break;
                    case 2:
                        energyAdvise.month = "Feb";
                        break;
                    case 3:
                        energyAdvise.month = "Mar";
                        break;
                    default:
                        ViewBag.Period = null;
                        break;
                }

                return View(energyAdvise);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Models;
using UsageStatistics.Models;

namespace UsageStatistics.Controllers
{
    public class EnergyUsageController : Controller
    {
        private Session _session;

        // GET: EnergyUsage
        public ActionResult Index(string location, string type, string timePeriod)
        {
            _session = Session.getInstance;

            if (_session.IsLogin())
            {
                EnergyUsage result = new EnergyUsage();

                // gets individal energy usage in kwh and rounding it off to 2dp
                ViewBag.sum = Math.Round(result.IndividualEnergyUsage(location, type, timePeriod), 2);
                ViewBag.location = location;

                return View(result);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }          
            
        }
        
    }
}
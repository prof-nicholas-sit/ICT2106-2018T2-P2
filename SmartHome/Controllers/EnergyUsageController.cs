using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UsageStatistics.Models;

namespace UsageStatistics.Controllers
{
    public class EnergyUsageController : Controller
    {    
        // GET: EnergyUsage
        public ActionResult Index(string location, string type, string timePeriod)
        {
            EnergyUsage result = new EnergyUsage();
            
            // gets individal energy usage in kwh and rounding it off to 2dp
            ViewBag.sum = Math.Round(result.IndividualEnergyUsage(location, type, timePeriod), 2);
            ViewBag.location = location;

            return View(result);
        }
        
        // GET: EnergyUsage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }        
    }
}
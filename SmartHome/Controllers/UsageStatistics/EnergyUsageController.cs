using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public ActionResult Index(string location, string name, string timePeriod)
        {
            _session = Session.getInstance;

            if (_session != null)
            {
                EnergyUsage result = new EnergyUsage(timePeriod);

<<<<<<< HEAD
                if (location == null)
                {
                    result.Location = result.Locations[0];
                } 
                else
                {
                    result.Location = location;
                }

                if (name == null)
                {
                    result.Name = result.DevicesInLocation[0];
                }
                else
                {
                    result.Name = name;
                }

                if (timePeriod == null)
                {
                    result.TimePeriod = "daily";
                }
                else
                {
                    result.TimePeriod = timePeriod;
                }
=======
                // gets individal energy usage in kwh and rounding it off to 2dp
                ViewBag.sum = Math.Round(result.IndividualEnergyUsage(location, type), 2);
                ViewBag.location = location;
>>>>>>> 6404fea4306eb812f59c6de216739c7d0ee44800

                return View(result);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }            
        }        
    }
}
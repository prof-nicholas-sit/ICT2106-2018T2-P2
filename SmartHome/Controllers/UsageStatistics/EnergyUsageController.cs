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
                
                return View(result);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }            
        }        
    }
}
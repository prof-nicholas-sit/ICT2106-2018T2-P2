using Microsoft.AspNetCore.Mvc;
using SmartHome.Models;
using UsageStatistics.Models;

namespace UsageStatistics.Controllers
{
    public class EnergyAdviseController : Controller
    {
        private Session _session;

        // GET: EnergyUsage
        public ActionResult Index(int month = 1)
        {
            _session = Session.getInstance;

            if (_session != null)
            {
                EnergyAdvise energyAdvise = new EnergyAdvise(month);
             
                return View(energyAdvise);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }        
    }
}
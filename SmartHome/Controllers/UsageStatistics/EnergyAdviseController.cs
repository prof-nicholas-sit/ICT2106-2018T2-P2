using System;
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
<<<<<<< HEAD

                return View();
=======
                EnergyAdvise energyAdvise = new EnergyAdvise(month);
                return View(energyAdvise);
>>>>>>> 6404fea4306eb812f59c6de216739c7d0ee44800
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }        
    }
}
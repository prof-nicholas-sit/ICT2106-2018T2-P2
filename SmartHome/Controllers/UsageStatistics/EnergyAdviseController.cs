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
        public ActionResult Index()
        {
            _session = Session.getInstance;

            if (_session.IsLogin())
            {

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }        
    }
}
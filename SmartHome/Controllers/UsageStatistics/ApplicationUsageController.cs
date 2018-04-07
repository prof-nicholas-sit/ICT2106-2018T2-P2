using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHome;
using SmartHome.Models;
using UsageStatistics.Models;

namespace UsageStatistics.Controllers
{
    public class ApplicationUsageController : Controller
    {
        private readonly ApplicationUsage applicationUsage;
        protected Session _session;

        public ApplicationUsageController([FromServices] IAppLogCreator ac, [FromServices] IAppLogRetriever ar) {
            ac.PushLogs();
            applicationUsage = new ApplicationUsage(ar);
        }

        // GET: EnergyUsage
        public ActionResult Index(string period = null)
        {
            switch (period)
            {
                case "daily":
                    applicationUsage.TimePeriod = "daily";
                    break;
                case "weekly":
                    applicationUsage.TimePeriod = "weekly";
                    break;
                case "monthly":
                    applicationUsage.TimePeriod = "monthly";
                    break;
                default:
                    ViewBag.Period = null;
                    break;
            }
            return View(applicationUsage);
        }
    }
}
using System;
using System.Collections.Generic;
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

        public ApplicationUsageController([FromServices] IAppLogCreator ac, [FromServices] IAppLogRetriever ar) {
            ac.PushLogs();
            applicationUsage = new ApplicationUsage(ar);
        } 

        // GET: EnergyUsage
        public ActionResult Index()
        {
            return View(applicationUsage);
        }

        // GET: EnergyUsage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }        
    }
}
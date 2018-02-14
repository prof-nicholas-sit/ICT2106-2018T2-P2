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
    public class EnergyUsageController : Controller
    {    
        // GET: EnergyUsage
        public ActionResult Index()
        {
            return View(new EnergyUsage());
        }
        
        // GET: EnergyUsage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }        
    }
}
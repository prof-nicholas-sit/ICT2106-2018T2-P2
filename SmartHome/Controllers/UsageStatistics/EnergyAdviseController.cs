using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UsageStatistics.Controllers
{
    public class EnergyAdviseController : Controller
    {
        // GET: EnergyUsage
        public ActionResult Index()
        {
            return View();
        }

        // GET: EnergyUsage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }        
    }
}
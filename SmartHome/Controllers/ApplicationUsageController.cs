using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Models;

namespace UsageStatistics.Controllers
{
    public class ApplicationUsageController : Controller
    {
        // GET: EnergyUsage
        public ActionResult Index()
        {
            AppLog appLog = new AppLog("user.login", DateTime.Now, 2);
            Console.WriteLine(appLog.ToString());

            AppLog appLog1 = new AppLog("user.login", DateTime.Now, values: "yolo");
            Console.WriteLine(appLog1.ToString());
            return View();
        }

        // GET: EnergyUsage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }        
    }
}
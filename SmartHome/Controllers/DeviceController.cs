using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Models;

namespace SmartHome.Controllers
{
    public class DeviceController : Controller
    {
        static List<Device> model = new List<Device>();

        public IActionResult Index()
        {
            //Device t = new Device("1", "1", "1","1");
            //var device1 = new Device();
            //model.Add(device1);
            /*
            var tour1 = new Tour();
            tour1.Name = "Cali Walking Tour";

            var tour2 = new Tour();
            tour2.Name = "Cali Cycling Tour";

            //var model = new List<Tour> { tour1, tour2 };
            model.Add(tour1);
            model.Add(tour2);
            return View(model);
            */
            //model.Add(t);
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult SelectType()
        {
            ViewData["Message"] = "Your create page.";

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(String param, Device device)
        {

            try
            {
                // TODO: Add insert logic here
                model.Add(device);
                ViewData["Message"] = param;
                //return View("Index", device);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
         
            // ViewData["Message"] = "Your create page.";
            //ViewData["Message"] = param;


            //return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

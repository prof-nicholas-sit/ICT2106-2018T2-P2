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

        //GET METHOD
        public IActionResult Create(String param)
        {
            string deviceType = Request.Query["deviceType"].ToString();
            ViewBag.deviceType = deviceType;
            return View();
        }


        //POST METHOD
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
            
        }


        // GET: Tours/Edit/5
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Device result = model.FirstOrDefault();
            //Lamda function to find ID
            model.ForEach(x =>
            {
                if (id == x.DeviceID) { 
                    result = x;
                }
            });

            return View(result);
        }

        
        //Post Form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("DeviceID", "HouseholdID", "DeviceName", "Location", "Brand", "Model", "Type", "State", "UsageKwH", "favourite", "timestamp")] Device device)
        {
            //Device obj = model.FirstOrDefault(x => x.DeviceID == id);
            //obj = device;
            Device result = model.FirstOrDefault();
            //Lamda function to find ID
            model.ForEach(x =>
            {
                if (id == x.DeviceID) { 
                    result.HouseholdID = device.HouseholdID;
                    result.DeviceName = device.DeviceName;
                    result.Location = device.Location;
                    result.Brand = device.Brand;
                    result.Model = device.Model;
                    result.Type = device.Type;
                    result.HouseholdID = device.HouseholdID;
                    result.State = device.State;
                    result.UsageKwH = device.UsageKwH;
                    result.favourite = device.favourite;
                    result.timestamp = device.timestamp;
                }
            });



            return RedirectToAction(nameof(Index));
        }



        // GET: Tours/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Device result = model.FirstOrDefault();
            //Lamda function to find ID
            model.ForEach(x =>
            {
                if (id == x.DeviceID)
                {
                    result = x;
                }
            });

            return View(result);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var itemToRemove = model.Single(x => x.DeviceID == id);
            model.Remove(itemToRemove);
            return RedirectToAction(nameof(Index));
        }







        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

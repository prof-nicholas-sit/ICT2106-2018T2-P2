using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using SmartHome.Models.SmartDevice;
using SmartHome.Models.SmartDevice.SmartAircon;
//using SmartHome.Models.SmartDevice.SmartAirconFactory;
using SmartHome.Models;
using SmartHome.Models.SmartDevice.SmartFan;
using SmartHome.Models.SmartDevice.SmartLight;

namespace SmartHome.Controllers
{
    public class DeviceController : Controller
    {

        static int tmpID = 0;
        static List<SmartDevice> model = new List<SmartDevice>();

        public IActionResult Index()
        {
            return View(model);
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
        public IActionResult Create(String param, String DeviceName,String Location,String Brand,String Model,String Type)
        {
            //Device
            try
            {
                tmpID++;
                int ID =tmpID;
                DeviceFactory FD = new DeviceFactory();
                IDevice SmartDeviceObj = FD.getDevice(ID,0,DeviceName,Location,Brand,Model,Type,0);
                if (SmartDeviceObj.GetType() == typeof(MySmartAircon))
                {
                    model.Add((MySmartAircon)SmartDeviceObj);
                }
                else if(SmartDeviceObj.GetType()==typeof(MySmartFan))

                {
                    model.Add((MySmartFan)SmartDeviceObj);
                }
                else
                {
                    model.Add((MySmartLight)SmartDeviceObj);
                }

                ViewData["Message"] = param;
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
            if (id == null)
            {
                return NotFound();
            }

            SmartDevice result = model.FirstOrDefault();
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


        //Post Form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("DeviceID", "HouseholdID", "DeviceName", "Location", "Brand", "Model",  "State", "UsageKwH", "favourite", "timestamp")] SmartDevice device)
        {
            SmartDevice result = model.FirstOrDefault();
            //Lamda function to find ID
            model.ForEach(x =>
            {
                if (id == x.DeviceID)
                {
                    result.HouseholdID = device.HouseholdID;
                    result.DeviceName = device.DeviceName;
                    result.Location = device.Location;
                    result.Brand = device.Brand;
                    result.Model = device.Model;
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

            SmartDevice result = model.FirstOrDefault();
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


    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SmartHome.Models;

namespace SmartHome.Controllers
{
    public class DeviceLogController : Controller
    {
        static List<DeviceLog> logList = new List<DeviceLog>();

        public ActionResult Index()
        {
            // Dummy data
            var log1 = new DeviceLog(1, "Mitusubishi Aircon", "Bedroom", "Air Con", "ON",0);
            var log2 = new DeviceLog(2, "Mitusubishi Aircon", "Bedroom", "Air con", "OFF", 120.0);
            var log3 = new DeviceLog(3, "Toshiba Fan", "Living room", "Fan", "ON", 0);
            var log4 = new DeviceLog(4, "Toshiba fan ", "Living room", "Fan", "OFF", 100.0);
            var log5 = new DeviceLog(5, "Led light", "Kitchen", "Light", "ON", 0);
            var log6 = new DeviceLog(6, "Led light", "Kitchen", "Light", "OFF", 200.0);


            var logList = new List<DeviceLog> { log1,log2,log3,log4,log5,log6 };
            
           

            return View(logList);
        }

        public IActionResult LogManagement()
        {
            return View();
        }

        public IActionResult UploadToDB()
        {

            return View();
        }

        public IActionResult ExportFile()
        {
            
            return View();
        }

        public IActionResult SortLogs()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Models;

namespace UsageStatistics.Controllers
{
    public class EnergyUsageController : Controller
    {    
        // GET: EnergyUsage
        public ActionResult Index()
        {
            // creating a fake device and device logs for that device
            int deviceId = 1;
            Device device = new Device(deviceId, "Living room", 150, "Fridge");

            List<DeviceLogs> allDeviceLogs = new List<DeviceLogs>();
            
            DeviceLogs deviceLog1 = new DeviceLogs(1, deviceId, new DateTime(2018, 02, 10, 12, 00, 00), "off");
            DeviceLogs deviceLog2 = new DeviceLogs(2, deviceId, new DateTime(2018, 02, 10, 13, 00, 00), "on");
            DeviceLogs deviceLog3 = new DeviceLogs(3, deviceId, new DateTime(2018, 02, 11, 00, 00, 00), "off");
            DeviceLogs deviceLog4 = new DeviceLogs(4, deviceId, new DateTime(2018, 02, 12, 00, 00, 00), "on");

            allDeviceLogs.Add(deviceLog1);
            allDeviceLogs.Add(deviceLog2);
            allDeviceLogs.Add(deviceLog3);
            allDeviceLogs.Add(deviceLog4);

            // for each device log, call calculateEnergyUsage
            foreach (DeviceLogs log in allDeviceLogs)
            {

            }

            return View();
        }

        // GET: EnergyUsage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }        
    }
}
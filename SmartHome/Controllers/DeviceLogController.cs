using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Models;

namespace SmartHome.Controllers
{
    public class DeviceLogController : Controller
    {
        public IActionResult Index()
        {

            return View();
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using SmartHome.Models;
using SmartHome.Utility;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SmartHome.Controllers
{
    public class DeviceLogController : Controller
    {
        static List<DeviceLog> logList = new List<DeviceLog>();
		private readonly IHostingEnvironment _hostingEnvironment;

        List<DeviceLog> dataList = new List<DeviceLog>();

        

        string jsonDummy = @"[{
   'ID': 1001,
   'householdID': 200,
   'name': 'Mitsubishi',
   'location': 'Living Room',
   'type': 'aircon',
   'state': 'ON',
    'kWh': 120.0,
   'dateTime': '1/6/2013 12:32:00 PM'},
{'ID': 1002,
   'householdID': 300,
   'name': 'Mitsubishi',
   'location': 'Bedroom',
   'type': 'light',
   'state': 'ON',
    'kWh': 200.0,
   'dateTime': '1/6/2013 12:32:00 PM'
}
]
  

";

        public DeviceLogController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
		
        public ActionResult Index()
        {
            // Dummy data
            // Temporary commented out due to protected access type for DeviceLog
            // If need to use change it to public 
            //var log1 = new DeviceLog(1, 1001, "Mitusubishi Aircon", "Bedroom", "Air Con", "ON", 0);
            //var log2 = new DeviceLog(2, 1001, "Mitusubishi Aircon", "Bedroom", "Air con", "OFF", 120.0);
            //var log3 = new DeviceLog(3, 1011, "Toshiba Fan", "Living room", "Fan", "ON", 0);
            //var log4 = new DeviceLog(4, 1011, "Toshiba fan ", "Living room", "Fan", "OFF", 0);
            //var log5 = new DeviceLog(5, 1011, "Led light", "Kitchen", "Light", "ON", 0);
            //var log6 = new DeviceLog(6, 1011, "Led light", "Kitchen", "Light", "OFF", 200.0);


            //var logList = new List<DeviceLog> { log1, log2, log3, log4, log5, log6 };


            return View(JsonToDeviceObject(jsonDummy));
        }

        public IActionResult LogManagement()
        {
            return View();
        }

		public ActionResult UploadToDB()
        {
            return View();
        }
		
        [HttpPost] 
        [Route("UploadToDB")]
        public ActionResult UploadToDB(string path) 
        {
            System.Diagnostics.Debug.WriteLine("Path = " + path);
            var filePath = path;
            FileInfo file = new FileInfo(filePath);

            // Can use for csv
            //using (StreamReader sr = file.OpenText())
            //{
            //    string s = "";
            //    while ((s = sr.ReadLine()) != null)
            //    {
            //        System.Diagnostics.Debug.WriteLine("MESSAGESSSSSSSSSSSS = " + s);
            //        Console.WriteLine(s);
            //    }
            //}

            // For xlsx
            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(filePath)))
            {
                var myWorksheet = xlPackage.Workbook.Worksheets.First(); //select sheet here
                var totalRows = myWorksheet.Dimension.End.Row;
                var totalColumns = myWorksheet.Dimension.End.Column;

                
                for (int rowNum = 1; rowNum <= totalRows; rowNum++) //selet starting row here
                {
                    var row = myWorksheet.Cells[rowNum, 1, rowNum, totalColumns].Select(c => c.Value == null ? string.Empty : c.Value.ToString());
                    var sb = new StringBuilder(); //this is your your data
                    sb.AppendLine(string.Join(",", row));
                    string[] tokens = sb.ToString().Split(",");
                    DeviceLogFactory dlf = new DeviceLogFactory(tokens);
                    dlf.CreateClass();

                    //DeviceLog dataset = new DeviceLog();
                    //dataset.Id = Convert.ToInt32(tokens[0]);
                    //dataset.householdId = Convert.ToInt32(tokens[1]);
                    //dataset.name = tokens[2];
                    //dataset.location = tokens[3];
                    //dataset.type = tokens[4];
                    //dataset.state = tokens[5];
                    //dataset.kWh = Convert.ToDouble(tokens[6]);
                    //dataset.dateTime = DateTime.Parse(tokens[7]);
                    ////dataset.dateTime = DateTime.ParseExact(tokens[7], "dd/MM/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                    //dataList.Add(dataset);
                }
            }
            return View(dataList);

            
        }

        public IActionResult ExportFile()
        {
            
            return View();
        }

        // Export log
        [HttpGet]
        public FileContentResult ExportToExcel()
        {
            //List<DeviceLog> technologies = TempData["test"];'
            // Added household ID
            var log1 = new DeviceLog(1, 1001, "Mitusubishi Aircon", "Bedroom", "Air Con", "ON", 0);
            var log2 = new DeviceLog(2, 1001, "Mitusubishi Aircon", "Bedroom", "Air con", "OFF", 120.0);
            var log3 = new DeviceLog(3, 1011, "Toshiba Fan", "Living room", "Fan", "ON", 0);
            var log4 = new DeviceLog(4, 1011, "Toshiba fan ", "Living room", "Fan", "OFF", 100.0);
            var log5 = new DeviceLog(5, 1011, "Led light", "Kitchen", "Light", "ON", 0);
            var log6 = new DeviceLog(6, 1011, "Led light", "Kitchen", "Light", "OFF", 200.0);


            List<DeviceLog> logList = new List<DeviceLog> { log1, log2, log3, log4, log5, log6 };

            string[] columns = { "name", "location", "type","state","kWh","dateTime"};
            byte[] filecontent = ExcelExportHelper.ExportExcel(logList, "Device Log", true, columns);
            String date = DateTime.Now.ToString("dd-MM-yyyy");
            return File(filecontent, ExcelExportHelper.ExcelContentType, "DeviceLog-"+date+".xlsx");
        }

        public IActionResult SortLogs()
        {
            return View();
        }

        [HttpPost]
        public IList<DeviceLog> JsonToDeviceObject(string j) {
           
           // List<DeviceLog> temp = new List<DeviceLog>();

            IList<DeviceLog> TeamsList = new List<DeviceLog>();

            TeamsList = JsonConvert.DeserializeObject<List<DeviceLog>>(j);

            //temp.Add(newDeviceLoggy);

            return TeamsList;
        }

      
    }
}
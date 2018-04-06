using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
using SmartHome.DAL.Mappers;
using MongoDB.Bson;

namespace SmartHome.Controllers
{
    public class DeviceLogController : Controller
    {
        static List<DeviceLog> logList = new List<DeviceLog>();
        DeviceLogFactory dlf = new DeviceLogFactory();


        private readonly IHostingEnvironment _hostingEnvironment;

        List<DeviceLog> dataList = new List<DeviceLog>();


        public DeviceLogController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        
        public IActionResult Index()
        {
            // apiController.cs will be called

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
            List<DeviceLog> logs = new List<DeviceLog>();
            System.Diagnostics.Debug.WriteLine("Path = " + path);
            var filePath = path;
            FileInfo file = new FileInfo(filePath);
            System.Diagnostics.Debug.WriteLine(file.FullName);

            try
            {
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

                        logs.Add(dlf.CreateClass(tokens));
                    }
                }
            }

            catch (Exception e)
            {

            }
            new DeviceLogMapper().CreateLogs(logs).Save().Commit();
           
            
            return View(dataList);
        }

        public IActionResult ExportFile()
        {
            
            return View();
        }

        // Export log/ currently hardcoded
        [HttpGet]
        public FileContentResult ExportToExcel()
        { 
            string[] columns = { "name", "location", "type","state","kWh","dateTime"};
            byte[] filecontent = ExcelExportHelper.ExportExcel(logList, "Device Log", true, columns);
            String date = DateTime.Now.ToString("dd-MM-yyyy");
            return File(filecontent, ExcelExportHelper.ExcelContentType, "DeviceLog-"+date+".xlsx");
        }

   
      
    }
}
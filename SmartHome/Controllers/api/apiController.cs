using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartHome.Controllers.api
{
    [Route("api/apiController")]
    public class apiController : Controller
    {
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post()
        {
            var requestFormData = Request.Form;
            List<Models.DeviceLog> lstItems = GetData();
            
            var list = ProcessCollection(lstItems, requestFormData);

            dynamic response = new
            {
                Data = list,
                Draw = requestFormData["draw"],
                RecordsFiltered = lstItems.Count,
                RecordsTotal = lstItems.Count
            };

            return Ok(response);
        }

        // Get a list of Items
        private List<Models.DeviceLog> GetData()
        {
            var log1 = new DeviceLog(1, 1001, "Mitusubishi Aircon", "Bedroom", "Air Con", "ON", 0);
            var log2 = new DeviceLog(2, 1001, "Mitusubishi Aircon", "Bedroom", "Air con", "OFF", 120.0);
            var log3 = new DeviceLog(3, 1011, "Toshiba Fan", "Living room", "Fan", "ON", 0);
            var log4 = new DeviceLog(4, 1011, "Toshiba fan ", "Living room", "Fan", "OFF", 0);
            var log5 = new DeviceLog(5, 1011, "Led light", "Kitchen", "Light", "ON", 0);
            var log6 = new DeviceLog(6, 1011, "Led light", "Kitchen", "Light", "OFF", 200.0);

            var logList = new List<DeviceLog> { log1, log2, log3, log4, log5, log6 };

            return logList;
        }

        private PropertyInfo getProperty(string name)
        {
            var properties = typeof(Models.DeviceLog).GetProperties();
            PropertyInfo prop = null;
            foreach (var item in properties)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    prop = item;
                    break;
                }
            }
            return prop;
        }

        private List<Models.DeviceLog> ProcessCollection(List<Models.DeviceLog> lstElements, IFormCollection requestFormData)
        {
            var skip = Convert.ToInt32(requestFormData["start"].ToString());
            var pageSize = Convert.ToInt32(requestFormData["length"].ToString());
            Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };

            if (requestFormData.TryGetValue("order[0][column]", out tempOrder))
            {
                var columnIndex = requestFormData["order[0][column]"].ToString();
                var sortDirection = requestFormData["order[0][dir]"].ToString();
                tempOrder = new[] { "" };
                if (requestFormData.TryGetValue($"columns[{columnIndex}][data]", out tempOrder))
                {
                    var columName = requestFormData[$"columns[{columnIndex}][data]"].ToString();

                    if (pageSize > 0)
                    {
                        var prop = getProperty(columName);
                        if (sortDirection == "asc")
                        {
                            return lstElements.OrderBy(prop.GetValue).Skip(skip).Take(pageSize).ToList();
                        }
                        else
                            return lstElements.OrderByDescending(prop.GetValue).Skip(skip).Take(pageSize).ToList();
                    }
                    else
                        return lstElements;
                }
            }
            return null;
        }
    }
}

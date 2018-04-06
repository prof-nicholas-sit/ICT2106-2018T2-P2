using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Models;
using MongoDB.Bson;
using SmartHome.DAL.Mappers;

namespace SmartHome.Controllers.api
{
    [Route("DeviceLogs/apiController")]
    public class apiController : Controller
    {
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post()
        {
            var requestFormData = Request.Form;
            List<Models.DeviceLog> lstItems = GetData();
            
            var list = ProcessCollection(lstItems, requestFormData);
            int recFiltered = GetTotalRecordsFiltered(requestFormData, lstItems, list);

            dynamic response = new
            {
                Data = list,
                Draw = requestFormData["draw"],
                RecordsFiltered = list.Count,
                RecordsTotal = lstItems.Count
            };

            return Ok(response);
        }

        // ToDo: Comment hardcoded and uncommment coded
        // Get a list of Items
        private List<Models.DeviceLog> GetData()
        {

            // ToDo: Change HouseholdID
            List<DeviceLog> logList = new DeviceLogMapper().SelectFromDateRange(new ObjectId("5349b4ddd2781d08c09890f3"), default(DateTime), DateTime.MaxValue).ToList();

            return logList;
        }

        // Get a property info object from Item class filtering by property name.
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

        // Process a list of items according to Form data parameters
        private List<Models.DeviceLog> ProcessCollection(List<Models.DeviceLog> lstElements, IFormCollection requestFormData)
        {
            string searchText = string.Empty;
            Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };
            if (requestFormData.TryGetValue("search[value]", out tempOrder))
            {
                searchText = requestFormData["search[value]"].ToString();
            }
            tempOrder = new[] { "" };
            var skip = Convert.ToInt32(requestFormData["start"].ToString());
            var pageSize = Convert.ToInt32(requestFormData["length"].ToString());

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
                            return lstElements
                                .Where(x => x.Name.ToLower().Contains(searchText.ToLower())
                                       || x.Location.ToLower().Contains(searchText.ToLower())
                                       || x.Type.ToLower().Contains(searchText.ToLower())
                                       || x.State.ToLower().Contains(searchText.ToLower()))
                                .Skip(skip)
                                .Take(pageSize)
                                .OrderBy(prop.GetValue).ToList();
                        }
                        else
                        {
                            return lstElements
                                .Where(x => x.Name.ToLower().Contains(searchText.ToLower())
                                       || x.Location.ToLower().Contains(searchText.ToLower())
                                       || x.Type.ToLower().Contains(searchText.ToLower())
                                       || x.State.ToLower().Contains(searchText.ToLower()))
                                .Skip(skip)
                                .Take(pageSize)
                                .OrderByDescending(prop.GetValue).ToList();
                        }
                    }
                    else
                        return lstElements;
                }
            }
            return null;
        }

        // Gets Total number of records filtered in a collection
        private int GetTotalRecordsFiltered(IFormCollection requestFormData, List<Models.DeviceLog> lstItems, List<Models.DeviceLog> listProcessedItems)
        {
            var recFiltered = 0;
            Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };
            if (requestFormData.TryGetValue("search[value]", out tempOrder))
            {
                if (string.IsNullOrEmpty(requestFormData["search[value]"].ToString().Trim()))
                {
                    recFiltered = lstItems.Count;
                }
                else
                {
                    recFiltered = listProcessedItems.Count;
                }
            }
            return recFiltered;
        }
    }
}
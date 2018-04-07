﻿using MongoDB.Bson;
using SmartHome;
using SmartHome.DAL.Mappers;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.AppLogging
{
    public class AppLogRetriever : IAppLogRetriever
    {
        private ObjectId householdId;

        public void SetHouseholdId(ObjectId inputId) {
            householdId = inputId;
        }

        public int AggregateQuery(DateTime start, DateTime end, string logType = null, string deviceType = null)
        {
            var DB = new AppLogMapper();
            int result = DB.AggregateQuery(householdId, start, end, logType, deviceType);
            return result;
        }

        public List<string> ListDeviceTypes(DateTime start, DateTime end, string logType = null)
        {
            var DB = new AppLogMapper();
            List<string> result = (List<string>) DB.ListDeviceTypes(householdId, start, end, logType);
            return result;
        }

        public List<string> ListLogTypes(DateTime start, DateTime end, string deviceType = null)
        {
            var DB = new AppLogMapper();
            List<string> result = (List<string>)DB.ListLogTypes(householdId, start, end, deviceType);
            return result;
        }

        public IAppLogIterator SelectQuery(DateTime start, DateTime end, string logType = null, string deviceType = null)
        {
            var DB = new AppLogMapper();
            List<AppLog> result = DB.SelectQuery(householdId, start, end, logType, deviceType).ToList();
            return new AppLogIterator(result);
        }
    }
}

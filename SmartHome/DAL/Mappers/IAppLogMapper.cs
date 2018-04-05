﻿using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public interface IAppLogMapper : IBaseMapper<AppLog>
    {
        IAppLogMapper InsertMany(IEnumerable<AppLog> appLogs);

        int AggregateQuery(ObjectId householdId, DateTime start, DateTime end, string logType = null,
            string deviceType = null);

        IEnumerable<AppLog> SelectQuery(ObjectId householdId, DateTime start, DateTime end, string logType = null,
            string deviceType = null);

        IEnumerable<string> ListLogTypes(ObjectId householdId, DateTime start, DateTime end, string deviceType = null);

        IEnumerable<string> ListDeviceTypes(ObjectId householdId, DateTime start, DateTime end, string logType = null);
    }
}
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    interface IAppLogMapper : IBaseMapper<IAppLog>
    {
        void InsertMany(IEnumerable<IAppLog> newAppLog);

        int AggregateQuery(ObjectId householdId, DateTime start, DateTime end, string logType = null,
            string deviceType = null);

        IEnumerable<IAppLog> SelectQuery(ObjectId householdId, DateTime start, DateTime end, string logType = null,
            string deviceType = null);

        IEnumerable<string> ListLogTypes(ObjectId householdId, DateTime start, DateTime end, string deviceType = null);

        IEnumerable<string> ListDeviceTypes(ObjectId householdId, DateTime start, DateTime end, string logType = null);
    }
}
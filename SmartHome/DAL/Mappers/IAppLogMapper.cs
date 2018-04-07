using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public interface IAppLogMapper : IBaseMapper<AppLog>
    {
        // create multiple applogs
        IAppLogMapper InsertMany(IEnumerable<AppLog> appLogs);
        // get count of number of applogs that have the specified arguments (filters)
        int AggregateQuery(ObjectId householdId, DateTime start, DateTime end, string logType = null,
            string deviceType = null);
        // get applogs that have the specified arguments (filters)
        IEnumerable<AppLog> SelectQuery(ObjectId householdId, DateTime start, DateTime end, string logType = null,
            string deviceType = null);
        // get distinct logtypes within a start and end datetime
        IEnumerable<string> ListLogTypes(ObjectId householdId, DateTime start, DateTime end, string deviceType = null);
        // get distinct devicetypes within a start and end datetime
        IEnumerable<string> ListDeviceTypes(ObjectId householdId, DateTime start, DateTime end, string logType = null);
    }
}
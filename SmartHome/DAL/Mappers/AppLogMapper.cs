using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.DAL.Transactions;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public class AppLogMapper : BaseMapper<AppLog>, IAppLogMapper
    {
        public AppLogMapper() : base("applogs")
        {
        }

        public IAppLogMapper InsertMany(IEnumerable<AppLog> newAppLog)
        {
            throw new NotImplementedException();
        }

        public int AggregateQuery(ObjectId householdId, DateTime start, DateTime end, string logType = null, string deviceType = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppLog> SelectQuery(ObjectId householdId, DateTime start, DateTime end, string logType = null,
            string deviceType = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> ListLogTypes(ObjectId householdId, DateTime start, DateTime end, string deviceType = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> ListDeviceTypes(ObjectId householdId, DateTime start, DateTime end, string logType = null)
        {
            throw new NotImplementedException();
        }
    }
}

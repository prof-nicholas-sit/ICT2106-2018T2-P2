using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome
{
    public interface IAppLogRetriever
    {
        void SetHouseholdId(ObjectId inputId);
        int AggregateQuery(DateTime start, DateTime end, string logType = null, string deviceType = null);
        List<string> ListLogTypes(DateTime start, DateTime end, string deviceType = null);
        List<string> ListDeviceTypes(DateTime start, DateTime end, string logType = null);
        List<IAppLog> SelectQuery(DateTime start, DateTime end, string logType = null, string deviceType = null);
    }
}

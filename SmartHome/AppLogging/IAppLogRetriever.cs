using MongoDB.Bson;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SmartHome.AppLogging

{
    public interface IAppLogRetriever
    {
        void SetHouseholdId(ObjectId inputId);
        int AggregateQuery(DateTime start, DateTime end, string logType = null, string deviceType = null);
        List<string> ListLogTypes(DateTime start, DateTime end, string deviceType = null);
        List<string> ListDeviceTypes(DateTime start, DateTime end, string logType = null);
        IAppLogIterator SelectQuery(DateTime start, DateTime end, string logType = null, string deviceType = null);
    }
}

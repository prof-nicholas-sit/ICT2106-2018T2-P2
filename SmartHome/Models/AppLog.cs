using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SmartHome.Models
{
    public class AppLog : MongoDbObject
    {
        public string LogType { get; set; }
        public DateTime Timestamp { get; set; }
        public ObjectId HouseholdId { get; set; }
        public string DeviceType { get; set; }
        public string Values { get; set; }

        public AppLog(string logType, DateTime timestamp, ObjectId householdId, string deviceType = null,
            string values = null)
        {
            LogType = logType;
            Timestamp = timestamp;
            HouseholdId = householdId;
            DeviceType = deviceType;
            Values = values;
        }
    }
}
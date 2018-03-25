using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// TO BE DELETED, PLACEHOLDER DEVICE LOGS 
namespace SmartHome.Models
{
    public class AppLog
    {
        protected String LogType { get; set; }
        protected DateTime Timestamp { get; set; }
        protected int HouseholdID { get; set; }
        protected String DeviceType { get; set; }
        protected String Values { get; set; }

        public AppLog(String logType, DateTime timestamp, int householdID = 0, String deviceType = null, String values = null)
        {
            LogType = logType;
            Timestamp = timestamp;
            HouseholdID = householdID;
            DeviceType = deviceType;
            Values = values;
        }

        override
        public String ToString()
        {
            return "AppLog: " + LogType + ", " + Timestamp.ToString() + ", " + HouseholdID + ", " + DeviceType + ", " + Values;
        }
    }
}

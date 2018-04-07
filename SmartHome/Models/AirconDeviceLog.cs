using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SmartHome.Models
{
    public class AirconDeviceLog : DeviceLog
    {
        private int Temperature { get; set; }
        private string Windspeed { get; set; }
        private string Mode { get; set; }
        private string Swing { get; set; }

        public AirconDeviceLog(ObjectId householdId, string name, string location, string type, string state, double kWh, DateTime dateStamp, int temp, string windSpeed, string mode, string swing)
            : base(householdId, name, location, type, state, kWh, dateStamp)
        {
            this.Temperature = temp;
            this.Windspeed = windSpeed;
            this.Mode = mode;
            this.Swing = swing;
        }
    }
}

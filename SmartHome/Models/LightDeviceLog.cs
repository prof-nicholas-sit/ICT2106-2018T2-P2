using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SmartHome.Models
{
    public class LightDeviceLog : DeviceLog
    {
        private int Brightness { get; set; }
        private int ColorTemperature { get; set; }

        public LightDeviceLog(ObjectId householdId, string name, string location, string type, string state, double kWh, DateTime dateStamp, int brightness, int colorTemp)
            : base(householdId, name, location, type, state, kWh, dateStamp)
        {
            this.Brightness = brightness;
            this.ColorTemperature = colorTemp;
        }
    }
}

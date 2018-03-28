using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Light : DeviceLog
    {
        private int brightness { get; set; }
        private int colorTemperature { get; set; }

        public Light(int Id, int householdId, string name, string location, string type, string state, double kWh, DateTime dateStamp, int brightness, int colorTemp)
            : base(Id, householdId, name, location, type, state, kWh, dateStamp)
        {
            this.brightness = brightness;
            this.colorTemperature = colorTemp;
        }
    }
}

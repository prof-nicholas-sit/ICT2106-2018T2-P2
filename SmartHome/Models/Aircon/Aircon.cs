using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Aircon : DeviceLog
    {
        private int temperature { get; set; }
        private string windspeed { get; set; }
        private string mode { get; set; }
        private string swing { get; set; }

        public Aircon(int Id, int householdId, string name, string location, string type, string state, double kWh, DateTime dateStamp, int temp, string windSpeed, string mode, string swing)
            : base(Id, householdId, name, location, type, state, kWh, dateStamp)
        {
            this.temperature = temp;
            this.windspeed = windSpeed;
            this.mode = mode;
            this.swing = swing;
        }
    }
}

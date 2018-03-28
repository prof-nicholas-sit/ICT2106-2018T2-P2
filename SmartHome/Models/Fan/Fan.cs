using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Fan : DeviceLog
    {
        private int fanSpeed { get; set; }

        public Fan(int Id, int householdId, string name, string location, string type, string state, double kWh, DateTime dateStamp, int fanSpeed)
            : base(Id, householdId, name, location, type, state, kWh, dateStamp)
        {
            this.fanSpeed = fanSpeed;
        }
    }
}

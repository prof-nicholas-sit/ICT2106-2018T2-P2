using System;

namespace SmartHome.Models
{
    public class FanDeviceLog : DeviceLog
    {
        public int FanSpeed { get; set; }

        public FanDeviceLog(string householdId, string name, string location, string type, string state, double kWh, DateTime dateStamp, int fanSpeed)
            : base(householdId, name, location, type, state, kWh, dateStamp)
        {
            this.FanSpeed = fanSpeed;
        }
    }
}
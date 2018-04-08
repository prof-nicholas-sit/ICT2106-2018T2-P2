using System;
using MongoDB.Bson;

namespace SmartHome.Models
{
    /**
     * Example of a DeviceLog subclass
     */
    public class FanDeviceLog : DeviceLog
    {
        public int FanSpeed { get; set; }

        public FanDeviceLog(ObjectId householdId, string name, string location, string type, string state, double kWh, DateTime dateStamp, int fanSpeed)
            : base(householdId, name, location, type, state, kWh, dateStamp)
        {
            this.FanSpeed = fanSpeed;
        }
    }
}
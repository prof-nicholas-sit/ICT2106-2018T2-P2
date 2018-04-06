using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models.SmartDevice
{
    public class SmartDevice
    {

        public int DeviceID { get; set; }
        public int HouseholdID { get; set; }
        public String DeviceName { get; set; }
        public String Location { get; set; }
        public String Brand { get; set; }
        public String Model { get; set; }
        public String Type { get; set; }
        public String State { get; set; }
        public double UsageKwH { get; set; }
        public int favourite { get; set; }
        public DateTime timestamp { get; set; }

        public SmartDevice() { }

        public SmartDevice(int DeviceID, int HouseholdID, String DeviceName, String Location,
String Brand, String Model, String Type, String State, double UsageKwH, int favourite, DateTime timestamp)
        {
            this.DeviceID = DeviceID;
            this.HouseholdID = HouseholdID;
            this.DeviceName = DeviceName;
            this.Brand = Brand;
            this.Model = Model;
            this.Type = Type;
            this.Location = Location;
            this.State = "OFF";
            this.UsageKwH = UsageKwH;
            this.favourite = 0;
            this.timestamp = DateTime.Now;

        }


    }
}

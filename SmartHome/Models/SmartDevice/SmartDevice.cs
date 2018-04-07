using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models.SmartDevice
{
    public class SmartDevice:IDevice
    {

        public int DeviceID { get; set; }
        public int HouseholdID { get; set; }
        public String DeviceName { get; set; }
        public String Location { get; set; }
        public String Brand { get; set; }
        public String Model { get; set; }
        public String State { get; set; }
        public double UsageKwH { get; set; }
        public int favourite { get; set; }
        public DateTime timestamp { get; set; }

        public SmartDevice() { }

        public SmartDevice(int DeviceID, int HouseholdID, String DeviceName, String Location,
String Brand, String Model, double UsageKwH)
        {
            this.DeviceID = DeviceID;
            this.HouseholdID = HouseholdID;
            this.DeviceName = DeviceName;
            this.Brand = Brand;
            this.Model = Model;
            
            this.Location = Location;
            this.UsageKwH = UsageKwH;
            
            
            //Default values when device is created
            State = "OFF";
            favourite = 0;
            timestamp = DateTime.Now;

        }


    }
}

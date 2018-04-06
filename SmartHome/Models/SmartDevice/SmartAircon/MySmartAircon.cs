using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models.SmartDevice.SmartAircon
{
    public class MySmartAircon : SmartDevice
    {

        //Additional Attributes
        public int temperature { get; set; }
        public string mode { get; set; }
        public string windspeed { get; set; }
        public string swing { get; set; }

        //Default Values Constructor
        public MySmartAircon(SmartDevice device) {
            this.DeviceID = device.DeviceID;
            this.DeviceName = device.DeviceName;
            this.timestamp = DateTime.Now;
            
            this.HouseholdID = device.HouseholdID;
            this.DeviceName = device.DeviceName;
            this.Brand = device.Brand;
            this.Model = device.Model;
            this.Type = device.Type;
            this.Location = device.Location;
            this.State = "OFF";
            this.UsageKwH = device.UsageKwH;
            this.favourite = 0;

            this.temperature = 24;
            this.mode = "Medium";
            this.windspeed = "Auto";
            this.swing = "SWING";
        }


        //Constructor
        public MySmartAircon(int DeviceID, int HouseholdID, String DeviceName, String Location,
        String Brand, String Model, String Type, String State, double UsageKwH, int favourite, 
        DateTime timestamp, int temperature, string mode, string windspeed, string swing)
        :base(DeviceID, HouseholdID, DeviceName, Location, Brand, Model, Type, State, UsageKwH, favourite, timestamp)
        {
            this.temperature = temperature;
            this.mode = mode;
            this.windspeed = windspeed;
            this.swing = swing;
        }

    }
}

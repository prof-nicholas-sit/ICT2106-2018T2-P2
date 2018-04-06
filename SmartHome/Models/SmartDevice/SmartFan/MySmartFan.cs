using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models.SmartDevice.SmartFan
{
    public class MySmartFan : SmartDevice
    {
        //Additional Attributes
        public int fanSpeed { get; set; }

        //Default Values Constructor
        public MySmartFan(SmartDevice device) {
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

            this.fanSpeed = 0;
        }

        //Constructor
        public MySmartFan(int DeviceID, int HouseholdID, String DeviceName, String Location,
        String Brand, String Model, String Type, String State, double UsageKwH, int favourite,
        DateTime timestamp, int fanSpeed)
        : base(DeviceID, HouseholdID, DeviceName, Location, Brand, Model, Type, State, UsageKwH, favourite, timestamp)
        {
            this.fanSpeed = fanSpeed;
        }

    }
}

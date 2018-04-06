using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models.SmartDevice.SmartLight
{
    public class MySmartLight : SmartDevice
    {

        //Additional Attributes
        public int brightness { get; set; }
        public int colorTemperture { get; set; }

        //Default Values Constructor
        public MySmartLight(SmartDevice device) {
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

            this.brightness = brightness;
            this.colorTemperture = colorTemperture;
        }

        //Constructor
        public MySmartLight(int DeviceID, int HouseholdID, String DeviceName, String Location,
        String Brand, String Model, String Type, String State, double UsageKwH, int favourite,
        DateTime timestamp, int brightness, int colorTemperture)
        : base(DeviceID, HouseholdID, DeviceName, Location, Brand, Model, Type, State, UsageKwH, favourite, timestamp)
        {
            this.brightness = brightness;
            this.colorTemperture = brightness;
        }

    }
}

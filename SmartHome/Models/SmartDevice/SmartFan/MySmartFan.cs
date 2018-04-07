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
        public int FanSpeed { get; set; }

        //Default Values Constructor
        public MySmartFan(int DeviceID,int HouseholdID,String DeviceName,String Location,String 
            Brand,String Model, double UsageKwH):
            base(DeviceID, HouseholdID, DeviceName,  Location,
             Brand,  Model,UsageKwH){
            FanSpeed = 0;
        }

    }
}

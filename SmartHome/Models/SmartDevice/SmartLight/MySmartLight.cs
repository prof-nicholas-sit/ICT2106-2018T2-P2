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
        public int Brightness { get; set; }
        public int ColorTemperture { get; set; }

        //Default Values Constructor
        public MySmartLight(int DeviceID,int HouseholdID,String DeviceName,String Location,String Brand,String Model,String Type,double UsageKwH) :
            base(DeviceID,HouseholdID,DeviceName,Location,Brand,Model,UsageKwH){
            Brightness = 0;
            ColorTemperture = 0;
        }

    }
}

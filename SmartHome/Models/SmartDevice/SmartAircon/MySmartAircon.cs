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
        
        /*
         * Default Inheritance
         */
        public MySmartAircon(int DeviceID, int HouseholdID, String DeviceName, String Location,
            String Brand, String Model, double UsageKwH) :
            base(DeviceID, HouseholdID, DeviceName, Location,
                Brand, Model,  UsageKwH)
        {
            this.temperature = 24;
            this.mode = "Medium";
            this.windspeed = "Auto";
            this.swing = "SWING";
            
        }


    }
}

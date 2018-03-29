using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models.SmartDevice.SmartAircon
{
    public class SmartAircon : SmartDevice
    {

        //Might auto increment once we have the DATABASE working
        //static int count = 0;
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /*
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
        */
        //Additional Attributes
        public int temperature { get; set; }
        public string mode { get; set; }
        public string windspeed { get; set; }
        public string swing { get; set; }

        //Empty Constructor
        public SmartAircon() { }


        //Constructor
        public SmartAircon(int DeviceID, int HouseholdID, String DeviceName, String Location,
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

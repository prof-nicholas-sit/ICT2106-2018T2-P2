using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models.SmartDevice.SmartLight
{
    public class SmartLight : ISmartDevice
    {

        //Might auto increment once we have the DATABASE working
        static int count = 0;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        //Additional Attributes
        public int brightness { get; set; }
        public int colorTemperture { get; set; }

    }
}

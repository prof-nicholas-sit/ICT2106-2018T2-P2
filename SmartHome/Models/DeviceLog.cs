using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class DeviceLog
    {
        public int Id { get; set; }
        public int householdId { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string type { get; set; }
        public string state { get; set; }
        public double kWh { get; set; }
        public DateTime dateTime { get; set; }
        //public string name { get; set; }
    }
}

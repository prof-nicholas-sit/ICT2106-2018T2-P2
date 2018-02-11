using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Aircon : DeviceLog
    {
        private int temperature { get; set; }
        private string windspeed { get; set; }
        private string mode { get; set; }
        private string swing { get; set; }
    }
}

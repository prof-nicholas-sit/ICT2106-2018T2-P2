using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class DeviceAppLog : AppLog
    {
        public String DeviceName { get; set; }
        public int Value { get; set; }
    }
}

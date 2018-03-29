using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SmartHome.Models.SmartDevice.SmartAircon;

namespace SmartHome.Models.SmartDevice
{
    public class DeviceFactory
    {
      

        public SmartDevice getDevice(String type)
        {
            switch (type)
            {
                case "Aircon":
                    return new MySmartAircon();
                default:
                    return null;
            }
        }

    }
}

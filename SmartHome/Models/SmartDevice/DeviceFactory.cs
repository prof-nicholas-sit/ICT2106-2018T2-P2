using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SmartHome.Models.SmartDevice.SmartAircon;
using SmartHome.Models.SmartDevice.SmartFan;
using SmartHome.Models.SmartDevice.SmartLight;

namespace SmartHome.Models.SmartDevice
{
    public class DeviceFactory
    {
      

        public SmartDevice getDevice(String type, SmartDevice device)
        {
            switch (type)
            {
                case "aircon":
                    return new MySmartAircon(device);
                case "fan":
                    return new MySmartFan(device);
                case "light":
                    return new MySmartLight(device);
                default:
                    return null;
            }
        }

    }
}

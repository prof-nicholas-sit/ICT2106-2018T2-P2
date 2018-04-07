using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SmartHome.Models.SmartDevice.SmartAircon;
using SmartHome.Models.SmartDevice.SmartFan;
using SmartHome.Models.SmartDevice.SmartLight;

namespace SmartHome.Models.SmartDevice
{
    public class DeviceFactory
    {
      

        public SmartDevice getDevice(int DeviceID,int HouseHoldID,String DeviceName,String Location,String Brand,String Model,String Type,int UsageKwH)
        {
            switch (Type)
            {
                case "aircon":
                    return new MySmartAircon(DeviceID,0,DeviceName,Location,Model,Brand,0);
                case "fan":
                    return new MySmartFan(DeviceID,0,DeviceName,Location,Model,Brand,0);
                case "light":
                    return new MySmartLight(DeviceID,0,DeviceName,Location,Brand,Model,Type,0);
                default:
                    return null;
            }
        }

    }
}

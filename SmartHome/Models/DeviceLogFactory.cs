using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class DeviceLogFactory
    {

        public DeviceLogFactory()
        {

        }

        public DeviceLog CreateClass(string[] data)
        // Do we need to return an object or can we just send it to data layer to insert in db?
        //public void CreateClass(string[] data) // Temporary Console.log 
        {
            DeviceLog newDevice = null;
            switch (data[4].ToLower())
            {
                case "aircon":
                    // Temporary hardcode, future improvement can check for a header in the excel file. Can do if there is time....
                    newDevice = new AirconDeviceLog("5349b4ddd2781d08c09890f3", data[0], data[1], data[2], data[3], Convert.ToDouble(data[4]), DateTime.Parse(data[5]),
                        Convert.ToInt32(data[6]), data[7], data[8], data[9]);
                    //System.Diagnostics.Debug.WriteLine("AIRCON:\n" + newAC);
                    break;
                case "fan":
                    newDevice = new FanDeviceLog("5349b4ddd2781d08c09890f3", data[0], data[1], data[2], data[3], Convert.ToDouble(data[4]), DateTime.Parse(data[5]),
                        Convert.ToInt32(data[6]));
                    //System.Diagnostics.Debug.WriteLine("FAN:\n" + newFan);
                    break;
                case "light":
                    newDevice = new LightDeviceLog("5349b4ddd2781d08c09890f3", data[0], data[1], data[2], data[3], Convert.ToDouble(data[4]), DateTime.Parse(data[5]),
                        Convert.ToInt32(data[6]), Convert.ToInt32(data[7]));
                    //System.Diagnostics.Debug.WriteLine("LIGHT:\n" + newLight);
                    break;
                default:
                    break;
            }
            return newDevice;
        } 

       /* public DeviceLog CreateClass() // Temporary Console.log 
        {
            DeviceLog newDeviceLog = null;
            switch (data[4].ToLower())
            {
                case "aircon":
                    // Temporary hardcode, future improvement can check for a header in the excel file. Can do if there is time....
                    newDeviceLog = new Aircon(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), data[2], data[3], data[4], data[5], Convert.ToDouble(data[6]), DateTime.Parse(data[7]),
                        Convert.ToInt32(data[8]), data[9], data[10], data[11]);
                    System.Diagnostics.Debug.WriteLine("AIRCON:\n" + newDeviceLog);
                    return newDeviceLog;
                case "fan":
                    newDeviceLog = new Fan(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), data[2], data[3], data[4], data[5], Convert.ToDouble(data[6]), DateTime.Parse(data[7]),
                        Convert.ToInt32(data[8]));
                    System.Diagnostics.Debug.WriteLine("FAN:\n" + newDeviceLog);
                    return newDeviceLog;
                case "light":
                    newDeviceLog = new Light(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), data[2], data[3], data[4], data[5], Convert.ToDouble(data[6]), DateTime.Parse(data[7]),
                        Convert.ToInt32(data[8]), Convert.ToInt32(data[9]));
                    System.Diagnostics.Debug.WriteLine("LIGHT:\n" + newDeviceLog);
                    return newDeviceLog;
                default:
                    break;
            }

            return newDeviceLog;
        }

    */
    }
}

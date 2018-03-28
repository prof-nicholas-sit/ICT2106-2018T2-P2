﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class DeviceLogFactory
    {
        private string[] data;

        public DeviceLogFactory(string[] data)
        {
            this.data = data;
        }

        // public DeviceLog CreateClass()
        // Do we need to return an object or can we just send it to data layer to insert in db?
        public void CreateClass() // Temporary Console.log 
        {
            switch (data[4].ToLower())
            {
                case "aircon":
                    // Temporary hardcode, future improvement can check for a header in the excel file. Can do if there is time....
                    Aircon newAC = new Aircon(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), data[2], data[3], data[4], data[5], Convert.ToDouble(data[6]), DateTime.Parse(data[7]),
                        Convert.ToInt32(data[8]), data[9], data[10], data[11]);
                    System.Diagnostics.Debug.WriteLine("AIRCON:\n" + newAC);
                    break;
                case "fan":
                    Fan newFan = new Fan(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), data[2], data[3], data[4], data[5], Convert.ToDouble(data[6]), DateTime.Parse(data[7]),
                        Convert.ToInt32(data[8]));
                    System.Diagnostics.Debug.WriteLine("FAN:\n" + newFan);
                    break;
                case "light":
                    Light newLight = new Light(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), data[2], data[3], data[4], data[5], Convert.ToDouble(data[6]), DateTime.Parse(data[7]),
                        Convert.ToInt32(data[8]), Convert.ToInt32(data[9]));
                    System.Diagnostics.Debug.WriteLine("LIGHT:\n" + newLight);
                    break;
                default:
                    break;
            }
        }
    }
}

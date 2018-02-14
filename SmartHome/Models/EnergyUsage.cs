using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsageStatistics.Models
{
    public class EnergyUsage
    {
        public String Name { get; set; }
        public String Model { get; set; }
        public String Type { get; set; }
        public String State { get; set; }
        
        public double IndividualEnergyUsage(string location, string deviceType, string timePeriod)
        {
            return 0;
        }

        public double TotalEnergyUsage(string timePeriod)
        {
            // creating a fake device and device logs for that device
            int deviceId = 1;
            Device device = new Device(deviceId, "Living room", 90, "Lightbulb");

            List<DeviceLogs> allDeviceLogs = new List<DeviceLogs>();

            DeviceLogs deviceLog1 = new DeviceLogs(1, deviceId, new DateTime(2018, 02, 10, 11, 00, 00), "on");
            DeviceLogs deviceLog2 = new DeviceLogs(2, deviceId, new DateTime(2018, 02, 10, 13, 47, 00), "off");
            //DeviceLogs deviceLog3 = new DeviceLogs(3, deviceId, new DateTime(2018, 02, 11, 00, 00, 00), "on");
            //DeviceLogs deviceLog4 = new DeviceLogs(4, deviceId, new DateTime(2018, 02, 12, 00, 00, 00), "off");

            allDeviceLogs.Add(deviceLog1);
            allDeviceLogs.Add(deviceLog2);
            //allDeviceLogs.Add(deviceLog3);
            //allDeviceLogs.Add(deviceLog4);

            DateTime dtOn = new DateTime();
            DateTime dtOff = new DateTime();
            double sum = 0;

            // for each device log, call calculateEnergyUsage
            foreach (DeviceLogs log in allDeviceLogs)
            {
                if (log.DeviceId == device.Id)
                {
                    if (log.Status == "on")
                    {
                        dtOn = log.Datetime;
                    }
                    else if (log.Status == "off")
                    {
                        dtOff = log.Datetime;

                        if (dtOn != null)
                        {
                            sum += CalculateEnergyUsage(device.Energy, dtOn, dtOff);
                        }
                    }
                }
            }

            return sum;
        }

        private double CalculateEnergyUsage(double energy, DateTime on, DateTime off)
        {
            // Deduct off and on to get usage of device
            TimeSpan span = off.Subtract(on);
                       
            return energy*span.TotalHours;
        }
    }
}

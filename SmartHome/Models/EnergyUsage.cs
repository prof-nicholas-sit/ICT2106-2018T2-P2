using SmartHome.Models;
using System;
using System.Collections.Generic;

namespace UsageStatistics.Models
{
    public class EnergyUsage 
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
 
        List<DeviceLogs> allDeviceLogs = new List<DeviceLogs>();
        List<Device> allDevices = new List<Device>();
        
        public EnergyUsage()
        {
            // --- DEVICE STUBS
            // Creating fake devices and device logs for that device
            int device1 = 1;
            int device2 = 2;
            Device myDevice1 = new Device(device1, "Living room", 90, "Lightbulb");
            Device myDevice2 = new Device(device2, "Kitchen", 85, "Fridge");

            allDevices.Add(myDevice1);
            allDevices.Add(myDevice2);
                       
            // --- DEVICE LOG STUBS
            DeviceLogs deviceLog1 = new DeviceLogs(1, device1, new DateTime(2018, 02, 10, 11, 00, 00), "on");
            DeviceLogs deviceLog2 = new DeviceLogs(2, device1, new DateTime(2018, 02, 10, 13, 32, 00), "off");
            DeviceLogs deviceLog3 = new DeviceLogs(3, device2, new DateTime(2018, 02, 11, 15, 08, 00), "on");
            DeviceLogs deviceLog4 = new DeviceLogs(4, device2, new DateTime(2018, 02, 11, 15, 10, 00), "off");

            allDeviceLogs.Add(deviceLog1);
            allDeviceLogs.Add(deviceLog2);
            allDeviceLogs.Add(deviceLog3);
            allDeviceLogs.Add(deviceLog4);
        }
        
        public double IndividualEnergyUsage(string location, string deviceType, string timePeriod)
        {
            Device dev = new Device();

            // getDeviceByCategory(location, deviceType)
            // store to an int variable
            foreach (Device device in allDevices)
            {
                if (device.Location == location && device.Type == deviceType)
                {
                    dev = device;
                }
            }

            double sum = CalculateEnergyUsage(timePeriod, dev);

            return sum;
        }

        public double TotalEnergyUsage(string timePeriod)
        {            
            double sum = 0;

            foreach (Device dev in allDevices)
            {
                sum += CalculateEnergyUsage(timePeriod, dev);
            }

            return sum;
        }

        private double CalculateEnergyUsage(string timePeriod, Device dev)
        {
            DateTime dtOn = new DateTime();
            DateTime dtOff = new DateTime();
            double sum = 0;
            
            // For each device log, calculate energy usage
            // MISSING TO CHECK IF WITHIN TIME PERIOD (or can it be done during retrieval?)
            foreach (DeviceLogs log in allDeviceLogs)
            {
                if (log.DeviceId == dev.Id)
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
                            TimeSpan span = dtOff.Subtract(dtOn);
                            sum += dev.Energy * span.TotalHours;
                        }

                        // clear
                        dtOn = new DateTime();
                        dtOff = new DateTime();
                    }
                }
            }
            return sum;
        }        
    }
}

using SmartHome.Models;
using System;
using System.Collections.Generic;

namespace UsageStatistics.Models
{
    public class EnergyUsage : Filter
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string State { get; set; }

        public double individualEnergyUsage { get; set; }
        public double totalEnergyUsage { get; set; }

        private string location;

        public EnergyUsage(string location, string deviceType)
        {
            this.location = location;
            Type = deviceType;
        }

        public override void DoFilter(string timePeriod)
        {
            individualEnergyUsage = IndividualEnergyUsage(location, Type, timePeriod);
            totalEnergyUsage = TotalEnergyUsage(timePeriod);
        }
        
        private double IndividualEnergyUsage(string location, string deviceType, string timePeriod)
        {            
            // creating fake devices and device logs for that device
            List<Device> allDevices = new List<Device>();

            int device1 = 1;
            int device2 = 2;
            Device myDevice1 = new Device(device1, "Living room", 90, "Lightbulb");
            Device myDevice2 = new Device(device2, "Kitchen", 85, "Fridge");

            allDevices.Add(myDevice1);
            allDevices.Add(myDevice2);

            // getDeviceByCategory(location, deviceType)
            // store to an int variable
            Device tDevice = new Device();

            foreach (Device device in allDevices)
            {
                if (device.Location == location && device.Type == deviceType)
                {
                    tDevice = device;
                }
            } 

            List<DeviceLogs> allDeviceLogs = new List<DeviceLogs>();

            DeviceLogs deviceLog1 = new DeviceLogs(1, device1, new DateTime(2018, 02, 10, 11, 00, 00), "on");
            DeviceLogs deviceLog2 = new DeviceLogs(2, device1, new DateTime(2018, 02, 10, 13, 32, 00), "off");
            DeviceLogs deviceLog3 = new DeviceLogs(3, device2, new DateTime(2018, 02, 11, 15, 08, 00), "on");
            DeviceLogs deviceLog4 = new DeviceLogs(4, device2, new DateTime(2018, 02, 11, 15, 10, 00), "off");

            allDeviceLogs.Add(deviceLog1);
            allDeviceLogs.Add(deviceLog2);
            allDeviceLogs.Add(deviceLog3);
            allDeviceLogs.Add(deviceLog4);

            DateTime dtOn = new DateTime();
            DateTime dtOff = new DateTime();
            double sum = 0;

            // for each device log, call calculateEnergyUsage
            // MISSING TO CHECK IF WITHIN TIME PERIOD (or can it be done during retrieval?)
            foreach (DeviceLogs log in allDeviceLogs)
            {
                if (log.DeviceId == tDevice.Id)
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
                            sum += CalculateEnergyUsage(tDevice.Energy, dtOn, dtOff);
                        }
                        
                        // clear
                        dtOn = new DateTime();
                        dtOff = new DateTime();
                    }
                }
            }

            return sum;
        }

        private double TotalEnergyUsage(string timePeriod)
        {
            // creating fake devices and device logs for that device
            List<Device> allDevices = new List<Device>();
            int device1 = 1;
            int device2 = 2;
            Device myDevice1 = new Device(device1, "Living room", 90, "Lightbulb");
            Device myDevice2 = new Device(device2, "Kitchen", 85, "Fridge");

            allDevices.Add(myDevice1);
            allDevices.Add(myDevice2);

            List<DeviceLogs> allDeviceLogs = new List<DeviceLogs>();

            DeviceLogs deviceLog1 = new DeviceLogs(1, device1, new DateTime(2018, 02, 10, 11, 00, 00), "on");
            DeviceLogs deviceLog2 = new DeviceLogs(2, device1, new DateTime(2018, 02, 10, 13, 32, 00), "off");
            DeviceLogs deviceLog3 = new DeviceLogs(3, device2, new DateTime(2018, 02, 11, 15, 08, 00), "on");
            DeviceLogs deviceLog4 = new DeviceLogs(4, device2, new DateTime(2018, 02, 11, 15, 10, 00), "off");

            allDeviceLogs.Add(deviceLog1);
            allDeviceLogs.Add(deviceLog2);
            allDeviceLogs.Add(deviceLog3);
            allDeviceLogs.Add(deviceLog4);

            DateTime dtOn = new DateTime();
            DateTime dtOff = new DateTime();
            double sum = 0;

            // for each device log, call calculateEnergyUsage
            foreach (Device dev in allDevices)
            {
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
                                sum += CalculateEnergyUsage(dev.Energy, dtOn, dtOff);
                            }

                            // clear
                            dtOn = new DateTime();
                            dtOff = new DateTime();
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

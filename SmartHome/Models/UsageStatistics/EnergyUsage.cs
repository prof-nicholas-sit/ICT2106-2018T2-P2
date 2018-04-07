using SmartHome.DAL.Mappers;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using System.Diagnostics;

namespace UsageStatistics.Models
{
    public class EnergyUsage
    {
        public string Location { get; set; }
        public string TimePeriod { get; set; }
        public List<string> Locations { get; set; }

        public double EnergyUsed { get { return Math.Round(IndividualEnergyUsage(), 2); } }
        public List<string> DevicesInLocation { get { return GetDevicesInLocation(); } }

        public string Name { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string State { get; set; }

        private List<DeviceLog> allDeviceLogs = new List<DeviceLog>();
        private Session _session;

        public EnergyUsage()
        {
            _session = Session.getInstance;
            Household householduser = (Household)_session.GetUser();

            allDeviceLogs = new DeviceLogMapper().SelectFromDateRange(householduser.houseHoldId, DateTime.MinValue, DateTime.Now).ToList();
            Locations = GetLocationsInLogs();

            System.Diagnostics.Debug.WriteLine("Instantiated how many: " + allDeviceLogs.Count);
        }


        private List<DeviceLog> GetLogs()
        {
            // default is everything from the earliest date in DateTime to current time
            var startTime = DateTime.MinValue;
            var endTime = DateTime.Now;

            switch (TimePeriod)
            {
                case "daily":
                    startTime = DateTime.Now.Date;
                    break;
                case "weekly":
                    // monday this week (12:00AM)
                    startTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                    break;
                case "monthly":
                    // first day this month (12:00AM)
                    startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    break;
                default:
                    break;
            }

            // retrieve logs from appLog module
            List<DeviceLog> logList = new DeviceLogMapper().SelectFromDateRange(((Household) _session.GetUser()).houseHoldId, startTime, endTime).ToList();

            return logList;
        }

        public double IndividualEnergyUsage()
        {
            // FOR THIS FUNCTION TO WORK,
            // LOGS ARE ASSUMED TO BE ACCURATELY LOGGED AND BE SORTED IN DATETIME WHEN RETRIEVING

            List<DeviceLog> deviceLogs = GetLogs();

            double sum = 0;
            double kwh = 0;

            DateTime dtOn = DateTime.MinValue;
            DateTime dtOff = DateTime.MinValue;

            foreach (DeviceLog log in deviceLogs)
            {
                if (log.Location == Location && log.Name == Name)
                {
                    kwh = log.KWh;

                    if (log.State == "on")
                    {
                        dtOn = log.DateTime;
                    }
                    else if (log.State == "off")
                    {
                        dtOff = log.DateTime;

                        if (dtOn != DateTime.MinValue)
                        {
                            TimeSpan span = dtOff.Subtract(dtOn);
                            sum += log.KWh * span.TotalHours;
                        }

                        // clear
                        dtOn = DateTime.MinValue;
                        dtOff = DateTime.MinValue;
                    }

                    State = log.State;
                }
            }


            if (dtOn != DateTime.MinValue)
            {
                dtOff = DateTime.Now;

                TimeSpan span = dtOff.Subtract(dtOn);
                sum += kwh * span.TotalHours;
            }
            return sum;
        }

        private List<String> GetLocationsInLogs()
        {
            List<String> locationInLogs = new List<string>();

            foreach (DeviceLog log in allDeviceLogs)
            {
                if (!locationInLogs.Contains(log.Location))
                {
                    locationInLogs.Add(log.Location);
                }
            }

            return locationInLogs;
        }

        private List<String> GetDevicesInLocation()
        {
            List<String> devicesInLocation = new List<string>();

            foreach (DeviceLog log in allDeviceLogs)
            {
                if (!devicesInLocation.Contains(log.Name) && log.Location.Equals(Location))
                {
                    devicesInLocation.Add(log.Name);
                }
            }

            return devicesInLocation;
        }
    }
}

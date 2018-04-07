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

        public string GraphPower { get { return GetGraphPower();  } }
        

        private List<DeviceLog> allDeviceLogs = new List<DeviceLog>();
        private Session _session;
        private DateTime start;
        private DateTime end;

        /*Constructor*/
        public EnergyUsage(string timePeriod = null)
        {
            _session = Session.getInstance;
            Household householduser = (Household)_session.GetUser();

            allDeviceLogs = new DeviceLogMapper().SelectFromDateRange(householduser.houseHoldId, DateTime.MinValue, DateTime.Now).ToList();
            Locations = GetLocationsInLogs();
            
        }

        /*This method retrives all login logs by selected time range*/
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
            List<DeviceLog> logList = new DeviceLogMapper().SelectFromDateRange(((Household)_session.GetUser()).houseHoldId, startTime, endTime).ToList();

            return logList;
        }

        /*This method calculates the sum of energy usage of the household
         The list of device logs is obtained by calling deviceLogs() method
         */
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

        /*This method adds the devices into a list of locations*/
        private List<string> GetDevicesInLocation()
        {
            List<string> devicesInLocation = new List<string>();

            foreach (DeviceLog log in allDeviceLogs)
            {
                if (!devicesInLocation.Contains(log.Name) && log.Location.Equals(Location))
                {
                    devicesInLocation.Add(log.Name);
                    Debug.WriteLine("added" + log.Name);
                }
            }

            Debug.WriteLine("added" + devicesInLocation);
            return devicesInLocation;
        }

        /*This method retrives all locations of the household by looping through all device logs
         and tabulating the locations.*/
        private List<string> GetLocationsInLogs()
        {
            List<string> locationInLogs = new List<string>();

            foreach (DeviceLog log in allDeviceLogs)
            {
                if (!locationInLogs.Contains(log.Location))
                {
                    locationInLogs.Add(log.Location);
                }
            }

            return locationInLogs;
        }

        //This method generates data to be passed to the graph API to generate the graphs
        private string GetGraphPower()
        {
            _session = Session.getInstance;
            Household householduser = (Household)_session.GetUser();
            double sum = 0;
            start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);
            end = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);
            List<string> powerInterval = new List<string>();
 
            for (int i = 0; i < 13; i ++)
            {
                allDeviceLogs = new DeviceLogMapper().SelectFromDateRange(householduser.houseHoldId, start, end).ToList();
                Debug.WriteLine("DATETIME: " + end.ToString());
                foreach (DeviceLog log in allDeviceLogs)
                {
                    DateTime dtOn = new DateTime();
                    DateTime dtOff = new DateTime();
                    
                    if (log.State == "on")
                    {
                        dtOn = log.DateTime;
                        System.Diagnostics.Debug.WriteLine("Datetime on: " + dtOn);

                    }
                    else if (log.State == "off")
                    {
                        dtOff = log.DateTime;

                        if (dtOn != null)
                        {
                            TimeSpan span = dtOff.Subtract(dtOn);
                            sum += log.KWh * span.TotalHours;
                        }

                        // clear
                        dtOn = new DateTime();
                        dtOff = new DateTime();
                    }
                }
                powerInterval.Add(sum.ToString());
               
                end = end.AddHours(2);
            }
            return string.Join(",", powerInterval);
        }
    }
}

using SmartHome.DAL.Mappers;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace UsageStatistics.Models
{
    public class EnergyUsage 
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string GraphPower { get { return GetGraphPower();  } }
        
        private List<DeviceLog> allDeviceLogs = new List<DeviceLog>();
        private Session _session;
        private DateTime start;
        private DateTime end;

        public EnergyUsage(string timePeriod = null)
        {
            _session = Session.getInstance;
            Household householduser = (Household)_session.GetUser();
            
            if (timePeriod == "daily")
            {
                start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);
                end = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59, 999);
            }
            else if (timePeriod == "weekly")
            {

            }
            else if (timePeriod == "monthly")
            {
                DateTime date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                start = new DateTime(date.Year, date.Month, 1);
                end = start.AddMonths(1).AddDays(-1);
            }

            allDeviceLogs = new DeviceLogMapper().SelectFromDateRange(householduser.houseHoldId, start, end).ToList();

            // System.Diagnostics.Debug.WriteLine("Instantiated how many: " + allDeviceLogs.Count);            
        }

        public double IndividualEnergyUsage(string location, string deviceType)
        {
            double sum = 0;

            foreach (DeviceLog log in allDeviceLogs)
            {
                if (log.Location == location && log.Type == deviceType)
                {
                    sum += CalculateEnergyUsage(log);
                }
            }

            return sum;
        }

        public double TotalEnergyUsage()
        {
            double sum = 0;

            foreach (DeviceLog log in allDeviceLogs)
            {
                sum += CalculateEnergyUsage(log);
            }

            return sum;
        }

        private double CalculateEnergyUsage(DeviceLog log)
        {
            DateTime dtOn = new DateTime();
            DateTime dtOff = new DateTime();
            double sum = 0;

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

            return sum;
        }        
        
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
                System.Diagnostics.Debug.WriteLine("DATETIME: " + end.ToString());
                foreach (DeviceLog log in allDeviceLogs)
                {
                    sum += CalculateEnergyUsage(log);
                }
                powerInterval.Add(sum.ToString());
               
                end = end.AddHours(2);
            }
            return string.Join(",", powerInterval);
        }
    }
}

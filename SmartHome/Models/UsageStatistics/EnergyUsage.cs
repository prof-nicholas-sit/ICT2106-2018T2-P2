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
 
        private List<DeviceLog> allDeviceLogs = new List<DeviceLog>();
        private Session _session;

        public EnergyUsage()
        {
            _session = Session.getInstance;
            Household householduser = (Household)_session.GetUser();
         
            allDeviceLogs = new DeviceLogMapper().SelectFromDateRange(householduser.houseHoldId, DateTime.MinValue, DateTime.Now).ToList();

            System.Diagnostics.Debug.WriteLine("Instantiated how many: " + allDeviceLogs.Count);            
        }

        public double IndividualEnergyUsage(string location, string deviceType, string timePeriod)
        {
            double sum = 0;

            foreach (DeviceLog log in allDeviceLogs)
            {
                if (log.Location == location && log.Type == deviceType)
                {
                    sum += CalculateEnergyUsage(timePeriod, log);
                }
            }

            return sum;
        }

        public double TotalEnergyUsage(string timePeriod)
        {            
            double sum = 0;

            foreach (DeviceLog log in allDeviceLogs)
            {
                sum += CalculateEnergyUsage(timePeriod, log);
            }

            return sum;
        }

        private double CalculateEnergyUsage(string timePeriod, DeviceLog log)
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
    }
}

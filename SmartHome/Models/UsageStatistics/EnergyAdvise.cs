using SmartHome.DAL.Mappers;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsageStatistics.Models;

namespace UsageStatistics.Models
{
    public class EnergyAdvise
    {
        public double HouseholdConsumption { get { return TotalEnergyUsage(); } }
        public double AverageConsumption { get { return CalculateAverageConsumption(); } }
        public double PreviousMonthConsumption { get { return GetPreviousMonthConsumption(); } }

        private Session _session;
        private List<Household> allHouseholds = new List<Household>();
        private List<DeviceLog> allDeviceLogs = new List<DeviceLog>();
        private DateTime start;
        private DateTime end;

        public EnergyAdvise(int month)
        {
            _session = Session.getInstance;

            allHouseholds = new HouseholdMapper().SelectAll().ToList();

            // Based on month selected and current year, current day as throwaway
            DateTime date = new DateTime(DateTime.Now.Year, month, DateTime.Now.Day);
            start = new DateTime(date.Year, date.Month, 1);
            end = start.AddMonths(1).AddDays(-1);
        }

        public EnergyAdvise()
        {
            _session = Session.getInstance;
            Household householduser = (Household)_session.GetUser();

            allDeviceLogs = new DeviceLogMapper().SelectFromDateRange(householduser.houseHoldId, DateTime.MinValue, DateTime.Now).ToList();
        }

        private double CalculateAverageConsumption()
        {
            double sum = 0;            
            
            foreach (Household household in allHouseholds)
            {
                allDeviceLogs.AddRange(new DeviceLogMapper().SelectFromDateRange(household.houseHoldId, start, end));                
                //System.Diagnostics.Debug.WriteLine("Instantiated how many: " + allDeviceLogs.Count);
            }

            if (allDeviceLogs.Count != 0)
            {
                TotalEnergyUsage();
            }
            
            return sum/allHouseholds.Count;
        }

        private double GetPreviousMonthConsumption()
        {
            double sum = 0;
            int prevMonth = 0;
            
            // Assign to previous month
            if (start.Month - 1 == 0)
            {
                prevMonth = 12;
            }
            else
            {
                prevMonth = start.Month - 1;
            }

            if (prevMonth != 0)
            {
                Household householduser = (Household)_session.GetUser();

                // Based on month selected and current year
                DateTime date = new DateTime(DateTime.Today.Year, prevMonth, DateTime.Today.Day);
                start = new DateTime(date.Year, date.Month, 1);
                end = start.AddMonths(1).AddDays(-1);
                
                allDeviceLogs = new DeviceLogMapper().SelectFromDateRange(householduser.houseHoldId, start, end).ToList();

                sum = TotalEnergyUsage();
            }

            return sum;
        }

        private List<DeviceLog> GetLogs()
        {
            return allDeviceLogs;
        }

        public double TotalEnergyUsage()
        {
            // FOR THIS FUNCTION TO WORK,
            // LOGS ARE ASSUMED TO BE ACCURATELY LOGGED AND BE SORTED IN DATETIME WHEN RETRIEVING

            List<DeviceLog> deviceLogs = GetLogs();

            double sum = 0;

            DateTime dtOn = new DateTime();
            DateTime dtOff = new DateTime();

            Dictionary<string, DateTime> trackDeviceStates = new Dictionary<string, DateTime>();
            Dictionary<string, double> trackDeviceKwh = new Dictionary<string, double>();

            foreach (DeviceLog log in deviceLogs)
            {
                if (!trackDeviceKwh.ContainsKey(log.Name))
                {
                    trackDeviceKwh.Add(log.Name, log.KWh);
                }

                if (log.State.Equals("on") && !trackDeviceStates.ContainsKey(log.Name))
                {
                    trackDeviceStates.Add(log.Name, log.DateTime);
                }
                else if (log.State.Equals("off") && trackDeviceStates.ContainsKey(log.Name))
                {
                    dtOn = trackDeviceStates[log.Name];
                    dtOff = log.DateTime;

                    trackDeviceStates.Remove(log.Name);
                    TimeSpan span = dtOff.Subtract(dtOn);
                    sum += log.KWh * span.TotalHours;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("There is a problem with the log. Either it's off without being on (can be ignored), or there's two on in a row (problem with logging!)");
                }
            }

            // for states that are on and not yet off
            foreach (KeyValuePair<string, DateTime> deviceState in trackDeviceStates)
            {
                dtOn = deviceState.Value;
                dtOff = DateTime.Now;

                TimeSpan span = dtOff.Subtract(dtOn);
                sum += trackDeviceKwh[deviceState.Key] * span.TotalHours;
            }

            return sum;
        }
        }
}

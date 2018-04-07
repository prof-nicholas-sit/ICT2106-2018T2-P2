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
        public string GraphData { get { return GenerateGraphData(); } }
        private Session _session;
        private List<Household> allHouseholds = new List<Household>();
        private List<DeviceLog> allDeviceLogs = new List<DeviceLog>();
        private DateTime firstDayOfMonth;
        private DateTime lastDayOfMonth;
        private DateTime firstWeekOfMonth;
        private DateTime secondWeekOfMonth;
        private DateTime thirdWeekOfMonth;
        private DateTime fourthWeekOfMonth;

        public EnergyAdvise(int month)
        {
            _session = Session.getInstance;

            allHouseholds = new HouseholdMapper().SelectAll().ToList();

            // Based on month selected and current year, current day as throwaway
            DateTime date = new DateTime(DateTime.Now.Year, month, DateTime.Now.Day);
            firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            //Get end day of each week
            firstWeekOfMonth = firstDayOfMonth.AddDays(6);
            secondWeekOfMonth = firstWeekOfMonth.AddDays(7);
            thirdWeekOfMonth = secondWeekOfMonth.AddDays(7);
            fourthWeekOfMonth = thirdWeekOfMonth.AddDays(10);
        }

        private double CalculateOwnConsumption(DateTime startDate, DateTime endDate)
        {
            double sum = 0;
            Household householduser = (Household)_session.GetUser();

            allDeviceLogs = new DeviceLogMapper().SelectFromDateRange(householduser.houseHoldId, startDate, endDate).ToList();
            if (allDeviceLogs.Count != 0)
            {
                sum = TotalEnergyUsage();
            }
            return sum;
        }

        private double CalculateAverageConsumption(DateTime startDate, DateTime endDate)
        {
            double sum = 0;            
            
            //Get all device fromeach household
            foreach (Household household in allHouseholds)
            {               
                allDeviceLogs.AddRange(new DeviceLogMapper().SelectFromDateRange(household.houseHoldId, startDate, endDate));                
                System.Diagnostics.Debug.WriteLine("Instantiated how many: " + allDeviceLogs.Count);
            }

            //Sum all energy usage for all devices from all household
            if (allDeviceLogs.Count != 0)
            {
                sum = TotalEnergyUsage();

            }
            return sum /allHouseholds.Count;
        }

        private double GetPreviousMonthConsumption(DateTime startDate, DateTime endDate)
        {
            double sum = 0;
            Household householduser = (Household)_session.GetUser();

            // Assign to previous month
            if (startDate.Month - 1 == 0)
            {
                startDate = startDate.AddYears(-1).AddMonths(11);
                endDate = endDate.AddYears(-1).AddMonths(11);

                allDeviceLogs = new DeviceLogMapper().SelectFromDateRange(householduser.houseHoldId, startDate, endDate).ToList();
                System.Diagnostics.Debug.WriteLine("startDate: " + startDate);
                System.Diagnostics.Debug.WriteLine("endDate: " + endDate);
            }
            else
            {
                startDate = startDate.AddMonths(-1);
                endDate = endDate.AddMonths(-1);

                allDeviceLogs = new DeviceLogMapper().SelectFromDateRange(householduser.houseHoldId, startDate, endDate).ToList();
                System.Diagnostics.Debug.WriteLine("startDate: " + startDate);
                System.Diagnostics.Debug.WriteLine("endDate: " + endDate);
            }
            sum = TotalEnergyUsage();
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
        private string GenerateGraphData()
        {
            //Init data list
            List<double> myHouseholdData = new List<double>();
            List<double> averageHouseholdData = new List<double>();
            List<double> previousMonthData = new List<double>();

            //Algorithm to pull data from DB
            myHouseholdData.Add(CalculateOwnConsumption(firstDayOfMonth, firstWeekOfMonth));
            myHouseholdData.Add(CalculateOwnConsumption(firstWeekOfMonth, secondWeekOfMonth));
            myHouseholdData.Add(CalculateOwnConsumption(secondWeekOfMonth, thirdWeekOfMonth));
            myHouseholdData.Add(CalculateOwnConsumption(thirdWeekOfMonth, lastDayOfMonth));

            averageHouseholdData.Add(CalculateAverageConsumption(firstDayOfMonth, firstWeekOfMonth));
            averageHouseholdData.Add(CalculateAverageConsumption(firstWeekOfMonth, secondWeekOfMonth));
            averageHouseholdData.Add(CalculateAverageConsumption(secondWeekOfMonth, thirdWeekOfMonth));
            averageHouseholdData.Add(CalculateAverageConsumption(thirdWeekOfMonth, lastDayOfMonth));

            previousMonthData.Add(GetPreviousMonthConsumption(firstDayOfMonth, firstWeekOfMonth));
            previousMonthData.Add(GetPreviousMonthConsumption(firstWeekOfMonth, secondWeekOfMonth));
            previousMonthData.Add(GetPreviousMonthConsumption(secondWeekOfMonth, thirdWeekOfMonth));
            previousMonthData.Add(GetPreviousMonthConsumption(thirdWeekOfMonth, lastDayOfMonth));

            //Parse to JSON format
            String myHouseholdJSON = string.Join(",", myHouseholdData);
            String averageHouseholdJSON = string.Join(",", averageHouseholdData);
            String previousMonthJSON = string.Join(",", previousMonthData);
            String output = "[" + "[" + myHouseholdJSON + "]," + "[" + averageHouseholdJSON + "]," + "[" + previousMonthJSON + "]" + "]";

            return output;
        }
    }
}


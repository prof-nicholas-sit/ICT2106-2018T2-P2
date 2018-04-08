using SmartHome.DAL.Mappers;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UsageStatistics.Models
{
    public class EnergyAdvise
    {
        public double HouseholdConsumption { get { return TotalEnergyUsage(); } }
        public string GraphData { get { return GenerateGraphData(); } }

        // Commonly used variables within this context
        private Session _session;
        private List<Household> allHouseholds = new List<Household>();
        private List<DeviceLog> allDeviceLogs = new List<DeviceLog>();
        private DateTime firstDayOfMonth;
        private DateTime lastDayOfMonth;
        private DateTime firstWeekOfMonth;
        private DateTime secondWeekOfMonth;
        private DateTime thirdWeekOfMonth;
        private DateTime fourthWeekOfMonth;

        // Constructor
        public EnergyAdvise(int month)
        {
            _session = Session.getInstance;

            allHouseholds = new HouseholdMapper().SelectAll().ToList();

            // Based on month selected and current year, current day as throwaway
            DateTime date = new DateTime(DateTime.Now.Year, month, DateTime.Now.Day);
            firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            // Get end day of each week
            firstWeekOfMonth = firstDayOfMonth.AddDays(6);
            secondWeekOfMonth = firstWeekOfMonth.AddDays(7);
            thirdWeekOfMonth = secondWeekOfMonth.AddDays(7);
            fourthWeekOfMonth = thirdWeekOfMonth.AddDays(10);
        }

        /*This method retrieves a list of device logs of this household, 
         * then calls TotalEnergUsage() method to return the sum of the consumption.
         * */
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

        /*This method retrieves a list of device logs of all households, 
         * then calls TotalEnergUsage() method to return the sum of the consumption.
         * */
        private double CalculateAverageConsumption(DateTime startDate, DateTime endDate)
        {
            double sum = 0;            
            
            // Get all device fromeach household
            foreach (Household household in allHouseholds)
            {               
                allDeviceLogs.AddRange(new DeviceLogMapper().SelectFromDateRange(household.houseHoldId, startDate, endDate));                
                System.Diagnostics.Debug.WriteLine("Instantiated how many: " + allDeviceLogs.Count);
            }

            // Sum all energy usage for all devices from all household
            if (allDeviceLogs.Count != 0)
            {
                sum = TotalEnergyUsage();

            }
            return sum /allHouseholds.Count;
        }

        /* This method retrieves a list of device logs of this household,
        *  1 month before the provided time range,
        *  then calls TotalEnergUsage() method to return the sum of the consumption.
        * */
        private double GetPreviousMonthConsumption(DateTime startDate, DateTime endDate)
        {
            double sum = 0;
            Household householduser = (Household)_session.GetUser();

            // If month is 1, go back to last year december 
            if (startDate.Month - 1 == 0)
            {
                startDate = startDate.AddYears(-1).AddMonths(11);
                endDate = endDate.AddYears(-1).AddMonths(11);

                allDeviceLogs = new DeviceLogMapper().SelectFromDateRange(householduser.houseHoldId, startDate, endDate).ToList();           
            }
            else
            {
                startDate = startDate.AddMonths(-1);
                endDate = endDate.AddMonths(-1);

                allDeviceLogs = new DeviceLogMapper().SelectFromDateRange(householduser.houseHoldId, startDate, endDate).ToList();             
            }
            sum = TotalEnergyUsage();
            return sum;
        }

        private List<DeviceLog> GetLogs()
        {
            return allDeviceLogs;
        }
        
        /* This method calculates total energy usage from list of device logs */
        private double TotalEnergyUsage()
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

            // For states that are on and not yet off
            foreach (KeyValuePair<string, DateTime> deviceState in trackDeviceStates)
            {
                dtOn = deviceState.Value;
                dtOff = DateTime.Now;

                TimeSpan span = dtOff.Subtract(dtOn);
                sum += trackDeviceKwh[deviceState.Key] * span.TotalHours;
            }

            return sum;
        }
        
        /* This method generates data to be passed to the graph API to generate the graphs */
        private string GenerateGraphData()
        {
            // Init data list
            List<double> myHouseholdData = new List<double>();
            List<double> averageHouseholdData = new List<double>();
            List<double> previousMonthData = new List<double>();

            // Get own household data by week
            myHouseholdData.Add(CalculateOwnConsumption(firstDayOfMonth, firstWeekOfMonth));
            myHouseholdData.Add(CalculateOwnConsumption(firstWeekOfMonth, secondWeekOfMonth));
            myHouseholdData.Add(CalculateOwnConsumption(secondWeekOfMonth, thirdWeekOfMonth));
            myHouseholdData.Add(CalculateOwnConsumption(thirdWeekOfMonth, lastDayOfMonth));

            // Get average household consumption data by week
            averageHouseholdData.Add(CalculateAverageConsumption(firstDayOfMonth, firstWeekOfMonth));
            averageHouseholdData.Add(CalculateAverageConsumption(firstWeekOfMonth, secondWeekOfMonth));
            averageHouseholdData.Add(CalculateAverageConsumption(secondWeekOfMonth, thirdWeekOfMonth));
            averageHouseholdData.Add(CalculateAverageConsumption(thirdWeekOfMonth, lastDayOfMonth));

            // Get previous month data by week
            previousMonthData.Add(GetPreviousMonthConsumption(firstDayOfMonth, firstWeekOfMonth));
            previousMonthData.Add(GetPreviousMonthConsumption(firstWeekOfMonth, secondWeekOfMonth));
            previousMonthData.Add(GetPreviousMonthConsumption(secondWeekOfMonth, thirdWeekOfMonth));
            previousMonthData.Add(GetPreviousMonthConsumption(thirdWeekOfMonth, lastDayOfMonth));

            // Parse to JSON format
            String myHouseholdJSON = string.Join(",", myHouseholdData);
            String averageHouseholdJSON = string.Join(",", averageHouseholdData);
            String previousMonthJSON = string.Join(",", previousMonthData);
            String output = "[" + "[" + myHouseholdJSON + "]," + "[" + averageHouseholdJSON + "]," + "[" + previousMonthJSON + "]" + "]";

            return output;
        }
    }
}


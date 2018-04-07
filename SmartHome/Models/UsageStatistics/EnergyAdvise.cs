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
        public double HouseholdConsumption { get { return new EnergyUsage().TotalEnergyUsage(); } }
        //public double AverageConsumption { get { return CalculateAverageConsumption(); } }
        public double PreviousMonthConsumption { get { return GetPreviousMonthConsumption(); } }
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
            fourthWeekOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
        }

        private double CalculateAverageConsumption(DateTime startDate, DateTime endDate)
        {
            double sum = 0;            
            
            //Get all device fromeach household
            foreach (Household household in allHouseholds)
            {
                System.Diagnostics.Debug.WriteLine("HouseholdId: " + household.houseHoldId);
                System.Diagnostics.Debug.WriteLine("startDate: " + startDate);
                System.Diagnostics.Debug.WriteLine("endDate: " + endDate);

                allDeviceLogs.AddRange(new DeviceLogMapper().SelectFromDateRange(household.houseHoldId, startDate, endDate));                
                System.Diagnostics.Debug.WriteLine("Instantiated how many: " + allDeviceLogs.Count);
            }

            //Sum all energy usage for all devices from all household
            if (allDeviceLogs.Count != 0)
            {
                foreach (DeviceLog log in allDeviceLogs)
                {
                    sum += new EnergyUsage().TotalEnergyUsage();
                }
            }

            return sum /allHouseholds.Count;
        }

        private double GetPreviousMonthConsumption()
        {
            double sum = 0;
            int prevMonth = 0;

            // Assign to previous month
            if (firstDayOfMonth.Month - 1 == 0)
            {
                prevMonth = 12;
            }
            else
            {
                prevMonth = firstDayOfMonth.Month - 1;
            }

            if (prevMonth != 0)
            {
                Household householduser = (Household)_session.GetUser();

                // Based on month selected and current year
                DateTime date = new DateTime(DateTime.Now.Year, prevMonth, DateTime.Now.Day);
                firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                allDeviceLogs = new DeviceLogMapper().SelectFromDateRange(householduser.houseHoldId, firstDayOfMonth, lastDayOfMonth).ToList();

                foreach (DeviceLog log in allDeviceLogs)
                {
                    sum += new EnergyUsage().TotalEnergyUsage();
                }
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
            myHouseholdData.Add(5);
            myHouseholdData.Add(15);
            myHouseholdData.Add(55);
            myHouseholdData.Add(25);

            averageHouseholdData.Add(CalculateAverageConsumption(firstDayOfMonth, firstWeekOfMonth));
            averageHouseholdData.Add(CalculateAverageConsumption(firstWeekOfMonth, secondWeekOfMonth));
            averageHouseholdData.Add(CalculateAverageConsumption(secondWeekOfMonth, thirdWeekOfMonth));
            averageHouseholdData.Add(CalculateAverageConsumption(thirdWeekOfMonth, lastDayOfMonth));

            previousMonthData.Add(55);
            previousMonthData.Add(33);
            previousMonthData.Add(22);
            previousMonthData.Add(77);

            //Parse to JSON format
            String myHouseholdJSON = string.Join(",", myHouseholdData);
            String averageHouseholdJSON = string.Join(",", averageHouseholdData);
            String previousMonthJSON = string.Join(",", previousMonthData);
            String output = "[" + "[" + myHouseholdJSON + "]," + "[" + averageHouseholdJSON + "]," + "[" + previousMonthJSON + "]" + "]";

            return output;
        }
    }
}

using SmartHome.DAL.Mappers;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsageStatistics.Models;

namespace UsageStatistics.Models
{
    public class EnergyAdvise : EnergyUsage
    {
        public double HouseholdConsumption { get { return TotalEnergyUsage(""); } }
        public double AverageConsumption { get { return CalculateAverageConsumption(); } }
        public double PreviousMonthConsumption { get { return GetPreviousMonthConsumption(); } }

        private Session _session;
        private List<Household> allHouseholds = new List<Household>();
        private List<DeviceLog> allDeviceLogs = new List<DeviceLog>();
        private DateTime firstDayOfMonth;
        private DateTime lastDayOfMonth;
        public string month { get; set; }

        public EnergyAdvise(int month)
        {
            _session = Session.getInstance;

            allHouseholds = new HouseholdMapper().SelectAll().ToList();

            // Based on month selected and current year, current day as throwaway
            DateTime date = new DateTime(DateTime.Now.Year, month, DateTime.Now.Day);
            firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
        }
        
        private double CalculateAverageConsumption()
        {
            double sum = 0;            
            
            foreach (Household household in allHouseholds)
            {
                allDeviceLogs.AddRange(new DeviceLogMapper().SelectFromDateRange(household.houseHoldId, firstDayOfMonth, lastDayOfMonth));                
                System.Diagnostics.Debug.WriteLine("Instantiated how many: " + allDeviceLogs.Count);
            }

            if (allDeviceLogs.Count != 0)
            {
                foreach (DeviceLog log in allDeviceLogs)
                {
                    sum += TotalEnergyUsage("");
                }
            }
            
            return sum/allHouseholds.Count;
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
                    sum += TotalEnergyUsage("");
                }
            }

            return sum;
        }
    }
}

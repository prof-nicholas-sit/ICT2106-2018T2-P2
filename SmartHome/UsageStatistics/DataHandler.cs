using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsageStatistics.UsageStatistics
{
    public class DataHandler : IDataHandler
    {
        public double CalculateAverageConsumption()
        {
            return 0;
        }

        public double CalculateEnergyUsage(double energy, DateTime on, DateTime off)
        {
            return 0;
        }

        public string CalculateLoginDuration(DateTime login, DateTime logoff)
        {
            return null;
        }

        public DateTime GetLastLogin()
        {
            return DateTime.Now;
        }

        public int GetLoginCount()
        {
            return 0;
        }

        public int GetPageCount(string page)
        {
            return 0;
        }

        public double IndividualEnergyUsage(string location, string deviceType, string timePeriod)
        {
            return 0;
        }

        public double TotalEnergyUsage(string timePeriod)
        {
            return 0;
        }
    }
}

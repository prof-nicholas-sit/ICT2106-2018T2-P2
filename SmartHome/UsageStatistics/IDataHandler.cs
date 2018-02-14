using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsageStatistics.UsageStatistics
{
    interface IDataHandler
    {
        double TotalEnergyUsage(string timePeriod);
        double IndividualEnergyUsage(string location, string deviceType, string timePeriod);
        double CalculateEnergyUsage(double energy, DateTime on, DateTime off);
        double CalculateAverageConsumption();
        string CalculateLoginDuration(DateTime login, DateTime logoff);
        int GetPageCount(string page);
        int GetLoginCount();
        DateTime GetLastLogin();
    }
}

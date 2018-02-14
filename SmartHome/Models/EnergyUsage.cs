using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsageStatistics.Models
{
    public class EnergyUsage
    {
        public String Name;
        public String Model;
        public String Type;
        public String State;
        public String PowerUsage;
        
        public double IndividualEnergyUsage(string location, string deviceType, string timePeriod)
        {
            return 0;
        }

        public double TotalEnergyUsage(string timePeriod)
        {
            return 0;
        }

        private double CalculateEnergyUsage(double energy, DateTime on, DateTime off)
        {
            return 0;
        }
    }
}

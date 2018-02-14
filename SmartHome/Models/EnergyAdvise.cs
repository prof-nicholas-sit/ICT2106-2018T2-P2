using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsageStatistics.Models
{
    public class EnergyAdvise
    {
        public double HouseholdConsumption;
        public double AverageConsumption;
        public double Target;
        public double PreviousMonthConsumption;

        private double CalculateAverageConsumption()
        {
            return 0;
        }
    }
}

using SmartHome.DAL.Mappers;
using SmartHome.Models;
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

        private List<DeviceLog> allDeviceLogs = new List<DeviceLog>();
        private Session _session;

        public EnergyAdvise()
        {
            _session = Session.getInstance;
            Household householduser = (Household)_session.GetUser();

            allDeviceLogs = new DeviceLogMapper().SelectFromDateRange(householduser.houseHoldId, DateTime.MinValue, DateTime.Now).ToList();
            System.Diagnostics.Debug.WriteLine("Instantiated how many: " + allDeviceLogs.Count);
        }

        private double CalculateAverageConsumption()
        {
            return 0;
        }


        public double TotalEnergyUsage()
        {
            // FOR THIS FUNCTION TO WORK,
            // LOGS ARE ASSUMED TO BE ACCURATELY LOGGED AND BE SORTED IN DATETIME WHEN RETRIEVING
            double sum = 0;

            DateTime dtOn = new DateTime();
            DateTime dtOff = new DateTime();

            Dictionary<string, DateTime> trackDeviceStates = new Dictionary<string, DateTime>();
            Dictionary<string, double> trackDeviceKwh = new Dictionary<string, double>();

            foreach (DeviceLog log in allDeviceLogs)
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
            System.Diagnostics.Debug.WriteLine("tOTAL: " + sum);
            // for states that are on but not yet off
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

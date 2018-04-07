using SmartHome;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartHome.AppLogging;

namespace UsageStatistics.Models
{
    public class ApplicationUsage
    {
        public string LastLogin { get { return GetLastLogin(); } }
        public int LoginCount { get { return GetLoginCount(); } }
        public int DevicePageCount { get { return GetPageCount("", "");  } }
        public int SchedulePageCount { get; set; }
        public string CurrentLoginDuration { get { return CalculateLoginDuration(); } }

        private readonly AppLogRetriever appLogRetriever;

        public ApplicationUsage(IAppLogRetriever ar)
        {
            appLogRetriever = (AppLogRetriever) ar;
        }
        
        public string CalculateLoginDuration()
        {
            AppLogIterator logIter = (AppLogIterator) appLogRetriever.SelectQuery(DateTime.MinValue, DateTime.Now, "SmartHome.Controllers.HomeController*/-LOGIN");

            AppLog log = (AppLog)logIter.Last();
            DateTime startTime = log.Timestamp;
            DateTime endTime = DateTime.Now;
            TimeSpan span = endTime.Subtract(startTime);

            //String sequence of days,hours, minutes and seconds together.
            //Minues 8 hours for GMT
            String timeString = (span.Days + " Days, " + (span.Hours - 8) + " Hours, " + span.Minutes + " Minutes, " + span.Seconds + " Seconds");

            return timeString;
        }

        private string GetLastLogin()
        {
            AppLogIterator logIter = (AppLogIterator)appLogRetriever.SelectQuery(DateTime.MinValue, DateTime.Now, "SmartHome.Controllers.HomeController*/-LOGIN");

            AppLog lastLog = (AppLog)logIter.Last();

            return lastLog.Timestamp.ToShortDateString();
        }

        private int GetLoginCount()
        {
            List<String> logList = appLogRetriever.ListLogTypes(DateTime.MinValue, DateTime.Now);

            int count = 0;
            foreach (String log in logList)
            {
                if (log.Split("*/-")[1].Equals("LOGIN"))
                {
                    count++;
                }
            }
            return count;
        }

        private int GetPageCount(string page, string timePeriod)
        {
            // To be implemented after page set up
            return 0;
        }        
    }
}

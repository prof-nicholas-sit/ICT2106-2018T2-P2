using SmartHome;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace UsageStatistics.Models
{
    public class ApplicationUsage
    {
        public DateTime LastLogin { get; set; }
        public int LoginCount { get { return GetLoginCount(); } }
        public int DevicePageCount { get { return GetPageCount("", "");  } }
        public int SchedulePageCount { get; set; }
        public string CurrentLoginDuration { get; set; }

        private readonly AppLogRetriever appLogRetriever;

        public ApplicationUsage(IAppLogRetriever ar)
        {
            appLogRetriever = (AppLogRetriever) ar;
        }
        
        public string CalculateLoginDuration(DateTime login, DateTime logoff)
        {
            return null;
        }

        private DateTime GetLastLogin(string timePeriod)
        {
            return DateTime.Now;
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

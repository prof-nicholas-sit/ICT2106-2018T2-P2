using SmartHome;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace UsageStatistics.Models
{
    public class ApplicationUsage
    {
        public string LastLogin { get { return GetLastLogin(); } }
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

        private string GetLastLogin()
        {
            List<AppLog> logList = appLogRetriever.SelectQuery(DateTime.MinValue, DateTime.Now, "SmartHome.Controllers.HomeController*/-LOGIN");

            AppLog log = logList[logList.Count - 1];
            
            if (logList.Count > 1)
            {
                log = logList[logList.Count - 2];
            }
            
            return log.Timestamp.ToShortDateString();
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

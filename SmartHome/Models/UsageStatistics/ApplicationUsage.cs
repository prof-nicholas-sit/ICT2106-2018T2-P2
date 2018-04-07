﻿using SmartHome;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using SmartHome.AppLogging;
=======
>>>>>>> origin/Team11-dev

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
<<<<<<< HEAD
            AppLogIterator logIter = (AppLogIterator) appLogRetriever.SelectQuery(DateTime.MinValue, DateTime.Now, "SmartHome.Controllers.HomeController*/-LOGIN");

            AppLog log = (AppLog)logIter.Last();
=======
            List<AppLog> logList = appLogRetriever.SelectQuery(DateTime.MinValue, DateTime.Now, "SmartHome.Controllers.HomeController*/-LOGIN");

            AppLog log = logList[logList.Count - 1];
>>>>>>> origin/Team11-dev
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
<<<<<<< HEAD
            AppLogIterator logIter = (AppLogIterator)appLogRetriever.SelectQuery(DateTime.MinValue, DateTime.Now, "SmartHome.Controllers.HomeController*/-LOGIN");

            AppLog lastLog = (AppLog)logIter.Last();

            return lastLog.Timestamp.ToShortDateString();
=======
            List<AppLog> logList = appLogRetriever.SelectQuery(DateTime.MinValue, DateTime.Now, "SmartHome.Controllers.HomeController*/-ACTION*/-LOGIN");
            
            AppLog log = logList[logList.Count - 1];
            
            if (logList.Count > 1)
            {
                log = logList[logList.Count - 2];
            }
            
            return log.Timestamp.ToShortDateString();
>>>>>>> origin/Team11-dev
        }

        private int GetLoginCount()
        {
            List<String> logList = appLogRetriever.ListLogTypes(DateTime.MinValue, DateTime.Now);

            int count = 0;
            foreach (String log in logList)
            {
                if (log.Split("*/-")[2].Equals("LOGIN"))
                {
                    count++;
                }
            }
            return count;
        }

        private List<String> GetLogs()
        {
            // default is everything from the earliest date in DateTime to current time
            var startTime = DateTime.MinValue;
            var endTime = DateTime.Now;

            switch (timePeriod)
            {
                case "daily":
                    // monday this week (12:00AM)
                    startTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                    break;
                case "weekly":
                    // first day this month (12:00AM)
                    startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    break;
                case "monthly":
                    // Jan 1 (12:00 AM) of this year
                    startTime = new DateTime(DateTime.Now.Year, 1, 1);
                    break;
                default:
                    break;
            }

            // retrieve logs from appLog module
            List<String> logList = appLogRetriever.ListLogTypes(startTime, endTime);

            return logList;
        }

        private Dictionary<string, int> GetPageCount()
        {
            // get logs based on time period
            List<String> logList = GetLogs();
            // to store filtered results for display in view
            Dictionary<string, int> PageCount = new Dictionary<string, int>();

            foreach (String log in logList)
            {
                // example of a page type log: "SmartHome.Controllers.HouseholdController*/-PAGE*/-View-Neighbours"

                String[] logParts = log.Split("*/-");
                String pageName = logParts[2].Replace("-", " ");

                if (logParts[1].Equals("PAGE"))
                {
                    // not in dictionary, initialise
                    if (!PageCount.ContainsKey(pageName))
                    {
                        PageCount.Add(pageName, 1);
                    }
                    // in dictionary, plus one count
                    else
                    {
                        PageCount[pageName] += 1;
                    }
                }
            }


            return PageCount;
        }
    }
}

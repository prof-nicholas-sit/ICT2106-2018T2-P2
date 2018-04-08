using SmartHome.Models;
using System;
using System.Collections.Generic;
using SmartHome.AppLogging;

namespace UsageStatistics.Models
{
    public class ApplicationUsage
    {
        public string TimePeriod { get; set; }
        public string LastLogin { get { return GetLastLogin(); } }
        public int LoginCount { get { return GetLoginCount(); } }
        public Dictionary<string, int> PageCount { get { return GetPageCount(); } }
        public string CurrentLoginDuration { get { return CalculateLoginDuration(); } }

        private readonly IAppLogRetriever appLogRetriever;

        // Constructor
        public ApplicationUsage(IAppLogRetriever ar)
        {
            appLogRetriever = ar;
        }

        /* This method calculates the login duration of the user by
         * subtracting current time with the last login logged time.
         * */
        public string CalculateLoginDuration()
        {
            AppLogIterator logIter = (AppLogIterator)appLogRetriever.SelectQuery(DateTime.MinValue, DateTime.Now, "SmartHome.Controllers.HomeController*/-ACTION*/-LOGIN");
            AppLog log = logIter.Last();

            DateTime startTime = log.Timestamp;
            DateTime endTime = DateTime.Now;
            TimeSpan span = endTime.Subtract(startTime);

            // String sequence of days,hours, minutes and seconds together.
            // Minus 8 hours for GMT
            String timeString = (span.Days + " Days, " + (span.Hours - 8) + " Hours, " + span.Minutes + " Minutes, " + span.Seconds + " Seconds");

            return timeString;
        }

        /* This method retrieves last login log and returns the time stamp as string */
        private string GetLastLogin()
        {
            AppLogIterator logIter = (AppLogIterator)appLogRetriever.SelectQuery(DateTime.MinValue, DateTime.Now, "SmartHome.Controllers.HomeController*/-ACTION*/-LOGIN");

            AppLog lastLog = (AppLog)logIter.Last();

            return lastLog.Timestamp.ToShortDateString();
        }

        /* This method retrieves the list of all login logs and counts the number of login times */
        private int GetLoginCount()
        {
            List<String> logList = GetLogs();

            int count = 0;
            foreach (String log in logList)
            {
                if (log.Split("*/-")[2] == "LOGIN")
                {
                    count++;
                }
            }
            return count;
        }

        /* This method retrives login logs by selected time range */
        private List<String> GetLogs()
        {
            // Default is everything from the earliest date in DateTime to current time
            var startTime = DateTime.MinValue;
            var endTime = DateTime.Now;

            switch (TimePeriod)
            {
                case "daily":
                    startTime = DateTime.Now.Date;
                    break;
                case "weekly":
                    // Monday this week (12:00AM)
                    startTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                    break;
                case "monthly":
                    // First day this month (12:00AM)
                    startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    break;
                default:
                    break;
            }

            // Retrieve logs from appLog module
            List<String> logList = appLogRetriever.ListLogTypes(startTime, endTime);

            return logList;
        }

        /* For displaying of pages visited into table format, stores count to a dictionary */
        private Dictionary<string, int> GetPageCount()
        {
            // Get logs based on time period
            List<String> logList = GetLogs();
            // To store filtered results for display in view
            Dictionary<string, int> PageCount = new Dictionary<string, int>();

            foreach (String log in logList)
            {
                // Example of a page type log: "SmartHome.Controllers.HouseholdController*/-PAGE*/-View-Neighbours"

                String[] logParts = log.Split("*/-");
                String pageName = logParts[2].Replace("-", " ");

                if (logParts[1] == "PAGE")
                {
                    // Not in dictionary, initialise
                    if (!PageCount.ContainsKey(pageName))
                    {
                        PageCount.Add(pageName, 1);
                    }
                    // In dictionary, plus one count
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
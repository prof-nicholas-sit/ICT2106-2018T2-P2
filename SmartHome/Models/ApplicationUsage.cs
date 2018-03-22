using SmartHome.Models;
using System;
namespace UsageStatistics.Models
{
    public class ApplicationUsage
    {
        public DateTime LastLogin;
        public int LoginCount;
        public int DevicePageCount;
        public int SchedulePageCount;
        public string CurrentLoginDuration;

        private string page;

        public ApplicationUsage(string page)
        {
            this.page = page;
        }

        public string CalculateLoginDuration(DateTime login, DateTime logoff)
        {
            return null;
        }

        private DateTime GetLastLogin(string timePeriod)
        {
            return DateTime.Now;
        }

        private int GetLoginCount(string timePeriod)
        {
            return 0;
        }

        private int GetPageCount(string page, string timePeriod)
        {
            return 0;
        }        
    }
}

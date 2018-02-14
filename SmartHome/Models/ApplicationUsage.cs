using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsageStatistics.Models
{
    public class ApplicationUsage
    {
        public DateTime LastLogin;
        public int LoginCount;
        public int DevicePageCount;
        public int SchedulePageCount;
        public string CurrentLoginDuration;

        public string CalculateLoginDuration(DateTime login, DateTime logoff)
        {
            return null;
        }

        public DateTime GetLastLogin()
        {
            return DateTime.Now;
        }

        public int GetLoginCount()
        {
            return 0;
        }

        public int GetPageCount(string page)
        {
            return 0;
        }
    }
}

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class DeviceLogs
    {
        int Id;
        int DeviceId;
        DateTime Datetime;
        string Status;

        public DeviceLogs(int id, int deviceId, DateTime datetime, string status)
        {
            Id = id;
            DeviceId = deviceId;
            Datetime = datetime;
            Status = status;
        }
    }
}

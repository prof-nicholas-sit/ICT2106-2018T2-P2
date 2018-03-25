using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// TO BE DELETED, PLACEHOLDER DEVICE LOGS
namespace SmartHome.Models
{
    public class DeviceLogs
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public DateTime Datetime { get; set; }
        public string Status { get; set; }

        public DeviceLogs(int id, int deviceId, DateTime datetime, string status)
        {
            Id = id;
            DeviceId = deviceId;
            Datetime = datetime;
            Status = status;
        }
    }
}

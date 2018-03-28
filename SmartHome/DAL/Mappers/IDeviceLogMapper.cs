using MongoDB.Bson;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.DAL
{
    interface IDeviceLogMapper : IBaseMapper<DeviceAppLog>
    {
        List<DeviceAppLog> SelectFromDateRange(ObjectId householdId, DateTime startDate, DateTime endDate);
        DeviceAppLog SelectIndividual(ObjectId householdId, string location, string type, DateTime startDate, DateTime endDate);
        void CreateLogs(List<DeviceAppLog> logs);
    }
}

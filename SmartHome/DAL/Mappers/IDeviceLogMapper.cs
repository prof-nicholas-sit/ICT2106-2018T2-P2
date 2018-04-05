using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public interface IDeviceLogMapper : IBaseMapper<DeviceLog>
    {
        IDeviceLogMapper CreateLogs(IEnumerable<DeviceLog> logs);
        IEnumerable<DeviceLog> SelectFromDateRange(ObjectId householdId, DateTime start, DateTime end);
        DeviceLog SelectIndividual(ObjectId householdId, string location, string type, DateTime start, DateTime end);
    }
}

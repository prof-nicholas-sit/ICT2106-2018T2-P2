using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public interface IDeviceLogMapper : IBaseMapper<DeviceLog>
    {
        List<DeviceLog> SelectFromDateRange(ObjectId householdId, DateTime startDate, DateTime endDate);
        DeviceLog SelectIndividual(ObjectId householdId, string location, string type, DateTime startDate, DateTime endDate);
        IDeviceLogMapper CreateLogs(List<DeviceLog> logs);
    }
}

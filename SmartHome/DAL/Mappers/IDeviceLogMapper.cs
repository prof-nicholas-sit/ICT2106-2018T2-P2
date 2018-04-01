using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    interface IDeviceLogMapper : IBaseMapper<DeviceAppLog>
    {
        List<DeviceAppLog> SelectFromDateRange(ObjectId householdId, DateTime startDate, DateTime endDate);
        DeviceAppLog SelectIndividual(ObjectId householdId, string location, string type, DateTime startDate, DateTime endDate);
        void CreateLogs(List<DeviceAppLog> logs);
    }
}

using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public interface IDeviceLogMapper : IBaseMapper<DeviceLog>
    {
		// create multiple logs
        IDeviceLogMapper CreateLogs(IEnumerable<DeviceLog> logs);
        // select all devicelogs belonging to householdId within start and end DateTime
        IEnumerable<DeviceLog> SelectFromDateRange(ObjectId householdId, DateTime start, DateTime end);
        // select 1 devicelog based on the specified arguments
        DeviceLog SelectIndividual(ObjectId householdId, string location, string type, DateTime start, DateTime end);
    }
}

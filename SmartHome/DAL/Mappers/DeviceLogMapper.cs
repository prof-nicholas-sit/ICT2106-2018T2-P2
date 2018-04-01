using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.DAL.Transactions;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public class DeviceLogMapper : BaseMapper<DeviceLog>, IDeviceLogMapper
    {
        public DeviceLogMapper() : base("devicelogs")
        {
        }

        public void CreateLogs(List<DeviceLog> logs)
        {
            // Similar to Create() but inserts a list of logs
            // Used when user import a file containing logs
            throw new NotImplementedException();
        }

        public List<DeviceLog> SelectFromDateRange(ObjectId householdId, DateTime startDate, DateTime endDate)
        {
            // make query for selecting deviceapplog within the date range
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public DeviceLog SelectIndividual(ObjectId householdId, string location, string type, DateTime startDate, DateTime endDate)
        {
            // make query for selecting 1 deviceapplog based on all parameters
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }
    }
}

using MongoDB.Bson;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.DAL
{
    interface IDeviceLogMapper : IBaseMapper<AppLog>
    {
        List<AppLog> SelectFromDateRange(ObjectId householdId, DateTime startDate, DateTime endDate);
        AppLog SelectIndividual(ObjectId householdId, string location, string type, DateTime startDate, DateTime endDate);
        void CreateLogs(List<AppLog> logs);
    }
}

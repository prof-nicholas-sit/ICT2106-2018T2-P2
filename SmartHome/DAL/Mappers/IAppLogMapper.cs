using MongoDB.Bson;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.DAL
{
    interface IAppLogMapper : IBaseMapper<AppLog>
    {
        List<string> SelectDistinctUserLogTypes();
        List<string> SelectDistinctDeviceLogTypes();
        List<string> SelectDistinctScheduleLogTypes();
        List<string> SelectDistinctMiscLogTypes();
        AppLog SelectLastUserLog(ObjectId householdId, String logType);
        List<AppLog> SelectUserLogFromType(ObjectId householdId, string logType);
        void CreateUserLogs(List<AppLog> logs);
        void UpdateUserLogs(List<AppLog> logs);
    }
}

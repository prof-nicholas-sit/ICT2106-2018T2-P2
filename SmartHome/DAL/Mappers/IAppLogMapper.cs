using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    interface IAppLogMapper : IBaseMapper<AppLog>
    {
        List<string> SelectDistinctUserLogTypes();
        List<string> SelectDistinctDeviceLogTypes();
        List<string> SelectDistinctScheduleLogTypes();
        List<string> SelectDistinctMiscLogTypes();
        UserAppLog SelectLastUserLog(ObjectId householdId, String logType);
        List<UserAppLog> SelectUserLogFromType(ObjectId householdId, string logType);
        void CreateUserLogs(List<UserAppLog> logs);
        void CreateDeviceLogs(List<DeviceAppLog> logs);
        void CreateScheduleLogs(List<ScheduleAppLog> logs);
        void CreateMiscLogs(List<MiscAppLog> logs);
        void UpdateUserLogs(List<UserAppLog> logs);
        void UpdateDeviceLogs(List<DeviceAppLog> logs);
        void UpdateScheduleLogs(List<ScheduleAppLog> logs);
        void UpdateMiscLogs(List<MiscAppLog> logs);
    }
}

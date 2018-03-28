using MongoDB.Bson;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartHome.DAL.UnitOfWork;

namespace SmartHome.DAL
{
    public class AppLogMapper : IAppLogMapper
    {
        private UnitOfWork<AppLog> Uow;

        public AppLogMapper()
        {
            // initialise Uow
        }

        public void Create(AppLog obj)
        {
            // create applog object query
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public void CreateDeviceLogs(List<DeviceAppLog> logs)
        {
            // create deviceapplog object query
            // use insertMany to create multiple at a time
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public void CreateMiscLogs(List<MiscAppLog> logs)
        {
            // create misceapplog object query
            // use insertMany to create multiple at a time
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public void CreateScheduleLogs(List<ScheduleAppLog> logs)
        {
            // create scheduleapplog object query
            // use insertMany to create multiple at a time
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public void CreateUserLogs(List<UserAppLog> logs)
        {
            // create userapplog object query
            // use insertMany to create multiple at a time
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public AppLog Delete(ObjectId id)
        {
            // delete applog object query with _id
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public void Save()
        {
            // Uow.SaveChanges()
            throw new NotImplementedException();
        }

        public IEnumerable<AppLog> SelectAll()
        {
            // make query for selecting all applog
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public AppLog SelectById(ObjectId id)
        {
            // make query for selecting applog by _id
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public List<string> SelectDistinctDeviceLogTypes()
        {
            // make query for selecting all distinct deviceapplog logtypes
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public List<string> SelectDistinctMiscLogTypes()
        {
            // make query for selecting all distinct miscapplog logtypes
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public List<string> SelectDistinctScheduleLogTypes()
        {
            // make query for selecting all distinct scheduleapplog logtypes
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public List<string> SelectDistinctUserLogTypes()
        {
            // make query for selecting all distinct userapplog logtypes
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public UserAppLog SelectLastUserLog(ObjectId householdId, string logType)
        {
            // make query for selecting userapplog based on logtype
            // only retrieve latest timestamp
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public List<UserAppLog> SelectUserLogFromType(ObjectId householdId, string logType)
        {
            // make query for selecting userapplog based on logtype
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public void Update(AppLog obj)
        {
            // update applog object query
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public void UpdateDeviceLogs(List<DeviceAppLog> logs)
        {
            // update deviceapplog object query from a list of logs
            // update multiple documents at once
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public void UpdateMiscLogs(List<MiscAppLog> logs)
        {
            // update miscapplog object query from a list of logs
            // update multiple documents at once
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public void UpdateScheduleLogs(List<ScheduleAppLog> logs)
        {
            // update scheduleapplog object query from a list of logs
            // update multiple documents at once
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public void UpdateUserLogs(List<UserAppLog> logs)
        {
            // update userapplog object query from a list of logs
            // update multiple documents at once
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }
    }
}

using MongoDB.Bson;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartHome.DAL.UnitOfWork;

namespace SmartHome.DAL
{
    public class DeviceLogMapper : IDeviceLogMapper
    {
        private UnitOfWork<AppLog> Uow;

        public DeviceLogMapper()
        {
            // initialise Uow
        }

        public void Create(AppLog obj)
        {
            // The obj parameter can be of class Fan/AirCon/Light with different properties
            // Reflection will be used to determine the properties of the obj at runtime
            // Type T = typeof(obj)
            // PropertyInfo[] properties = T.GetProperties();
            // foreach (PropertyInfo property in properties) {
            //      map into document form
            // }
            // insert document to Mongodb

            throw new NotImplementedException();
        }

        public void CreateLogs(List<AppLog> logs)
        {
            // Similar to Create() but inserts a list of logs
            // Used when user import a file containing logs
            throw new NotImplementedException();
        }

        public AppLog Delete(ObjectId id)
        {
            // delete deviceapplog object query
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
            // make query for selecting all deviceapplog
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public AppLog SelectById(ObjectId id)
        {
            // make query for selecting deviceapplog by _id
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public List<AppLog> SelectFromDateRange(ObjectId householdId, DateTime startDate, DateTime endDate)
        {
            // make query for selecting deviceapplog within the date range
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public AppLog SelectIndividual(ObjectId householdId, string location, string type, DateTime startDate, DateTime endDate)
        {
            // make query for selecting 1 deviceapplog based on all parameters
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public void Update(AppLog obj)
        {
            // update deviceapplog object query
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }
    }
}

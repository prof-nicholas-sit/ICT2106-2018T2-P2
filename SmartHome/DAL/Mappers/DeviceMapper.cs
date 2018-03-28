using MongoDB.Bson;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartHome.DAL.UnitOfWork;

namespace SmartHome.DAL
{
    public class DeviceMapper : IDeviceMapper
    {
        // for retrieves, creation and updating, will use reflection to get subclass properties
        // and manual mapping of these properties upon retrieval

        private UnitOfWork<Device> Uow;

        public DeviceMapper() 
        {
            // initialise DeviceMapper    
        }

        public void Create(Device obj)
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

        public Device Delete(ObjectId id)
        {
            // delete device object query
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public void Save()
        {
            // Uow.SaveChanges()
            throw new NotImplementedException();
        }

        public IEnumerable<Device> SelectAll()
        {
            // make query for selecting all devices
            // Uow.ExecuteSelection(query)
            // return result       
            throw new NotImplementedException();
        }

        public List<Device> SelectByHouseholdId(ObjectId householdId)
        {
            // make query for selecting devices with householdId
            // Uow.ExecuteSelection(query)
            // return result       
            throw new NotImplementedException();
        }

        public Device SelectById(ObjectId id)
        {
            // make query for selecting devices with _id
            // Uow.ExecuteSelection(query)
            // return result       
            throw new NotImplementedException();
        }

        public List<Device> SelectByName(string name)
        {
            // make query for selecting devices with certain name
            // Uow.ExecuteSelection(query)
            // return result            
            throw new NotImplementedException();
        }

        public void ToggleFavourite(ObjectId _id)
        {
            // update device object query
            // toggles whether device is favourited
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public void Update(Device obj)
        {
            // update device object query
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.DAL.Transactions;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public class DeviceMapper : BaseMapper<Device>, IDeviceMapper
    {
        public DeviceMapper() : base("devices")
        {
        }

        public List<Device> SelectByHouseholdId(ObjectId householdId)
        {
            // make query for selecting devices with householdId
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
    }
}

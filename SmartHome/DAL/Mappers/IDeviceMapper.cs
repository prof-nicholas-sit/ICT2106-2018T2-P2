using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    interface IDeviceMapper : IBaseMapper<Device>
    {
        List<Device> SelectByName(string name);
        List<Device> SelectByHouseholdId(ObjectId householdId);
        void ToggleFavourite(ObjectId _id);
    }
}

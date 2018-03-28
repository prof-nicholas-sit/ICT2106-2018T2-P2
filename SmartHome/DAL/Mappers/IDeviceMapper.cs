using MongoDB.Bson;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.DAL
{
    interface IDeviceMapper : IBaseMapper<Device>
    {
        List<Device> SelectByName(string name);
        List<Device> SelectByHouseholdId(ObjectId householdId);
        void ToggleFavourite(ObjectId _id);
    }
}

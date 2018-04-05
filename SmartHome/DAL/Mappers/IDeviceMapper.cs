using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public interface IDeviceMapper : IBaseMapper<Device>
    {
        List<Device> SelectByName(string name);
        List<Device> SelectByHouseholdId(ObjectId householdId);
        IDeviceMapper SetFavourite(ObjectId deviceId, bool isFavourite);
    }
}

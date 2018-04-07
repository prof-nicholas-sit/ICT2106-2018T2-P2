using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public interface IDeviceMapper : IBaseMapper<Device>
    {
        // get all devices with specified name
        List<Device> SelectByName(string name);
        // get all devices belonging to a household with householdId
        List<Device> SelectByHouseholdId(ObjectId householdId);
        // toggle a device as favourite device
        IDeviceMapper SetFavourite(ObjectId deviceId, bool isFavourite);
    }
}

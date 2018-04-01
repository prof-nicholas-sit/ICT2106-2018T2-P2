using MongoDB.Bson;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public interface IScheduleMapper : IBaseMapper<Schedule>
    {
        Schedule SelectByDevice(ObjectId deviceId);
    }
}

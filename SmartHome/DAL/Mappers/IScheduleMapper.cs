using MongoDB.Bson;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public interface IScheduleMapper : IBaseMapper<Schedule>
    {
        // select a schedule with the specified deviceId
        Schedule SelectByDevice(ObjectId deviceId);
    }
}

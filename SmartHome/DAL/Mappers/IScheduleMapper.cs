using MongoDB.Bson;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.DAL
{
    interface IScheduleMapper : IBaseMapper<Schedule>
    {
        Schedule SelectByDevice(ObjectId deviceId);
    }
}

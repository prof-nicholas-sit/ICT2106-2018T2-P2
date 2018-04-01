using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.DAL.Transactions;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public class ScheduleMapper : BaseMapper<Schedule>, IScheduleMapper
    {
        public ScheduleMapper() : base("schedules")
        {
        }

        public Schedule SelectByDevice(ObjectId deviceId)
        {
            // make query for selecting schedule by deviceId
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }
    }
}

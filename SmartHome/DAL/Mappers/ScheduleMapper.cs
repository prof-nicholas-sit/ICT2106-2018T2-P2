using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
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
            FilterDefinition<BsonDocument> filterDefinition = Builders<BsonDocument>.Filter.Eq("DeviceId", deviceId);
            BsonDocument document = Uow.ExecuteRetrieveFirst(CollectionName, filterDefinition);
            return DeserializeDocument<Schedule>(document);
        }
    }
}

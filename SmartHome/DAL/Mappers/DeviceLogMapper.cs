using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SmartHome.DAL.Transactions;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public class DeviceLogMapper : BaseMapper<DeviceLog>, IDeviceLogMapper
    {
        public DeviceLogMapper() : base("devicelogs")
        {
        }

        public IDeviceLogMapper CreateLogs(IEnumerable<DeviceLog> logs)
        {
            foreach (DeviceLog deviceLog in logs)
            {
                Create(deviceLog);
            }

            return this;
        }

        public IEnumerable<DeviceLog> SelectFromDateRange(ObjectId householdId, DateTime start, DateTime end)
        {
            FilterDefinition<BsonDocument> filterDefinition =
                Builders<BsonDocument>.Filter.Eq("HouseholdId", householdId);
            filterDefinition &= Builders<BsonDocument>.Filter.Gte("DateTime", start);
            filterDefinition &= Builders<BsonDocument>.Filter.Lte("DateTime", end);
            IEnumerable<BsonDocument> documentList = Uow.ExecuteRetrieveAll(CollectionName, filterDefinition);
            List<DeviceLog> deviceLogList = new List<DeviceLog>();
            foreach (BsonDocument document in documentList)
            {
                deviceLogList.Add(DeserializeDocument<DeviceLog>(document));
            }

            return deviceLogList;
        }

        public DeviceLog SelectIndividual(ObjectId householdId, string location, string type, DateTime start,
            DateTime end)
        {
            FilterDefinition<BsonDocument> filterDefinition =
                Builders<BsonDocument>.Filter.Eq("HouseholdId", householdId);
            filterDefinition &= Builders<BsonDocument>.Filter.Eq("Location", location);
            filterDefinition &= Builders<BsonDocument>.Filter.Eq("Type", type);
            filterDefinition &= Builders<BsonDocument>.Filter.Gte("DateTime", start);
            filterDefinition &= Builders<BsonDocument>.Filter.Lte("DateTime", end);
            BsonDocument document = Uow.ExecuteRetrieveFirst(CollectionName, filterDefinition);
            return DeserializeDocument<DeviceLog>(document);
        }
    }
}
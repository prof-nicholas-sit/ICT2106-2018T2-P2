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

        public IDeviceLogMapper CreateLogs(List<DeviceLog> logs)
        {
            foreach (DeviceLog deviceLog in logs)
            {
                Create(deviceLog);
            }

            return this;
        }

        public List<DeviceLog> SelectFromDateRange(ObjectId householdId, DateTime startDate, DateTime endDate)
        {
            FilterDefinition<BsonDocument> filterDefinition =
                Builders<BsonDocument>.Filter.Eq("HouseholdId", householdId);
            filterDefinition &= Builders<BsonDocument>.Filter.Gte("DateTime", startDate);
            filterDefinition &= Builders<BsonDocument>.Filter.Lte("DateTime", endDate);
            IEnumerable<BsonDocument> documentList = Uow.ExecuteRetrieveAll(filterDefinition);
            List<DeviceLog> deviceList = new List<DeviceLog>();
            foreach (BsonDocument document in documentList)
            {
                deviceList.Add(DeserializeDocument<DeviceLog>(document));
            }

            return deviceList;
        }

        public DeviceLog SelectIndividual(ObjectId householdId, string location, string type, DateTime startDate,
            DateTime endDate)
        {
            FilterDefinition<BsonDocument> filterDefinition =
                Builders<BsonDocument>.Filter.Eq("HouseholdId", householdId);
            filterDefinition &= Builders<BsonDocument>.Filter.Eq("Location", location);
            filterDefinition &= Builders<BsonDocument>.Filter.Eq("Type", type);
            filterDefinition &= Builders<BsonDocument>.Filter.Gte("DateTime", startDate);
            filterDefinition &= Builders<BsonDocument>.Filter.Lte("DateTime", endDate);
            BsonDocument document = Uow.ExecuteRetrieveFirst(filterDefinition);
            return DeserializeDocument<DeviceLog>(document);
        }
    }
}
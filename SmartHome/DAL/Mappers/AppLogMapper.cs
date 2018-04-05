using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using SmartHome.DAL.Transactions;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public class AppLogMapper : BaseMapper<AppLog>, IAppLogMapper
    {
        public AppLogMapper() : base("applogs")
        {
        }

        public IAppLogMapper InsertMany(IEnumerable<AppLog> appLogs)
        {
            foreach (AppLog appLog in appLogs)
            {
                Create(appLog);
            }

            return this;
        }

        public int AggregateQuery(ObjectId householdId, DateTime start, DateTime end, string logType = null, string deviceType = null)
        {
            FilterDefinition<BsonDocument> filterDefinition =
                Builders<BsonDocument>.Filter.Eq("HouseholdId", householdId);
            filterDefinition &= Builders<BsonDocument>.Filter.Gte("Timestamp", start);
            filterDefinition &= Builders<BsonDocument>.Filter.Lte("Timestamp", end);

            if (logType != null)
            {
                filterDefinition &= Builders<BsonDocument>.Filter.Gte("LogType", logType);
            }

            if (deviceType != null)
            {
                filterDefinition &= Builders<BsonDocument>.Filter.Gte("DeviceType", deviceType);
            }

            IEnumerable<BsonDocument> documentList = Uow.ExecuteRetrieveAll(CollectionName, filterDefinition);
            List<AppLog> appLogList = new List<AppLog>();
            foreach (BsonDocument document in documentList)
            {
                appLogList.Add(DeserializeDocument<AppLog>(document));
            }

            return appLogList.Count;
        }

        public IEnumerable<AppLog> SelectQuery(ObjectId householdId, DateTime start, DateTime end,
            string logType = null, string deviceType = null)
        {
            FilterDefinition<BsonDocument> filterDefinition =
                Builders<BsonDocument>.Filter.Eq("HouseholdId", householdId);
            filterDefinition &= Builders<BsonDocument>.Filter.Gte("Timestamp", start);
            filterDefinition &= Builders<BsonDocument>.Filter.Lte("Timestamp", end);

            if (logType != null)
            {
                filterDefinition &= Builders<BsonDocument>.Filter.Gte("LogType", logType);
            }

            if (deviceType != null)
            {
                filterDefinition &= Builders<BsonDocument>.Filter.Gte("DeviceType", deviceType);
            }

            IEnumerable<BsonDocument> documentList = Uow.ExecuteRetrieveAll(CollectionName, filterDefinition);
            List<AppLog> appLogList = new List<AppLog>();
            foreach (BsonDocument document in documentList)
            {
                appLogList.Add(DeserializeDocument<AppLog>(document));
            }

            return appLogList;
        }

        public IEnumerable<string> ListLogTypes(ObjectId householdId, DateTime start, DateTime end,
            string deviceType = null)
        {
            FilterDefinition<BsonDocument> filterDefinition =
                Builders<BsonDocument>.Filter.Eq("HouseholdId", householdId);
            filterDefinition &= Builders<BsonDocument>.Filter.Gte("Timestamp", start);
            filterDefinition &= Builders<BsonDocument>.Filter.Lte("Timestamp", end);

            if (deviceType != null)
            {
                filterDefinition &= Builders<BsonDocument>.Filter.Gte("DeviceType", deviceType);
            }

            IEnumerable<BsonDocument> documentList = Uow.ExecuteRetrieveAll(CollectionName, filterDefinition);
            IEnumerable<string> logTypeList = null;
            if (documentList != null)
            {
                logTypeList = documentList.Select(x => x.GetValue("LogType").AsString).ToList();
            }

            return logTypeList;
        }

        public IEnumerable<string> ListDeviceTypes(ObjectId householdId, DateTime start, DateTime end,
            string logType = null)
        {
            FilterDefinition<BsonDocument> filterDefinition =
                Builders<BsonDocument>.Filter.Eq("HouseholdId", householdId);
            filterDefinition &= Builders<BsonDocument>.Filter.Gte("Timestamp", start);
            filterDefinition &= Builders<BsonDocument>.Filter.Lte("Timestamp", end);

            if (logType != null)
            {
                filterDefinition &= Builders<BsonDocument>.Filter.Gte("LogType", logType);
            }

            IEnumerable<BsonDocument> documentList = Uow.ExecuteRetrieveAll(CollectionName, filterDefinition);
            IEnumerable<string> logTypeList = null;
            if (documentList != null)
            {
                logTypeList = documentList.Select(x => x.GetValue("DeviceType").AsString).ToList();
            }

            return logTypeList;
        }
    }
}
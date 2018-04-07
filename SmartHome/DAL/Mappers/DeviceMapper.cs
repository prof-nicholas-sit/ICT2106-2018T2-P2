using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SmartHome.DAL.Transactions;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    /**
     * Concrete class for IDeviceMapper
     */
    public class DeviceMapper : BaseMapper<Device>, IDeviceMapper
    {
        public DeviceMapper() : base("devices")
        {
        }

        public List<Device> SelectByHouseholdId(ObjectId householdId)
        {
            FilterDefinition<BsonDocument> filterDefinition = Builders<BsonDocument>.Filter.Eq("HouseholdId", householdId);
            IEnumerable<BsonDocument> documentList = Uow.ExecuteRetrieveAll(CollectionName, filterDefinition);
            List<Device> deviceList = new List<Device>();
            foreach (BsonDocument document in documentList)
            {
                deviceList.Add(DeserializeDocument<Device>(document));
            }

            return deviceList;
        }

        public List<Device> SelectByName(string name)
        {
            FilterDefinition<BsonDocument> filterDefinition = Builders<BsonDocument>.Filter.Eq("Name", name);
            IEnumerable<BsonDocument> documentList = Uow.ExecuteRetrieveAll(CollectionName, filterDefinition);
            List<Device> deviceList = new List<Device>();
            foreach (BsonDocument document in documentList)
            {
                deviceList.Add(DeserializeDocument<Device>(document));
            }

            return deviceList;
        }

        public IDeviceMapper SetFavourite(ObjectId deviceId, bool isFavourite)
        {
            FilterDefinition<BsonDocument> filterDefinition = Builders<BsonDocument>.Filter.Eq("_id", deviceId);
            UpdateDefinition<BsonDocument>
                updateDefinition = Builders<BsonDocument>.Update.Set("IsFavourite", isFavourite);
            Uow.RegisterDirty(CollectionName, filterDefinition, updateDefinition);
            return this;
        }
    }
}

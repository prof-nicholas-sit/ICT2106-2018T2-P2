using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SmartHome.DAL.Transactions;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public class HouseholdMapper : BaseMapper<Household>, IHouseholdMapper
    {
        public HouseholdMapper() : base("accounts")
        {
        }

        public Account Login(string username, string password)
        {
            FilterDefinition<BsonDocument> filterDefinition = Builders<BsonDocument>.Filter.Eq("Username", username);
            filterDefinition &= Builders<BsonDocument>.Filter.Eq("Password", password);
            BsonDocument document = Uow.ExecuteRetrieveFirst(CollectionName, filterDefinition);
            return DeserializeDocument<Account>(document);
        }

        public Household SelectByAddress(string street, int postalCode, string unitNo)
        {
            FilterDefinition<BsonDocument> filterDefinition = Builders<BsonDocument>.Filter.Eq("Street", street);
            filterDefinition &= Builders<BsonDocument>.Filter.Eq("PostalCode", postalCode);
            filterDefinition &= Builders<BsonDocument>.Filter.Eq("UnitNo", unitNo);
            BsonDocument document = Uow.ExecuteRetrieveFirst(CollectionName, filterDefinition);
            return DeserializeDocument<Household>(document);
        }

        public Household SelectByUsername(string username)
        {
            FilterDefinition<BsonDocument> filterDefinition = Builders<BsonDocument>.Filter.Eq("Username", username);
            BsonDocument document = Uow.ExecuteRetrieveFirst(CollectionName, filterDefinition);
            return DeserializeDocument<Household>(document);
        }

        public bool CheckRequestingResetPw(string username)
        {
            FilterDefinition<BsonDocument> filterDefinition = Builders<BsonDocument>.Filter.Eq("Username", username);
            BsonDocument document = Uow.ExecuteRetrieveFirst(CollectionName, filterDefinition);
            Household household = DeserializeDocument<Household>(document);
            return household != null && household.IsResetPassword;
        }

        public IHouseholdMapper RequestPasswordReset(string username)
        {
            FilterDefinition<BsonDocument> filterDefinition = Builders<BsonDocument>.Filter.Eq("Username", username);
            UpdateDefinition<BsonDocument>
                updateDefinition = Builders<BsonDocument>.Update.Set("IsResetPassword", true);
            Uow.RegisterDirty(CollectionName, filterDefinition, updateDefinition);
            return this;
        }

        public IHouseholdMapper ResetPassword(string username, string password)
        {
            FilterDefinition<BsonDocument> filterDefinition = Builders<BsonDocument>.Filter.Eq("Username", username);
            UpdateDefinition<BsonDocument>
                updateDefinition = Builders<BsonDocument>.Update.Set("Password", password);
            Uow.RegisterDirty(CollectionName, filterDefinition, updateDefinition);
            return this;
        }
    }
}
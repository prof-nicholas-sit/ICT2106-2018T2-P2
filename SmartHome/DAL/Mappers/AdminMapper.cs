using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SmartHome.DAL.Transactions;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public class AdminMapper : BaseMapper<Administrator>, IAdminMapper
    {
        public AdminMapper() : base("accounts")
        {
        }

        public Account Login(string username, string password)
        {
            FilterDefinition<BsonDocument> filterDefinition = Builders<BsonDocument>.Filter.Eq("Username", username);
            filterDefinition &= Builders<BsonDocument>.Filter.Eq("Password", password);
            BsonDocument document = Uow.ExecuteRetrieveFirst(filterDefinition);
            return DeserializeDocument<Account>(document);
        }
    }
}
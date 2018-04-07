using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SmartHome.DAL.Transactions;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    /**
     * IAdminMapper concrete class. Used to login as administrator.
     */
    public class AdminMapper : BaseMapper<Administrator>, IAdminMapper
    {
        public AdminMapper() : base("administrators")
        {
        }

        // login function
        public Administrator Login(string username, string password)
        {
            FilterDefinition<BsonDocument> filterDefinition = Builders<BsonDocument>.Filter.Eq("Username", username);
            filterDefinition &= Builders<BsonDocument>.Filter.Eq("Password", password);
            BsonDocument document = Uow.ExecuteRetrieveFirst(CollectionName, filterDefinition);
            return DeserializeDocument<Administrator>(document);
        }
    }
}
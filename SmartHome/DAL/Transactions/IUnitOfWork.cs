using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.Transactions
{
    public interface IUnitOfWork
    {
        void RegisterNew(BsonDocument document);
        void RegisterDirty(FilterDefinition<BsonDocument> filterDefinition, UpdateDefinition<BsonDocument> updateDefinition);
        void RegisterDeleted(FilterDefinition<BsonDocument> filterDefinition);
        List<BsonDocument> ExecuteRetrieveAll(FilterDefinition<BsonDocument> filterDefinition);
        BsonDocument ExecuteRetrieveFirst(FilterDefinition<BsonDocument> filterDefinition);
        void Commit();
        void Rollback();
    }
}

using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.Transactions
{
    public interface IUnitOfWork
    {
        void RegisterNew(BsonDocument document);
        void RegisterDirty(FilterDefinition<BsonDocument> filterDefinition, UpdateDefinition<BsonDocument> updateDefinition);
        void RegisterDirty(FilterDefinition<BsonDocument> filterDefinition, BsonDocument document);
        void RegisterDeleted(FilterDefinition<BsonDocument> filterDefinition);
        IEnumerable<BsonDocument> ExecuteRetrieveAll(FilterDefinition<BsonDocument> filterDefinition);
        BsonDocument ExecuteRetrieveFirst(FilterDefinition<BsonDocument> filterDefinition);
        void Commit();
        void Rollback();
    }
}

using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.Transactions
{
    public abstract class MongoDbQuery
    {
        public FilterDefinition<BsonDocument> FilterDefinition { get; }

        public MongoDbQuery(FilterDefinition<BsonDocument> filterDefinition)
        {
            FilterDefinition = filterDefinition;
        }
        
        public abstract void Execute();
        // This method is for future enhancement, to allow commands to be reverted. Currently does not have impl
        public abstract void Undo();
    }
}
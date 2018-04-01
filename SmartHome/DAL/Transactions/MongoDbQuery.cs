using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.Transactions
{
    public abstract class MongoDbQuery
    {
        public IMongoCollection<BsonDocument> Collection { get; }
        
        public MongoDbQuery(IMongoCollection<BsonDocument> collection)
        {
            Collection = collection;
        }
        
        public abstract void Execute();
        // This method is for future enhancement, to allow commands to be reverted. Currently does not have impl
        public abstract void Undo();
        public abstract override string ToString();
    }
}
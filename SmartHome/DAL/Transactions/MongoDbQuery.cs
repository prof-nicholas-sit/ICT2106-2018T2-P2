using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.Transactions
{
    /**
     * Abstract mongodb query class that implements IMongoDbQuery
     *
     * Consists of constructor to take in the collection that will modified
     */
    public abstract class MongoDbQuery : IMongoDbQuery
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
using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.Transactions
{
    public class DeleteMongoDbQuery : MongoDbQuery
    {
        private FilterDefinition<BsonDocument> FilterDefinition;
        
        public DeleteMongoDbQuery(IMongoCollection<BsonDocument> collection,
            FilterDefinition<BsonDocument> filterDefinition) : base(collection)
        {
            FilterDefinition = filterDefinition;
        }

        public override void Execute()
        {
            DeleteResult result = Collection.DeleteMany(FilterDefinition);
            
            if (result.IsAcknowledged)
            {
                Console.WriteLine("Deleted {0} document(s).", result.DeletedCount);
            }
        }

        public override void Undo()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return FilterDefinition.ToJson();
        }
    }
}
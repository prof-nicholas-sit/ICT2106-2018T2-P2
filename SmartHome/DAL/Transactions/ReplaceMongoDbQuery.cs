using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.Transactions
{
    public class ReplaceMongoDbQuery : MongoDbQuery
    {
        private FilterDefinition<BsonDocument> FilterDefinition;
        private BsonDocument UpdateDocument;

        public ReplaceMongoDbQuery(IMongoCollection<BsonDocument> collection,
            FilterDefinition<BsonDocument> filterDefinition,
            BsonDocument updateDocument) : base(collection)
        {
            FilterDefinition = filterDefinition;
            UpdateDocument = updateDocument;
        }

        public override void Execute()
        {
            ReplaceOneResult result = Collection.ReplaceOne(FilterDefinition, UpdateDocument);

            if (result.IsModifiedCountAvailable)
            {
                Console.WriteLine("Modified {0} document(s).", result.ModifiedCount);
            }
        }

        public override void Undo()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return FilterDefinition.RenderToBsonDocument() + "\n---with---\n" + UpdateDocument;
        }
    }
}
using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.Transactions
{
    /**
     * Represents a query that replaces a document in a collection. Replace is an update query.
     */
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
            // execute replace query
            ReplaceOneResult result = Collection.ReplaceOne(FilterDefinition, UpdateDocument);
            // print to console for debug purposes
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
            return FilterDefinition.RenderToBsonDocument().ToJson() + " ---with--- " + UpdateDocument.ToJson();
        }
    }
}
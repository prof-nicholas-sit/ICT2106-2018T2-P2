using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.Transactions
{
    /**
     * Represents a query that performs an update to a collection.
     */
    public class UpdateMongoDbQuery : MongoDbQuery
    {
        private FilterDefinition<BsonDocument> FilterDefinition;
        private UpdateDefinition<BsonDocument> UpdateDefinition;

        public UpdateMongoDbQuery(IMongoCollection<BsonDocument> collection,
            FilterDefinition<BsonDocument> filterDefinition,
            UpdateDefinition<BsonDocument> updateDefinition)
            : base(collection)
        {
            FilterDefinition = filterDefinition;
            UpdateDefinition = updateDefinition;
        }

        public override void Execute()
        {
            // execute update query
            UpdateResult result = Collection.UpdateMany(FilterDefinition, UpdateDefinition);
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
            return FilterDefinition.RenderToBsonDocument().ToJson() + " ---with--- " +
                   UpdateDefinition.RenderToBsonDocument().ToJson();
        }
    }
}
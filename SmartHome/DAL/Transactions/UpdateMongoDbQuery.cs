using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.Transactions
{
    public class UpdateMongoDbQuery : MongoDbQuery
    {
        private UpdateDefinition<BsonDocument> UpdateDefinition;

        public UpdateMongoDbQuery(FilterDefinition<BsonDocument> filterDefinition,
            UpdateDefinition<BsonDocument> updateDefinition)
            : base(filterDefinition)
        {
            UpdateDefinition = updateDefinition;
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}
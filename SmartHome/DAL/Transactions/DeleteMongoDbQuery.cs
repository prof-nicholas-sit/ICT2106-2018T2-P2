using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.Transactions
{
    public class DeleteMongoDbQuery : MongoDbQuery
    {
        public DeleteMongoDbQuery(FilterDefinition<BsonDocument> filterDefinition) : base(filterDefinition)
        {
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
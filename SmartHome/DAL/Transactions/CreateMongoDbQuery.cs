using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.Transactions
{
    public class CreateMongoDbQuery :  MongoDbQuery
    {
        public CreateMongoDbQuery(FilterDefinition<BsonDocument> filterDefinition) : base(filterDefinition)
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
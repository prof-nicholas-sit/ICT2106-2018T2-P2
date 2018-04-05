using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.Transactions
{
    public class CreateMongoDbQuery : MongoDbQuery
    {
        private BsonDocument NewDocument;
        
        public CreateMongoDbQuery(IMongoCollection<BsonDocument> collection, BsonDocument bsonDocument) : base(
            collection)
        {
            NewDocument = bsonDocument;
        }

        public override void Execute()
        {
            Collection.InsertOne(NewDocument);
        }

        public override void Undo()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return NewDocument.ToJson();
        }
    }
}
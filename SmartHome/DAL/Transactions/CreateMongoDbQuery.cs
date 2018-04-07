using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.Transactions
{
    /**
     * Represents a query that performs a create to a collection.
     */
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
            // execute insert query
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
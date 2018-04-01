using MongoDB.Bson;

namespace SmartHome.Models
{
    public abstract class MongoDbObject : IMongoDbObject
    {
        public ObjectId _id { get; set; }
    }
}
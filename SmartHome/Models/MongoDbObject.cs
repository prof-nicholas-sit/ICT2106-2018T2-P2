using MongoDB.Bson;

namespace SmartHome.Models
{
    public abstract class MongoDbObject
    {
        public ObjectId _id { get; set; }
    }
}
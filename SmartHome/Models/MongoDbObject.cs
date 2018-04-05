using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace SmartHome.Models
{
    public abstract class MongoDbObject
    {
        public MongoDbObject()
        {
            

        }
        public ObjectId _id { get; set; }
        public string ClassType { get; set; }
    }
}
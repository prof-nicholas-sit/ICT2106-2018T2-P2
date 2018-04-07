using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace SmartHome.Models
{
    /**
     * Abstract class needed for all objects to be stored in mongodb as documents.
     * Consists of attributes that are needed for serialization and deserialization, such as document _id,
     * and ClassType meant for Reflection.
     *
     * All parent domain model classes that need to be stored in MongoDB MUST inherit from this class.
     */
    public abstract class MongoDbObject
    {
        public ObjectId _id { get; set; }
        public string ClassType { get; set; }
    }
}
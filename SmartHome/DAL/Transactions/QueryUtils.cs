using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace SmartHome.DAL.Transactions
{
    public static class QueryUtils
    {
        /**
         * https://stackoverflow.com/a/32146281
         */
        public static BsonDocument RenderToBsonDocument<T>(this FilterDefinition<T> filter)
        {
            var serializerRegistry = BsonSerializer.SerializerRegistry;
            var documentSerializer = serializerRegistry.GetSerializer<T>();
            return filter.Render(documentSerializer, serializerRegistry);
        }
        
        public static BsonDocument RenderToBsonDocument<T>(this UpdateDefinition<T> filter)
        {
            var serializerRegistry = BsonSerializer.SerializerRegistry;
            var documentSerializer = serializerRegistry.GetSerializer<T>();
            return filter.Render(documentSerializer, serializerRegistry);
        }
    }
}
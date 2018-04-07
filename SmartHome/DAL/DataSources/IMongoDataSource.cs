using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.DataSources
{
    public interface IMongoDataSource
    {
        IMongoCollection<BsonDocument> GetCollection(string collection);
    }
}
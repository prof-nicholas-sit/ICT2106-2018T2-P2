using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.DataSource
{
    public interface IMongoDataSource
    {
        IMongoCollection<BsonDocument> GetCollection(string collection);
    }
}

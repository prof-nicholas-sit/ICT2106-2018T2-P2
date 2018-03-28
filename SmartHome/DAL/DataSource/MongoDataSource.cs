using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.DataSource
{
    public class MongoDataSource : IMongoDataSource
    {
        private static MongoDataSource Instance;
        private IMongoDatabase Database;
        
        // Singleton Class Other classes not allowed to instantiate an object of this class
        private MongoDataSource()
        {
            Initialise(); 
        }

        // initialise MongoDatabase
        // establish connection to mongodb by specifying URL and Port
        private void Initialise()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            Database = client.GetDatabase("smart-home-ict2106");
        }

        // If instance already exist return instance else create a new instance.
        public static MongoDataSource GetInstance()
        {
            return Instance ?? (Instance = new MongoDataSource());
        }


        // Returns a user specifed collection
        public IMongoCollection<BsonDocument> GetCollection(string collection)
        {
            return Database.GetCollection<BsonDocument>(collection);
        }
    }
}

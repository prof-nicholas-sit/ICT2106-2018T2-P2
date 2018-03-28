using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.DAL
{
    public class MongoDataSource : IMongoDataSource
    {
        private static MongoDataSource Instance;
        private MongoDatabase Database;
        
        // Singleton Class Other classes not allowed to instantiate an object of this class
        private MongoDataSource()
        {
            // initialise MongoDatabase
            // establish connection to mongodb by specifying URL and Port
        }


        // If instance already exist return instance else create a new instance.
        public static MongoDataSource GetInstance()
        {
            if (Instance == null)
            {
                Instance = new MongoDataSource();
            }
            return Instance;
        }


        // Returns a user specifed collection
        public MongoCollection GetCollection(string collection)
        {
            // return database.getCollection(collection);
            throw new NotImplementedException();
        }
    }
}

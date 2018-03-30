using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using SmartHome.DAL.DataSource;
using SmartHome.DAL.UnitOfWork;
using SmartHome.Models;

namespace SmartHome.DAL
{
    public class AdminMapper : IAdminMapper
    {
        private UnitOfWork<Administrator> Uow;



        private IMongoDataSource DataSource;
        IMongoCollection<BsonDocument> Collection;

        public AdminMapper()
        {
            // initialise Uow


            DataSource = MongoDataSource.GetInstance();
            Collection = DataSource.GetCollection("Admin");
        }

        public void Create(Household obj)
        {
            // create administrator object query
            // Uow.RegisterQuery(query)

            Collection.InsertOne(obj.ToBsonDocument());
        }

        public Household Delete(ObjectId id)
        {
            // delete administrator object query
            // Uow.RegisterQuery(query)

            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);

            BsonDocument result = Collection.Find(filter).FirstOrDefault().ToBsonDocument();

            if (result != null)
            {
                return BsonSerializer.Deserialize<Household>(result);
            }
            return null;
        }

        public Household Login(string username, string password)
        {
            // collection.Find() any document that has the same username and password given in the parameters
            // If exists retrieve json document file and map into the Administrator Object

            var filterBuilder = Builders<BsonDocument>.Filter;
            var filter = filterBuilder.Eq("Username", username) & filterBuilder.Eq("Password", password);
            BsonDocument result = Collection.Find(filter).FirstOrDefault().ToBsonDocument();

            if (result != null)
            {
                return BsonSerializer.Deserialize<Household>(result);
            }
            return null;
        }

        public void Save()
        {
            // Uow.SaveChanges()
            throw new NotImplementedException();
        }

        public IEnumerable<Household> SelectAll()
        {
            // make query for selecting all administrators
            // Uow.ExecuteSelection(query)
            // return result
            /*
            IEnumerable<Household> result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Household>>(Collection.Find(new BsonDocument()).ToList().ToJson());

            foreach (Household doc in result) {
                Console.WriteLine(doc);
            }
            */
            /*
            if (result != null)
            {
                using (var jsonReader = new JsonReader(text)
                {
                    var serializer = new BsonArraySerializer();
                    var bsonArray = serializer.Deserialize(BsonDeserializationContext.CreateRoot(jsonReader));

                }
                
                return BsonSerializer.Deserialize<IList<Household>>(result.ToList());
            }
            */
            return null;
        }

        public Household SelectById(ObjectId id)
        {
            // make query for selecting all administrator by _id
            // Uow.ExecuteSelection(query)
            // return result

            var filterBuilder = Builders<BsonDocument>.Filter;
            var filter = filterBuilder.Eq("_id", id);
            BsonDocument result = Collection.Find(filter).FirstOrDefault().ToBsonDocument();

            if (result != null)
            {
                return BsonSerializer.Deserialize<Household>(result);
            }
            return null;
        }

        public void Update(Household obj)
        {
            // update administrator object query
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }
    }
}

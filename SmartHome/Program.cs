using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using SmartHome.DAL.Mappers;
using SmartHome.Models;

namespace SmartHome
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Program");
            Console.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture));
//            BuildWebHost(args).Run();

            new AdminMapper().Create(new Administrator() {Username = "test", Password = "123"}).Save();
            new AdminMapper().Login("test", "123");

//            MongoDataSource dataSource = MongoDataSource.GetInstance();
//            IMongoCollection<BsonDocument> collection = dataSource.GetCollection("household");
//            collection.InsertOne(new Household("test", "pw").ToBsonDocument());

//            IMongoCollection<BsonDocument> collection = dataSource.GetCollection("applog");
//            AppLog applog = new AppLog();
//            applog.content = "content";
//            applog.testList = new List<Schedule>() {new Schedule() {_id = ObjectId.GenerateNewId(), schedule = "asdsdas"}};
//            collection.InsertOne(applog.ToBsonDocument());
//
//            test(new DeviceAppLog());    
//            test(new ScheduleAppLog());    

//            IFindFluent<BsonDocument, BsonDocument> find = collection.Find(new BsonDocument());
//            foreach (var bsonDocument in find.ToList())
//            {
//                MethodInfo method = typeof(BsonSerializer).GetMethod("Deserialize");
//                Console.WriteLine(Type.GetType("Household"));
//                method = method.MakeGenericMethod(Type.GetType("Household"));
//                method.Invoke(null, new object[] {bsonDocument});
//            }
//            Console.WriteLine("Finish Program");
        }

//        public static void test(AppLog appLog)
//        {
//            Console.WriteLine(appLog.GetType());
//            MongoDataSource dataSource = MongoDataSource.GetInstance();
//            IMongoCollection<BsonDocument> collection = dataSource.GetCollection("applog");
//            BsonClassMap.LookupClassMap(appLog.GetType());
//            collection.InsertOne(appLog.ToBsonDocument());
//        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
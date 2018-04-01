using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.Transactions
{
    public abstract class MongoDbQueryDecorator : MongoDbQuery
    {
        private MongoDbQuery DecoratedMongoDbQuery;
        
        protected MongoDbQueryDecorator(MongoDbQuery mongoDbQuery) : base(mongoDbQuery.FilterDefinition)
        {
            DecoratedMongoDbQuery = mongoDbQuery;
        }

        public override void Execute()
        {
            // This impl can be changed in the future, for now it prints into console some logging information of the 
            // query being executed
            Console.WriteLine(String.Format(""));
        }
    }
}
using System;
using System.Globalization;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartHome.DAL.Transactions
{
    /**
     * Abstract class representing a decorator for MongoDbQuerys
     */
    public abstract class MongoDbQueryDecorator : MongoDbQuery
    {
        protected MongoDbQuery DecoratedMongoDbQuery;

        protected MongoDbQueryDecorator(MongoDbQuery mongoDbQuery) : base(mongoDbQuery.Collection)
        {
            DecoratedMongoDbQuery = mongoDbQuery;
        }
    }
}
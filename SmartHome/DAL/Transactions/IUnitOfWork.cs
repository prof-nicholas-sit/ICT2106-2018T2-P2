using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SmartHome.DAL.DataSources;

namespace SmartHome.DAL.Transactions
{
    public abstract class IUnitOfWork
    {
        // All mapper classes methods will add queries into this list
        protected List<IMongoDbQuery> Queries = new List<IMongoDbQuery>();
        protected IMongoDataSource DataSource;

        /**
         * This design implementation allows queries to and fro different collections within 1 UoW.
         */
        public IUnitOfWork()
        {
            // initialise DataSource
            DataSource = MongoDataSource.GetInstance();
        }

        public abstract void RegisterNew(string collectionName, BsonDocument document);

        public abstract void RegisterDirty(string collectionName, FilterDefinition<BsonDocument> filterDefinition,
            UpdateDefinition<BsonDocument> updateDefinition);

        public abstract void RegisterDirty(string collectionName, FilterDefinition<BsonDocument> filterDefinition,
            BsonDocument document);

        public abstract void RegisterDeleted(string collectionName, FilterDefinition<BsonDocument> filterDefinition);

        public abstract IEnumerable<BsonDocument> ExecuteRetrieveAll(string collectionName,
            FilterDefinition<BsonDocument> filterDefinition);

        public abstract BsonDocument ExecuteRetrieveFirst(string collectionName,
            FilterDefinition<BsonDocument> filterDefinition);

        public abstract void Commit();
        public abstract void Rollback();

        public static IUnitOfWork operator +(IUnitOfWork c1, IUnitOfWork c2)
        {
            List<IMongoDbQuery> newQueries = new List<IMongoDbQuery>();
            newQueries.AddRange(c1.Queries);
            newQueries.AddRange(c2.Queries);
            return new UnitOfWork() {Queries = newQueries};
        }
    }
}
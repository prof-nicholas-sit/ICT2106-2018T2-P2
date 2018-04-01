using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SmartHome.DAL.DataSources;

namespace SmartHome.DAL.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        // All mapper classes methods will add queries into this list
        private List<MongoDbQuery> Queries = new List<MongoDbQuery>();
        private IMongoCollection<BsonDocument> Collection;     

        /**
         * This design implementation assumes that the UoW only handles queries from 1 specified collection.
         * If requirements changed such that need to support querying from multiple collections within 1 UoW, then
         * collection should be specified in all RegisterNew, RegisterDirty, RegisterDeleted functions.
         */ 
        public UnitOfWork(string collection)
        {
            // initialise DataSource
            IMongoDataSource DataSource = MongoDataSource.GetInstance();
            // get specified collection
            Collection = DataSource.GetCollection(collection);
        }
        
        /**
         * Add creation query to list of queries
         */
        public void RegisterNew(BsonDocument document)
        {
            CreateMongoDbQuery createQuery = new CreateMongoDbQuery(Collection, document);
            LoggingMongoDbQuery query = new LoggingMongoDbQuery(createQuery);
            Queries.Add(query);
        }

        /**
         * Add update query to list of queries
         */
        public void RegisterDirty(FilterDefinition<BsonDocument> filterDefinition, UpdateDefinition<BsonDocument> updateDefinition)
        {
            UpdateMongoDbQuery updateQuery = new UpdateMongoDbQuery(Collection, filterDefinition, updateDefinition);
            LoggingMongoDbQuery query = new LoggingMongoDbQuery(updateQuery);
            Queries.Add(query);
        }

        public void RegisterDirty(FilterDefinition<BsonDocument> filterDefinition, BsonDocument document)
        {
            ReplaceMongoDbQuery replaceQuery = new ReplaceMongoDbQuery(Collection, filterDefinition, document);
            LoggingMongoDbQuery query = new LoggingMongoDbQuery(replaceQuery);
            Queries.Add(query);
        }

        /**
         * Add delete query to list of queries
         */
        public void RegisterDeleted(FilterDefinition<BsonDocument> filterDefinition)
        {
            DeleteMongoDbQuery deleteQuery = new DeleteMongoDbQuery(Collection, filterDefinition);
            LoggingMongoDbQuery query = new LoggingMongoDbQuery(deleteQuery);
            Queries.Add(query);
        }

        /**
         * Retrieve all documents matching filters
         * Does not require commit() since retrieval does not modify the database
         * Retrieval done synchronously, so data is return without needing callbacks
         */
        public IEnumerable<BsonDocument> ExecuteRetrieveAll(FilterDefinition<BsonDocument> filterDefinition)
        {
            return Collection.Find(filterDefinition).ToList();
        }

        /**
         * Similar to ExecuteRetrieveAll(), but only returns the first document that matches the specified filter
         */
        public BsonDocument ExecuteRetrieveFirst(FilterDefinition<BsonDocument> filterDefinition)
        {
            return Collection.Find(filterDefinition).FirstOrDefault();
        }

        /**
         * Perform all the registered queries to MongoDB database in sequential order
         * Ideally, this function will apply some optimization algorithms to combine multiple transactions together
         * For instance, combining multiple insertion queries into a batch insert
         */
        public void Commit()
        {
            // loop through the Queries
            // for each query, execute the query
            foreach (MongoDbQuery query in Queries)
            {
                query.Execute();
            }
        }

        /**
         * This method is for future enhancement, to allow commands to be reverted based on the list of commands that
         * had been committed previously.
         *
         * The command pattern used lays the foundation for this method to perform the undo operation for the commands
         * since the IMongoDbQuery interface specifies an undo method (for future use)
         *
         * Could also use a combination with Memento pattern to remember the state of the data in the database so that
         * reverting commands can be done
         */
        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SmartHome.DAL.DataSources;

namespace SmartHome.DAL.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        /**
         * Add creation query to list of queries
         */
        public override void RegisterNew(string collectionName, BsonDocument document)
        {
            IMongoCollection<BsonDocument> collection = DataSource.GetCollection(collectionName);
            CreateMongoDbQuery createQuery = new CreateMongoDbQuery(collection, document);
            LoggingMongoDbQuery query = new LoggingMongoDbQuery(createQuery);
            Queries.Add(query);
        }

        /**
         * Add update query to list of queries
         */
        public override void RegisterDirty(string collectionName, FilterDefinition<BsonDocument> filterDefinition,
            UpdateDefinition<BsonDocument> updateDefinition)
        {
            IMongoCollection<BsonDocument> collection = DataSource.GetCollection(collectionName);
            UpdateMongoDbQuery updateQuery = new UpdateMongoDbQuery(collection, filterDefinition, updateDefinition);
            LoggingMongoDbQuery query = new LoggingMongoDbQuery(updateQuery);
            Queries.Add(query);
        }

        public override void RegisterDirty(string collectionName, FilterDefinition<BsonDocument> filterDefinition,
            BsonDocument document)
        {
            IMongoCollection<BsonDocument> collection = DataSource.GetCollection(collectionName);
            ReplaceMongoDbQuery replaceQuery = new ReplaceMongoDbQuery(collection, filterDefinition, document);
            LoggingMongoDbQuery query = new LoggingMongoDbQuery(replaceQuery);
            Queries.Add(query);
        }

        /**
         * Add delete query to list of queries
         */
        public override void RegisterDeleted(string collectionName, FilterDefinition<BsonDocument> filterDefinition)
        {
            IMongoCollection<BsonDocument> collection = DataSource.GetCollection(collectionName);
            DeleteMongoDbQuery deleteQuery = new DeleteMongoDbQuery(collection, filterDefinition);
            LoggingMongoDbQuery query = new LoggingMongoDbQuery(deleteQuery);
            Queries.Add(query);
        }

        /**
         * Retrieve all documents matching filters
         * Does not require commit() since retrieval does not modify the database
         * Retrieval done synchronously, so data is return without needing callbacks
         */
        public override IEnumerable<BsonDocument> ExecuteRetrieveAll(string collectionName,
            FilterDefinition<BsonDocument> filterDefinition)
        {
            return DataSource.GetCollection(collectionName).Find(filterDefinition).ToList();
        }

        /**
         * Similar to ExecuteRetrieveAll(), but only returns the first document that matches the specified filter
         */
        public override BsonDocument ExecuteRetrieveFirst(string collectionName, FilterDefinition<BsonDocument> filterDefinition)
        {
            return DataSource.GetCollection(collectionName).Find(filterDefinition).FirstOrDefault();
        }

        /**
         * Perform all the registered queries to MongoDB database in sequential order
         * Ideally, this function will apply some optimization algorithms to combine multiple transactions together
         * For instance, combining multiple insertion queries into a batch insert
         */
        public override void Commit()
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
        public override void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
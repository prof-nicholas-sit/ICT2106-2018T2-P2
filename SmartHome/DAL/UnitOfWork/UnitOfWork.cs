using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using SmartHome.DAL.DataSource;

namespace SmartHome.DAL.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        
        // All mapper classes methods will add queries into this list
        private List<IQueryable<T>> Queries;
        private MongoDataSource DataSource;

        public UnitOfWork(string collection)
        {
            // initialise DataSource
            DataSource = MongoDataSource.GetInstance();
        }

        // append query to Queries
        public void RegisterNew(IQueryable<T> createQuery)
        {
            // .InsertOne()
            throw new NotImplementedException();
        }

        public void RegisterDirty(IQueryable<T> updateQuery)
        {
            // .UpdateMany()
            // var result = collection.UpdateOne(filter, update);

//            if (result.IsModifiedCountAvailable)
//            {
//                Console.WriteLine(result.ModifiedCount);
//            }
            throw new NotImplementedException();
        }

        public void RegisterDeleted(IQueryable<T> deleteQuery)
        {
            // .DeleteMany()
            throw new NotImplementedException();
        }

        // Retrieve document based on the retrieve query
        public List<BsonDocument> ExecuteRetrieveAll(IQueryable<T> retrieveQuery)
        {
            // execute query, store result in var
            // convert var to json string
            // return the json
            // .ToList()
            throw new NotImplementedException();
        }

        public BsonDocument ExecuteRetrieveFirst(IQueryable<T> retrieveQuery)
        {
            // .FirstOrDefault()
            throw new NotImplementedException();
        }

        // Perform all the registered queries to MongoDB database
        public void Commit()
        {
            // loop through the Queries
            // for each query, execute the query
            throw new NotImplementedException();
        }
    }
}

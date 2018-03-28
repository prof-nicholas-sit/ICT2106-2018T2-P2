using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.DAL
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        
        // All mapper classes methods will add queries into this list
        private List<IQueryable<T>> Queries;
        private MongoDataSource DataSource;

        public UnitOfWork(string collection)
        {
            // initialise DataSource
        }

        // Retrieve json string based on the retrieve query
        public string ExecuteSelection(IQueryable<T> query)
        {
            // execute query, store result in var
            // convert var to json string
            // return the json
            throw new NotImplementedException();
        }

        // Inserts mongo queries into the unit of work
        public void RegisterQuery(IQueryable<T> query)
        {
            // append query to Queries
            throw new NotImplementedException();
        }

        // Perform all the registered queries to MongoDB database
        public void SaveChanges()
        {
            // loop through the Queries
            // for each query, execute the query
            throw new NotImplementedException();
        }
    }
}

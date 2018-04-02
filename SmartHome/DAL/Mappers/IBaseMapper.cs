using System.Collections.Generic;
using System.Reflection;
using MongoDB.Bson;
using SmartHome.DAL.Transactions;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public interface IBaseMapper<T> where T : MongoDbObject
    {
        /*
         * All methods below will be implemented by the Mapper classes 
         * Mapper interfaces extend this interface
         * All methods insert MongoDB queries into the UnitOfWork.Queries list
         *
         * Create, Update, Delete returns the mapper so you can do method chaining
        */

        /* Returns all data for the <T> collection */
        IEnumerable<T> SelectAll();

        /* Find a document by the MongoDB _id identifier. Maps the document into an appropriate Model  */
        T SelectById(ObjectId id);

        /* Maps the T obj into a Mongo document and insert into MongoDB */
        IBaseMapper<T> Create(T obj);

        /* Map the T obj into a document. Find the Mongodb Document by _id and update the document*/
        IBaseMapper<T> Update(T obj);

        /* Scans the collection for _id and remove the document */
        IBaseMapper<T> Delete(ObjectId id);

        /* Builds the Unit of Work for query chaining */
        IUnitOfWork Save();
    }
}
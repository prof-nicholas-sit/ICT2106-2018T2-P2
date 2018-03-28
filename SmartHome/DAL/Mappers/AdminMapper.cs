using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using SmartHome.DAL.UnitOfWork;
using SmartHome.Models;

namespace SmartHome.DAL
{
    public class AdminMapper : IAdminMapper
    {
        private UnitOfWork<Administrator> Uow;

        public AdminMapper()
        {
            // initialise Uow
        }

        public void Create(Administrator obj)
        {
            // create administrator object query
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public Administrator Delete(ObjectId id)
        {
            // delete administrator object query
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public Administrator Login(string username, string password)
        {
            // collection.Find() any document that has the same username and password given in the parameters
            // If exists retrieve json document file and map into the Administrator Object

            throw new NotImplementedException();
        }

        public void Save()
        {
            // Uow.SaveChanges()
            throw new NotImplementedException();
        }

        public IEnumerable<Administrator> SelectAll()
        {
            // make query for selecting all administrators
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public Administrator SelectById(ObjectId id)
        {
            // make query for selecting all administrator by _id
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public void Update(Administrator obj)
        {
            // update administrator object query
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.DAL.Transactions;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public class AdminMapper : BaseMapper<Administrator>, IAdminMapper
    {
        public AdminMapper() : base("accounts")
        {
        }

        public Administrator Login(string username, string password)
        {
            // collection.Find() any document that has the same username and password given in the parameters
            // If exists retrieve json document file and map into the Administrator Object

            throw new NotImplementedException();
        }
    }
}

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.DAL
{
    interface IMongoDataSource
    {
        MongoCollection GetCollection(string collection);
    }
}

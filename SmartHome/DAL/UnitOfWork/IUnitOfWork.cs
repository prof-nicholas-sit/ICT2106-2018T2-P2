﻿using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace SmartHome.DAL.UnitOfWork
{
    public interface IUnitOfWork<T> where T : class
    {
        void RegisterNew(IQueryable<T> createQuery);
        void RegisterDirty(IQueryable<T> updateQuery);
        void RegisterDeleted(IQueryable<T> deleteQuery);
        List<BsonDocument> ExecuteRetrieveAll(IQueryable<T> retrieveQuery);
        BsonDocument ExecuteRetrieveFirst(IQueryable<T> retrieveQuery);
        void Commit();
    }
}

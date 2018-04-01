using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using SmartHome.DAL.Transactions;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public abstract class BaseMapper<T> : IBaseMapper<T> where T : MongoDbObject
    {
        protected IUnitOfWork Uow { get; }

        public BaseMapper(string collectionName)
        {
            // initialise Uow
            Uow = new UnitOfWork(collectionName);
        }

        public IEnumerable<T> SelectAll()
        {
            IEnumerable<BsonDocument> documentList = Uow.ExecuteRetrieveAll(Builders<BsonDocument>.Filter.Empty);
            List<T> objectList = new List<T>();
            foreach (BsonDocument document in documentList)
            {
                objectList.Add(DeserializeDocument<T>(document));
            }

            return objectList;
        }

        public T SelectById(ObjectId id)
        {
            BsonDocument document = Uow.ExecuteRetrieveFirst(Builders<BsonDocument>.Filter.Eq("_id", id));
            return DeserializeDocument<T>(document);
        }

        public IBaseMapper<T> Create(T obj)
        {
            AddToBsonClassMap(obj);
            obj._id = ObjectId.GenerateNewId();
            // sometimes adding to classmap does not add _t property to the document
            // this ensures that the type discriminator will always be added to the document
            // type discriminator added to allow flexibility with filtering queries
            obj._t = obj.GetType().Name;
            // will also need to define our own type discriminator as we need to retrieve the value of it to do 
            // reflection, it requires namespace and class name, otherwise Type.GetType() may return null.
            obj.ClassType = obj.GetType().FullName;
            Uow.RegisterNew(obj.ToBsonDocument());
            return this;
        }

        public IBaseMapper<T> Update(T obj)
        {
            AddToBsonClassMap(obj);
            Uow.RegisterDirty(Builders<BsonDocument>.Filter.Eq("_id", obj._id), obj.ToBsonDocument());
            return this;
        }

        public IBaseMapper<T> Delete(ObjectId id)
        {
            Uow.RegisterDeleted(Builders<BsonDocument>.Filter.Eq("_id", id));
            return this;
        }

        public void Save()
        {
            Uow.Commit();
        }

        /**
         * TODO comments on reflection
         */
        protected TD DeserializeDocument<TD>(BsonDocument document) where TD : MongoDbObject
        {
            if (document != null)
            {
                string classTypeName = document.GetValue("ClassType").AsString;
                MethodInfo method = typeof(BsonSerializer).GetMethods().Single(m =>
                    m.Name == "Deserialize" && m.ContainsGenericParameters &&
                    m.GetParameters()[0].ParameterType == typeof(BsonDocument));
                method = method.MakeGenericMethod(Type.GetType(classTypeName));
                return (TD) method.Invoke(null, new object[] {document, null});
            }

            return null;
        }

        /**
         * TODO
         * https://stackoverflow.com/a/27858497
         */
        protected void AddToBsonClassMap(MongoDbObject obj)
        {
            Type objType = obj.GetType();
            if (BsonClassMap.IsClassMapRegistered(objType))
            {
                Console.WriteLine("ClassMap registered.");
                return;
            }

            Console.WriteLine("Registering ClassMap...");
            BsonClassMap.LookupClassMap(objType);
        }
    }
}
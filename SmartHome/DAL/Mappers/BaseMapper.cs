﻿using System;
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
    /**
     * Abstract mapper class that accepts a generic type.
     *
     * Collection name in mongoDB must be specified in the constructor.
     *
     * Provides basic CRUD operations, if more customized functions are needed, you should extend this class.
     */
    public abstract class BaseMapper<T> : IBaseMapper<T> where T : MongoDbObject
    {
        protected AbstractUnitOfWork Uow { get; }
        protected string CollectionName { get; }

        public BaseMapper(string collectionName)
        {
            // initialise Uow
            Uow = new UnitOfWork();
            CollectionName = collectionName;
        }

        public IEnumerable<T> SelectAll()
        {
            IEnumerable<BsonDocument> documentList =
                Uow.ExecuteRetrieveAll(CollectionName, Builders<BsonDocument>.Filter.Empty);
            List<T> objectList = new List<T>();
            foreach (BsonDocument document in documentList)
            {
                objectList.Add(DeserializeDocument<T>(document));
            }

            return objectList;
        }

        public T SelectById(ObjectId id)
        {
            BsonDocument document =
                Uow.ExecuteRetrieveFirst(CollectionName, Builders<BsonDocument>.Filter.Eq("_id", id));
            return DeserializeDocument<T>(document);
        }

        public IBaseMapper<T> Create(T obj)
        {
            AddToBsonClassMap(obj);
            obj._id = ObjectId.GenerateNewId();
            // sometimes adding to classmap does not add _t property to the document
            // will also need to define our own type discriminator as we need to retrieve the value of it to do 
            // reflection, it requires namespace and class name, otherwise Type.GetType() may return null.
            // this also allows us to do our own custom filtering by class type.
            obj.ClassType = obj.GetType().FullName;
            Uow.RegisterNew(CollectionName, obj.ToBsonDocument());
            return this;
        }

        public IBaseMapper<T> Update(T obj)
        {
            AddToBsonClassMap(obj);
            Uow.RegisterDirty(CollectionName, Builders<BsonDocument>.Filter.Eq("_id", obj._id), obj.ToBsonDocument());
            return this;
        }

        public IBaseMapper<T> Delete(ObjectId id)
        {
            Uow.RegisterDeleted(CollectionName, Builders<BsonDocument>.Filter.Eq("_id", id));
            return this;
        }

        public AbstractUnitOfWork Save()
        {
            return Uow;
        }

        /**
         * Specifying generic types for function calls need to be provided at compile time.
         *
         * However since we are using a "factory pattern", whereby the ClassType is specified at run-time, require to
         * use reflection in order to input the correct class type to do the Bson deserialization. Deserializer
         * will then be able to deserialize the BsonDocument to the specified class as output.
         */
        protected static TD DeserializeDocument<TD>(BsonDocument document) where TD : MongoDbObject
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
         * Checks if the object has been registered in the classmap for serialization/deserialization purposes.
         * If it is not registered, automatically register the input object's classmap
         * https://stackoverflow.com/a/27858497
         */
        protected static void AddToBsonClassMap(MongoDbObject obj)
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
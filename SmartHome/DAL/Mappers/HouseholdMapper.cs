using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.DAL.Transactions;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public class HouseholdMapper : IHouseholdMapper
    {
        private IUnitOfWork Uow;

        public HouseholdMapper() 
        {
            // initialise Uow
            Uow = new UnitOfWork("accounts");
        }

        public bool CheckRequestingResetPW(string username)
        {
            // make query for checking if isResetPassword flag set for household with username
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public void Create(Household obj)
        {
            // create household object query
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public Household Delete(ObjectId id)
        {
            // delete household object query
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public Household Login()
        {
            // collection.Find() any document that has the same username and password given in the parameters
            // If exists retrieve json document file and map into the Administrator Object

            throw new NotImplementedException();
        }

        public void RequestPasswordReset(string username)
        {
            // update household isResetPassword flag
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public void ResetPassword(string username, string password)
        {
            // update password for household with username
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public void Save()
        {
            // Uow.SaveChanges()
            throw new NotImplementedException();
        }

        public IEnumerable<Household> SelectAll()
        {
            // make query for selecting all household
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public Household SelectByAddress(string street, int postalCode, string unitNo)
        {
            // make query for selecting household by address
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public Household SelectById(ObjectId id)
        {
            // make query for selecting household by _id
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public Household SelectByUsername(string username)
        {
            // make query for selecting household by username
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public void Update(Household obj)
        {
            throw new NotImplementedException();
        }
    }
}

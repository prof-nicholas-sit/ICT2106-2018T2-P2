using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SmartHome.DAL.Transactions;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public class HouseholdMapper : BaseMapper<Household>, IHouseholdMapper
    {
        public HouseholdMapper() : base("accounts")
        {
        }

        public Household Login()
        {
            // collection.Find() any document that has the same username and password given in the parameters
            // If exists retrieve json document file and map into the Administrator Object

            throw new NotImplementedException();
        }

        public Household SelectByAddress(string street, int postalCode, string unitNo)
        {
            // make query for selecting household by address
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
        
        public bool CheckRequestingResetPw(string username)
        {
            // make query for checking if isResetPassword flag set for household with username
            // Uow.ExecuteSelection(query)
            // return result
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
    }
}
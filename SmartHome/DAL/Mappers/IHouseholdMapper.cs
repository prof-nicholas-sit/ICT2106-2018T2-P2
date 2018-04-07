using System;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public interface IHouseholdMapper : IBaseMapper<Household>
    {
        // login as a household account
        Household Login(string username, string password);
        // get household with that specified username
        Household SelectByUsername(string username);
        // get household with the specified address
        Household SelectByAddress(string street, int postalCode, string unitNo);
        // check if the specified household is requesting to reset password
        bool CheckRequestingResetPw(string username);
        // set the request reset password flag to true
        IHouseholdMapper RequestPasswordReset(string username);
        // update a household accounts password to the specified password
        IHouseholdMapper ResetPassword(string username, string password);
    }
}

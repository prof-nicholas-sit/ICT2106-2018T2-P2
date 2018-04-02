using System;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    public interface IHouseholdMapper : IBaseMapper<Household>
    {
        Account Login(string username, string password);
        Household SelectByUsername(string username);
        Household SelectByAddress(string street, int postalCode, string unitNo);
        bool CheckRequestingResetPw(string username);
        IHouseholdMapper RequestPasswordReset(string username);
        IHouseholdMapper ResetPassword(string username, string password);
    }
}

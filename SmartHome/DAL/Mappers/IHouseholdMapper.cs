using System;
using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    interface IHouseholdMapper : IBaseMapper<Household>
    {
        Household Login();
        Household SelectByUsername(string username);
        Household SelectByAddress(string street, int postalCode, string unitNo);
        bool CheckRequestingResetPw(string username);
        void RequestPasswordReset(string username);
        void ResetPassword(string username, string password);
    }
}

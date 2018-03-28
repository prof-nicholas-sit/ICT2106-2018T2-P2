using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.DAL
{
    interface IHouseholdMapper : IBaseMapper<Household>
    {
        Household Login();
        Household SelectByUsername(string username);
        Household SelectByAddress(string street, int postalCode, string unitNo);
        Boolean CheckRequestingResetPW(string username);
        void RequestPasswordReset(string username);
        void ResetPassword(string username, string password);
    }
}

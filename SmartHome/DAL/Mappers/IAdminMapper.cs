using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.DAL
{
    interface IAdminMapper : IBaseMapper<Administrator>
    {
        Administrator Login(string username, string password);
    }
}

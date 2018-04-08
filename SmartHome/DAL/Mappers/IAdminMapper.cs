using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    interface IAdminMapper : IBaseMapper<Administrator>
    {
        // login as administrator
        Administrator Login(string username, string password);
    }
}
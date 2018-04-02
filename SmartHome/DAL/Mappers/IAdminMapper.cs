using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    interface IAdminMapper : IBaseMapper<Administrator>
    {
        Account Login(string username, string password);
    }
}

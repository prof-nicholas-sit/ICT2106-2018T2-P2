using SmartHome.Models;

namespace SmartHome.DAL.Mappers
{
    interface IAdminMapper : IBaseMapper<Administrator>
    {
        Administrator Login(string username, string password);
    }
}

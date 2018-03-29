using System.ComponentModel.DataAnnotations;

namespace SmartHome.Models
{
    public abstract class User:IUser
    {
        public string Username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}

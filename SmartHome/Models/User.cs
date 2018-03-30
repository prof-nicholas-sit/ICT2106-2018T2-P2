using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SmartHome.Models
{
    public class User:IUser
    {
        public User(string Username, string email, string password)
        {
            this.Username = Username;
            this.email = email;
            this.password = password;
        }
        public User()
        {

        }
        public User(string Username,string password)
        {
            this.Username = Username;
            this.password = password;
        }
        [Required]
        public string Username { get; set; }
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}

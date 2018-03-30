using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class AdminModel : User
    {
        public AdminModel(string Username, string password, string email, int adminID) : base(Username, email, password)
        {
            this.adminID = adminID;
            this.isLogin = false;
        }
        public int adminID{get; set;}
        public Boolean isLogin { get; set; }

    }
}

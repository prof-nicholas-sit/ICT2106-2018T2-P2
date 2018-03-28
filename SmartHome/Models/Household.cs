using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Household
    {
        public ObjectId _id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String Street { get; set; }
        public String PostalCode { get; set; }
        public String UnitNo { get; set; }
        public String Surname { get; set; }
        public String ContactNo { get; set; }
        public Boolean IsResetPassword { get; set; }
    }
}

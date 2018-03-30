using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Household : User
    {
        public String Street { get; set; }
        public String PostalCode { get; set; }
        public String UnitNo { get; set; }
        public String Surname { get; set; }
        public String ContactNo { get; set; }
        public Boolean IsResetPassword { get; set; }
    }
}

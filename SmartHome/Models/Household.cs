using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SmartHome.Models
{
    public class Household : Account
    {
        public string Street { get; set; }
        public int PostalCode { get; set; }
        public string UnitNo { get; set; }
        public string Surname { get; set; }
        public string ContactNo { get; set; }
        public bool IsResetPassword { get; set; }
    }
}

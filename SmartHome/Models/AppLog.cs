using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SmartHome.Models
{
    public class AppLog
    {
        public ObjectId _id { get; set; }
        public String content { get; set; }
        public List<Schedule> testList { get; set; }
    }
}

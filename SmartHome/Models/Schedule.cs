using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SmartHome.Models
{
    public class Schedule
    {
        public ObjectId _id { get; set; }
        public string schedule { get; set; }
    }
}

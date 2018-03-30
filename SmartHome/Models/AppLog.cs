using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class AppLog
    {
        public ObjectId _id { get; set; }
        public String Type { get; set; }
        public ObjectId HouseholdId { get; set; }
        public String LogType { get; set; }
        public String Date { get; set; }
        public String Timestamp { get; set; }
        public String DeviceName { get; set; }
        public int Value { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SmartHome.Models
{
    public class Schedule : MongoDbObject
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool ApplyToEveryWeek { get; set; }
        public List<String> DayOfWeek { get; set; }
    }
}

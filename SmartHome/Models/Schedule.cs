using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Schedule
    {
        public ObjectId _id { get; set; }
        public ObjectId DeviceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Boolean ApplyToEveryWeek { get; set; }
        public String[] DayOfWeek { get; set; }     // Unsure
    }
}

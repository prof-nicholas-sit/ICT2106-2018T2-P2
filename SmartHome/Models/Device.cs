using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Device
    {
        public ObjectId _id { get; set; }
        public String Name { get; set; }
        public String Location { get; set; }
        public String Type { get; set; }
        public String State { get; set; }
        public String kWh { get; set; }
        public String Brand { get; set; }
        public String Model { get; set; }
        public Boolean Favourite { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

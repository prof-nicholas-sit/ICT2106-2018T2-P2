using System;
using MongoDB.Bson;

namespace SmartHome.Models
{
    /**
     * Domain Model for DeviceLog
     */
    public abstract class DeviceLog : MongoDbObject
    {
        public ObjectId HouseholdId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public int KWh { get; set; }
        public DateTime DateTime { get; set; }
    }
}
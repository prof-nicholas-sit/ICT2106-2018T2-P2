using System;
using MongoDB.Bson;

namespace SmartHome.Models
{
    /**
     * Domain Model for Device
     */
    public abstract class Device : MongoDbObject
    {
        public ObjectId HouseholdId { get; set; }
        public ObjectId ScheduleId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public int KWh { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool IsFavourite { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
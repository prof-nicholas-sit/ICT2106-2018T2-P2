using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

// namespace SmartHome.Models
// {
    // public class Device
    // {
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // public int DeviceId { get; set; }
        
        // public int HouseholdID { get; set; }
        // [Required]
        // public string DeviceName { get; set; }
        // [Required]
        // public string Brand { get; set; }
        // [Required]
        // public string Model { get; set; }
        // [Required]
        // public string Type { get; set; }
        // [Required]
        // public string Location { get; set; }
        // [Required]
        // public string State { get; set; }
        // [Required]
        // public double UsageKwH { get; set; }
        
        // public int favourite { get; set; }
        
        // public DateTime timestamp { get; set; }

        // //public virtual Device device { get; set; }
    // }
// }

using MongoDB.Bson;

namespace SmartHome.Models
{
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


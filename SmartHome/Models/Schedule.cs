using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// namespace SmartHome.Models
// {
    // public class Schedule
    // {
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // public int ScheduleId { get; set; }

        // [Required]
        // [DataType(DataType.Time)]
        // [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        // public TimeSpan startTime { get; set; }

        // [Required]
        // [DataType(DataType.Time)]
        // [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        // public TimeSpan endTime { get; set; }

        // public bool applyToEveryWeek { get; set; }

        // public string dayOfWeek { get; set; }

        // public int statusWhenOn { get; set; }

        // [ForeignKey("device")]
        // public int deviceId { get; set; }
        
        // public virtual Device device { get; set; }
        


using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SmartHome.Models
{
    public class Schedule : MongoDbObject
    {
        public ObjectId DeviceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool ApplyToEveryWeek { get; set; }
        public List<String> DayOfWeek { get; set; }

    }
}

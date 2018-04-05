using System;
using System.Collections.Generic;
using System.ComponentModel;
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


        //public string dayOfWeek { get; set; }
        
        //public int statusWhenOn { get; set; }

        // public string dayOfWeek { get; set; }

        // public int statusWhenOn { get; set; }


        // [ForeignKey("device")]
        // public int deviceId { get; set; }
        
        // public virtual Device device { get; set; }
        


using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using MongoDB.Bson;

namespace SmartHome.Models
{
    public class Schedule : MongoDbObject
    {
        public ObjectId DeviceId { get; set; }

        public int ScheduleId { get; set; }
         
        //[DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        //public DateTime StartTime { get; set; }

        //[DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
       // public DateTime EndTime { get; set; }

        [XmlIgnore()]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [XmlIgnore()]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

        [XmlElement(ElementName = "StartTime")]
        public string XmlStartTime
        {
            get { return XmlConvert.ToString(StartTime, XmlDateTimeSerializationMode.RoundtripKind); }
            set { StartTime = DateTimeOffset.Parse(value).DateTime; }
        }

        [XmlElement(ElementName = "EndTime")]
        public string XmlEndTime
        {
            get { return XmlConvert.ToString(EndTime, XmlDateTimeSerializationMode.RoundtripKind); }
            set { EndTime = DateTimeOffset.Parse(value).DateTime; }
        }

        public bool ApplyToEveryWeek { get; set; }

        public List<String> DayOfWeek { get; set; }

        public int StatusWhenOn { get; set; }
    }
}

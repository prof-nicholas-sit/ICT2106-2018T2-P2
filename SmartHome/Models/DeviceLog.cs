using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class DeviceLog : MongoDbObject//, IComparable<string>
    {
        public ObjectId HouseholdId { get; set; }

        [Required]
        [Display(Name = "Device Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Device Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Device Type")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Device State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Device Energy Usage")]
        public double KWh { get; set; }

        [Required]
        [Display(Name = "Log Date and Time")]
        public DateTime DateTime { get; set; }

        protected DeviceLog(string householdId, string name,string location,string type,string state,double kWh, DateTime dateStamp) {
            this.HouseholdId = new ObjectId(householdId);
            this.Name = name;
            this.Location = location;
            this.Type = type;
            this.State = state;
            this.KWh = kWh;
            //String date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            //this.dateTime = Convert.ToDateTime(date);
            this.DateTime = dateStamp;
        }

        public DeviceLog(string name, string location, string type, string state, double kWh)
        {
            this.Name = name;
            this.Location = location;
            this.Type = type;
            this.State = state;
            this.KWh = kWh;
            String date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            this.DateTime = Convert.ToDateTime(date);
        }

        //public int CompareTo(string other)
        //{
        //    if (this.HouseholdId.ToString().Equals(other)) return 0;
        //    return 1;
        //}
    }
}

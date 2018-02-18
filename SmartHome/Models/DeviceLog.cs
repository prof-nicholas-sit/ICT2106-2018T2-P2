using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class DeviceLog
    {
       
        
        public int Id { get; set; }
        public int householdId { get; set; }

        [Required]
        [Display(Name = "Device Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Device Location")]
        public string location { get; set; }

        [Required]
        [Display(Name = "Device Type")]
        public string type { get; set; }

        [Required]
        [Display(Name = "Device State")]
        public string state { get; set; }

        [Required]
        [Display(Name = "Device Energy Usage")]
        public double kWh { get; set; }

        [Required]
        [Display(Name = "Log Date and Time")]
        public DateTime dateTime { get; set; }

        public DeviceLog(int Id,string name,string location,string type,string state,double kWh) {
            this.Id = Id;
            this.name = name;
            this.location = location;
            this.type = type;
            this.state = state;
            this.kWh = kWh;
            String date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            this.dateTime = Convert.ToDateTime(date);
        }

        public DeviceLog()
        {
            this.Id = Id;
            this.name = name;
            this.location = location;
            this.type = type;
            this.state = state;
            this.kWh = kWh;
            String date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            this.dateTime = Convert.ToDateTime(date);
        }
    }
}

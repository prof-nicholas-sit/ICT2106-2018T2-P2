using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Device
    {
        //Might auto increment once we have the DATABASE working
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceID { get; set; }
        public int HouseholdID { get; set; }

        [Required]
        [Display(Name = "Device Name")]
        public String DeviceName { get; set; }

        [Required]
        [Display(Name = "Location")]
        public String Location { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public String Brand { get; set; }

        [Required]
        [Display(Name = "Model")]
        public String Model { get; set; }

        [Required]
        public String Type { get; set; }
        public String State { get; set; }
        public double UsageKwH { get; set; }
        //Default Values
        public int favourite { get; }

        //Default Values
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime timestamp { get; }


        //Empty Constructor
        public Device()
        {
                this.DeviceID = DeviceID;
                this.HouseholdID = HouseholdID;
                this.DeviceName = DeviceName;
                this.Brand = Brand;
                this.Model = Model;
                this.Type = Type;
                this.Location = Location;
                this.State = "OFF";
                this.UsageKwH = UsageKwH;
                this.favourite = 0;
                this.timestamp = DateTime.Now;
        }




        /*
        public Device(int DeviceID, int HouseholdID, String DeviceName,
            String Brand, String Model, String Type, String Location,
            String State, double UsageKwH, int favourite, DateTime timestamp)
        {
            this.DeviceID = DeviceID;
            this.HouseholdID = HouseholdID;
            this.DeviceName = DeviceName;
            this.Brand = Brand;
            this.Model = Model;
            this.Type = Type;
            this.Location = Location;
            this.State = State;
            this.UsageKwH = UsageKwH;
            this.favourite = favourite;
            this.timestamp = timestamp;
        }
        */

        /*
        public int getDeviceID()
        {
            return this.DeviceID;
        }

        public int getHouseholdID()
        {
            return this.HouseholdID;
        }

        public String getDeviceName()
        {
            return DeviceName;
        }

        public String getBrand()
        {
            return this.Brand;
        }

        public String getModel()
        {
            return this.Model;
        }

        public String getType()
        {
            return this.Type;
        }

        public String getLocation()
        {
            return this.Location;
        }

        public String getState()
        {
            return this.State;
        }

        public double getUsageKwH()
        {
            return this.UsageKwH;
        }

        public int getFavourite()
        {
            return this.favourite;
        }

        public DateTime getTimestamp()
        {
            return this.timestamp;
        }
        */
    }
}

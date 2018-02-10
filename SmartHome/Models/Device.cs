using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Device
    {
        [Required]
        private int DeviceID;
        private int HouseholdID;
        private String DeviceName;
        private String Brand;
        private String Model;
        private String Type;
        private String Location;
        private String State;
        private double UsageKwH;
        private int favourite;
        private DateTime timestamp;


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
            return this.DeviceName;
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
    }
}

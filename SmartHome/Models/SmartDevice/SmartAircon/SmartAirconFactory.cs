using System;

namespace SmartHome.Models.SmartDevice.SmartAircon
{
    public class SmartAirconFactory : IDeviceFactory
    {

        public int DeviceID { get; set; }
        public int HouseholdID { get; set; }
        public String DeviceName { get; set; }
        public String Location { get; set; }
        public String Brand { get; set; }
        public String Model { get; set; }
        public String Type { get; set; }
        public String State { get; set; }
        public double UsageKwH { get; set; }
        public int favourite { get; set; }
        public DateTime timestamp { get; set; }

        //Additional Attributes
        public int temperature { get; set; }
        public string mode { get; set; }
        public string windspeed { get; set; }
        public string swing { get; set; }

        //Constructor
        public SmartAirconFactory(int DeviceID, int HouseholdID, String DeviceName, String Location,
String Brand,String Model,String Type,String State,double UsageKwH,int favourite,DateTime timestamp,int temperature,
String mode,String windspeed,String swing)
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

            this.temperature = temperature;
            this.mode = mode;
            this.windspeed = windspeed;
            this.swing = swing;
        }

        public void Create()
        {
            throw new NotImplementedException();
        }
    }
}

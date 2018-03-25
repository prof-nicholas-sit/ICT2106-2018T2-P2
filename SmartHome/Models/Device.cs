using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// TO BE DELETED, PLACEHOLDER DEVICE LOGS 
namespace SmartHome.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public double Energy { get; set; }
        public string Type { get; set; }

        public Device ()
        {

        }

        public Device(int id, string location, double energy, string type)
        {
            Id = id;
            Location = location;
            Energy = energy;
            Type = type;
        }
    }
}

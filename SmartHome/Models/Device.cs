using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Device
    {
        int Id;
        string Location;
        double Energy;
        string Type;

        public Device(int id, string location, double energy, string type)
        {
            Id = id;
            Location = location;
            Energy = energy;
            Type = type;
        }
    }
}

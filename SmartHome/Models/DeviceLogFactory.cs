using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class DeviceLogFactory
    {
        private Session _session;

        public DeviceLogFactory()
        {

        }

        public DeviceLog CreateClass(string[] data)
      
        {
            DeviceLog newDevice = null;

            _session = Session.getInstance;
            Household householduser = (Household)_session.GetUser();
            
            switch (data[2].ToLower())
            {

                case "aircon":
                    // Temporary hardcode, future improvement can check for a header in the excel file.
                    newDevice = new AirconDeviceLog(householduser.houseHoldId, data[0], data[1], data[2], data[3], Convert.ToDouble(data[4]), DateTime.Parse(data[5]),
                        Convert.ToInt32(data[6]), data[7], data[8], data[9]);
                    //return newDevice;
                    //System.Diagnostics.Debug.WriteLine("AIRCON:\n" + newAC);
                    break;
                case "fan":
                    newDevice = new FanDeviceLog(householduser.houseHoldId, data[0], data[1], data[2], data[3], Convert.ToDouble(data[4]), DateTime.Parse(data[5]),
                        Convert.ToInt32(data[6]));
                    //return newDevice;
                    //System.Diagnostics.Debug.WriteLine("FAN:\n" + newFan);
                    break;
                case "light":
                    newDevice = new LightDeviceLog(householduser.houseHoldId, data[0], data[1], data[2], data[3], Convert.ToDouble(data[4]), DateTime.Parse(data[5]),
                        Convert.ToInt32(data[6]), Convert.ToInt32(data[7]));
                    //return newDevice;
                    //System.Diagnostics.Debug.WriteLine("LIGHT:\n" + newLight);
                    break;
                default:
                    break;
            }
            return newDevice;
        } 

    }
}

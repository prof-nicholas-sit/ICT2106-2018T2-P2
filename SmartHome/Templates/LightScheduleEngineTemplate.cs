using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Templates
{
    public class LightScheduleEngineTemplate : AbstractScheduleEngine
    {
        Dictionary<TimeSpan, int> sensorBrightness = new Dictionary<TimeSpan, int>() {
            {new TimeSpan(00, 00, 00), 50},
            {new TimeSpan(01, 00, 00), 50},
            {new TimeSpan(02, 00, 00), 50},
            {new TimeSpan(03, 00, 00), 50},
            {new TimeSpan(04, 00, 00), 50},
            {new TimeSpan(05, 00, 00), 50},
            {new TimeSpan(06, 00, 00), 40},
            {new TimeSpan(07, 00, 00), 30},
            {new TimeSpan(08, 00, 00), 10},
            {new TimeSpan(09, 00, 00), 10},
            {new TimeSpan(10, 00, 00), 10},
            {new TimeSpan(11, 00, 00), 10},
            {new TimeSpan(12, 00, 00), 10},
            {new TimeSpan(13, 00, 00), 20},
            {new TimeSpan(14, 00, 00), 20},
            {new TimeSpan(15, 00, 00), 30},
            {new TimeSpan(16, 00, 00), 30},
            {new TimeSpan(17, 00, 00), 40},
            {new TimeSpan(18, 00, 00), 50},
            {new TimeSpan(19, 00, 00), 50},
            {new TimeSpan(20, 00, 00), 50},
            {new TimeSpan(21, 00, 00), 50},
            {new TimeSpan(22, 00, 00), 50},
            {new TimeSpan(23, 00, 00), 50}
        };

        public override int sensorRecommendedValue(TimeSpan timeOfDay)
        {
            int desiredBrightness = 0;

            foreach (KeyValuePair<TimeSpan, int> timeTemp in sensorBrightness)
            {
                if (timeTemp.Key.Equals(timeOfDay))
                {
                    desiredBrightness = timeTemp.Value;
                }
            }

            return desiredBrightness;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Templates
{
    public class FanScheduleEngineTemplate : AbstractScheduleEngine
    {
        Dictionary<TimeSpan, int> sensorSpeed = new Dictionary<TimeSpan, int>() {
            {new TimeSpan(00, 00, 00), 1},
            {new TimeSpan(01, 00, 00), 1},
            {new TimeSpan(02, 00, 00), 1},
            {new TimeSpan(03, 00, 00), 2},
            {new TimeSpan(04, 00, 00), 3},
            {new TimeSpan(05, 00, 00), 1},
            {new TimeSpan(06, 00, 00), 1},
            {new TimeSpan(07, 00, 00), 1},
            {new TimeSpan(08, 00, 00), 1},
            {new TimeSpan(09, 00, 00), 1},
            {new TimeSpan(10, 00, 00), 3},
            {new TimeSpan(11, 00, 00), 2},
            {new TimeSpan(12, 00, 00), 3},
            {new TimeSpan(13, 00, 00), 3},
            {new TimeSpan(14, 00, 00), 3},
            {new TimeSpan(15, 00, 00), 3},
            {new TimeSpan(16, 00, 00), 3},
            {new TimeSpan(17, 00, 00), 1},
            {new TimeSpan(18, 00, 00), 1},
            {new TimeSpan(19, 00, 00), 1},
            {new TimeSpan(20, 00, 00), 1},
            {new TimeSpan(21, 00, 00), 1},
            {new TimeSpan(22, 00, 00), 2},
            {new TimeSpan(23, 00, 00), 2}
        };

        public override int sensorRecommendedValue(TimeSpan timeOfDay)
        {
            int desiredSpeed = 0;

            foreach (KeyValuePair<TimeSpan, int> timeTemp in sensorSpeed)
            {
                if (timeTemp.Key.Equals(timeOfDay))
                {
                    desiredSpeed = timeTemp.Value;
                }
            }

            return desiredSpeed;
        }
    }
}

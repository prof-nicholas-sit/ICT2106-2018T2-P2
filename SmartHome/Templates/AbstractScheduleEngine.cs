using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Templates
{
    public abstract class AbstractScheduleEngine
    {
        public abstract int sensorRecommendedValue(TimeSpan timeOfDay);
    }
}

using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.DAL
{
    public class ScheduleGateway : DataGateway<Schedule>
    {
        private SmartHomeDbContext db;

        public ScheduleGateway(SmartHomeDbContext context) : base(context)
        {
            
        }
    }
}

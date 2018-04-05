using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome
{
    public interface IAppLogCreator
    {
        string GetCurrentType();
        void setHouseholdId(ObjectId inputId);
        void AddLog(Controller controller, string logType, DateTime timeStamp, string extras = null);
        void PushLogs();
    }
}

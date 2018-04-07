using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.AppLogging
{
    public interface IAppLogCreator
    {
        string GetCurrentType();
        void SetHouseholdId(ObjectId inputId);
        bool AddLog(Controller controller, string logType, DateTime timeStamp, string deviceType = null, string extras = null);
        void PushLogs();
    }
}

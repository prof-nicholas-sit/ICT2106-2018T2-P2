using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartHome.Models;
using MongoDB.Bson;
using SmartHome.DAL.Mappers;

namespace SmartHome.AppLogging
{
    public class AppLogCreator : IAppLogCreator
    {
        private List<AppLog> Buffer;
        public const string DELIMITER = "*/-";
        private const int MAX = 15;
        private ObjectId householdId;

        public AppLogCreator()
        {
            Buffer = new List<AppLog>();
        }

        public string GetCurrentType()
        {
            return this.GetType().ToString();
        }

        public void SetHouseholdId(ObjectId inputId) {
            householdId = inputId;
        }

        public bool AddLog(Controller controller, string logType, DateTime timeStamp, string deviceType = null, string extras = null )
        {
            AppLog temp = new AppLog(controller.GetType().ToString() + DELIMITER + logType, timeStamp, householdId, deviceType, extras); //PARSE IN HOUSEHOLD ID.
            Buffer.Add(temp);
            if (Buffer.Count == MAX) { //When Nth log is added
                PushLogs();
                return true;
            } else {
                return false;
            }
        }

        public void PushLogs()  //To be called when buffer hits max and upon logout.
        {
            Console.WriteLine("Logs pushed to db");
            var DL = new AppLogMapper().InsertMany(Buffer).Save();
            DL.Commit();
            Buffer.Clear(); //Clear buffer
        }
    }
}

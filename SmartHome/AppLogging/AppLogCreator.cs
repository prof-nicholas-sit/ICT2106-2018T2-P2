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
            Console.WriteLine("New DataLogger created!");
        }

        public string GetCurrentType()
        {
            return this.GetType().ToString();
        }
        public void SetHouseholdId(ObjectId inputId) {
            householdId = inputId;
        }

        public void AddLog(Controller controller, string logType, DateTime timeStamp, string extras = null)
        {
            AppLog temp = new AppLog(controller.GetType().ToString() + DELIMITER + logType, timeStamp, householdId); //PARSE IN HOUSEHOLD ID.
            Buffer.Add(temp);
            if (Buffer.Count == MAX) { //When Nth log is added
                PushLogs();
            }
            Console.WriteLine("Current buffer: ");
            Buffer.ForEach(Console.WriteLine);
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

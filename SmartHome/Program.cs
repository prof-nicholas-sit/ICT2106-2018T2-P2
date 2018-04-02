using System;
using System.Globalization;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using MongoDB.Bson;
using SmartHome.DAL.Mappers;
using SmartHome.Models;

namespace SmartHome
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Program");
            Console.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture));

//            var a = new DeviceMapper().Create(new FanDevice()).Save();
//            a += new DeviceLogMapper().Create(new FanDeviceLog()).Save();
//            a.Commit();
//            new ScheduleMapper().Create(new Schedule()).Save().Commit();
//            new HouseholdMapper().RequestPasswordReset("test").Save().Commit();
//            new DeviceMapper().Delete(new ObjectId("5ac2092cd59b4b1327023167")).Save().Commit();
            
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
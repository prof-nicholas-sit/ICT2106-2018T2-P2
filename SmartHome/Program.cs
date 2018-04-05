using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmartHome.DAL;

using MongoDB.Bson;
using MongoDB.Driver.Builders;
using SmartHome.DAL.Mappers;
using SmartHome.Models;

namespace SmartHome
{
    public class Program
    {
        LinkedList<object> list = new LinkedList<object>();
        private static IScheduleMapper _ScheduleMapper = new ScheduleMapper();
        private static IDeviceMapper _DeviceMapper = new DeviceMapper();

        public static void Main(string[] args)
        {

            //BuildWebHost(args).Run();

            // var host = BuildWebHost(args);

            // using (var scope = host.Services.CreateScope())
            // {
                // var services = scope.ServiceProvider;
                // try
                // {
                    // var context = services.GetRequiredService<SmartHomeDbContext>();
                    // DbInitializer.Initialize(context);
                // }
                // catch (Exception ex)
                // {
                    // var logger = services.GetRequiredService<ILogger<Program>>();
                    // logger.LogError(ex, "An error occured while seeding the databse.");
                // }
            // }

            // host.Run();


            Console.WriteLine("Starting Program");
            Console.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture));

            //Household household = new Household();
            //FanDevice sampleDevice = new FanDevice();
            //Schedule schedule = new Schedule();

            //ObjectId houseId = new ObjectId("5ac26535276cca1f46f54bc3");
            //ObjectId scheduleId = new ObjectId("5ac5abcf630e212034b3a32c");

            

           

            //sampleDevice.HouseholdId = houseId;
            //sampleDevice.Name = "Living Room Fan";
            //sampleDevice.Location = "Living Room";
            //sampleDevice.Type = "Fan";
            //sampleDevice.State = "Off";
            //sampleDevice.KWh = 20;
            //sampleDevice.Brand = "Akira";
            //sampleDevice.Model = "ST-88F";
            //sampleDevice.IsFavourite = true;
            //sampleDevice.TimeStamp = new DateTime(2009, 01, 01, 06, 36, 00);
            //sampleDevice.FanSpeed = 3;

            //_DeviceMapper.Create(sampleDevice).Save().Commit();


            //Console.WriteLine(_DeviceMapper.SelectAll() + "\n");

            //_ScheduleMapper.Create(lol).Save().Commit(); //create object
            //Console.WriteLine(_HouseholdMapper.SelectById(id).Email + "\n");//select obj by attribute


            BuildWebHost(args).Run();

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
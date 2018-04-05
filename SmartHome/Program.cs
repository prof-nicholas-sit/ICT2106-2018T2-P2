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

        private static IHouseholdMapper _HouseholdMapper = new HouseholdMapper();
        private static IDeviceMapper _DeviceMapper = new DeviceMapper();
        private static IScheduleMapper _ScheduleMapper = new ScheduleMapper();

        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Program");
            Console.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture));

            Household household = new Household();
            FanDevice deviceFan = new FanDevice();
            Schedule schedule = new Schedule();

            ObjectId houseId = new ObjectId("5ac26535276cca1f46f54bc3");
            ObjectId scheduleId = new ObjectId("5ac5abcf630e212034b3a32c");
            ObjectId deviceId = new ObjectId("5ac609b14589ec02bcff878c"); 
            //deviceFan.HouseholdId = houseId;
            //deviceFan.ScheduleId = scheduleId;
            //deviceFan.Name = "asda";
            //deviceFan.Location = "asda";
            //deviceFan.Type = "asda";
            //deviceFan.State = "asda";
            //deviceFan.KWh = 1000;
            //deviceFan.Brand = "asda";
            //deviceFan.Model = "asda";
            //deviceFan.IsFavourite = true;
            //deviceFan.TimeStamp = new DateTime(2009, 01, 01, 06, 36, 00);

            //_DeviceMapper.Create(deviceFan).Save().Commit();
            
            Console.WriteLine(_DeviceMapper.SelectById(deviceId).TimeStamp.ToLocalTime() + "\n");

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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using MongoDB.Bson;
using SmartHome.DAL.Mappers;
using SmartHome.Models;

namespace SmartHome
{
    public class Program
    {
        LinkedList<object> list = new LinkedList<object>();
        private static IScheduleMapper _ScheduleMapper = new ScheduleMapper();

        public static void Main(string[] args)
        {

        Console.WriteLine("Starting Program");
            //Console.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture));
            List<String> list1 = new List<string>();

            list1.Add("1");
            list1.Add("2");

            Schedule lol = new Schedule();
            lol.StartTime = new DateTime();
            lol.EndTime = new DateTime();
            lol.ApplyToEveryWeek = true;
            lol.DayOfWeek = list1;
            _ScheduleMapper.Create(lol).Save().Commit();
            
            
            Console.WriteLine(_ScheduleMapper.SelectAll() + "\n");

            //Console.WriteLine(_ScheduleMapper.SelectById("sdfsdf"));

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
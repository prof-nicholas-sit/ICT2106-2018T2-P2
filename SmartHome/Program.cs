using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
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

            new AdminMapper().Create(new Administrator() {Username = "test1", Password = "123"}).Save();
            Console.WriteLine(new AdminMapper().Login("test1", "123") == null);

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartHome.Models.SmartDevice;

namespace SmartHome
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
            /*
            DeviceFactory myStuffs = new DeviceFactory();
            SmartDevice sd = myStuffs.getDevice("Aircon");
            Console.WriteLine(sd);
            */
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

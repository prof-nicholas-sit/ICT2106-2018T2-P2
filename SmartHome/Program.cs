using System;
using System.Globalization;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SmartHome
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Program");
            Console.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture));

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CreatingASPdotnetCoreWebApp
{
    public class Program
    {
        //ASP core application starts with console application where main method is called
        public static void Main(string[] args)
        {
            //build method will build the webhost, this web host will host this application
            //run method runs the application and wait for the response from user
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            //createdefaultbuilder: create webhost with some preconfiguration
            //1. setting up the webserver
            //2. loading configuration from various configuration sources
            //3. configure the logging
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //usestartup: extension method
                    webBuilder.UseStartup<Startup>();
                });
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MiddlewareDemo
{
    //middleware in asp.net: software: which handle the http request or response, authenticate the user, handling the errors, serve static files in a pipe line
    //it has access to the incomming request and out going response
    //each middle ware decides of passing the out response by calling the next middle ware or not calling the next middle ware(this is called short circuit) or just passing the response without processing it
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        /*
         * CreateDefaultBuilder: it will set the kasteral server and logging confiuration
         * */
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MiddlewareDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime in the order they are defined. Use this method to configure the HTTP request pipeline by dependency injuction(parameters in the method    ).
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            //1st middle ware: take care of the exception of the page if the environemnt is development
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //to register the another middle ware we use "use method", to call 2nd middle ware we use: next() delegate
            app.Use(async (context, next) => { await context.Response.WriteAsync("3rd middle ware\n"); await next(); });

            //for logging the information, we use Ilogger: 4th middle ware
            app.Use(async (context, next) => { logger.LogInformation("4th middle ware\n"); await next(); }); //msg will be displayed in the console

            //2st middle ware: write a msg(a plane text) to the response object. this middle ware will handle all the request
            //run method accepts request deligate: async (context) => { await context.Response.WriteAsync("hello world"); } it is an request deligate
            //request deligate: it takes http context obj as a parameter
            //run detemines the termination of the middle ware, no further middleware will be executed
            app.Run(async (context) => { await context.Response.WriteAsync("hello world"); });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConfiguringEnvironmetVariables
{
    /*
     * In development environment: 
     * 1. development: developer can know the reason of exception
     * 2. staging: identify deployment related issues(interfacing to other services).
     * 3. production: uesr friendly display of the exception, to prevent from hacker
     * */
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //to access environment variable value IWebHostEnvironment is used

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async context =>
                {
                    await context.Response.WriteAsync("hosting env: " + env.EnvironmentName);
                });
        }
    }
}

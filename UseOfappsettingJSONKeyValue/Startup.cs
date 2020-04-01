using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UseOfappsettingJSONKeyValue
{
    public class Startup
    {
        private IConfiguration _configuration;

        //IConfiguration: capable of reading all the configuration from various congiguration sources
        /*
         * order of configuration setting:
         * appsetting.json: when published
         * appsetting.development.json: for developer environment
         * launchsetting.json: for local machine hosting
         * uesr secrets
         * environment variables
         * command line: dotnet run key="value"
         * */
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(_configuration["key"]);
                });
            });
        }
    }
}

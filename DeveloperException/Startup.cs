using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DeveloperException
{
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
            //this developerexceptionpage middle ware detects the middle ware registered, which throws the exception and server it. 
            //it should be decalred at start of middle ware so that it can detect the exception thrown by other middle ware
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();

                //for customise the exception use developerexceptionPageOptions
                DeveloperExceptionPageOptions developerExceptionPageOptionsObj = new DeveloperExceptionPageOptions() { SourceCodeLineCount = 1 };
                app.UseDeveloperExceptionPage(developerExceptionPageOptionsObj);
            }
             
            app.UseFileServer();

            /*
             * exception will not be thrown as the usefileserver serve the request
             * exception is thrown when the request done by the client is not served ex: if user enters localhost/abc.html which is not preset in directoy
             * */
            app.Run(async context => {
                throw new Exception("thrown exception as static file was not served by the usestaticfile"); 
            });
        }
    }
}

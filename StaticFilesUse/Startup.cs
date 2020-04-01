using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace StaticFilesUse
{
    //all static files to be present in the wwwroot folder called as contentrootfolder
    //to serve static file, add usestaticfile middle ware 
    //to set the default file on the response, file name need to be default.html or index.html and then register it using usedefaultfile or else if u have any other file home.html then create the obj of defaultFileOptions and pass it to usedefaultfile
    //the 
    public class Startup
    {
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

            //define before usestaticfiles: beacause it won't serve the requeset, it just change the request path and is passed to usestaticfile which serve the requeset
            //when file name to be default is default.html
            //app.UseDefaultFiles();

            //if file name to be default is home.html
            //DefaultFilesOptions obj = new DefaultFilesOptions();
            //obj.DefaultFileNames.Clear();
            //obj.DefaultFileNames.Add("htmlpage.html");
            //app.UseDefaultFiles(obj);

            //app.UseStaticFiles();

            //usefileserver middle ware: it combines the defaultfile and static files
            //app.UseFileServer();

            //after launch refresh once
            FileServerOptions fileServerOptionsObj = new FileServerOptions();
            fileServerOptionsObj.DefaultFilesOptions.DefaultFileNames.Clear();
            fileServerOptionsObj.DefaultFilesOptions.DefaultFileNames.Add("htmlpage.html");
            app.UseFileServer(fileServerOptionsObj);

            app.Run(async context => { await context.Response.WriteAsync("Hello World!"); });
        }
    }
}

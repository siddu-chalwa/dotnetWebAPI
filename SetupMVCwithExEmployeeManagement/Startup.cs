using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SetupMVCwithExEmployeeManagement.Models;

namespace SetupMVCwithExEmployeeManagement
{
    //to add the controller, add dependence injuction to configureServices, and mvc middleware to the requesting pipeline
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //AddMvc method adds all the required MVC services, internally it calls AddMvcCore()
            //services.AddMvc(options => options.EnableEndpointRouting = false);
            //AddMvcCore: only adds the core MVC services

            //if u want xml format on home/index/1 or home/details/1
            services.AddMvc(options => options.EnableEndpointRouting = false).AddXmlSerializerFormatters();
            services.AddSingleton<EmployeeRepository, MockEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //if the request is for static file then it is served by usestaticfile
            //if the request is for mvc then usestaticfiles will pass the request to the next middle ware.
            app.UseStaticFiles();
            //it will take care the request for mvc
            //default templete: {controller=Home}/{action=Index}/{id?}
            app.UseMvcWithDefaultRoute();

            app.Run(async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
        }
    }
}

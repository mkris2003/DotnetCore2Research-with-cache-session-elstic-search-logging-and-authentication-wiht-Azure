using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCore2Research.BL;
using DotnetCore2Research.Classes;
using DotnetCore2Research.DL;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using StructureMap;
using static DotnetCore2Research.BL.ExceptionMiddlewareExtensions;
namespace DotnetCore2Research
{
    public class Startup
    {
        public IConfigurationRoot Configuration
        {
            get;
            set;
        }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            Log.Logger = new LoggerConfiguration()
                                .ReadFrom.Configuration(Configuration)
                                .CreateLogger();
        }

       

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);               
            services.AddDBProvider(Configuration);
            // services.AddSingleton<IEmployee, EmployeeProcess>();// Make sure Interface and class names are equal except I
            services.AddLogging();
           // services.AddTockenBaseAuthentication();// jwttocken
            services.AddCaching(Configuration);
            services.AddSession(Configuration);
            return services.ConfigureStructureMap();

        }

       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            //Logging
            loggerFactory.AddSerilog();
            //global exception logging 
            // app.ConfigureExceptionHandler(loggerFactory);        
            app.ConfigureCustomExceptionMiddleware();
            // app.ConfigureAuthenticationMiddleware(); // custom token
            //app.UseAuthentication();// this is jwt example
            app.ConfigureAuthenticationTockenMiddleware();
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseMvc();
           
        }
    }
}

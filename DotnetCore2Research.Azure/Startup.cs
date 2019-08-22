using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCore2Research.Azure.BL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.AzureAppServices;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using Serilog.Exceptions;
namespace DotnetCore2Research.Azure
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

            //this is for database and flat files 
            //Log.Logger = new LoggerConfiguration()
            //                    .ReadFrom.Configuration(Configuration)
            //                    .CreateLogger();

            //Elastic search 

            var elasticUri = Configuration["ElasticConfiguration:Uri"];
            var userName= Configuration["ElasticConfiguration:UserName"];
            var password= Configuration["ElasticConfiguration:Password"];
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .WriteTo.Elasticsearch(new  ElasticsearchSinkOptions(new Uri(elasticUri))
                {
                    ModifyConnectionSettings = x => x.BasicAuthentication(userName, password),
                    //AutoRegisterTemplate = true,// this willenable wehn local account
                })
            .CreateLogger();

        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDBProvider(Configuration);            
            services.AddLogging();
           // services.AddCaching(Configuration);
           // services.AddSession(Configuration);

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
//            loggerFactory.AddAzureWebAppDiagnostics(
//  new AzureAppServicesDiagnosticsSettings
//  {
//      OutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss zzz} [{Level}] {RequestId}-{SourceContext}: {Message}{NewLine}{Exception}"
//  }
//);
            app.ConfigureCustomExceptionMiddleware();
            app.ConfigurRequestResponseMiddleware();
           // app.UseHttpsRedirection();
           // app.UseSession();
            app.UseMvc();

        }
    }
}

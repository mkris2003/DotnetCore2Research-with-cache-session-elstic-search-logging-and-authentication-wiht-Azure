
using Couchbase.Configuration.Client;
using Couchbase.Extensions.Caching;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.Extensions.Session;
using DotnetCore2Research.Azure;
using DotnetCore2Research.Azure.BL;
using DotnetCore2Research.Azure.BL.MiddleWare;
using DotnetCore2Research.Azure.DL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCore2Research.Azure.BL
{
    public static class ServiceCollectionExtesions
    {
       private const string SolutionName = "DotnetCore2Research.Azure", CouchBaseClientKeyName = "couchbase";
       
        public static IServiceProvider ConfigureStructureMap(this IServiceCollection services)
        {
            var container = new Container();
            container.Configure(config =>
            {
                // Register stuff in container, using the StructureMap APIs...
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Startup));
                    _.Assembly(SolutionName);     // Project solution name           
                    _.WithDefaultConventions();
                    _.LookForRegistries();
                });

                //Populate the container using the service collection
                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }
        public static void AddDBProvider(this IServiceCollection services, IConfigurationRoot Configuration)
        {
            services.AddSingleton<IDbConnectionFactory>(new SqlConnectionFactory(Configuration));
        }
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static void ConfigurRequestResponseMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
        }

        public static void AddCaching(this IServiceCollection services, IConfigurationRoot Configuration)
        {
            var definition = GetCouchbaseClientDefinition(Configuration);
            services.AddCouchbase(opt =>
            {
                opt.Username = definition.Username;
                opt.Password = definition.Password;
                opt.Servers = definition.Servers;
            });
            services.AddDistributedCouchbaseCache(definition?.Buckets[0]?.Name, string.Empty, opt => { });



        }

        public static void AddSession(this IServiceCollection services, IConfigurationRoot Configuration)
        {
            var definition = GetCouchbaseClientDefinition(Configuration);
            services.AddCouchbase(opt =>
            {
                opt.Username = definition.Username;
                opt.Password = definition.Password;
                opt.Servers = definition.Servers;
            });
            services.AddDistributedCouchbaseCache(definition?.Buckets[0]?.Name, string.Empty, opt => { });

            services.AddCouchbaseSession(opt =>
            {
               
               // opt.CookieName = "DotnetCore2Research.Cookie";
                opt.IdleTimeout = new TimeSpan(0, 0, 0, 20);// Session expiration
            });

        }

        public static CouchbaseClientDefinition GetCouchbaseClientDefinition(IConfigurationRoot Configuration)
        {
            var couchbaseClientDefinition = new CouchbaseClientDefinition();
            Configuration.GetSection(CouchBaseClientKeyName).Bind(couchbaseClientDefinition);
            return couchbaseClientDefinition;

        }

    }
}

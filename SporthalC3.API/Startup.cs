using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SporthalC3.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {



                routes.MapRoute(
                    name: null,
                    template: "Filter/Sportname{sportname}",
                    defaults: new { controller = "Filter", action = "FilterView" });

                routes.MapRoute(
                    name: null,
                    template: "Filter/{sportname}/{Length}/{Width}/{Canteen}/{NumberOfShowers}/{NumberOfDressingSpace}",
                    defaults: new { controller = "Filter", action = "FilterView" });

                routes.MapRoute(
                     name: null,
                    template: "Filter/Sportname{sportname}",
                    defaults: new { controller = "Filter", action = "FilterView" });
            });
        }
    }
}

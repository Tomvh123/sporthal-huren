using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SporthalC3;
using SporthalC3.Domain;


namespace SporthalC3.Infrastructure
{
    public class Startup
    {
        IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();

        }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                Configuration["Data:SportsBuildingAdministrator:ConnectionString"]));


            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(Configuration["Data:SportHallIdentity:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddTransient<ISportHalRepository, EFSportHal>();

            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseSession();
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
            

            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
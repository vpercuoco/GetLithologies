using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetLithologies.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GetLithologies
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IDataRepository, DataRepository>();
            services.AddLogging();

            var builder = services.AddControllersWithViews().AddRazorRuntimeCompilation();

            string connection = "Server=(localdb)\\ProjectsV13;Database=LithologyDatabase;Trusted_Connection=True;";
            //For Entity Framework Core
            services.AddDbContext<LithologyDatabaseContext>(opts =>
            {
                opts.UseSqlServer(connection);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //From OdeToCode.UseNodelModules library, serves up files from node_modules as if they existed in wwwroot
            app.UseNodeModules();
            

            app.UseRouting();

            app.UseAuthorization();

            logger.LogInformation("Mapping endpoints");


            /*
            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapControllers();
            });
            */

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=LithologyTables}/{action=GetLithologyTable}/{id?}");

                // Controllers with Actions
                // To handle routes like `/api/VTRouting/route`, I added this custom
                endpoints.MapControllerRoute(
                    name: "ControllerAndAction",
                    pattern: "api/{controller}/{action}");

                // Controllers with Actions and Parameters. I added this while writing the api 8-7-2020
                // To handle routes like `/api/VTRouting/route`, I added this custom
                endpoints.MapControllerRoute(
                    name: "ControllerAndActionAndID",
                    pattern: "api/{controller}/{action}/{id?}");


            });
            logger.LogInformation("Finished mapping endpoints");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using AspNet5Angular2Demo.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspNet5Angular2Demo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //kommunikációhoz 
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            });

            //sql server új EF-hez
            services.AddEntityFramework().AddSqlServer().AddDbContext<AppDbContext>();

            //Identity system beállítása
            services.AddIdentity<IdentityUser, IdentityRole>(
                config =>
                {
                    //login url beállítása
                    config.Cookies.ApplicationCookie.LoginPath = new Microsoft.AspNet.Http.PathString("/Auth/Login"); //alap ".." megadásával nem ment.. érdekes
                }
                ).
                AddEntityFrameworkStores<AppDbContext>();//adatbázishoz csapás

            services.AddTransient<Seeder>(); //??
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Seeder seeder)
        {
            // Add the platform handler to the request pipeline.
            app.UseIISPlatformHandler();
            
            app.UseDefaultFiles();
            app.UseStaticFiles();

            //Identity
            app.UseIdentity();
            //alapértelmezett route minta beállítása
            app.UseMvc(
                config=>
                {
                    config.MapRoute(
                        name:"Default",
                        template: "{Controller}/{action}/{id?}"
                        );
                });

            //adatbázisba belenyúlás "aszinkron"
            seeder.EnsureSeedData().Wait();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

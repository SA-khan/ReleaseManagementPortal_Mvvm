using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ServerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace ServerApp
{
    public class Startup
    {
        //public Startup(IWebHostEnvironment env)
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(env.ContentRootPath)
        //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        //        .AddEnvironmentVariables()
        //        .AddCommandLine(System.Environment.GetCommandLineArgs()
        //        .Skip(1).ToArray());
        //    Configuration = builder.Build();

        //}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<DataContext>(options => {
                options.UseSqlServer(connectionString);
            });
            services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true).AddNewtonsoftJson(); ;

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Release Management API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services) //,IAntiforgery antiforgery, IHostApplicationLifetime lifetime
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions { 
            //    RequestPath = "",
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(), "./wwwroot/app"))
            //});



            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "angular_fallback",
                    pattern: "{target:regex(companies|companydetail|products|productdetail|environments|environmentdetail|releases|releasedetail|reference|referencedetail|store)}",
                    defaults: new { Controller = "Home", Action = "Index" }
                    );

            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            SeedData.SeedDatabase(services.GetRequiredService<DataContext>());

            //if ((Configuration["INITDB"] ?? "false") == "true")
            //{
            //    System.Console.WriteLine("Preparing Database..");
            //    SeedData.SeedDatabase(services.GetRequiredService<DataContext>());
            //    System.Console.WriteLine("Database Preparation Complete");
            //    lifetime.StopApplication();
            //}

            app.UseSpa(spa =>
            {
                string strategy = Configuration["DevTools:ConnectionStrategy"];
                if (strategy == "proxy")
                {
                    spa.UseProxyToSpaDevelopmentServer("http://127.0.0.1:4200");
                }
                else if (strategy == "managed")
                {
                    spa.Options.SourcePath = "../ClientApp";
                    spa.UseAngularCliServer("start");
                }
            });

        }
    }
}

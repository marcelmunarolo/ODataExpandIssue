using System;
using System.Collections.Generic;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ODataExpandIssue.Data;
using ODataExpandIssue.Model;

namespace ODataExpandIssue
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("ECommerce"),
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), new List<int>());
                        sqlOptions.MigrationsAssembly("ODataExpandIssue");
                        sqlOptions.MigrationsHistoryTable("__MigrationsHistory", "Migrations");
                    }));

            services.AddOData();
            services.AddControllers(options => { options.EnableEndpointRouting = false; });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
                DataGenerator.Initialize(context);
            }

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseMvc(appBuilder =>
            {
                appBuilder.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
                var modelBuilder = new ODataConventionModelBuilder();
                modelBuilder.EntitySet<Order>("OrderQuery");
                var edmModel = modelBuilder.GetEdmModel();
                appBuilder.MapODataServiceRoute("odata", "odata", edmModel);
            });
        }
    }
}
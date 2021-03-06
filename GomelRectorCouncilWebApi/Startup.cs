﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using GomelRectorCouncilWebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GomelRectorCouncilWebApi
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

            //Sqlite
            services.AddDbContext<CouncilDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("CouncilConnectionSqlite")));
            //SQL Server
            //services.AddDbContext<CouncilDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("CouncilConnectionSQL")));
            //MySQL
            //services.AddDbContext<CouncilDbContext>(options =>
            //    options.UseMySQL(Configuration.GetConnectionString("CouncilConnectionMysql")));

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CouncilDbContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();
            // инициализация базы данных по университетам
            DbInitializer.Initialize(context);
        }
    }
}

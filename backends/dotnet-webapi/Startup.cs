using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebAPI.PredatorBG.HubConfig;
using WebAPI.PredatorBG.Models;
using WebAPI.PredatorBG.Services;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            DbType dbType = Configuration.GetValue<DbType>("DbType");

            switch (dbType)
            {
                case DbType.SqlServer:
                    services.AddDbContext<PredatorBGDbContext>(options =>
                    {
                        options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"));
                        options.UseLazyLoadingProxies();
                    });
                    break;

                case DbType.Sqlite:
                    services.AddDbContext<PredatorBGDbContext>(options =>
                    {
                        options.UseSqlite(Configuration.GetConnectionString("SqliteConnection"));
                        options.UseLazyLoadingProxies();
                    });
                    break;
            }

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<PredatorBGDbContext>()
            .AddDefaultTokenProviders();

            var allowedOrigins = Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>()
                ?? new[] { "http://localhost:4200" };

            services.AddCors(options =>
            {
                options.AddPolicy("Frontend", builder =>
                    builder.WithOrigins(allowedOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
            });

            services.AddTransient<IPredatorBGService, PredatorBGService>();
            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
                options.MaximumReceiveMessageSize = null;
            });
            services.AddControllers();
            services.AddHealthChecks();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            if (!env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }

            app.UseRouting();
            app.UseCors("Frontend");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<LobbyHub>("/PredatorWebsocket");
                endpoints.MapHealthChecks("/health");
            });

            var context = services.GetRequiredService<PredatorBGDbContext>();
            var directory = Configuration["ImageStore"];
            DbInitializer.Initialize(context, directory);
        }
    }
}

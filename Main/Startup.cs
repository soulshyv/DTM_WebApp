using System.Data;
using Autofac;
using DTM.Core.Contracts;
using DTM.Core.Models;
using DTM.Core.Repositories;
using DTM.Core.Services;
using DTM.DbManager;
using DTM.UserManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace DemonTaleManager.Web
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
            services.AddScoped<ILifetimeScope>();

            services.AddMvc();

            services.AddScoped<IDbConnection>(_ =>
                new MySqlConnection(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddDbContext<DtmDbContext>();

            services.AddRepositories();

            var defaultConnection = Configuration.GetConnectionString("DefaultConnection");
            services.AddSingleton<IDtmDbConnection>(_ =>
                new DtmDbConnection(defaultConnection));

            services.AddDbManager();

            services.AddUserManager();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using Autofac;
using DTM.Core;
using DTM.Core.Models;
using DTM.Core.Mvc;
using DTM.Core.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DemonTaleManager.Web
{
    public class DtmWebStartup : DtmStartupBase
    {
        /// <inheritdoc />
        public DtmWebStartup(IConfiguration configuration) : base(configuration)
        {
        }

        /// <inheritdoc />
        protected override void PopulateServices(ContainerBuilder bld, IServiceCollection services)
        {
            base.PopulateServices(bld, services);

            services.AddRouting(OnConfigureRouting);
            services.AddMvc(OnConfigureMvc);

            services.AddEntityFrameworkMySql().AddDbContext<DtmDbContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<CaracRepository>();
            services.AddScoped<DemonPersoRepository>();
            services.AddScoped<DemonRepository>();
            services.AddScoped<DonPersoRepository>();
            services.AddScoped<DonRepository>();
            services.AddScoped<ElementPersoRepository>();
            services.AddScoped<ElementRepository>();
            services.AddScoped<InventaireRepository>();
            services.AddScoped<ItemRepository>();
            services.AddScoped<JaugeRepository>();
            services.AddScoped<MetierRepository>();
            services.AddScoped<MetierPersoRepository>();
            services.AddScoped<PersoRepository>();
            services.AddScoped<PassifDemonRepository>();
            services.AddScoped<PassifPersoRepository>();
            services.AddScoped<PassifRepository>();
            services.AddScoped<SkillPersoRepository>();
            services.AddScoped<SkillRepository>();
            services.AddScoped<StatRepository>();
            services.AddScoped<UserRepository>();

            services.AddCore();
        }

        protected virtual void OnConfigureRouting(RouteOptions routeOptions)
        {
        }

        protected virtual void OnConfigureMvc(MvcOptions o)
        {
        }

        /// <inheritdoc />
        public override void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory lgf,
            IApplicationLifetime lifetime)
        {
            app.UseStaticFiles();
            app.UseMvc(OnConfigureMvcRoutes);
        }

        protected virtual void OnConfigureMvcRoutes(IRouteBuilder routes)
        {
            routes.MapRoute(
                "default",
                "{controller=Home}/{action=Index}/{id?}");
        }
    }
}

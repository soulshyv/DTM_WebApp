using Autofac;
using DTM.Core;
using DTM.Core.Models;
using DTM.Core.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RpgManager.Ged;
using RpgManager.Ged.Services;

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

            var defaultConnection = Configuration.GetConnectionString("DefaultConnection");
            
            services.AddDbContext<JdrContext>(options =>
            {
                options.UseMySql(defaultConnection);
            });

            services.AddCore();

            services.AddGed(bld, new GedConfiguration
            {
                BaseDirectory = Configuration["Dtm:Ged:Repo"]
            }).WithMySqlRepository();
        }

        protected override void OnConfigureMvcRoutes(IRouteBuilder routes)
        {
            routes.MapRoute(
                   "areas",
                   "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                   );

            base.OnConfigureMvcRoutes(routes);
        }
    }
}

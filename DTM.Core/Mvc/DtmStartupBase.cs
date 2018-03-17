using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RpgManager.Core.Mvc;

namespace DTM.Core.Mvc
{
    public class DtmStartupBase : RpgStartupBase
    {
        /// <inheritdoc />
        public DtmStartupBase(IConfiguration configuration) : base(configuration)
        {
        }

        protected virtual string ErrorHandlingPath { get; } = "/Error/Index/";

        /// <inheritdoc />
        protected override void PopulateServices(ContainerBuilder bld, IServiceCollection services)
        {
            base.PopulateServices(bld, services);

            services.AddRouting(OnConfigureRouting);
            services.AddMvc(OnConfigureMvc);
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
            base.Configure(app, env, lgf, lifetime);

            ConfigureExceptionHandler(app, env);

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc(OnConfigureMvcRoutes);
        }

        protected virtual void OnConfigureMvcRoutes(IRouteBuilder routes)
        {
            routes.MapRoute(
                "default",
                "{controller=Home}/{action=Index}/{id?}");
        }

        protected virtual void ConfigureExceptionHandler(IApplicationBuilder app, IHostingEnvironment env)
        {
            var forceNiceErrors = !string.IsNullOrWhiteSpace(Configuration["NICE_ERRORS"]);

            if (forceNiceErrors)
            {
                app.UseExceptionHandler(ErrorHandlingPath);
                return;
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(ErrorHandlingPath);
            }
        }
    }
}

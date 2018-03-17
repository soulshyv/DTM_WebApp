using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DTM.Core.Mvc
{
    public abstract class DtmStartupBase
    {
        protected DtmStartupBase(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var bld = new ContainerBuilder();

            PopulateServices(bld, services);

            bld.Populate(services);

            ApplicationContainer = bld.Build();

            bld.RegisterInstance(this)
                .AsSelf()
                .AsImplementedInterfaces()
                .SingleInstance()
                .ExternallyOwned()
            ;

            return new AutofacServiceProvider(ApplicationContainer);
        }

        protected virtual void PopulateServices(ContainerBuilder bld, IServiceCollection services)
        {
        }

        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory lgf, IApplicationLifetime lifetime)
        {
            lifetime.ApplicationStopped.Register(() =>
            {
                Log.CloseAndFlush();
                ApplicationContainer?.Dispose();
            });
        }
    }
}

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Compact;
using System;

namespace RpgManager.Core.Mvc
{
    public abstract class RpgStartupBase
    {
        protected RpgStartupBase(IConfiguration configuration)
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

        protected virtual LoggerConfiguration ConfigureLogging(LoggerConfiguration cfg, IHostingEnvironment env)
        {
            cfg
                .Enrich.WithProperty("AppName", GetType().Assembly.GetName().Name)
                .Enrich.FromLogContext()
                .WriteTo.Async(_ => _.RollingFile(new CompactJsonFormatter(), "Logs/_json/All-{Date}.log"))
                ;

            if (env.IsDevelopment())
            {
                cfg = cfg.WriteTo.Debug();
            }

            return cfg;
        }

        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory lgf, IApplicationLifetime lifetime)
        {
            var cfg = ConfigureLogging(new LoggerConfiguration(), env);

            Log.Logger = cfg.CreateLogger();

            lgf.AddSerilog();

            lifetime.ApplicationStopped.Register(() =>
            {
                Log.CloseAndFlush();
                ApplicationContainer?.Dispose();
            });
        }
    }
}

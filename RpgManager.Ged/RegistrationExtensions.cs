using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RpgManager.Core.Configuration;
using RpgManager.Ged.Contracts;
using RpgManager.Ged.Repositories;
using RpgManager.Ged.Services;

namespace RpgManager.Ged
{
    public static class RegistrationExtensions
    {
        public static IGedConfigurationBuilder AddGed(
            this IServiceCollection sc,
            ContainerBuilder b,
            GedConfiguration cfg
        )
        {
            sc.TryAddSingleton<IGedConfiguration>(cfg);

            sc.TryAddScoped<IFilePathGenerator, FilePathGenerator>();
            sc.TryAddScoped<IMimeTypeResolver, DefaultMimeTypeResolver>();
            sc.TryAddScoped<IFileExtensionValidator, FileExtensionValidator>();
            sc.TryAddScoped<IGedService, GedService>();

            return new GedConfigurationBuilder(sc, b);  
        }

        public static IGedConfigurationBuilder WithMySqlRepository(this IGedConfigurationBuilder self)
        {
            self.ServiceCollection.TryAddScoped<IGedDocumentRepository, MySqlGedDocumentRepository>();

            return self;
        }
            
        public interface IGedConfigurationBuilder : IConfigurationBuilder
        {
        }

        public class GedConfigurationBuilder : ConfigurationBuilderBase, IGedConfigurationBuilder
        {
            /// <inheritdoc />
            public GedConfigurationBuilder(IServiceCollection serviceCollection,
                ContainerBuilder containerBuilder) : base(serviceCollection, containerBuilder)
            {
            }
        }
    }
}
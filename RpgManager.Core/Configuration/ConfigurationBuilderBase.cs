using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace RpgManager.Core.Configuration
{
    public class ConfigurationBuilderBase
    {
        public ConfigurationBuilderBase(IServiceCollection serviceCollection, ContainerBuilder containerBuilder)
        {
            ServiceCollection = serviceCollection;
            ContainerBuilder = containerBuilder;
        }

        public IServiceCollection ServiceCollection { get; }
        public ContainerBuilder ContainerBuilder { get; }
    }
}
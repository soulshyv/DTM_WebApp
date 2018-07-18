using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace RpgManager.Core.Configuration
{
    public interface IConfigurationBuilder
    {
        IServiceCollection ServiceCollection { get; }
        ContainerBuilder ContainerBuilder { get; }
    }
}
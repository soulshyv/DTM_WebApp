using DTM.DbManager.Contracts;
using DTM.DbManager.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DTM.DbManager
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddDbManager(this IServiceCollection sc)
        {
            sc.TryAddScoped<IDtmRepository, DtmRepository>();
            sc.TryAddScoped<ICharacPicSearcher>(_ =>
                new CharacPicSearcher(@"./wwwRoot/images/"));

            return sc;
        }
    }
}

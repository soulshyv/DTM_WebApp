using DTM.Core.Contracts;
using DTM.Core.Repositories;
using DTM.Core.Services;
using DTM.DbManager.Contracts;
using DTM.DbManager.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DTM.Core
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection sc)
        {
            sc.TryAddScoped<DemonPersoRepository>();
            sc.TryAddScoped<DemonRepository>();
            sc.TryAddScoped<DonPersoRepository>();
            sc.TryAddScoped<DonRepository>();
            sc.TryAddScoped<ElementPersoRepository>();
            sc.TryAddScoped<ElementRepository>();
            sc.TryAddScoped<InventaireRepository>();
            sc.TryAddScoped<ItemRepository>();
            sc.TryAddScoped<MetierRepository>();
            sc.TryAddScoped<MetierPersoRepository>();
            sc.TryAddScoped<PersoRepository>();
            sc.TryAddScoped<PassifDemonRepository>();
            sc.TryAddScoped<PassifPersoRepository>();
            sc.TryAddScoped<PassifRepository>();
            sc.TryAddScoped<SkillPersoRepository>();
            sc.TryAddScoped<SkillRepository>();
            sc.TryAddScoped<UserRepository>();

            sc.TryAddScoped<DtmRepositories>();

            sc.TryAddScoped<ICharacPicSearcher>(_ =>
                new CharacPicSearcher(@"./wwwroot/images/CharacPictures/", @"../../images/CharacPictures/"));

            sc.TryAddScoped<IMd5Encryption, Md5Encryption>();

            return sc;
        }
    }
}
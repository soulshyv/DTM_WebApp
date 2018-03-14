using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DTM.Core.Repositories
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection sc)
        {
            sc.TryAddScoped<CaracRepository>();
            sc.TryAddScoped<DemonPersoRepository>();
            sc.TryAddScoped<DemonRepository>();
            sc.TryAddScoped<DonPersoRepository>();
            sc.TryAddScoped<DonRepository>();
            sc.TryAddScoped<ElementPersoRepository>();
            sc.TryAddScoped<ElementRepository>();
            sc.TryAddScoped<InventaireRepository>();
            sc.TryAddScoped<ItemRepository>();
            sc.TryAddScoped<JaugeRepository>();
            sc.TryAddScoped<MetierRepository>();
            sc.TryAddScoped<MetierPersoRepository>();
            sc.TryAddScoped<PassifDemonRepository>();
            sc.TryAddScoped<PassifPersoRepository>();
            sc.TryAddScoped<PassifRepository>();
            sc.TryAddScoped<SkillPersoRepository>();
            sc.TryAddScoped<SkillRepository>();
            sc.TryAddScoped<StatRepository>();
            sc.TryAddScoped<UserRepository>();

            sc.TryAddScoped<DtmRepositories>();

            return sc;
        }
    }
}
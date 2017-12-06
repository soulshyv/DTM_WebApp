using DTM.Encryption;
using DTM.DbManager.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using UserManager.Contracts;
using UserManager.Services;

namespace DTM.DbManager
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddUserManager(this IServiceCollection sc)
        {
            sc.TryAddScoped<IMd5Encryption, Md5Encryption>();
            sc.TryAddSingleton<IUserRepository, UserRepository>();
            sc.TryAddScoped<IUserManager, global::UserManager.Services.UserManager>();

            return sc;
        }
    }
}

﻿using DTM.Encryption;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using UserManager.Contracts;
using UserManager.Services;

namespace UserManager
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddUserManager(this IServiceCollection sc)
        {
            sc.TryAddScoped<IMd5Encryption, Md5Encryption>();
            sc.TryAddSingleton<IUserRepository, UserRepository>();
            sc.TryAddSingleton<IUserManager, Services.UserManager>();

            return sc;
        }
    }
}

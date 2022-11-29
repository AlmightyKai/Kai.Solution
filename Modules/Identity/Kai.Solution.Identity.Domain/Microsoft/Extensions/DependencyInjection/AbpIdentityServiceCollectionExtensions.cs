using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Kai.Solution.Identity;

namespace Microsoft.Extensions.DependencyInjection;

public static class AbpIdentityServiceCollectionExtensions
{
    public static IdentityBuilder AddAbpIdentity(this IServiceCollection services)
    {
        return services.AddAbpIdentity(setupAction: null);
    }

    public static IdentityBuilder AddAbpIdentity(this IServiceCollection services, Action<IdentityOptions> setupAction)
    {
        //AbpRoleManager
        services.TryAddScoped<RoleManager>();
        services.TryAddScoped(typeof(RoleManager<Role>), provider => provider.GetService(typeof(RoleManager)));

        //AbpUserManager
        services.TryAddScoped<IdentityUserManager>();
        services.TryAddScoped(typeof(UserManager<IdentityUser>), provider => provider.GetService(typeof(IdentityUserManager)));

        //AbpUserStore
        services.TryAddScoped<IdentityUserStore>();
        services.TryAddScoped(typeof(IUserStore<IdentityUser>), provider => provider.GetService(typeof(IdentityUserStore)));

        //AbpRoleStore
        services.TryAddScoped<RoleStore>();
        services.TryAddScoped(typeof(IRoleStore<Role>), provider => provider.GetService(typeof(RoleStore)));

        return services
            .AddIdentityCore<IdentityUser>(setupAction)
            .AddRoles<Role>()
            .AddClaimsPrincipalFactory<AbpUserClaimsPrincipalFactory>();
    }
}

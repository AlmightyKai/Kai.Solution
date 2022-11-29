using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.Security.Claims;
using Volo.Abp.Threading;
using Volo.Abp.Users;

namespace Kai.Solution.Identity
{
    [DependsOn(typeof(AbpAutoMapperModule))]
    [DependsOn(typeof(AbpDddDomainModule))]
    [DependsOn(typeof(AbpUsersDomainModule))]
    [DependsOn(typeof(DomainSharedModule))]
    public class DomainModule : AbpModule
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<DomainModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<IdentityDomainMappingProfile>(validate: true);
            });

            Configure<AbpDistributedEntityEventOptions>(options =>
            {
                options.EtoMappings.Add<IdentityUser, UserEto>(typeof(DomainModule));
                options.EtoMappings.Add<IdentityClaimType, ClaimTypeEto>(typeof(DomainModule));
                options.EtoMappings.Add<Role, RoleEto>(typeof(DomainModule));
                options.EtoMappings.Add<OrganizationUnit, OrganizationUnitEto>(typeof(DomainModule));

                options.AutoEventSelectors.Add<IdentityUser>();
                options.AutoEventSelectors.Add<Role>();
            });

            var identityBuilder = context.Services.AddAbpIdentity(options =>
            {
                options.User.RequireUniqueEmail = true;
            });

            context.Services.AddObjectAccessor(identityBuilder);
            context.Services.ExecutePreConfiguredActions(identityBuilder);

            Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserIdClaimType = AbpClaimTypes.UserId;
                options.ClaimsIdentity.UserNameClaimType = AbpClaimTypes.UserName;
                options.ClaimsIdentity.RoleClaimType = AbpClaimTypes.Role;
                options.ClaimsIdentity.EmailClaimType = AbpClaimTypes.Email;
            });

            context.Services.AddAbpDynamicOptions<IdentityOptions, AbpIdentityOptionsManager>();
        }

        public override void PostConfigureServices(ServiceConfigurationContext context)
        {
            OneTimeRunner.Run(() =>
            {
                ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToEntity(
                    ModuleExtensionConsts.ModuleName,
                    ModuleExtensionConsts.EntityNames.User,
                    typeof(IdentityUser)
                );

                ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToEntity(
                    ModuleExtensionConsts.ModuleName,
                    ModuleExtensionConsts.EntityNames.Role,
                    typeof(Role)
                );

                ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToEntity(
                    ModuleExtensionConsts.ModuleName,
                    ModuleExtensionConsts.EntityNames.ClaimType,
                    typeof(IdentityClaimType)
                );

                ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToEntity(
                    ModuleExtensionConsts.ModuleName,
                    ModuleExtensionConsts.EntityNames.OrganizationUnit,
                    typeof(OrganizationUnit)
                );
            });
        }
    }
}

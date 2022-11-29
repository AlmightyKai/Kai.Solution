using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.Threading;

namespace Kai.Solution.Identity
{
    [DependsOn(typeof(DomainSharedModule))]
    [DependsOn(typeof(AbpDddApplicationContractsModule))]
    [DependsOn(typeof(AbpAuthorizationModule))]
    public class ApplicationContractsModule : AbpModule
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }

        public override void PostConfigureServices(ServiceConfigurationContext context)
        {
            OneTimeRunner.Run(() =>
            {
                ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToApi(
                    ModuleExtensionConsts.ModuleName,
                    ModuleExtensionConsts.EntityNames.Role,
                    getApiTypes: new[] { typeof(RoleDto) },
                    createApiTypes: new[] { typeof(RoleCreateDto) },
                    updateApiTypes: new[] { typeof(RoleUpdateDto) }
                );

                ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToApi(
                    ModuleExtensionConsts.ModuleName,
                    ModuleExtensionConsts.EntityNames.User,
                    getApiTypes: new[] { typeof(UserDto) },
                    createApiTypes: new[] { typeof(UserCreateDto) },
                    updateApiTypes: new[] { typeof(UserUpdateDto) }
                );
            });
        }
    }
}

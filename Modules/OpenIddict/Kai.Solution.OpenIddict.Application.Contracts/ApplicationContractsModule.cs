using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Kai.Solution.OpenIddict
{
    [DependsOn(typeof(DomainSharedModule))]
    [DependsOn(typeof(AbpDddApplicationContractsModule))]
    [DependsOn(typeof(AbpAuthorizationModule))]
    public class ApplicationContractsModule : AbpModule
    {

    }
}

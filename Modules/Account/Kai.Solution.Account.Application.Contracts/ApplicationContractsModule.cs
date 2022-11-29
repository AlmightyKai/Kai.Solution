using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Kai.Solution.Account
{
    [DependsOn(typeof(DomainSharedModule))]
    [DependsOn(typeof(AbpDddApplicationContractsModule))]
    [DependsOn(typeof(AbpAuthorizationModule))]
    public class ApplicationContractsModule : AbpModule
    {

    }
}

using Volo.Abp.Modularity;

namespace Kai.Solution.Account
{
    [DependsOn(typeof(DomainSharedModule))]
    [DependsOn(typeof(DomainSharedModule))]
    public class DomainModule : AbpModule
    {

    }
}

using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Kai.Solution.OpenIddict
{
    [DependsOn(typeof(AbpDddDomainModule))]
    [DependsOn(typeof(DomainSharedModule))]
    public class DomainModule : AbpModule
    {

    }
}

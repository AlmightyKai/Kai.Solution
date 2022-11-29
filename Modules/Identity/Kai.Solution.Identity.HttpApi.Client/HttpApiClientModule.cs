using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Kai.Solution.Identity
{
    [DependsOn(typeof(ApplicationContractsModule))]
    [DependsOn(typeof(AbpHttpClientModule))]
    public class HttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ApplicationContractsModule).Assembly,
                RemoteServiceConsts.RemoteServiceName
            );

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<HttpApiClientModule>();
            });

        }
    }
}

using Kai.Solution.Account.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Kai.Solution.Account
{
    [DependsOn(typeof(ApplicationContractsModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    public class HttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(HttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<Resource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}

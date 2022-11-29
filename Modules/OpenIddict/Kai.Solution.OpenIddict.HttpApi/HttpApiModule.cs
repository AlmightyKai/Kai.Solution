using Localization.Resources.AbpUi;
using Kai.Solution.OpenIddict.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Kai.Solution.OpenIddict
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

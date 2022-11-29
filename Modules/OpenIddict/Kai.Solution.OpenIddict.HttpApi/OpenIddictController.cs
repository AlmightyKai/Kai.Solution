using Kai.Solution.OpenIddict.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Kai.Solution.OpenIddict
{
    public abstract class OpenIddictController : AbpControllerBase
    {
        protected OpenIddictController()
        {
            LocalizationResource = typeof(Resource);
        }
    }
}

using Kai.Solution.Account.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Kai.Solution.Account
{
    public abstract class AccountController : AbpControllerBase
    {
        protected AccountController()
        {
            this.LocalizationResource = typeof(Resource);
        }
    }
}

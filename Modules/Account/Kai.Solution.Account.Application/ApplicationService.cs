using Kai.Solution.Account.Localization;

namespace Kai.Solution.Account
{
    public abstract class ApplicationService : Volo.Abp.Application.Services.ApplicationService
    {
        protected ApplicationService()
        {
            this.LocalizationResource = typeof(Resource);
            this.ObjectMapperContext = typeof(AccountApplicationModule);
        }
    }
}

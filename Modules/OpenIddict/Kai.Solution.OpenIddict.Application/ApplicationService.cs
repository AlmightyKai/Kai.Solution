using Kai.Solution.OpenIddict.Localization;

namespace Kai.Solution.OpenIddict
{
    public abstract class ApplicationService : Volo.Abp.Application.Services.ApplicationService
    {
        protected ApplicationService()
        {
            this.LocalizationResource = typeof(Resource);
            this.ObjectMapperContext = typeof(ApplicationModule);
        }
    }
}

using Kai.Solution.Identity.Localization;

namespace Kai.Solution.Identity
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

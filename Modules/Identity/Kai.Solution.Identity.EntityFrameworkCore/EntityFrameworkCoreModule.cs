using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Kai.Solution.Identity.EntityFrameworkCore
{
    [DependsOn(typeof(DomainModule))]
    [DependsOn(typeof(AbpEntityFrameworkCoreModule))]
    public class EntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DbContext>(options =>
            {
                /*
                 * Add custom repositories here. Example:
                 *     options.AddRepository<Question, EfCoreQuestionRepository>();
                 */

                options.AddRepository<IdentityUser,        EfCoreUserRepository>();
                options.AddRepository<Role,        EfCoreRoleRepository>();
                options.AddRepository<IdentityClaimType,   EfCoreClaimTypeRepository>();
                options.AddRepository<OrganizationUnit,    EfCoreOrganizationUnitRepository>();
                options.AddRepository<SecurityLog, EFCoreSecurityLogRepository>();
                options.AddRepository<IdentityLinkUser,    EfCoreLinkUserRepository>();
            });
        }
    }
}

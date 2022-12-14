using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.SecurityLog;
using Volo.Abp.Uow;

namespace Kai.Solution.Identity
{
    [Dependency(ReplaceServices = true)]
    public class SecurityLogStore : ISecurityLogStore, ITransientDependency
    {
        public ILogger<SecurityLogStore> Logger { get; set; }

        protected AbpSecurityLogOptions SecurityLogOptions { get; }
        protected IIdentitySecurityLogRepository IdentitySecurityLogRepository { get; }
        protected IGuidGenerator GuidGenerator { get; }
        protected IUnitOfWorkManager UnitOfWorkManager { get; }

        public SecurityLogStore(
            ILogger<SecurityLogStore> logger,
            IOptions<AbpSecurityLogOptions> securityLogOptions,
            IIdentitySecurityLogRepository identitySecurityLogRepository,
            IGuidGenerator guidGenerator,
            IUnitOfWorkManager unitOfWorkManager)
        {
            Logger = logger;
            SecurityLogOptions = securityLogOptions.Value;
            IdentitySecurityLogRepository = identitySecurityLogRepository;
            GuidGenerator = guidGenerator;
            UnitOfWorkManager = unitOfWorkManager;
        }

        public async Task SaveAsync(SecurityLogInfo securityLogInfo)
        {
            if (!SecurityLogOptions.IsEnabled)
            {
                return;
            }

            using (var uow = UnitOfWorkManager.Begin(requiresNew: true))
            {
                await IdentitySecurityLogRepository.InsertAsync(new SecurityLog(GuidGenerator, securityLogInfo));
                await uow.CompleteAsync();
            }
        }
    }
}

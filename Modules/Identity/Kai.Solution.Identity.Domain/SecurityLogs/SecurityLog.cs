using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.SecurityLog;

namespace Kai.Solution.Identity
{
    public class SecurityLog : AggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        public string ApplicationName { get; protected set; }

        public string Identity { get; protected set; }

        public string Action { get; protected set; }

        public Guid? UserId { get; protected set; }

        public string UserName { get; protected set; }

        public string TenantName { get; protected set; }

        public string ClientId { get; protected set; }

        public string CorrelationId { get; protected set; }

        public string ClientIpAddress { get; protected set; }

        public string BrowserInfo { get; protected set; }

        public DateTime CreationTime { get; protected set; }

        protected SecurityLog()
        {

        }

        public SecurityLog(IGuidGenerator guidGenerator, SecurityLogInfo securityLogInfo)
            : base(guidGenerator.Create())
        {
            TenantId = securityLogInfo.TenantId;
            TenantName = securityLogInfo.TenantName.Truncate(SecurityLogConsts.MaxTenantNameLength);

            ApplicationName = securityLogInfo.ApplicationName.Truncate(SecurityLogConsts.MaxApplicationNameLength);
            Identity = securityLogInfo.Identity.Truncate(SecurityLogConsts.MaxIdentityLength);
            Action = securityLogInfo.Action.Truncate(SecurityLogConsts.MaxActionLength);

            UserId = securityLogInfo.UserId;
            UserName = securityLogInfo.UserName.Truncate(SecurityLogConsts.MaxUserNameLength);

            CreationTime = securityLogInfo.CreationTime;

            ClientIpAddress = securityLogInfo.ClientIpAddress.Truncate(SecurityLogConsts.MaxClientIpAddressLength);
            ClientId = securityLogInfo.ClientId.Truncate(SecurityLogConsts.MaxClientIdLength);
            CorrelationId = securityLogInfo.CorrelationId.Truncate(SecurityLogConsts.MaxCorrelationIdLength);
            BrowserInfo = securityLogInfo.BrowserInfo.Truncate(SecurityLogConsts.MaxBrowserInfoLength);

            foreach (var property in securityLogInfo.ExtraProperties)
            {
                ExtraProperties.Add(property.Key, property.Value);
            }
        }
    }
}

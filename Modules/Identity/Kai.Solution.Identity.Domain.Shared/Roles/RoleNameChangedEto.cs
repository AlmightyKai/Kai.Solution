using System;
using Volo.Abp.MultiTenancy;

namespace Kai.Solution.Identity
{
    [Serializable]
    public class RoleNameChangedEto : IMultiTenant
    {
        public Guid Id { get; set; }

        public Guid? TenantId { get; set; }

        public string Name { get; set; }

        public string OldName { get; set; }
    }
}

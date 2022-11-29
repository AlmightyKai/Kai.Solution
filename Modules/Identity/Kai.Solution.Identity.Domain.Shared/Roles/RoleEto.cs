using System;

namespace Kai.Solution.Identity
{
    [Serializable]
    public class RoleEto
    {
        public Guid Id { get; set; }

        public Guid? TenantId { get; set; }

        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public bool IsStatic { get; set; }

        public bool IsPublic { get; set; }
    }
}

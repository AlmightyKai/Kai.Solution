using System;

namespace Kai.Solution.Identity
{
    [Obsolete("Use the distributed event (IdentityRoleNameChangedEto) instead.")]
    public class RoleNameChangedEvent
    {
        public Role IdentityRole { get; set; }
        public string OldName { get; set; }
    }
}

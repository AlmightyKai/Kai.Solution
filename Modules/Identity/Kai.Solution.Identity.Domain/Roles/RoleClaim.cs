using System;
using System.Security.Claims;
using JetBrains.Annotations;

namespace Kai.Solution.Identity
{
    /// <summary>
    /// Represents a claim that is granted to all users within a role.
    /// </summary>
    public class RoleClaim : IdentityClaim
    {
        /// <summary>
        /// Gets or sets the of the primary key of the role associated with this claim.
        /// </summary>
        public virtual Guid RoleId { get; protected set; }

        protected RoleClaim()
        {

        }

        protected internal RoleClaim(
            Guid id,
            Guid roleId,
            [NotNull] Claim claim,
            Guid? tenantId)
            : base(
                  id,
                  claim,
                  tenantId)
        {
            RoleId = roleId;
        }

        public RoleClaim(
            Guid id,
            Guid roleId,
            [NotNull] string claimType,
            string claimValue,
            Guid? tenantId)
            : base(
                  id,
                  claimType,
                  claimValue,
                  tenantId)
        {
            RoleId = roleId;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Kai.Solution.Identity.EntityFrameworkCore
{
    [ConnectionStringName(DbProperties.ConnectionStringName)]
    public interface IDbContext : IEfCoreDbContext
    {
        /*
         * Add DbSet for each Aggregate Root here. Example:
         *     DbSet<Question> Questions { get; }
         */
        
        DbSet<IdentityUser> Users { get; }

        DbSet<Role> Roles { get; }

        DbSet<IdentityClaimType> ClaimTypes { get; }

        DbSet<OrganizationUnit> OrganizationUnits { get; }

        DbSet<SecurityLog> SecurityLogs { get; }

        DbSet<IdentityLinkUser> LinkUsers { get; }
    }
}

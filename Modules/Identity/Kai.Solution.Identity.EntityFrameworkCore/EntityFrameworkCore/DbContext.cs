using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Kai.Solution.Identity.EntityFrameworkCore
{

    [ConnectionStringName(DbProperties.ConnectionStringName)]
    public class DbContext : AbpDbContext<DbContext>, IDbContext
    {
        /*
         * Add DbSet for each Aggregate Root here. Example:
         *     public DbSet<Question> Questions { get; set; }
         */

        public DbSet<IdentityUser> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<IdentityClaimType> ClaimTypes { get; set; }

        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }

        public DbSet<SecurityLog> SecurityLogs { get; set; }

        public DbSet<IdentityLinkUser> LinkUsers { get; set; }

        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureIdentity();
        }
    }
}

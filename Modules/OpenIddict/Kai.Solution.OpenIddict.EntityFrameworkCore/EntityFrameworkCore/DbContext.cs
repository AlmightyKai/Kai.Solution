using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Kai.Solution.OpenIddict.EntityFrameworkCore
{
    [ConnectionStringName(DbProperties.ConnectionStringName)]
    public class DbContext : AbpDbContext<DbContext>, IDbContext
    {
        /*
         * Add DbSet for each Aggregate Root here. Example:
         *     public DbSet<Question> Questions { get; set; }
         */

        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureOpenIddict();
        }
    }
}

﻿using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Kai.Solution.OpenIddict.EntityFrameworkCore
{
    [ConnectionStringName(DbProperties.ConnectionStringName)]
    public interface IDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         *     DbSet<Question> Questions { get; }
         */
    }
}

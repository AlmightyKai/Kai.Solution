using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Kai.Solution.Identity.EntityFrameworkCore
{
    public class EfCoreRoleRepository : EfCoreRepository<IDbContext, Role, Guid>, IIdentityRoleRepository
    {
        public EfCoreRoleRepository(IDbContextProvider<IDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<Role> FindByNormalizedNameAsync(
            string normalizedRoleName,
            bool includeDetails = true,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetails)
                .OrderBy(x => x.Id)
                .FirstOrDefaultAsync(r => r.NormalizedName == normalizedRoleName, GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<Role>> GetListAsync(
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string filter = null,
            bool includeDetails = true,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetails)
                .WhereIf(!filter.IsNullOrWhiteSpace(),
                        x => x.Name.Contains(filter) ||
                        x.NormalizedName.Contains(filter))
                .OrderBy(sorting.IsNullOrWhiteSpace() ? nameof(Role.Name) : sorting)
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<Role>> GetListAsync(
            IEnumerable<Guid> ids,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .Where(t => ids.Contains(t.Id))
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<Role>> GetDefaultOnesAsync(
            bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetails)
                .Where(r => r.IsDefault)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<long> GetCountAsync(
            string filter = null,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .WhereIf(!filter.IsNullOrWhiteSpace(),
                    x => x.Name.Contains(filter) ||
                         x.NormalizedName.Contains(filter))
                .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        [Obsolete("Use WithDetailsAsync")]
        public override IQueryable<Role> WithDetails()
        {
            return GetQueryable().IncludeDetails();
        }

        public override async Task<IQueryable<Role>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Kai.Solution.Identity;

public interface IIdentityRoleRepository : IBasicRepository<Role, Guid>
{
    Task<Role> FindByNormalizedNameAsync(
        string normalizedRoleName,
        bool includeDetails = true,
        CancellationToken cancellationToken = default
    );

    Task<List<Role>> GetListAsync(
        string sorting = null,
        int maxResultCount = int.MaxValue,
        int skipCount = 0,
        string filter = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default
    );
    Task<List<Role>> GetListAsync(
        IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default
    );

    Task<List<Role>> GetDefaultOnesAsync(
        bool includeDetails = false,
        CancellationToken cancellationToken = default
    );

    Task<long> GetCountAsync(
        string filter = null,
        CancellationToken cancellationToken = default
    );
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Kai.Solution.Identity;

public interface IIdentitySecurityLogRepository : IBasicRepository<SecurityLog, Guid>
{
    Task<List<SecurityLog>> GetListAsync(
        string sorting = null,
        int maxResultCount = 50,
        int skipCount = 0,
        DateTime? startTime = null,
        DateTime? endTime = null,
        string applicationName = null,
        string identity = null,
        string action = null,
        Guid? userId = null,
        string userName = null,
        string clientId = null,
        string correlationId = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default);

    Task<long> GetCountAsync(
        DateTime? startTime = null,
        DateTime? endTime = null,
        string applicationName = null,
        string identity = null,
        string action = null,
        Guid? userId = null,
        string userName = null,
        string clientId = null,
        string correlationId = null,
        CancellationToken cancellationToken = default);

    Task<SecurityLog> GetByUserIdAsync(
        Guid id,
        Guid userId,
        bool includeDetails = false,
        CancellationToken cancellationToken = default);
}

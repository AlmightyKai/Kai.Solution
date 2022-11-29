using Kai.Solution.Identity.Localization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Services;
using Volo.Abp.Threading;

namespace Kai.Solution.Identity
{
    public class RoleManager : RoleManager<Role>, IDomainService
    {
        protected override CancellationToken CancellationToken => CancellationTokenProvider.Token;

        protected IStringLocalizer<Resource> Localizer { get; }
        protected ICancellationTokenProvider CancellationTokenProvider { get; }

        public RoleManager(
            RoleStore store,
            IEnumerable<IRoleValidator<Role>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<RoleManager> logger,
            IStringLocalizer<Resource> localizer,
            ICancellationTokenProvider cancellationTokenProvider)
            : base(
                  store,
                  roleValidators,
                  keyNormalizer,
                  errors,
                  logger)
        {
            Localizer = localizer;
            CancellationTokenProvider = cancellationTokenProvider;
        }

        public virtual async Task<Role> GetByIdAsync(Guid id)
        {
            var role = await Store.FindByIdAsync(id.ToString(), CancellationToken);
            if (role == null)
            {
                throw new EntityNotFoundException(typeof(Role), id);
            }

            return role;
        }

        public async override Task<IdentityResult> SetRoleNameAsync(Role role, string name)
        {
            if (role.IsStatic && role.Name != name)
            {
                throw new BusinessException(ErrorCodes.StaticRoleRenaming);
            }

            return await base.SetRoleNameAsync(role, name);
        }

        public async override Task<IdentityResult> DeleteAsync(Role role)
        {
            if (role.IsStatic)
            {
                throw new BusinessException(ErrorCodes.StaticRoleDeletion);
            }

            return await base.DeleteAsync(role);
        }
    }
}

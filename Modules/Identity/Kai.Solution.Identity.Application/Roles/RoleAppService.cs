using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.ObjectExtending;

namespace Kai.Solution.Identity
{
    [Authorize(Permissions.Permissions.Roles.Default)]
    public class RoleAppService : ApplicationService, IRoleAppService
    {
        protected RoleManager RoleManager { get; }
        protected IIdentityRoleRepository RoleRepository { get; }

        public RoleAppService(
            RoleManager roleManager,
            IIdentityRoleRepository roleRepository)
        {
            RoleManager = roleManager;
            RoleRepository = roleRepository;
        }

        public virtual async Task<RoleDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Role, RoleDto>(
                await RoleManager.GetByIdAsync(id)
            );
        }

        public virtual async Task<ListResultDto<RoleDto>> GetAllListAsync()
        {
            var list = await RoleRepository.GetListAsync();
            return new ListResultDto<RoleDto>(
                ObjectMapper.Map<List<Role>, List<RoleDto>>(list)
            );
        }

        public virtual async Task<PagedResultDto<RoleDto>> GetListAsync(GetRolesInput input)
        {
            var list = await RoleRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter);
            var totalCount = await RoleRepository.GetCountAsync(input.Filter);

            return new PagedResultDto<RoleDto>(
                totalCount,
                ObjectMapper.Map<List<Role>, List<RoleDto>>(list)
                );
        }

        [Authorize(Permissions.Permissions.Roles.Create)]
        public virtual async Task<RoleDto> CreateAsync(RoleCreateDto input)
        {
            var role = new Role(
                GuidGenerator.Create(),
                input.Name,
                CurrentTenant.Id
            )
            {
                IsDefault = input.IsDefault,
                IsPublic = input.IsPublic
            };

            input.MapExtraPropertiesTo(role);

            (await RoleManager.CreateAsync(role)).CheckErrors();
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<Role, RoleDto>(role);
        }

        [Authorize(Permissions.Permissions.Roles.Update)]
        public virtual async Task<RoleDto> UpdateAsync(Guid id, RoleUpdateDto input)
        {
            var role = await RoleManager.GetByIdAsync(id);

            role.SetConcurrencyStampIfNotNull(input.ConcurrencyStamp);

            (await RoleManager.SetRoleNameAsync(role, input.Name)).CheckErrors();

            role.IsDefault = input.IsDefault;
            role.IsPublic = input.IsPublic;

            input.MapExtraPropertiesTo(role);

            (await RoleManager.UpdateAsync(role)).CheckErrors();
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<Role, RoleDto>(role);
        }

        [Authorize(Permissions.Permissions.Roles.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            var role = await RoleManager.FindByIdAsync(id.ToString());
            if (role == null)
            {
                return;
            }

            (await RoleManager.DeleteAsync(role)).CheckErrors();
        }
    }
}

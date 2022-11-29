using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.ObjectExtending;

namespace Kai.Solution.Identity
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        protected IdentityUserManager UserManager { get; }
        protected IIdentityUserRepository UserRepository { get; }
        protected IIdentityRoleRepository RoleRepository { get; }
        protected IOptions<IdentityOptions> IdentityOptions { get; }

        public UserAppService(
            IdentityUserManager userManager,
            IIdentityUserRepository userRepository,
            IIdentityRoleRepository roleRepository,
            IOptions<IdentityOptions> identityOptions)
        {
            UserManager = userManager;
            UserRepository = userRepository;
            RoleRepository = roleRepository;
            IdentityOptions = identityOptions;
        }

        //TODO: [Authorize(IdentityPermissions.Users.Default)] should go the IdentityUserAppService class.
        [Authorize(Permissions.Permissions.Users.Default)]
        public virtual async Task<UserDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<IdentityUser, UserDto>(
                await UserManager.GetByIdAsync(id)
            );
        }

        [Authorize(Permissions.Permissions.Users.Default)]
        public virtual async Task<PagedResultDto<UserDto>> GetListAsync(GetUsersInput input)
        {
            var count = await UserRepository.GetCountAsync(input.Filter);
            var list = await UserRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter);

            return new PagedResultDto<UserDto>(
                count,
                ObjectMapper.Map<List<IdentityUser>, List<UserDto>>(list)
            );
        }

        [Authorize(Permissions.Permissions.Users.Default)]
        public virtual async Task<ListResultDto<RoleDto>> GetRolesAsync(Guid id)
        {
            //TODO: Should also include roles of the related OUs.

            var roles = await UserRepository.GetRolesAsync(id);

            return new ListResultDto<RoleDto>(
                ObjectMapper.Map<List<Role>, List<RoleDto>>(roles)
            );
        }

        [Authorize(Permissions.Permissions.Users.Default)]
        public virtual async Task<ListResultDto<RoleDto>> GetAssignableRolesAsync()
        {
            var list = await RoleRepository.GetListAsync();
            return new ListResultDto<RoleDto>(
                ObjectMapper.Map<List<Role>, List<RoleDto>>(list));
        }

        [Authorize(Permissions.Permissions.Users.Create)]
        public virtual async Task<UserDto> CreateAsync(UserCreateDto input)
        {
            await IdentityOptions.SetAsync();

            var user = new IdentityUser(
                GuidGenerator.Create(),
                input.UserName,
                input.Email,
                CurrentTenant.Id
            );

            input.MapExtraPropertiesTo(user);

            (await UserManager.CreateAsync(user, input.Password)).CheckErrors();
            await UpdateUserByInput(user, input);
            (await UserManager.UpdateAsync(user)).CheckErrors();

            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<IdentityUser, UserDto>(user);
        }

        [Authorize(Permissions.Permissions.Users.Update)]
        public virtual async Task<UserDto> UpdateAsync(Guid id, UserUpdateDto input)
        {
            await IdentityOptions.SetAsync();

            var user = await UserManager.GetByIdAsync(id);

            user.SetConcurrencyStampIfNotNull(input.ConcurrencyStamp);

            (await UserManager.SetUserNameAsync(user, input.UserName)).CheckErrors();

            await UpdateUserByInput(user, input);
            input.MapExtraPropertiesTo(user);

            (await UserManager.UpdateAsync(user)).CheckErrors();

            if (!input.Password.IsNullOrEmpty())
            {
                (await UserManager.RemovePasswordAsync(user)).CheckErrors();
                (await UserManager.AddPasswordAsync(user, input.Password)).CheckErrors();
            }

            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<IdentityUser, UserDto>(user);
        }

        [Authorize(Permissions.Permissions.Users.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            if (CurrentUser.Id == id)
            {
                throw new BusinessException(code: IdentityErrorCodes.UserSelfDeletion);
            }

            var user = await UserManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return;
            }

            (await UserManager.DeleteAsync(user)).CheckErrors();
        }

        [Authorize(Permissions.Permissions.Users.Update)]
        public virtual async Task UpdateRolesAsync(Guid id, UserUpdateRolesDto input)
        {
            var user = await UserManager.GetByIdAsync(id);
            (await UserManager.SetRolesAsync(user, input.RoleNames)).CheckErrors();
            await UserRepository.UpdateAsync(user);
        }

        [Authorize(Permissions.Permissions.Users.Default)]
        public virtual async Task<UserDto> FindByUsernameAsync(string userName)
        {
            return ObjectMapper.Map<IdentityUser, UserDto>(
                await UserManager.FindByNameAsync(userName)
            );
        }

        [Authorize(Permissions.Permissions.Users.Default)]
        public virtual async Task<UserDto> FindByEmailAsync(string email)
        {
            return ObjectMapper.Map<IdentityUser, UserDto>(
                await UserManager.FindByEmailAsync(email)
            );
        }

        protected virtual async Task UpdateUserByInput(IdentityUser user, UserCreateOrUpdateDtoBase input)
        {
            if (!string.Equals(user.Email, input.Email, StringComparison.InvariantCultureIgnoreCase))
            {
                (await UserManager.SetEmailAsync(user, input.Email)).CheckErrors();
            }

            if (!string.Equals(user.PhoneNumber, input.PhoneNumber, StringComparison.InvariantCultureIgnoreCase))
            {
                (await UserManager.SetPhoneNumberAsync(user, input.PhoneNumber)).CheckErrors();
            }

            (await UserManager.SetLockoutEnabledAsync(user, input.LockoutEnabled)).CheckErrors();

            user.Name = input.Name;
            user.Surname = input.Surname;
            (await UserManager.UpdateAsync(user)).CheckErrors();
            user.SetIsActive(input.IsActive);
            if (input.RoleNames != null)
            {
                (await UserManager.SetRolesAsync(user, input.RoleNames)).CheckErrors();
            }
        }
    }
}

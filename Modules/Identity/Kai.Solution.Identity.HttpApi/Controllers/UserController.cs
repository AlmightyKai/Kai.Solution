using Kai.Solution.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.Identity
{
    [RemoteService(Name = RemoteServiceConsts.RemoteServiceName)]
    [Area(RemoteServiceConsts.ModuleName)]
    [ControllerName("User")]
    [Route("api/identity/users")]
    public class UserController : AbpControllerBase, IUserAppService
    {
        protected IUserAppService UserAppService { get; }

        public UserController(IUserAppService userAppService)
        {
            UserAppService = userAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<UserDto> GetAsync(Guid id)
        {
            return UserAppService.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<UserDto>> GetListAsync(GetUsersInput input)
        {
            return UserAppService.GetListAsync(input);
        }

        [HttpPost]
        public virtual Task<UserDto> CreateAsync(UserCreateDto input)
        {
            return UserAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<UserDto> UpdateAsync(Guid id, UserUpdateDto input)
        {
            return UserAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return UserAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}/roles")]
        public virtual Task<ListResultDto<RoleDto>> GetRolesAsync(Guid id)
        {
            return UserAppService.GetRolesAsync(id);
        }

        [HttpGet]
        [Route("assignable-roles")]
        public Task<ListResultDto<RoleDto>> GetAssignableRolesAsync()
        {
            return UserAppService.GetAssignableRolesAsync();
        }

        [HttpPut]
        [Route("{id}/roles")]
        public virtual Task UpdateRolesAsync(Guid id, UserUpdateRolesDto input)
        {
            return UserAppService.UpdateRolesAsync(id, input);
        }

        [HttpGet]
        [Route("by-username/{userName}")]
        public virtual Task<UserDto> FindByUsernameAsync(string userName)
        {
            return UserAppService.FindByUsernameAsync(userName);
        }

        [HttpGet]
        [Route("by-email/{email}")]
        public virtual Task<UserDto> FindByEmailAsync(string email)
        {
            return UserAppService.FindByEmailAsync(email);
        }
    }
}

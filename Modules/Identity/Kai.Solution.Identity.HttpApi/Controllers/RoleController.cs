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
    [ControllerName("Role")]
    [Route("api/identity/roles")]
    public class RoleController : AbpControllerBase, IRoleAppService
    {
        protected IRoleAppService RoleAppService { get; }

        public RoleController(IRoleAppService roleAppService)
        {
            RoleAppService = roleAppService;
        }

        [HttpGet]
        [Route("all")]
        public virtual Task<ListResultDto<RoleDto>> GetAllListAsync()
        {
            return RoleAppService.GetAllListAsync();
        }

        [HttpGet]
        public virtual Task<PagedResultDto<RoleDto>> GetListAsync(GetRolesInput input)
        {
            return RoleAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<RoleDto> GetAsync(Guid id)
        {
            return RoleAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<RoleDto> CreateAsync(RoleCreateDto input)
        {
            return RoleAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<RoleDto> UpdateAsync(Guid id, RoleUpdateDto input)
        {
            return RoleAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return RoleAppService.DeleteAsync(id);
        }
    }
}

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Kai.Solution.Identity
{
    public interface IRoleAppService : ICrudAppService<RoleDto, Guid, GetRolesInput, RoleCreateDto, RoleUpdateDto>
    {
        Task<ListResultDto<RoleDto>> GetAllListAsync();
    }
}

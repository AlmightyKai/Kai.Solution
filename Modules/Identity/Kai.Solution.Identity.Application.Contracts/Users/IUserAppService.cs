using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Kai.Solution.Identity
{
    public interface IUserAppService : ICrudAppService<UserDto, Guid, GetUsersInput, UserCreateDto, UserUpdateDto>
    {
        Task<ListResultDto<RoleDto>> GetRolesAsync(Guid id);

        Task<ListResultDto<RoleDto>> GetAssignableRolesAsync();

        Task UpdateRolesAsync(Guid id, UserUpdateRolesDto input);

        Task<UserDto> FindByUsernameAsync(string userName);

        Task<UserDto> FindByEmailAsync(string email);
    }
}

using System;
using System.Threading.Tasks;

namespace Kai.Solution.Identity
{
    public interface IUserRoleFinder
    {
        Task<string[]> GetRolesAsync(Guid userId);
    }
}

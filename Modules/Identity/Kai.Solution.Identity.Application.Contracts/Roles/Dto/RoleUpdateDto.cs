using Volo.Abp.Domain.Entities;

namespace Kai.Solution.Identity
{
    public class RoleUpdateDto : RoleCreateOrUpdateDtoBase, IHasConcurrencyStamp
    {
        public string ConcurrencyStamp { get; set; }
    }
}

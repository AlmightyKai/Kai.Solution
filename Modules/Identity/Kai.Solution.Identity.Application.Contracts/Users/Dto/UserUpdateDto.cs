using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace Kai.Solution.Identity;

public class UserUpdateDto : UserCreateOrUpdateDtoBase, IHasConcurrencyStamp
{
    [DisableAuditing]
    [DynamicStringLength(typeof(UserConsts), nameof(UserConsts.MaxPasswordLength))]
    public string Password { get; set; }

    public string ConcurrencyStamp { get; set; }
}

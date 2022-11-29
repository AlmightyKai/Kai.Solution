using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;
using Volo.Abp.Validation;

namespace Kai.Solution.Identity;

public class UserCreateDto : UserCreateOrUpdateDtoBase
{
    [DisableAuditing]
    [Required]
    [DynamicStringLength(typeof(UserConsts), nameof(UserConsts.MaxPasswordLength))]
    public string Password { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace Kai.Solution.Identity;

public class UserUpdateRolesDto
{
    [Required]
    public string[] RoleNames { get; set; }
}

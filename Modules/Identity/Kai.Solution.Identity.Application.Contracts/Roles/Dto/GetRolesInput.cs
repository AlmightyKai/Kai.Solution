using Volo.Abp.Application.Dtos;

namespace Kai.Solution.Identity;

public class GetRolesInput : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}

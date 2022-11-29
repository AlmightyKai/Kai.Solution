using Volo.Abp.Application.Dtos;

namespace Kai.Solution.Identity;

public class UserLookupSearchInputDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}

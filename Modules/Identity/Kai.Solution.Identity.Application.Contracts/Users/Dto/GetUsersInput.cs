using Volo.Abp.Application.Dtos;

namespace Kai.Solution.Identity
{
    public class GetUsersInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}

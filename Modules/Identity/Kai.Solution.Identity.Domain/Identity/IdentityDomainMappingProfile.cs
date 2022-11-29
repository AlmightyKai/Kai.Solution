using AutoMapper;
using Volo.Abp.Users;

namespace Kai.Solution.Identity;

public class IdentityDomainMappingProfile : Profile
{
    public IdentityDomainMappingProfile()
    {
        CreateMap<IdentityUser, UserEto>();
        CreateMap<IdentityClaimType, ClaimTypeEto>();
        CreateMap<Role, RoleEto>();
        CreateMap<OrganizationUnit, OrganizationUnitEto>();
    }
}

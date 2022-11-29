using AutoMapper;

namespace Kai.Solution.Identity
{
    public class ApplicationAutoMapperProfile : Profile
    {
        public ApplicationAutoMapperProfile()
        {
            /*
             * You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization.
             */

            CreateMap<IdentityUser, UserDto>()
                .MapExtraProperties();

            CreateMap<Role, RoleDto>()
                .MapExtraProperties();
        }
    }
}

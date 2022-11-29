using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace Kai.Solution.Identity
{
    public class RoleCreateOrUpdateDtoBase : ExtensibleObject
    {
        [Required]
        [DynamicStringLength(typeof(RoleConsts), nameof(RoleConsts.MaxNameLength))]
        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public bool IsPublic { get; set; }

        protected RoleCreateOrUpdateDtoBase() : base(false)
        {

        }
    }
}

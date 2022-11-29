using Kai.Solution.Account.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Kai.Solution.Account.Permissions
{
    public class PermissionDefinitionProvider : Volo.Abp.Authorization.Permissions.PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(Permissions.GroupName, L("Permission:Account"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<Resource>(name);
        }
    }
}

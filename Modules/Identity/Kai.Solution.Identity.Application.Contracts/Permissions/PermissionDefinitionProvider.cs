using Kai.Solution.Identity.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Kai.Solution.Identity.Permissions
{
    public class PermissionDefinitionProvider : Volo.Abp.Authorization.Permissions.PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var group = context.AddGroup(Permissions.GroupName, L("Permission:Identity"));

            var roles = group.AddPermission(Permissions.Roles.Default, L("Permission:RoleManagement"));
            roles.AddChild(Permissions.Roles.Create, L("Permission:Create"));
            roles.AddChild(Permissions.Roles.Update, L("Permission:Edit"));
            roles.AddChild(Permissions.Roles.Delete, L("Permission:Delete"));
            roles.AddChild(Permissions.Roles.ManagePermissions, L("Permission:ChangePermissions"));

            var users = group.AddPermission(Permissions.Users.Default, L("Permission:UserManagement"));
            users.AddChild(Permissions.Users.Create, L("Permission:Create"));
            users.AddChild(Permissions.Users.Update, L("Permission:Edit"));
            users.AddChild(Permissions.Users.Delete, L("Permission:Delete"));
            users.AddChild(Permissions.Users.ManagePermissions, L("Permission:ChangePermissions"));

            group
                .AddPermission(Permissions.UserLookup.Default, L("Permission:UserLookup"))
                .WithProviders(ClientPermissionValueProvider.ProviderName);
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<Resource>(name);
        }
    }
}

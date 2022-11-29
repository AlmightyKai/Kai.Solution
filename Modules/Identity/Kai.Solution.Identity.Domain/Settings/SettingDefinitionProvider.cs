using Kai.Solution.Identity.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Kai.Solution.Identity.Settings
{
    public class SettingDefinitionProvider : Volo.Abp.Settings.SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            /*
             * Define module settings here.
             * Use names from Settings class.
             */

            context.Add(
                new SettingDefinition(
                    SettingNames.Password.RequiredLength,
                    6.ToString(),
                    L("DisplayName:Abp.Identity.Password.RequiredLength"),
                    L("Description:Abp.Identity.Password.RequiredLength"),
                    true),

                new SettingDefinition(
                    SettingNames.Password.RequiredUniqueChars,
                    1.ToString(),
                    L("DisplayName:Abp.Identity.Password.RequiredUniqueChars"),
                    L("Description:Abp.Identity.Password.RequiredUniqueChars"),
                    true),

                new SettingDefinition(
                    SettingNames.Password.RequireNonAlphanumeric,
                    true.ToString(),
                    L("DisplayName:Abp.Identity.Password.RequireNonAlphanumeric"),
                    L("Description:Abp.Identity.Password.RequireNonAlphanumeric"),
                    true),

                new SettingDefinition(
                    SettingNames.Password.RequireLowercase,
                    true.ToString(),
                    L("DisplayName:Abp.Identity.Password.RequireLowercase"),
                    L("Description:Abp.Identity.Password.RequireLowercase"),
                    true),

                new SettingDefinition(
                    SettingNames.Password.RequireUppercase,
                    true.ToString(),
                    L("DisplayName:Abp.Identity.Password.RequireUppercase"),
                    L("Description:Abp.Identity.Password.RequireUppercase"),
                    true),

                new SettingDefinition(
                    SettingNames.Password.RequireDigit,
                    true.ToString(),
                    L("DisplayName:Abp.Identity.Password.RequireDigit"),
                    L("Description:Abp.Identity.Password.RequireDigit"),
                    true),

                new SettingDefinition(
                    SettingNames.Lockout.AllowedForNewUsers,
                    true.ToString(),
                    L("DisplayName:Abp.Identity.Lockout.AllowedForNewUsers"),
                    L("Description:Abp.Identity.Lockout.AllowedForNewUsers"),
                    true),

                new SettingDefinition(
                    SettingNames.Lockout.LockoutDuration,
                    (5 * 60).ToString(),
                    L("DisplayName:Abp.Identity.Lockout.LockoutDuration"),
                    L("Description:Abp.Identity.Lockout.LockoutDuration"),
                    true),

                new SettingDefinition(
                    SettingNames.Lockout.MaxFailedAccessAttempts,
                    5.ToString(),
                    L("DisplayName:Abp.Identity.Lockout.MaxFailedAccessAttempts"),
                    L("Description:Abp.Identity.Lockout.MaxFailedAccessAttempts"),
                    true),

                new SettingDefinition(
                    SettingNames.SignIn.RequireConfirmedEmail,
                    false.ToString(),
                    L("DisplayName:Abp.Identity.SignIn.RequireConfirmedEmail"),
                    L("Description:Abp.Identity.SignIn.RequireConfirmedEmail"),
                    true),
                new SettingDefinition(
                    SettingNames.SignIn.EnablePhoneNumberConfirmation,
                    true.ToString(),
                    L("DisplayName:Abp.Identity.SignIn.EnablePhoneNumberConfirmation"),
                    L("Description:Abp.Identity.SignIn.EnablePhoneNumberConfirmation"),
                    true),
                new SettingDefinition(
                    SettingNames.SignIn.RequireConfirmedPhoneNumber,
                    false.ToString(),
                    L("DisplayName:Abp.Identity.SignIn.RequireConfirmedPhoneNumber"),
                    L("Description:Abp.Identity.SignIn.RequireConfirmedPhoneNumber"),
                    true),

                new SettingDefinition(
                    SettingNames.User.IsUserNameUpdateEnabled,
                    true.ToString(),
                    L("DisplayName:Abp.Identity.User.IsUserNameUpdateEnabled"),
                    L("Description:Abp.Identity.User.IsUserNameUpdateEnabled"),
                    true),

                new SettingDefinition(
                    SettingNames.User.IsEmailUpdateEnabled,
                    true.ToString(),
                    L("DisplayName:Abp.Identity.User.IsEmailUpdateEnabled"),
                    L("Description:Abp.Identity.User.IsEmailUpdateEnabled"),
                    true),

                new SettingDefinition(
                    SettingNames.OrganizationUnit.MaxUserMembershipCount,
                    int.MaxValue.ToString(),
                    L("Identity.OrganizationUnit.MaxUserMembershipCount"),
                    L("Identity.OrganizationUnit.MaxUserMembershipCount"),
                    true)
            );
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<Resource>(name);
        }
    }
}

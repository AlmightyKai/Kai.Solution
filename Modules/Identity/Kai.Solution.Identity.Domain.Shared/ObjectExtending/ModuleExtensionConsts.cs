namespace Volo.Abp.ObjectExtending
{
    public static class ModuleExtensionConsts
    {
        public const string ModuleName = "Identity";

        public static class EntityNames
        {
            public const string User = nameof(User);

            public const string Role = nameof(Role);

            public const string ClaimType = nameof(ClaimType);

            public const string OrganizationUnit = nameof(OrganizationUnit);
        }

        public static class ConfigurationNames
        {
            public const string AllowUserToEdit = nameof(AllowUserToEdit);
        }
    }
}

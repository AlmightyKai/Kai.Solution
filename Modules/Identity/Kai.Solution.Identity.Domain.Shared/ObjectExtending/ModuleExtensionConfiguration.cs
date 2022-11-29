using System;
using Volo.Abp.ObjectExtending.Modularity;

namespace Volo.Abp.ObjectExtending
{
    public class ModuleExtensionConfiguration : Modularity.ModuleExtensionConfiguration
    {
        public ModuleExtensionConfiguration ConfigureUser(Action<EntityExtensionConfiguration> configureAction)
        {
            return this.ConfigureEntity(ModuleExtensionConsts.EntityNames.User, configureAction);
        }

        public ModuleExtensionConfiguration ConfigureRole(Action<EntityExtensionConfiguration> configureAction)
        {
            return this.ConfigureEntity(ModuleExtensionConsts.EntityNames.Role, configureAction);
        }

        public ModuleExtensionConfiguration ConfigureClaimType(Action<EntityExtensionConfiguration> configureAction)
        {
            return this.ConfigureEntity(ModuleExtensionConsts.EntityNames.ClaimType, configureAction);
        }

        public ModuleExtensionConfiguration ConfigureOrganizationUnit(Action<EntityExtensionConfiguration> configureAction)
        {
            return this.ConfigureEntity(ModuleExtensionConsts.EntityNames.OrganizationUnit, configureAction );
        }
    }
}

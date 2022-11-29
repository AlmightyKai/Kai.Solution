using System;
using Volo.Abp.ObjectExtending.Modularity;

namespace Volo.Abp.ObjectExtending
{
    public static class ModuleExtensionConfigurationDictionaryExtensions
    {
        public static ModuleExtensionConfigurationDictionary ConfigureIdentity(
            this ModuleExtensionConfigurationDictionary modules,
            Action<ModuleExtensionConfiguration> configureAction)
        {
            return modules.ConfigureModule(ModuleExtensionConsts.ModuleName, configureAction);
        }
    }
}

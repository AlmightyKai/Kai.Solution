using Volo.Abp.Reflection;

namespace Kai.Solution.OpenIddict.Permissions
{
    public class Permissions
    {
        public const string GroupName = "OpenIddict";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(Permissions));
        }
    }
}

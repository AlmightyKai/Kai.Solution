using Volo.Abp.Reflection;

namespace Kai.Solution.Account.Permissions
{
    public class Permissions
    {
        public const string GroupName = "Account";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(Permissions));
        }
    }
}

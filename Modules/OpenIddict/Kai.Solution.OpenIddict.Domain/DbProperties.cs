namespace Kai.Solution.OpenIddict
{
    public static class DbProperties
    {
        public static string DbTablePrefix { get; set; } = "OpenIddict";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "OpenIddict";
    }
}

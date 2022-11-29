namespace Kai.Solution.Identity
{
    public static class DbProperties
    {
        public static string DbTablePrefix { get; set; } = "Identity";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Identity";
    }
}

namespace Kai.Solution.Account
{
    public static class DbProperties
    {
        public static string DbTablePrefix { get; set; } = "Account";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Account";
    }
}

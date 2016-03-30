namespace ForumSystem.Web.MVC
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ForumSystemDbContext, Configuration>());
            ForumSystemDbContext.Create().Database.Initialize(true);
        }
    }
}
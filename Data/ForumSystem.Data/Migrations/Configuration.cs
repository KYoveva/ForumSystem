namespace ForumSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Seed;

    public sealed class Configuration : DbMigrationsConfiguration<ForumSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ForumSystemDbContext context)
        {
            new AdminSeeder().Seed(context);
            new ForumPostsSeeder().Seed(context);
        }
    }
}

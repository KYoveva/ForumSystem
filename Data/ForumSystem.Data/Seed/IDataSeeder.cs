namespace ForumSystem.Data.Seed
{
        public interface IDataSeeder
        {
            void Seed(ForumSystemDbContext context);
        }
}

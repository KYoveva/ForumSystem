namespace ForumSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface IForumSystemDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<ForumPost> ForumPosts { get; set; }

        IDbSet<ForumPostCategory> ForumPostCategories { get; set; }

        IDbSet<Answer> Answers { get; set; }

        IDbSet<AnswerLike> AnswerLikes { get; set; }

        IDbSet<AnswerDislike> AnswerDislikes { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}

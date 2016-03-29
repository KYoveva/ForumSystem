namespace ForumSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Constants.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class ForumSystemDbContext : IdentityDbContext<User>, IForumSystemDbContext
    {
        public ForumSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ForumSystemDbContext, Configuration>());
        }

        public virtual IDbSet<AnswerDislike> AnswerDislikes { get; set; }

        public virtual IDbSet<AnswerLike> AnswerLikes { get; set; }

        public virtual IDbSet<Answer> Answers { get; set; }

        public virtual IDbSet<ForumPostCategory> ForumPostCategories { get; set; }

        public virtual IDbSet<ForumPost> ForumPosts { get; set; }

        public static ForumSystemDbContext Create()
        {
            return new ForumSystemDbContext();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<ForumPost>()
        //        .HasMany(x => x.Answers)
        //        .WithRequired(x => x.ForumPost)
        //        .WillCascadeOnDelete(true);

        //    modelBuilder
        //        .Entity<Answer>()
        //        .HasMany(x => x.Likes)
        //        .WithRequired(x => x.Answer)
        //        .WillCascadeOnDelete(true);

        //    modelBuilder
        //        .Entity<Answer>()
        //        .HasMany(x => x.Likes)
        //        .WithRequired(x => x.Answer)
        //        .WillCascadeOnDelete(true);

        //    base.OnModelCreating(modelBuilder);
        //}

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}

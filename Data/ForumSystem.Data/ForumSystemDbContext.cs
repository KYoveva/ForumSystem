namespace ForumSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class ForumSystemDbContext : IdentityDbContext<User>
    {
        public ForumSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<AnswerDislike> AnswerDislikes { get; set; }

        public IDbSet<AnswerLike> AnswerLikes { get; set; }

        public IDbSet<Answer> Answers { get; set; }

        public IDbSet<ForumPostCategory> ForumPostCategories { get; set; }

        public IDbSet<ForumPost> ForumPosts { get; set; }

        public static ForumSystemDbContext Create()
        {
            return new ForumSystemDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ForumPost>()
                .HasMany(x => x.Answers)
                .WithRequired(x => x.ForumPost)
                .WillCascadeOnDelete(true);

            modelBuilder
                .Entity<Answer>()
                .HasMany(x => x.Likes)
                .WithRequired(x => x.Answer)
                .WillCascadeOnDelete(true);

            modelBuilder
                .Entity<Answer>()
                .HasMany(x => x.Likes)
                .WithRequired(x => x.Answer)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
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
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}

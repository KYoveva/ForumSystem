namespace ForumSystem.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using ForumSystem.Data.Repositories;
    using Models;

    public class ForumPostsService : IForumPostsService
    {
        private readonly IRepository<ForumPost> forumPosts;

        public ForumPostsService(IRepository<ForumPost> forumPosts)
        {
            this.forumPosts = forumPosts;
        }

        public IQueryable<ForumPost> ForumPostById(int id)
        {
            return this.forumPosts.All().Where(x => x.Id == id);
        }

        public IQueryable<ForumPost> ForumPostsByCategory(int id)
        {
            return this.forumPosts.All().Where(x=>x.Category.Id==id);
        }
    }
}
